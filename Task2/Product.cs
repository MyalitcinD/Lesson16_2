using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task2
{
    class Product
    {
        [JsonPropertyName("productKey")]
        public int ProdCode { get; set; }
        [JsonPropertyName("productName")]
        public string ProdName { get; set; }
        [JsonPropertyName("productPrice")]
        public double ProdPrice { get; set; }


    }
}
