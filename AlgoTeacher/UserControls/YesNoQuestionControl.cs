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
    public partial class YesNoQuestionControl : QuestionControlBase
    {
        public YesNoQuestionControl()
        {
            InitializeComponent();
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
            YesButton.Focus();
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