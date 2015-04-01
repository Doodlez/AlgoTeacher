using System;
using System.Windows.Forms;

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
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (AnswerTextEdit.Text.Length == 0)
            {
                MessageBox.Show("Введите ответ");
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
    }
}
