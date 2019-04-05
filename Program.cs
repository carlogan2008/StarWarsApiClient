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

namespace StarWarsAPIClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            string apiKey = "";
            string cx = "";
            string query = "star wars";

            CustomsearchService svc = new CustomsearchService();
            
            ListRequest listRequest = svc.Cse.List(query);
            listRequest.Key = apiKey;
            listRequest.Cx = cx;
            listRequest.SearchType = Google.Apis.Customsearch.v1.CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Num = 3;
            Search search = listRequest.Execute();

            foreach (Result result in search.Items)
            {
                Console.WriteLine("Titulo: \n\t{0}", result.Title);
                Console.WriteLine("Link da Imagem: \n\t{0}", result.Link);
            }

        }
    }
}