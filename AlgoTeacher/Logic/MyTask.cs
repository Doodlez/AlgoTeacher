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

        private string _language;

        private string _introText;

        private string[] _introButtonsText;

        private string[] _infoButtonsText;

        private string[] _infoButtonNoText;

        private TaskHelp _help;

        public MyTask(string name, Type formType, string langauge, string introText, string[] introButtonsText, string[] infoButtonsText, string[] infoButtonNoText, TaskHelp help)
        {
            Name = name;
            _formType = formType;
            _language = langauge;
            _introText = introText;
            _introButtonsText = introButtonsText;
            _infoButtonsText = infoButtonsText;
            _infoButtonNoText = infoButtonNoText;
            _help = help;
        }

        public override string ToString()
        {
            return Name;
        }

        // Временное решение
        public void ShowForm()
        {
            var args = new object[] {_language};
            var TaskForm = (Form)Activator.CreateInstance(_formType, args);
            TaskForm.ShowDialog();
        }

        public void ShowIntro()
        {
            IntroForm form = new IntroForm(_introText, _introButtonsText);
            var res = form.ShowDialog();
            switch (res)
            {
                case DialogResult.OK:
                    // вывести форму информации
                    ShowInfo();
                    break;

                case DialogResult.No:
                    // перейти к заданиям
                    ShowForm();
                    break;

                case DialogResult.Cancel:
                    // вернуться в главное меню
                    return;
            }
            return;
        }

        public void ShowInfo()
        {
            InformationForm info = new InformationForm(_help, _infoButtonsText, _infoButtonNoText);
            var infoRes = info.ShowDialog();
            switch (infoRes)
            {
                case DialogResult.OK:
                // переход к заданиям
                ShowForm();
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
