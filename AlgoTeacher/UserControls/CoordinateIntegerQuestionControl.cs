using System;
using System.Drawing;
using DevExpress.XtraEditors.Controls;

namespace UserControls
{
    public partial class CoordinateIntegerQuestionControl : QuestionControlBase
    {
        private delegate void SetCleanCallback();

        public string GetAnswer()
        {
            return XTextEdit.Text + "," + YTextEdit.Text + "," + AnswerTextEdit.Text;
        }

        public CoordinateIntegerQuestionControl()
            : base()
        {
            InitializeComponent();
            XTextEdit.Focus();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            bool test = true;
            if (AnswerTextEdit.Text.Length == 0)
            {
                AnswerTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                AnswerTextEdit.Properties.Appearance.BorderColor = Color.Red;
                test = false;

            }

            if (XTextEdit.Text.Length == 0)
            {
                XTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                XTextEdit.Properties.Appearance.BorderColor = Color.Red;
                test = false;
            }

            if (YTextEdit.Text.Length == 0)
            {
                YTextEdit.Properties.BorderStyle = BorderStyles.Flat;
                YTextEdit.Properties.Appearance.BorderColor = Color.Red;
                test = false;
            }

            if (test)
            {
                checkAnswer(sender, e);
            }
          
        }

        public override void ClearControl()
        {

            if (this.AnswerTextEdit.InvokeRequired || XTextEdit.InvokeRequired || YTextEdit.InvokeRequired)
            {
                SetCleanCallback d = new SetCleanCallback(ClearControl);
                this.Invoke(d);
            }
            else
            {
                AnswerTextEdit.Text = string.Empty;
                XTextEdit.Text = string.Empty;
                YTextEdit.Text = string.Empty;
            }
        }

        protected override void checkAnswer(object sender, EventArgs e)
        {
            string userAnswer = "";

            userAnswer += GetAnswer(); 

            if (userAnswer == this.expectAnswer)
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

            if (this.XTextEdit.InvokeRequired)
            {
                SetCleanCallback d = new SetCleanCallback(SetFocus);
                this.Invoke(d);
            }
            else
            {
                XTextEdit.Focus();
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
