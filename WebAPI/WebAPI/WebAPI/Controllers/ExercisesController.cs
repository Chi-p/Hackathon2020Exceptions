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
    public class ExercisesController : ApiController
    {
        private NotAThiefDataBaseEntities db = new NotAThiefDataBaseEntities();

        // GET: api/Exercises
        public IQueryable<Exercise> GetExercise()
        {
            return db.Exercise;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult GetExercise(int ExerciseId, int StudentId)
        {
            var exercise = db.Exercise.ToList().FirstOrDefault(i => i.Id == ExerciseId);
            if (exercise == null)
                return NotFound();

            Student student = db.Student.ToList().FirstOrDefault(i => i.Id == StudentId);
            if (student == null)
                return NotFound();

            var taskList = exercise.Task;

            foreach (var item in taskList)
            {
                string desc = item.Description;

                var variableList = db.Variable.ToList();
                foreach (var variable in variableList)
                {
                    if (variable.TaskId == item.Id)
                    {
                        var variableValue = variable.VariableValue.ToList();
                        Random rand = new Random();
                        int randIndex = rand.Next(0, variableValue.Count);
                        student.VariableValue.Add(variableValue[randIndex]);
                        db.SaveChanges();

                        if (desc.Contains(variable.Name))
                            desc = desc.Replace(variable.Name, student.VariableValue.ToList()[randIndex].Value);
                    }
                }
            }

            var result = new ExerciseModel(exercise)
            {
                Tasks = taskList.ToList().ConvertAll(i => new TaskModel(i))
            };

            return Ok(result);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.Id)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult PostExercise(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise.Add(exercise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public IHttpActionResult DeleteExercise(int id)
        {
            Exercise exercise = db.Exercise.Find(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercise.Remove(exercise);
            db.SaveChanges();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(int id)
        {
            return db.Exercise.Count(e => e.Id == id) > 0;
        }
    }
}