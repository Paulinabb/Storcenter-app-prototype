using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AalborgStoreCenter.Models;
using System.Collections;

namespace AalborgStoreCenter.Controllers
{
    public class ProductController : ApiController
    {
        private Context db = new Context();

        // GET: api/Product/GetProducts
        //gets all the products 
        [HttpGet]
        public IQueryable<Product> GetProducts()
        {
            return db.Products; 
            
        }

        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            /* var productofcategory = db.Products
                        .Where(b => b.ProductID == id).ToList();
                        */
            Product product = await db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        //GET: api/Product/GetProduct/1
        //gets product that belong to certain category (looks for CategoryId)
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var productofcategory = db.Products
                       .Where(b => b.CategoryID == id)
                       .ToList();

            if (productofcategory != null)
            {
                return Ok(productofcategory);

            }
            return NotFound();
        
        }


        //GET: api/Product/GetStoreOfProduct/1
        //gets store of a certain product
        //this method required to be set as IEnumerable because it was returning error
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IEnumerable GetStoreOfProduct(int id)
        {
            var store = db.Products
                       .Where(b => b.ProductID == id)
                       .Include(b => b.Store)
                       .AsEnumerable();

            return store;

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}