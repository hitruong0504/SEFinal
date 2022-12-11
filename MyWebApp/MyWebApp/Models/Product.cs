using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Describe { get; set; }
        public string Img { get; set; }
        public int Amount { get; set; }

        public Product(int id, string name, int price, string description, string img, int amount)
        {
            Id = id;
            Name = name;
            Price = price;
            Describe = description;
            Img = img;
            Amount = amount;
        }

        public Product()
        {

        }
    }
}