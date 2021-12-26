using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.IO;

namespace Задание_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //товар 1
            Product product1 = new Product()
            {
                ProductCode = 1,
                ProductName = "Ручка",
                ProductPrice = 10.5,
            };
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string JsonStringProduct1 = JsonSerializer.Serialize(product1, options);
            //Console.WriteLine(JsonStringProduct1);
            //товар 2
            Product product2 = new Product()
            {
                ProductCode = 2,
                ProductName = "Карандаш",
                ProductPrice = 8.5,
            };
            string JsonStringProduct2 = JsonSerializer.Serialize(product2, options);
            //Console.WriteLine(JsonStringProduct2);
            //товар 3
            Product product3 = new Product()
            {
                ProductCode = 3,
                ProductName = "Тетрадь",
                ProductPrice = 20.0,
            };
            string JsonStringProduct3 = JsonSerializer.Serialize(product3, options);
            //Console.WriteLine(JsonStringProduct3);
            string[] products = new string[] { JsonStringProduct1, JsonStringProduct2, JsonStringProduct3 };
            //Записываю в файл
            string path = "Task 16.1";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string path1 = "Task 16.1/Task 16.1.json";
            if (!File.Exists(path1))
            {
                File.Create(path1).Close();
            }
            File.WriteAllLines(path1, products);
            //Console.ReadKey();

            Console.WriteLine(File.Exists(path1) ? "File exists." : "File does not exist.");
            try
            {
                Product product = JsonSerializer.Deserialize<Product>(path1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
