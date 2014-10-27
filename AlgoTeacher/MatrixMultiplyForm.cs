using System;
using System.Threading;
using System.Windows.Forms;
using AlgoTeacher.Logic;
using UserControls;

namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;
        
        private readonly MatrixMultiply _logic;
        private Matrix _matrix1;
        private Matrix _matrix2;

        private Thread CaclThread;
        private bool pressed = false;

        public MatrixMultiplyForm()
        {
            InitializeComponent();
            var answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            questionControl.AnswerClicked += answerClickHandler;

            var calculateClickHandler = new QuestionControl.CalculateClickedHandler(CalculateButton_Clicked);
            questionControl.CalculateClicked += calculateClickHandler;

            _matrix1 = new Matrix(3, 3);
            _matrix2 = new Matrix(3, 3);
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply();
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;
        }

        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {
            // Действия при загрузке
        }

        void Run()
        {
            _logic.MatrixMult(_matrix1, _matrix2);
        }

        public void CalculateButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии посчитать
            MessageBox.Show("Hi");
            questionControl.AnswerButtonEnabled = true;
            CaclThread  = new Thread(Run) {IsBackground = true};
            CaclThread.Start();
        }

        private void MatrixMultiplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                e.Cancel = true;

                Hide();

            }
        }

        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            MessageBox.Show("Quest works");
            this.questionControl.SetQuestionLabel(e.Quest.Question);
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }
            pressed = false;
        }

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
            pressed = true;
        }

        public void FillEventHandler(object sender, FillEvents.FillEventArgs e)
        {
            MessageBox.Show("Fill works");
        }
    }
}