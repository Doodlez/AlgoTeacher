using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Logic;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class InformationForm : DevExpress.XtraEditors.XtraForm
    {
        bool ModeFlag
        {
            get;
            set;
        }

        public IntroForm IntroForm
        {
            get;
            set;
        }

        public MyTask MyTask
        {
            get;
            set;
        }

        public InformationForm()
        {
            InitializeComponent();
        }

        public InformationForm(string tense, IntroForm introForm, MyTask myTask)
        {
            InitializeComponent();
            ModeFlag = false;
            QuestionLabel.Text = tense;
            IntroForm = introForm;
            MyTask = myTask;
        }

        private void ButtonExample_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            NextStep();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            NextStep();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            NextStep();
        }

        private void NextStep()
        {
            this.Visible = false;

            switch (DialogResult)
            {
                case DialogResult.OK:
                    if (this.ModeFlag == false)
                    {
                        MyTask.ShowForm();
                    }
                    else
                    {
                        //TODO: здесь надо вернуться на главную форму вместо выхода из программы
                        Application.Exit();
                    }
                    break;

                case DialogResult.No:
                    this.Visible = true;
                    //TODO: почему-то этот Visible перестал работать - посмотри. Недавно работал, а сейчас нет - зараза
                    this.ButtonExample.Visible = false;
                    this.QuestionLabel.Text =
                        "Объясняю подробнее: надо просто сложить 2 + 2 и получить 4. Теперь-то понятно?";
                    this.ModeFlag = true;
                    this.ButtonNext.Text = "Не понятно";
                    break;

                case DialogResult.Cancel:
                    if (this.ModeFlag == false)
                    {
                        IntroForm.Visible = true;
                    }
                    else
                    {
                        this.Visible = true;
                        this.ButtonNext.Text = "Да, давай пример";
                        ButtonExample.Visible = true;
                        this.QuestionLabel.Text = "Две матрицы A и B можно перемножить тогда и только тогда, когда... Понятно?";
                        this.ModeFlag = false;
                    }
                    break;
            }
        }
    }
}