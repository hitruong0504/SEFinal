using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Payment
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string account_Name { get; set; }

        [Required]
        public int card_Number { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string cvv { get; set; }

        [Required]
        public int total { get; set; }

        [ForeignKey("card_Number")]
        public Cart Cart { get; set; }

        public Payment() { }

        public Payment(int id, string account_Name, int card_Number, string cvv, int total)
        {
            this.id = id;
            this.account_Name = account_Name;
            this.card_Number = card_Number;
            this.cvv = cvv;
            this.total = total;
        }
    }
}