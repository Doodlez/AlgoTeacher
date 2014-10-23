using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AlgoTeacher.User_Controls
{
    public partial class QuestionControl : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void AnswerClickedHandler(object sender, EventArgs e);
        public event AnswerClickedHandler AnswerClicked;

        public delegate void CalculateClickedHandler(object sender, EventArgs e);
        public event CalculateClickedHandler CalculateClicked;

        //public delegate void AnswerButtonEnabledChangeHandler(object sender, EventArgs e);
        //public event AnswerButtonEnabledChangeHandler AnswerButtonEnabledChange;

        //public delegate void CalculateButtonEnabledChangeHandler(object sender, EventArgs e);
        //public event CalculateButtonEnabledChangeHandler CalculateButtonEnabledChange;

        public bool AnswerButtonEnabled
        {
            get { return AnswerButton.Enabled; }
            set { AnswerButton.Enabled = value;}
        }

        public bool CalculateButtonEnabled
        {
            get { return CalculateButton.Enabled; }
            set { CalculateButton.Enabled = value; }
        }

        public QuestionControl()
        {
            InitializeComponent();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (AnswerTextEdit.Text.Length == 0)
            {
                MessageBox.Show("Введите ответ");
            }
            else
            {
                OnAnswerClicked(sender, e);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateClicked(sender, e);
        }
        protected virtual void OnAnswerClicked(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (AnswerClicked != null)
            {
                AnswerClicked(sender, e);  
            }
        }

    }
}
