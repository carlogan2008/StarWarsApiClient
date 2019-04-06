using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using StarWarsApiClient.DataBase.especies;
using StarWarsAPIClient.Client;
using StarWarsAPIClient.DataBase;
using StarWarsAPIClient.DataBase.People;
using StarWarsAPIClient.DataBase.Planet;
using Google.Apis.Services;
using Google.Apis.Customsearch.v1;
using System.Text;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis;
using Google.Apis.Json;
using static Google.Apis.Customsearch.v1.CseResource;
using static Google.Apis.Customsearch.v1.CseResource.SiterestrictResource.ListRequest;
using static Google.Apis.Customsearch.v1.CseResource.ListRequest;
using StarWarsAPIClient.Helper;
using System.Net;
using System.Linq;

namespace StarWarsAPIClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("iniciando");
            var GIClient = new GoogleImagesClient();
            System.Console.WriteLine("Baixando imagens");
            var images = GIClient.Search("Star Wars");
            var client = new WebClient();
            foreach(var image in images){
                System.Console.WriteLine("\tEscrevendo imagem...");
                System.Console.WriteLine($"\t{image.Title}.{image.Link.Split(".").Last()}");
                var bytes = client.DownloadData(image.Link);
                File.WriteAllBytes($"images/{image.Title}.{image.Link.Split(".").Last()}", bytes);
            }
        }
    }
}