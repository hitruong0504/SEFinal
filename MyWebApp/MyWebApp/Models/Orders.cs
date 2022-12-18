using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Orders
    {
        [Key, Column(Order = 1)]
        [Required]
        public int Account_id { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        public int cart_code { get; set; }

        [ForeignKey("Account_id")]
        public Account Account { get; set; }

        [ForeignKey("cart_code")]
        public Cart Cart { get; set; }

        public Orders() { }

        public Orders(int account_id, int cart_code)
        {
            Account_id = account_id;
            this.cart_code = cart_code;
        }
    }
}