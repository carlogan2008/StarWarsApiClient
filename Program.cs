using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using StarWarsApiClient.DataBase.especies;
using StarWarsAPIClient.Client;
using StarWarsAPIClient.DataBase;
using StarWarsAPIClient.DataBase.Planet;


namespace StarWarsAPIClient
{
    class Program
    {

       
        static void Main(string[] args)
        {
       
       
            var planetas = PlanetRepository.GetAll();
            foreach(var planeta in planetas)
                {
                System.Console.WriteLine(planeta.Name);
                }

            var Especies = EspeciesRepository.GetAll();
            foreach(var spc in Especies)
                {
                 System.Console.WriteLine(spc.Name + " - " + spc.Planetanatal);
                }
            
        }
    }
}
