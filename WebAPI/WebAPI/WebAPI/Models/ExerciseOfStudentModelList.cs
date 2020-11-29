using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ExerciseOfStudentModelList
    {
        public ExerciseOfStudentModelList()
        {

        }

        public string SubjectName { get; set; }

        public List<ExerciseOfStudentModel> ExerciseOfStudentModels { get; set; }

    }
}