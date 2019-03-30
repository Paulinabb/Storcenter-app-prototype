using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AalborgStoreCenter.Models;
using System;
using System.Net.Http;

namespace AalborgStoreCenter.Controllers
{
    public class SelectedProductController : ApiController
    {
        private Context db = new Context();

        // GET: api/SelectedProduct
        public IQueryable<SelectedProduct> GetSelectedProducts()
        {
            return db.SelectedProducts;
        }

        // GET: api/SelectedProduct/GetSelectedProduct/5
        //returns all the products on the certain shopping list
        [ResponseType(typeof(SelectedProduct))]
        public IHttpActionResult GetSelectedProduct(int id)
        {

            var selected = db.SelectedProducts
                       .Where(b => b.ListID == id)
                       .Include(b => b.Product)
                       .ToList();

            if (selected != null)
            {
                return Ok(selected);

            }
            return NotFound();
        }

        // POST: api/SelectedProduct/PostSelectedProduct
        [HttpPost]
        [ResponseType(typeof(SelectedProduct))]
        public async Task<IHttpActionResult> PostSelectedProduct(int id)
        {
            var userId = 1;

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var countForDuplicate = db.SelectedProducts.Count(p => p.ProductID == id);

            if (countForDuplicate == 0)
            {
                var userListId = db.Lists.Where(p => p.UserID == userId).FirstOrDefault().ListID;
                var selectedProduct = new SelectedProduct() { ListID = userListId, ProductID = id };

                // Check if the object is not null
                if (selectedProduct != null)
                {
                    // Adds the product to database
                    db.SelectedProducts.Add(selectedProduct);

                    // Saves the changes in the database
                    await db.SaveChangesAsync();
                }

                return Ok(selectedProduct);
            }

            return Ok();

            //return CreatedAtRoute("postProduct", new { id = selectedProduct.SelectedProductID }, selectedProduct);
        }

        // DELETE: api/SelectedProduct/DeletedSelectedProduct/5
        [ResponseType(typeof(SelectedProduct))]
        public async Task<IHttpActionResult> DeleteSelectedProduct(int id)
        {
            SelectedProduct selectedProduct = await db.SelectedProducts.FindAsync(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            db.SelectedProducts.Remove(selectedProduct);
            await db.SaveChangesAsync();

            return Ok(selectedProduct);
        }

        // DELETE: api/SelectedProduct/DeleteSelectedProductByProdId
        [HttpDelete]
        [ResponseType(typeof(SelectedProduct))]
        public async Task<IHttpActionResult> DeleteSelectedProductByProdId(int id)
        {
            var userId = 1;

            var listId = db.Lists.FirstOrDefault(p => p.UserID == userId).ListID;

            var selectedProdId = db.SelectedProducts.Where(p => p.ProductID == id && p.ListID == listId).FirstOrDefault().SelectedProductID;

            if (selectedProdId != 0)
            {
                var selectedProduct = await db.SelectedProducts.FindAsync(selectedProdId);
                if (selectedProduct == null)
                {
                    return NotFound();
                }

                db.SelectedProducts.Remove(selectedProduct);
                await db.SaveChangesAsync();

                return Ok(selectedProduct);
            }

            return Ok();
        }
        [HttpDelete]
        [ResponseType(typeof(SelectedProduct))]
        public async Task<IHttpActionResult> DeleteAllSelectedProducts()
        {
            var userId = 1;

            // Gets the users corresponding List ID
            var listId = db.Lists.FirstOrDefault(p => p.UserID == userId).ListID;

            // Gets all the selected products from corresponding List ID and puts it to the List
            var selectedProd = db.SelectedProducts.Where(p => p.ListID == listId).ToList();

            // Check if the list is not empty
            if (selectedProd.Count > 0)
            {
                // Loop through the SelectedProd List and remove each of them from the database
                foreach (var i in selectedProd)
                {
                    db.SelectedProducts.Remove(i);

                }
                await db.SaveChangesAsync();

                return Ok(selectedProd);
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelectedProductExists(int id)
        {
            return db.SelectedProducts.Count(e => e.SelectedProductID == id) > 0;
        }
    }
}