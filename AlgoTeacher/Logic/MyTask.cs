using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic
{
    public class MyTask
    {
        public string Name;

        private Type _formType;

        private string _introText;

        private TaskHelp _help;

        public MyTask(string name, Type formType, string introText, TaskHelp help)
        {
            Name = name;
            _formType = formType;
            _introText = introText;
            _help = help;

        }

        public override string ToString()
        {
            return Name;
        }

        // Временное решение
        public void ShowForm()
        {
            var TaskForm = (Form)Activator.CreateInstance(_formType);
            TaskForm.Show();
        }

        public void ShowIntro()
        {
            IntroForm form = new IntroForm(_introText);
            var res = form.ShowDialog();
            switch (res)
            {
                case DialogResult.OK:
                    // вывести форму информации
                    ShowInfo();
                    break;

                case DialogResult.No:
                    // перейти к заданиям
                    ShowQuest();
                    break;

                case DialogResult.Cancel:
                    // вернуться в главное меню
                    return;
            }
            return;
        }

        public void ShowInfo()
        {
            InformationForm info = new InformationForm(_help);
            var infoRes = info.ShowDialog();
            switch (infoRes)
            {
                case DialogResult.OK:
                // переход к заданиям
                ShowQuest();
                break;

                case DialogResult.Cancel:
                // вернуться в главное меню
                return;
            }
        }

        public void ShowQuest()
        {
            MessageBox.Show("Тут будут задания");
        }
    }
}
