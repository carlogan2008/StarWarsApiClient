using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using StarWarsAPIClient.DataBase;
using StarWarsAPIClient.Helper;

namespace StarWarsAPIClient.Client
{
    public class GoogleImagesClient
    {
        public List<GoogleImageResult> Search(string searchTerm)
        {
            const int maxImages = 3;
            var images = new List<GoogleImageResult>();
            var config = ConfigReader.GetConfigurations();
            CustomsearchService svc = new CustomsearchService();
            var listRequest = svc.Cse.List(searchTerm);
            listRequest.Key = config.GoogleAPICredentials.key;
            listRequest.Cx = config.GoogleAPICredentials.cx;
            listRequest.SearchType = Google.Apis.Customsearch.v1.CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Num = 5;
            var search = listRequest.Execute();
            foreach (var item in search.Items)
            {
                if (images.Find(img => img.Title.Equals(item.Title)) == null)
                {
                    images.Add(new GoogleImageResult { Title = item.Title, Link = item.Link });
                }
                if (images.Count >= maxImages)
                {
                    break;
                }
            }
            return images;
        }
    }
}