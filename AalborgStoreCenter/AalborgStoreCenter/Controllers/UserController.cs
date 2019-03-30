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
    public class UserController : ApiController
    {
        private Context db = new Context();

        // GET: api/User
        [HttpGet]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }


        //Validates user that is already in database
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> ValidateUser(string username, string password)
        {
            var user = db.Users.Where(u => u.UserName.Equals(username) && u.Password.Equals(password));
            var userID = 0;
           foreach(var i in user)
            {
                userID = i.UserID;
            }

            if(user != null)
            {
                return Ok(user);
 
            }
            return NotFound();
        }

        // GET: api/User/Get/GetUser/5
        //gets user by id
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

        // PUT: api/User/5
        [HttpPut]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> UpdateUser([FromUri]string address)
        {
            var userId = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.FindAsync(userId);

            if (user != null)
            {
                user.Address = address;
                db.Entry(user).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok(user);
        }

        //// POST: api/User
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(user);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        //}

        //// DELETE: api/User/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> DeleteUser(int id)
        //{
        //    User user = await db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();

        //    return Ok(user);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}