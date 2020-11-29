using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class ExerciseModel
    {
        public ExerciseModel(Exercise exercise)
        {
            Id = exercise.Id;
            Name = exercise.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}