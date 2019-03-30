using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AalborgStoreCenter.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string StoreLogo { get; set; }

        [Required]
        public string LocationImage { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}