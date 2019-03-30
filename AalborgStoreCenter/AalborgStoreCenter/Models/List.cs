using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AalborgStoreCenter.Models
{
    public class List
    {
        [Key]
        public int ListID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}