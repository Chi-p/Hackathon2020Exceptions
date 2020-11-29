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

namespace WebAPI.Controllers
{
    public class TaskAnswersController : ApiController
    {
        private NotAThiefDataBaseEntities db = new NotAThiefDataBaseEntities();

        // GET: api/TaskAnswers
        public IQueryable<TaskAnswer> GetTaskAnswer()
        {
            return db.TaskAnswer;
        }

        // GET: api/TaskAnswers/5
        [ResponseType(typeof(TaskAnswer))]
        public IHttpActionResult GetTaskAnswer(int id)
        {
            TaskAnswer taskAnswer = db.TaskAnswer.Find(id);
            if (taskAnswer == null)
            {
                return NotFound();
            }

            return Ok(taskAnswer);
        }

        // PUT: api/TaskAnswers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskAnswer(int id, TaskAnswer taskAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskAnswer.TaskId)
            {
                return BadRequest();
            }

            db.Entry(taskAnswer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskAnswerExists(id))
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

        // POST: api/TaskAnswers
        [ResponseType(typeof(TaskAnswer))]
        public IHttpActionResult PostTaskAnswer(TaskAnswer taskAnswer)
        {
            Task task = db.Task.ToList().FirstOrDefault(i => i.Id == taskAnswer.TaskId);
            Student student = db.Student.ToList().FirstOrDefault(i => i.Id == taskAnswer.StudentId);
            if (task == null || student == null)
                return NotFound();

            db.TaskAnswer.Add(new TaskAnswer
            {
                Task = task,
                Student = student,
                Answer = taskAnswer.Answer
            });

            db.ExerciseOfStudent.ToList().FirstOrDefault(i => i.Exercise.Task.Contains(task) && i.Student == student).StatusId = 2;
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/TaskAnswers/5
        [ResponseType(typeof(TaskAnswer))]
        public IHttpActionResult DeleteTaskAnswer(int id)
        {
            TaskAnswer taskAnswer = db.TaskAnswer.Find(id);
            if (taskAnswer == null)
            {
                return NotFound();
            }

            db.TaskAnswer.Remove(taskAnswer);
            db.SaveChanges();

            return Ok(taskAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskAnswerExists(int id)
        {
            return db.TaskAnswer.Count(e => e.TaskId == id) > 0;
        }
    }
}