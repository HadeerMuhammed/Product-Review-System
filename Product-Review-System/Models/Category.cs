using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Product_Review_System.Models
{
    public class Category
    { 
        [DisplayName("Category id")]
        [Key]
        public int category_id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Products quantity")]
        public int no_of_products { get; set; }

        public ICollection<addProduct> Add { get; set; }
    }
}