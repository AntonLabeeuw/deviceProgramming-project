using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Favourite
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "image_id")]
        public string ImageId { get; set; }

        [JsonProperty(propertyName: "sub_id")]
        public string SubId { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(propertyName: "image")]
        public ImageClass Image { get; set; }
    }
}
