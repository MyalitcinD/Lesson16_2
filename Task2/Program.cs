using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            string jsonstr = String.Empty;
            double maxPrice;

            Product[] products = new Product[num];
            using(StreamReader sr = new StreamReader("../../../Products.json")) {
                jsonstr = sr.ReadToEnd();
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            products = JsonSerializer.Deserialize<Product[]>(jsonstr, options);
            maxPrice = products[0].ProdPrice;
            Product ExpensiveProd = products[0];
            foreach(Product p in products) {
                //Console.WriteLine($"{p.ProdCode} {p.ProdName} {p.ProdPrice}");
                if(maxPrice < p.ProdPrice) {
                    maxPrice = p.ProdPrice;
                    ExpensiveProd = p;
                }
            }
            Console.WriteLine($"Самый дорогой товар: {ExpensiveProd.ProdCode} {ExpensiveProd.ProdName} {ExpensiveProd.ProdPrice}");
            Console.ReadKey();
        }



    }
}
