using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace UserControls
{
    public partial class QuestionControl : QuestionControlBase
    {
        private delegate void SetCleanCallback();

        public string GetAnswer()
        {
            return AnswerTextEdit.Text;
        }

        public QuestionControl() : base ()
        {
            InitializeComponent();
            AnswerTextEdit.Focus();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (AnswerTextEdit.Text.Length == 0)
            {
                AnswerTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                AnswerTextEdit.Properties.Appearance.BorderColor = Color.Red;
            }
            else
            {
                checkAnswer(sender, e);
            }
        }

        public override void ClearControl()
        {
            if (this.AnswerTextEdit.InvokeRequired)
            {
                SetCleanCallback d = new SetCleanCallback(ClearControl);
                this.Invoke(d);
            }
            else
            {
                AnswerTextEdit.Text = string.Empty;
            } 
        }

        protected override void checkAnswer(object sender, EventArgs e)
        {
            if (AnswerTextEdit.Text == this.expectAnswer)
            {
                this.OnGoodAnswered(sender, e);
            }
            else
            {
                this.OnBadAnswered(sender, e);
            }
        }

        public override void SetFocus()
        {

            if (this.AnswerTextEdit.InvokeRequired)
            {
                SetCleanCallback d = new SetCleanCallback(SetFocus);
                this.Invoke(d);
            }
            else
            {
                AnswerTextEdit.Focus();
            } 
           
        }

        private void AnswerTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (AnswerTextEdit.Text.Length != 0)
            {
                AnswerTextEdit.Properties.BorderStyle = BorderStyles.NoBorder;
                AnswerTextEdit.Properties.Appearance.BorderColor = Color.Empty;
            }
        }
    }
}
