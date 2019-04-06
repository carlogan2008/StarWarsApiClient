using System.IO;
using StarWarsAPIClient.Client;
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
            var images = GIClient.Search("Darth Vader");
            var client = new WebClient();
            foreach (var image in images)
            {
                System.Console.WriteLine("\tEscrevendo imagem...");
                System.Console.WriteLine($"\t{image.Title}.{image.Link.Split(".").Last()}");
                try
                {
                    var bytes = client.DownloadData(image.Link);
                    File.WriteAllBytes($"images/{image.Title}.{image.Link.Split(".").Last().Split('/')[0]}", bytes);
                }
                catch (WebException) { }
            }
        }
    }
}