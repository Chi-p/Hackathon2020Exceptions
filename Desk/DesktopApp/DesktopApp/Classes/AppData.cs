using DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApp.Classes
{
    public static class AppData
    {
        public static Frame MainFrame;
        public static NotAThiefDataBaseEntities Context = new NotAThiefDataBaseEntities();
        public static User user;
        public static List<Entities.Task> listTask = new List<Entities.Task>();
        //public static List<Variable> _listOfVariable = new List<Variable>();
        //public static List<VariableValue> _listOfVariableValue = new List<VariableValue>();
    }
}
