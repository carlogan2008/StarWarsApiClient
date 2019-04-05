using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWarsAPIClient.DataBase
{
    public class PeopleModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]        
        public string SkinColor { get; set; }
        
        [JsonProperty("eye_color")]        
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]        
        public string BirthYear { get; set; }
        
        [JsonProperty("gender")]        
        public string Gender { get; set; }

        [JsonProperty("homeworld")]        
        public string Homeworld{ get; set; }

        [JsonProperty("films")]        
        public string[] Films { get; set; }

        [JsonProperty("species")]        
        public string[] Species { get; set; }

        [JsonProperty("vehicles")]        
        public string[] Vehicles { get; set; }

        [JsonProperty("starships")]        
        public string[] Starships { get; set; }

        [JsonProperty("created")]        
        public DateTime Created { get; set; }

        public DateTime Downloaded { get; set; }
    }
}
