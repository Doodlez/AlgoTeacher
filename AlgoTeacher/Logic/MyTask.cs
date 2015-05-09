using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;

namespace AlgoTeacher.Logic
{
    public class MyTask
    {
        const string Path = @"..\..\Questions\";

        public string Name;

        public string Label;

        private Type _formType;

        private string _language;

        private string _introText;

        private string[] _introButtonsText;

        private string[] _infoButtonsText;

        private string[] _infoButtonNoText;

        private TaskHelp _help;

        public MyTask(string name, string label, Type formType, string langauge)
        {
            Name = name;
            Label = label;
            _formType = formType;
            _language = langauge;
            _introText = File.ReadAllText(Path + _language + @"\intro_form\" + Name + @"\intro_text.txt", Encoding.Default); ;
            _introButtonsText = File.ReadAllLines(Path + _language + @"\intro_form\intro_form_buttons.txt", Encoding.Default);
            _infoButtonsText = File.ReadAllLines(Path + _language + @"\info_form\info_form_buttons.txt", Encoding.Default);
            _infoButtonNoText =  File.ReadAllLines(Path + _language + @"\info_form\info_form_no_button.txt", Encoding.Default);

            List<string> helpsText = new List<string>();
            var helpsText1 = File.ReadAllText(Path + _language + @"\" + Name + @"\helps_text_1.txt", Encoding.Default);
            var helpsText2 = File.ReadAllText(Path + _language + @"\" + Name + @"\helps_text_2.txt", Encoding.Default);
            var helpsText3 = File.ReadAllText(Path + _language + @"\" + Name + @"\helps_text_3.txt", Encoding.Default);
            helpsText.Add(helpsText1);
            helpsText.Add(helpsText2);
            helpsText.Add(helpsText3);

            _help = new TaskHelp("test", helpsText);
        }

        public override string ToString()
        {
            return Label;
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
