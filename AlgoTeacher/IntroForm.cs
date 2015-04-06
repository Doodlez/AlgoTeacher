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
        public IntroForm()
        {
            InitializeComponent();
        }

        public IntroForm(string question, string[] buttonsText)
        {
            InitializeComponent();
            this.QuestionLabel.Text = question;
            this.ButtonYes.Text = buttonsText[0];
            this.ButtonNo.Text = buttonsText[1];
            this.ButtonBack.Text = buttonsText[2];
        }

        private void IntroForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void QuestionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}