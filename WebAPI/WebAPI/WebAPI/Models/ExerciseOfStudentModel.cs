using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class ExerciseOfStudentModel
    {
        public ExerciseOfStudentModel(ExerciseOfStudent exerciseOfStudent)
        {
            Id = exerciseOfStudent.Id;
            Exercise = exerciseOfStudent.Exercise.Name;  
            Mark = exerciseOfStudent.Mark;
            Comment = exerciseOfStudent.Comment;
            Status = exerciseOfStudent.Status.Name;
        }

        public int Id { get; set; }
        public string Exercise { get; set; }
        public string Mark { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
    }
}