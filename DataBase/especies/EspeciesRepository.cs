using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StarWarsAPIClient.Client;

namespace StarWarsApiClient.DataBase.especies
{
    public class EspeciesRepository
    {
        public static EspeciesModel GetById(int speciesId){
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint($"species/{speciesId}");
            var planeta = JsonConvert.DeserializeObject<EspeciesModel>(result);
            return planeta;
        }

        public static List<EspeciesModel> GetAll(){
            var species = new List<EspeciesModel>();
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint("species/");
            var nextPageUrl = GetPaginationUrl(result);
            species.AddRange(GetPlanetsPage(result));
            do
            {
                result = StarWarsClient.GetByUrl(nextPageUrl);
                species.AddRange(GetPlanetsPage(result));
                nextPageUrl = GetPaginationUrl(result);
            } while (!String.IsNullOrEmpty(nextPageUrl));

            return species;
        }

        public static List<EspeciesModel> GetPlanetsPage(string content){
            var speciesResult = new {
                results = new List<EspeciesModel>()
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