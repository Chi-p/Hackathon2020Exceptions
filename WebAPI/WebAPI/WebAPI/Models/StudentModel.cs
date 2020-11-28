using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class StudentModel
    {
        public StudentModel(User user)
        {
            Id = user.Id;
            Role = user.Role.Name;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Patronymic = user.Patronymic;
            Login = user.Login;
            Password = user.Password;
            Group = user.Student.Group.ToList().FirstOrDefault(i => i.Student.Contains(user.Student)).Name;
            NamedNumber = user.Student.NamedNumber;
            DateOfReceipt = user.Student.DateOfReceipt;
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
        public string NamedNumber { get; set; }
        public DateTime DateOfReceipt { get; set; }
    }
}