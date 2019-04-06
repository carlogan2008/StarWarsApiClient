using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using StarWarsAPIClient.DataBase;
using StarWarsAPIClient.Helper;

namespace StarWarsAPIClient.Client
{
    public class GoogleImagesClient
    {
        public List<GoogleImageModel> Search(string searchTerm)
        {
            var images = new List<GoogleImageModel>();
            var config = ConfigReader.GetConfigurations();
            CustomsearchService svc = new CustomsearchService();
            var request = svc.Cse.List(searchTerm);
            request.Key = config.GoogleAPICredentials.key;
            request.Cx = config.GoogleAPICredentials.cx;
            request.SearchType = Google.Apis.Customsearch.v1.CseResource.ListRequest.SearchTypeEnum.Image;
            request.Num = 5;
            var search = request.Execute();
            foreach (var item in search.Items)
            {
                if (images.Find(img => img.Title.Equals(item.Title)) == null)
                {
                    images.Add(new GoogleImageModel { Title = item.Title, Link = item.Link });
                }
            }
            return images;
        }
    }
}