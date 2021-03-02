using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ChanEngine.Entities.Models
{
    public class Orders
    {
        [JsonPropertyName("Content")]
        public List<Content> Content { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("Lines")]
        public List<Line> Orders { get; set; }
    }

    public class Line
    {
        //[JsonPropertyName("gtin")]
        public string Gtin { get; set; }

        //[JsonPropertyName("description")]
        public string Description { get; set; }
        //[JsonPropertyName("merchantProductNo")]
        public string MerchantProductNo { get; set; }

        //[JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
