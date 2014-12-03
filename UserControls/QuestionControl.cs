using System;
using System.Windows.Forms;

namespace UserControls
{
    public partial class QuestionControl : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void AnswerClickedHandler(object sender, EventArgs e);
        public event AnswerClickedHandler AnswerClicked;

        public delegate void CalculateClickedHandler(object sender, EventArgs e);
        public event CalculateClickedHandler CalculateClicked;

        private delegate void SetTextCallback(string text1);
        private delegate void SetCleanCallback();

        public bool AnswerButtonEnabled
        {
            get { return AnswerButton.Enabled; }
            set { AnswerButton.Enabled = value;}
        }

        //public bool CalculateButtonEnabled
        //{
        //    get { return CalculateButton.Enabled; }
        //    set { CalculateButton.Enabled = value; }
        //}

        //public void SetQuestionLabel(string value)
        //{
        //    if (this.QuestionLabel.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetQuestionLabel);
        //        this.Invoke(d, new object[] {value});
        //    }
        //    else
        //    {
        //        QuestionLabel.Text = value;
        //    }
        //}

        //public string GetQuestion()
        //{
        //    return QuestionLabel.Text;
        //}

        public string GetAnswer()
        {
            return AnswerTextEdit.Text;
        }

        public void CleanAnswer()
        {
            if (this.AnswerTextEdit.InvokeRequired)
            {
                SetCleanCallback d = new SetCleanCallback(CleanAnswer);
                this.Invoke(d);
            }
            else
            {
                AnswerTextEdit.Text = string.Empty;
            } 
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
