using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StarWarsAPIClient.Client;
using StarWarsAPIClient.DataBase;

namespace StarWarsAPIClient.Client.Planet
{
    public class PlanetClient
    {
        public static PlanetModel GetById(int planetId){
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint($"planets/{planetId}");
            var planeta = JsonConvert.DeserializeObject<PlanetModel>(result);
            return planeta;
        }

        public static List<PlanetModel> GetAll(){
            var planetas = new List<PlanetModel>();
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint("planets/");
            var nextPageUrl = GetPaginationUrl(result);
            planetas.AddRange(GetPlanetsPage(result));
            do
            {
                result = StarWarsClient.GetByUrl(nextPageUrl);
                planetas.AddRange(GetPlanetsPage(result));
                nextPageUrl = GetPaginationUrl(result);
            } while (!String.IsNullOrEmpty(nextPageUrl));
            return planetas;
        }

        public static List<PlanetModel> GetPlanetsPage(string content){
            var planetsResult = new {
                results = new List<PlanetModel>()
            };
            var planets = JsonConvert.DeserializeAnonymousType(content, planetsResult);
            return planets.results;
        }

        public static string GetPaginationUrl(string content){
            var planetsResult = new {
                next = ""
            };
            var planets = JsonConvert.DeserializeAnonymousType(content, planetsResult);
            return planets.next;
        }
    }
}