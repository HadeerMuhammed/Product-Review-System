using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Product_Review_System.Models
{
    public class Product
    {
        [DisplayName("Product id")]
        public int id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Price")]
        public int price { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [DisplayName("Category id")]
        public int category_id { get; set; }

        [DisplayName("Image")]
        public String image { get; set; }

        public Category Category { get; set; }

    }
}