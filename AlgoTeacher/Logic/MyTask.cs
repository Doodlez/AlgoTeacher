using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoTeacher.Logic
{
    public class MyTask
    {
        public string Name;

        public Form TaskForm;

        public Help TaskHelp;

        public MyTask(string name, Form form)
        {
            Name = name;
            TaskForm = form;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
