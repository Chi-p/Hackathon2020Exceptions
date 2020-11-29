using DesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Entities
{
    public partial class TaskAnswer
    {
        public string Question
        {
            get
            {
                var student = Student;
                string desc = "";
                desc = Task.Description;
                foreach (var item in AppData.Context.Variable.ToList().Where(p => p.TaskId == Task.Id).ToList())
                {
                    foreach (var item1 in item.VariableValue.ToList())
                    {
                        if (item1.Student.ToList().Contains(student))
                        {
                            if (desc.Contains(item.Name))
                                desc = desc.Replace(item.Name, item1.Value);
                        }
                    }
                }
                return desc;
            }
            set
            {
            }
        }
    }
}
