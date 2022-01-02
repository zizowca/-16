using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Задание_16._2
{
    class Product
    {
        double price;
        [JsonPropertyName("Код товара")]
        public int Code { get; set; }
        [JsonPropertyName("Наименование товара")]
        public string Name { get; set; }
        [JsonPropertyName("Стоимость товара")]
        public double Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;

                }
                else
                {
                    Console.WriteLine("Стоимость не может быть отрицательной");
                }
            }
            get
            {
                return price;
            }
        }
    }
}
