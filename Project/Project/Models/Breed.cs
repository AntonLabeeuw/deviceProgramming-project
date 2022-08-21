using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Project.Models
{
    public class Breed
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "temperament")]
        public string Temperament { get; set; }

        [JsonProperty(propertyName: "origin")]
        public string Origin { get; set; }

        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }

        [JsonProperty(propertyName: "life_span")]
        public string LifeSpan { get; set; }

        [JsonProperty(propertyName: "affection_level")]
        public int AffectionLevel { get; set; }

        [JsonProperty(propertyName: "child_friendly")]
        public int ChildFriendly { get; set; }

        [JsonProperty(propertyName: "dog_friendly")]
        public int DogFriendly { get; set; }

        [JsonProperty(propertyName: "energy_level")]
        public int EnergyLevel { get; set; }

        [JsonProperty(propertyName: "intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty(propertyName: "stranger_friendly")]
        public int StrangerFriendly { get; set; }

        [JsonProperty(propertyName: "wikipedia_url")]
        public string WikipediaUrl { get; set; }

        [JsonProperty(propertyName: "reference_image_id")]
        public string Image { get; set; }
    }
}
