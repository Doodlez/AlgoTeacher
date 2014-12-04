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
    public partial class IntroForm : DevExpress.XtraEditors.XtraForm
    {
        public InformationForm InfoForm
        {
            get;
            set;
        }

        public MyTask MyTask
        {
            get;
            set;
        }

        public MainForm MainForm
        {
            get;
            set;
        }

        public IntroForm()
        {
            InitializeComponent();
        }

        public IntroForm(string question, MyTask myTask, MainForm mainForm)
        {
            InitializeComponent();
            this.QuestionLabel.Text = question;
            MyTask = myTask;
            MainForm = mainForm;
        }

        private void IntroForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            NextStep();
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            NextStep();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            NextStep();
        }

        private void NextStep()
        {
            this.Visible = false;

            switch (DialogResult)
            {
                case DialogResult.OK:
                    InfoForm = new InformationForm("Две матрицы A и B можно перемножить тогда и только тогда, когда... Понятно?", this, MyTask);
                    InfoForm.Show();
                    break;

                case DialogResult.No:
                    MyTask.ShowForm();
                    break;

                case DialogResult.Cancel:
                    MainForm.Visible = true;
                    break;
            }
        }
    }
}