namespace StarWarsAPIClient.DataBase
{
    public class GoogleAPICredentials{
        public string key { get; set; }
        public string cx { get; set; }
    }
    public class ConfigurationModel
    {
        public GoogleAPICredentials GoogleAPICredentials { get; set; }
    }
}