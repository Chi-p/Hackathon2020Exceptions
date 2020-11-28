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
    public class TasksController : ApiController
    {
        private NotAThiefDataBaseEntities db = new NotAThiefDataBaseEntities();

        // GET: api/Tasks
        public IQueryable<Task> GetTask()
        {
            return db.Task;
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int ExerciseId, int StudentId)
        {
            Exercise exercise = db.Exercise.ToList().FirstOrDefault(i => i.Id == ExerciseId);

            if (exercise == null)
                return NotFound();

            var task = db.Task.ToList().Where(i => i.Exercise.Contains(exercise)).ToList();

            if (task == null)
                return NotFound();

            Student student = db.Student.ToList().FirstOrDefault(i => i.Id == StudentId);

            foreach (var item in task)
            {
                var a = db.Variable.ToList().Where(i => i.Task == item).ToList();
                string desc = item.Description;

                foreach (var item1 in a)
                {
                    var d = db.VariableValue.ToList().FirstOrDefault(i => i.Variable == item1 && i.Student.ToList().First() == student);
                    if (desc.Contains(item1.Name))
                        desc = desc.Replace(item1.Name, d.Value);
                }

                item.Description = desc;
            }

            return Ok(task.ConvertAll(i => new TaskModel(i)));
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Task.Add(task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Task.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Task.Count(e => e.Id == id) > 0;
        }
    }
}