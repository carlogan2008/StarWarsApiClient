using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StarWarsApiClient.DataBase;
using StarWarsAPIClient.Client;

namespace StarWarsApiClient.Client.Species
{
    public class SpeciesClient
    {
        public static SpeciesModel GetById(int specieId){
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint($"species/{specieId}");
            var especie = JsonConvert.DeserializeObject<SpeciesModel>(result);
            return especie;
        }

        public static List<SpeciesModel> GetAll(){
            var species = new List<SpeciesModel>();
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint("species/");
            var nextPageUrl = GetPaginationUrl(result);
            species.AddRange(GetSpeciePage(result));
            do
            {
                result = StarWarsClient.GetByUrl(nextPageUrl);
                species.AddRange(GetSpeciePage(result));
                nextPageUrl = GetPaginationUrl(result);
            } while (!String.IsNullOrEmpty(nextPageUrl));

            return species;
        }

        public static List<SpeciesModel> GetSpeciePage(string content){
            var speciesResult = new {
                results = new List<SpeciesModel>()
            };
            var species = JsonConvert.DeserializeAnonymousType(content, speciesResult);
            return species.results;
        }

        public static string GetPaginationUrl(string content){
            var speciesResult = new {
                next = ""
            };
            var species = JsonConvert.DeserializeAnonymousType(content, speciesResult);
            return species.next;
        }



    }
}