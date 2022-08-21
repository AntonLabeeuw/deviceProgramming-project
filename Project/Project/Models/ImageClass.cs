using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class ImageClass
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "url")]
        public string Url { get; set; }

        [JsonProperty(propertyName: "width")]
        public string Width { get; set; }

        [JsonProperty(propertyName: "height")]
        public string Height { get; set; }
    }
}
