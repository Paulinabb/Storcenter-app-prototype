namespace AalborgStoreCenter.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AalborgStoreCenter.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AalborgStoreCenter.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var users = new List<User>
            {
                new User{UserID=1, UserName="TestUser", Address="Street 1", Password="test", Birthdate=DateTime.Parse("Dec 03, 2003 00:00:00 PM") },
                new User{UserID=2, UserName="TestUserTwo", Address="Street 2", Password="123", Birthdate=DateTime.Parse("Dec 01, 2003 00:00:00 PM") },
                new User{UserID=3, UserName="TestUserThree", Address="Street 3", Password="1234", Birthdate=DateTime.Parse("Dec 02, 2004 00:00:00 PM") }

            };

            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            //list


            var categories = new List<Category>
            {
                new Category{CategoryID=1, CategoryName="Cosmetics" },
                new Category{CategoryID=2, CategoryName="Technology" },
                new Category{CategoryID=3, CategoryName="Clothes" }
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();

            // categories


            var stores = new List<Store>
            {
                new Store{StoreID=1, StoreName="H&M", StoreLogo = "hmLogo.jpg", LocationImage = "hm.jpg", },
                new Store{StoreID=2, StoreName="Matas", StoreLogo = "matasLogo.jpg", LocationImage = "matas.jpg", },
                new Store{StoreID=3, StoreName="Inter Sport", StoreLogo = "isLogo.jpg", LocationImage = "is.jpg", }
            };

            stores.ForEach(s => context.Stores.AddOrUpdate(s));
            context.SaveChanges();


            var lists = new List<List>
            {
                new List{ListID=1, UserID=1,},
                new List{ListID=2, UserID=2,},
                new List{ListID=3, UserID=3,}
            };
            lists.ForEach(s => context.Lists.AddOrUpdate(s));
            context.SaveChanges();

            //lists


            var products = new List<Product>
            {
                new Product { ProductID=1, ProductDescription="Super product, buy it", ProductTitle="Body Lotion", ProductImage = "BodyLotion.jpg", ProductPrice = 24, StoreID =2, CategoryID=1, },
                new Product { ProductID=2, ProductDescription="Very good lotion", ProductTitle="Body Lotion 2", ProductImage = "BodyLotion2.jpg", ProductPrice = 23, StoreID =2, CategoryID=1, },
                new Product { ProductID=3, ProductDescription="Wireless mouse", ProductTitle="Mouse", ProductImage = "Mouse.jpg", StoreID =3, ProductPrice = 523, CategoryID=2, },
                new Product { ProductID=4, ProductDescription="blue Jeans", ProductTitle="Jeans", ProductImage = "Jeans.jpg", StoreID =1, ProductPrice = 223, CategoryID=3, },
                new Product { ProductID=5, ProductDescription="Very good lotion", ProductTitle="Body Lotion 3", ProductImage = "BodyLotion3.jpg", ProductPrice = 123, StoreID =2, CategoryID=1, }
            };

            products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();

            //SelectedProduct


            var selected = new List<SelectedProduct>
            {
                new SelectedProduct { SelectedProductID=1, ListID=1, ProductID=1, },
                new SelectedProduct { SelectedProductID=2, ListID=1, ProductID=2, }

            };

            selected.ForEach(s => context.SelectedProducts.AddOrUpdate(s));
            context.SaveChanges();

            //SelectedProduct




        }
    }
}


