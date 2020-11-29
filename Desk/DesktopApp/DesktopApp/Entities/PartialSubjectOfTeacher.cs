using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Entities
{
    public partial class SubjectOfTeacher
    {
        public string GroupFullName
        {
            get
            {
                return $"{Group.Name} ({Group.Student.Count} чел.)";
            }
        }
        public string GroupAndSubject
        {
            get
            {
                return $"{Group.Name} | {Subject.Name}";
            }
        }
    }
}
