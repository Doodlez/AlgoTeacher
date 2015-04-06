using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class InformationForm : DevExpress.XtraEditors.XtraForm
    {
        private string[] _buttonNoText;

        //1 - первый шаг объяснения
        //2 - второй шаг
        int ModeFlag
        {
            get;
            set;
        }

        public IntroForm IntroForm
        {
            get;
            set;
        }

        private TaskHelp _help; 

        public MyTask MyTask
        {
            get;
            set;
        }

        public InformationForm(TaskHelp help, string[] buttonsText, string[] buttonNoText)
        {
            InitializeComponent();
            _help = help;
            this.ButtonYes.Text = buttonsText[0];
            this.ButtonNo.Text = buttonsText[1];
            this.ButtonBack.Text = buttonsText[2];
            _buttonNoText = buttonNoText;
            ModeFlag = 1;
            QuestionLabel.Text = help.Content[0];
        }

        public InformationForm(string tense, IntroForm introForm, MyTask myTask)
        {
            InitializeComponent();
            ModeFlag = 1;
            QuestionLabel.Text = tense;
            IntroForm = introForm;
            MyTask = myTask;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            if (ModeFlag == 1)
            {
                this.QuestionLabel.Text = _help.Content[1];
                //"Объясняю подробнее: надо просто сложить 2 + 2 и получить 4. Теперь-то понятно?"
                this.ButtonNo.Text = _buttonNoText[0];
                this.ModeFlag = 2;
            }
            else if (ModeFlag == 2)
            {    
                this.QuestionLabel.Text = _help.Content[2];
                //"Объясняю подробнее: надо просто сложить 2 + 2 и получить 4. Теперь-то понятно?"
                this.ButtonNo.Text = _buttonNoText[1];
                this.ModeFlag = 3;
            }
            else
            {
                MessageBox.Show(_buttonNoText[2]);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {   
                // отлавливать  Ok и переходить к заданиям
                DialogResult = DialogResult.OK;
        }

        //private void NextStep()
        //{
        //    this.Visible = false;

        //    switch (DialogResult)
        //    {
        //        case DialogResult.OK:
        //            if (this.ModeFlag == false)
        //            {
        //                MyTask.ShowForm();
        //            }
        //            else
        //            {
        //                Application.Exit();
        //            }
        //            break;

        //        case DialogResult.No:
        //            this.Visible = true;
        //            this.ButtonNo.Visible = false;
        //            this.QuestionLabel.Text =
        //                "Объясняю подробнее: надо просто сложить 2 + 2 и получить 4. Теперь-то понятно?";
        //            this.ModeFlag = true;
        //            this.ButtonYes.Text = "Не понятно";
        //            break;

        //        case DialogResult.Cancel:
        //            if (this.ModeFlag == false)
        //            {
        //                IntroForm.Visible = true;
        //            }
        //            else
        //            {
        //                this.Visible = true;
        //                this.ButtonYes.Text = "Да, давай пример";
        //                ButtonNo.Visible = true;
        //                this.QuestionLabel.Text = "Две матрицы A и B можно перемножить тогда и только тогда, когда... Понятно?";
        //                this.ModeFlag = false;
        //            }
        //            break;
        //    }
        //}
    }
}