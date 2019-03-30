using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AalborgStoreCenter.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [MaxLength(100)]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public string ProductImage { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
    }
}