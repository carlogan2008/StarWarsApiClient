using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StarWarsAPIClient.Client;

namespace StarWarsAPIClient.DataBase.People
{
    public class PeopleRepository
    {
        
        public static PeopleModel GetById(int peopleId){
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint($"people/{peopleId}");
            var pessoa = JsonConvert.DeserializeObject<PeopleModel>(result);
            return pessoa;
        }

        public static List<PeopleModel> GetAll(){
            var pessoas = new List<PeopleModel>();
            var client = new StarWarsClient();
            var result = StarWarsClient.GetByEndPoint("people/");
            var nextPageUrl = GetPaginationUrl(result);
            pessoas.AddRange(GetPeoplesPage(result));
            do
            {
                result = StarWarsClient.GetByUrl(nextPageUrl);
                pessoas.AddRange(GetPeoplesPage(result));
                nextPageUrl = GetPaginationUrl(result);
            } while (!String.IsNullOrEmpty(nextPageUrl));

            return pessoas;
        }

        public static List<PeopleModel> GetPeoplesPage(string content){
            var peoplesResult = new {
                results = new List<PeopleModel>()
            };
            var peoples = JsonConvert.DeserializeAnonymousType(content, peoplesResult);
            return peoples.results;
        }

        public static string GetPaginationUrl(string content){
            var peoplesResult = new {
                next = ""
            };
            var peoples = JsonConvert.DeserializeAnonymousType(content, peoplesResult);
            return peoples.next;
        }
    }
}