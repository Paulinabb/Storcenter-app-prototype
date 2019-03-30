using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AalborgStoreCenter.Models
{
    public class SelectedProduct
    {
        [Key]
        public int SelectedProductID { get; set; }

        public int ListID { get; set; }
        public virtual List List { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}