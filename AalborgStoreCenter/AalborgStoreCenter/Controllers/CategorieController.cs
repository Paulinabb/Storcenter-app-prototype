using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AalborgStoreCenter.Models;
using System.Data.SqlClient;

namespace AalborgStoreCenter.Controllers
{
    public class CategorieController : ApiController
    {
        private Context db = new Context();

        // GET: api/Categorie/GetCategories
        // gets all the categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }


        ////GET: api/Categorie/GetCategorie
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult GetCategorie(int id)
        //{
        //    var productofcategory = db.Categories
        //               .Where(b => b.CategoryID == id)
        //               .Include(b => b.Product)
        //               .ToList();

        //    return Json(productofcategory);
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}