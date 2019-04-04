using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using StarWarsAPIClient.Client;
using StarWarsAPIClient.DataBase;
using StarWarsAPIClient.DataBase.People;
using StarWarsAPIClient.DataBase.Planet;

namespace StarWarsAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var planetas = PlanetRepository.GetAll();
            foreach(var planeta in planetas){
                System.Console.WriteLine(planeta.Name);
            }
            //JsonConvert.DeserializeAnonymousType(response.Content, (new {count = 0, next = "", results = new List<PlanetModel>()}));

            System.Console.WriteLine("\n Pessoas");
            var pessoas = PeopleRepository.GetAll();
            foreach(var pessoa in pessoas){
                System.Console.WriteLine(pessoa.Name);
            }
        }
    }
}
