using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Vote
    {
        [JsonProperty(propertyName: "image_id")]
        public string ImageId { get; set; }

        [JsonProperty(propertyName: "sub_id")]
        public string SubId { get; set; }

        [JsonProperty(propertyName: "value")]
        public string Value { get; set; }
    }
}
