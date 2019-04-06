using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWarsAPIClient.DataBase
{
    public class PlanetModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        [JsonProperty("climate")]        
        public string Climate { get; set; }
        
        [JsonProperty("gravity")]        
        public string Gravity { get; set; }

        [JsonProperty("terrain")]        
        public string Terrain { get; set; }
        
        [JsonProperty("surface_water")]        
        public string SurfaceWater { get; set; }

        [JsonProperty("population")]        
        public string population{ get; set; }

        [JsonProperty("residents")]        
        public string[] Residents { get; set; }

        [JsonProperty("films")]        
        public string[] Films { get; set; }

        [JsonProperty("created")]        
        public DateTime Created { get; set; }
        public DateTime Downloaded { get; set; }
    }
}


/*"name": "Yavin IV",
	"rotation_period": "24",
	"orbital_period": "4818",
	"diameter": "10200",
	"climate": "temperate, tropical",
	"gravity": "1 standard",
	"terrain": "jungle, rainforests",
	"surface_water": "8",
	"population": "1000",
	"residents": [],
	"films": [
		"https://swapi.co/api/films/1/"
	],
	"created": "2014-12-10T11:37:19.144000Z",
	"edited": "2014-12-20T20:58:18.421000Z", */