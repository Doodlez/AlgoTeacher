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
    public partial class QuestionControlBase : UserControl
    {
        public QuestionControlBase()
        {
            InitializeComponent();
        }

        // установка правильного значения
        public void SetAnswer(string expAnswer)
        {
            this.expectAnswer = expAnswer;
        }

        // правильный ответ
        protected string expectAnswer;

        public delegate void GoodAnswerHandler(object sender, EventArgs e);
        public delegate void BadAnswerHandler(object sender, EventArgs e);

        public event GoodAnswerHandler GoodAnswer;
        public event BadAnswerHandler BadAnswer;

        protected virtual void OnGoodAnswered(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (GoodAnswer != null)
            {
                GoodAnswer(sender, e);
            }
        }

        protected virtual void OnBadAnswered(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (BadAnswer != null)
            {
                BadAnswer(sender, e);
            }
        }

        // очистка формы
        public virtual void ClearControl()
        {
            
        }

        // проверка ответа: генерирует одно из событий
        protected virtual void checkAnswer(object sender, EventArgs e)
        {
            
        }
    }
}
