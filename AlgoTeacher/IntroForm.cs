using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class IntroForm : DevExpress.XtraEditors.XtraForm
    {
        public IntroForm()
        {
            InitializeComponent();
        }
        public IntroForm(string question)
        {
            this.QuestionLabel.Text = question;
        }


        private void IntroForm_Load(object sender, EventArgs e)
        {

        }
        // TODO: Вызывай ShowDialog() и проверяй у него DialogResult по закрытию формы
        private void ButtonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}