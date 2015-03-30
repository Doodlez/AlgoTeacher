using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Если нужно, базовый класс, В РЕАЛИЗАЦИИ...
namespace UserControls
{
    public abstract partial class QuestionControlBase : UserControl
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
        private string expectAnswer;

        public delegate void GoodAnswerHandler(object sender, EventArgs e);
        public delegate void BadAnswerHandler(object sender, EventArgs e);

        public event GoodAnswerHandler GoodAnswer;
        public event BadAnswerHandler BadAnswer;

        // очистка формы
        public abstract void ClearControl();

        // проверка ответа: генерирует одно из событий
        public abstract void checkAnswer();
    }
}
