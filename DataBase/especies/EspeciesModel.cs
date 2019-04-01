using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWarsApiClient.DataBase.especies
{
    public class EspeciesModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
          
        [JsonProperty("classification")]
        public string Classificacao { get; set; }

        [JsonProperty("designation")]
        public string Designacao { get; set; }

        [JsonProperty("average_height")]
        public string AlturaMedia { get; set; }
     
        [JsonProperty("skin_colors")]
        public string CorPele { get; set; }    

        [JsonProperty("hair_colors")]
        public string CorCabelo { get; set; } 

        [JsonProperty("eye_colors")]
        public string CorOlhos { get; set; } 

        [JsonProperty("average_lifespan")]
        public string TempoDeVida { get; set; } 

        [JsonProperty("homeworld")]
        public string Planetanatal { get; set; } 

        [JsonProperty("language")]
        public string Lingua { get; set; }        
    
        [JsonProperty("people")]        
        public string[] Pessoa { get; set; }
        
        [JsonProperty("films")]        
        public string[] filmes { get; set; }

       /*  [JsonProperty("created")]        
        public String[] Created { get; set; }*/
    }

    
}