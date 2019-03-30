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

namespace AalborgStoreCenter.Controllers
{
    public class ListController : ApiController
    {
        private Context db = new Context();


        [ResponseType(typeof(List))]
        //public async Task<IHttpActionResult> GetUserList()
        public IList<Product> GetUserList()
        {
            int userId = 1;
            var list = new List<Product>();

            var getListId = db.Lists.Where(p => p.UserID == userId).FirstOrDefault().ListID;
            var productList = db.SelectedProducts.Where(p => p.ListID == getListId).ToList();

            foreach(var p in productList)
            {
                var prod = db.Products.Find(p.ProductID);
                list.Add(prod);       
            }

            return list;
        }


        // POST: api/List/PostList
        [HttpPost]
        [ResponseType(typeof(List))]
        public async Task<IHttpActionResult> PostList(List list)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            db.Lists.Add(list);
            await db.SaveChangesAsync();

            return Ok();
        }


        //DELETE: api/list/deletelist/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteList(int id)
        {
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            db.Lists.Remove(list);
            await db.SaveChangesAsync();

            return Ok();
        }

        // GET: api/List/GetList/5
        [ResponseType(typeof(List))]
        public async Task<IHttpActionResult> GetList(int id)
        {
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListExists(int id)
        {
            return db.Lists.Count(e => e.ListID == id) > 0;
        }
    }
}