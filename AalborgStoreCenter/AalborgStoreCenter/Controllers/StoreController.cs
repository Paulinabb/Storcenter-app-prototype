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
using System.Web.Http.Cors;

namespace AalborgStoreCenter.Controllers
{
    public class StoreController : ApiController
    {
        private Context db = new Context();

        // GET: api/Store/GetStores
        //gets all the stores
        [HttpGet]
        public IQueryable<Store> GetStores()
        {
            return db.Stores;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.StoreID == id) > 0;
        }
    }
}