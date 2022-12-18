using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Cart
    {

        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int cart_code { get; set; }

        public int product_id { get; set; }

        public string img { get; set; }


        public string name { get; set; }


        public string description { get; set; }

        public int amount { get; set; }

        public int price { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }

        public Cart() { }

        public Cart(int cart_code, int product_id, string img, string name, string description, int amount, int price)
        {
            this.cart_code = cart_code;
            this.product_id = product_id;
            this.img = img;
            this.name = name;
            this.description = description;
            this.amount = amount;
            this.price = price;
        }
    }
}