using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class TwoVariantsQuestionControl : QuestionControlBase
    {
        private string FirstVariant = "Да";
        private string SecondVariant = "Нет";

        public TwoVariantsQuestionControl()
        {
            InitializeComponent();
        }

        public TwoVariantsQuestionControl(string firstVariant, string secondVariant)
        {
            InitializeComponent();
            FirstButton.Text = firstVariant;
            SecondButton.Text = secondVariant;
        }

        private bool ActualAnswer;

        private delegate void SetTextCallback(string text1);

        private void YesButton_Click(object sender, EventArgs e)
        {
            ActualAnswer = true;
            checkAnswer(sender, e);
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            ActualAnswer = false;
            checkAnswer(sender,e);
        }

        // nothing need to clear :)
        public override void ClearControl()
        {
        }
        
        public override void SetFocus()
        {
            FirstButton.Focus();
        }

        protected override void checkAnswer(object sender, EventArgs e)
        {
            if (this.expectAnswer == this.ActualAnswer.ToString())
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