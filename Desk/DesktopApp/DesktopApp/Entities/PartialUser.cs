using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Entities
{
    public partial class User
    {
        public string FIO
        {
            get
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
    }
}
