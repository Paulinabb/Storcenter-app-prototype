using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AalborgStoreCenter.Models
{
    public class Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Context() : base("name=Context")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.SelectedProduct> SelectedProducts { get; set; }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.List> Lists { get; set; }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<AalborgStoreCenter.Models.Category> Categories { get; set; }
    }
}
