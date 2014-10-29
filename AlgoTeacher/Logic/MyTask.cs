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

        private Type FormType;

        public Help TaskHelp;

        public MyTask(string name, Type formType)
        {
            Name = name;
            FormType = formType;
        }

        public override string ToString()
        {
            return Name;
        }

        // Временное решение
        public void ShowForm()
        {
            var TaskForm = (Form)Activator.CreateInstance(FormType);
            TaskForm.Show();
        }
    }
}
