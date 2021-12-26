using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Задание_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "D:/Азиза/Автоматизация BIM проектирования/Задание 16/Задание 16/bin/Debug/Task 16.1/Task 16.1.json";
            Console.WriteLine(File.Exists(path1) ? "File exists." : "File does not exist.");
            string jsonString = File.ReadAllText(path1);
            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.Cyrillic, UnicodeRanges.BasicLatin),
            //    WriteIndented = true
            //};
            Product[] prod = JsonSerializer.Deserialize<Product[]>(jsonString);
            //Console.WriteLine(jsonString);
            //Console.WriteLine(prod);
            Console.ReadKey();
        }
    }
    class Product
    {
        double productPrice;
        [JsonPropertyName("Код товара")]
        public int ProductCode { get; set; }
        [JsonPropertyName("Наименование товара")]
        public string ProductName { get; set; }
        [JsonPropertyName("Стоимость товара")]
        public double ProductPrice
        {
            set
            {
                if (value > 0)
                {
                    productPrice = value;

                }
                else
                {
                    Console.WriteLine("Стоимость не может быть отрицательной");
                }
            }
            get
            {
                return productPrice;
            }
        }
    }
}
