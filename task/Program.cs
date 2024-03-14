using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            Product[] products = new Product[num];
            for(int i = 0; i < num; i++) {
                products[i] = new Product();
                Console.Write("Введите код товара {0}: ", i);
                int a = Convert.ToInt32(Console.ReadLine());
                products[i].ProdCode = a;
                Console.Write("Введите имя товара {0}: ", i);
                string str = Console.ReadLine(); ;
                products[i].ProdName = str;
                Console.Write("Введите цену товара {0}: ", i);
                double b = Convert.ToDouble(Console.ReadLine());
                products[i].ProdPrice = b;
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonstring = JsonSerializer.Serialize(products, options);

            using(StreamWriter sw = new StreamWriter("../../../Products.json")) {
                sw.WriteLine(jsonstring);
            }


        }
    }
}
