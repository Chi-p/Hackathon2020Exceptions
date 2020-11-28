using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class TaskModel
    {
        public TaskModel(Task task)
        {
            Id = task.Id;
            Description = task.Description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}