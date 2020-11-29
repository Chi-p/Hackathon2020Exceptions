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
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private NotAThiefDataBaseEntities db = new NotAThiefDataBaseEntities();

        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            return db.User;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string login, string pass)
        {
            User user = db.User.ToList().FirstOrDefault(i => i.Login == login && i.Password == pass);
            if (user == null)
            {
                return NotFound();
            }

            switch (user.Role.Name)
            {
                case "Студент":
                    return Ok(new StudentModel(user));
                case "Преподаватель":
                case "Администратор":
                    ModelState.AddModelError("400", "Пользователь не доступен");
                    break;
                default:
                    ModelState.AddModelError("400", "Неизвестная ошибка");
                    break;
            }

            return BadRequest(ModelState);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int Id)
        {
            User user = db.User.ToList().FirstOrDefault(i => i.Id == Id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new StudentModel(user));
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currUser = db.User.ToList().FirstOrDefault(i => i.Login == user.Login && i.Password == user.Password);
            if (currUser == null)
                return NotFound();

            return Ok(new StudentModel(currUser));
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

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
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}