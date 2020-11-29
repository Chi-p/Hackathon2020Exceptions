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
    public class ExerciseOfStudentsController : ApiController
    {
        private NotAThiefDataBaseEntities db = new NotAThiefDataBaseEntities();

        // GET: api/ExerciseOfStudents
        public IQueryable<ExerciseOfStudent> GetExerciseOfStudent()
        {
            return db.ExerciseOfStudent;
        }

        // GET: api/ExerciseOfStudents/5
        [ResponseType(typeof(ExerciseOfStudent))]
        public IHttpActionResult GetExerciseOfStudent(int StudentId)
        {
            var exerciseOfStudent = db.ExerciseOfStudent.ToList().Where(i => i.StudentId == StudentId).ToList();
            if (exerciseOfStudent == null)
                return NotFound();

            var result = new List<ExerciseOfStudentModelList>();
            foreach(var item in exerciseOfStudent.GroupBy(i => i.SubjectOfTeacher.Subject))
            {
                result.Add(new ExerciseOfStudentModelList
                {
                    SubjectName = item.First().SubjectOfTeacher.Subject.Name,
                    ExerciseOfStudentModels = exerciseOfStudent.ToList().Where(i => 
                    i.SubjectOfTeacher == item.First().SubjectOfTeacher).ToList().ConvertAll(i => new ExerciseOfStudentModel(i))
                });
            }

            return Ok(result);
        }

        // PUT: api/ExerciseOfStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseOfStudent(int id, ExerciseOfStudent exerciseOfStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseOfStudent.Id)
            {
                return BadRequest();
            }

            db.Entry(exerciseOfStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseOfStudentExists(id))
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

        // POST: api/ExerciseOfStudents
        [ResponseType(typeof(ExerciseOfStudent))]
        public IHttpActionResult PostExerciseOfStudent(ExerciseOfStudent exerciseOfStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseOfStudent.Add(exerciseOfStudent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseOfStudent.Id }, exerciseOfStudent);
        }

        // DELETE: api/ExerciseOfStudents/5
        [ResponseType(typeof(ExerciseOfStudent))]
        public IHttpActionResult DeleteExerciseOfStudent(int id)
        {
            ExerciseOfStudent exerciseOfStudent = db.ExerciseOfStudent.Find(id);
            if (exerciseOfStudent == null)
            {
                return NotFound();
            }

            db.ExerciseOfStudent.Remove(exerciseOfStudent);
            db.SaveChanges();

            return Ok(exerciseOfStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseOfStudentExists(int id)
        {
            return db.ExerciseOfStudent.Count(e => e.Id == id) > 0;
        }
    }
}