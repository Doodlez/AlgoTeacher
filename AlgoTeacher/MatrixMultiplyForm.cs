using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Logic;
using AlgoTeacher.User_Controls;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm
    {
        private QuestEvents.QuestEventHandler _questHandler;
        private FillEvents.FillEventHandler _fillHandler;
        private MatrixMultiply _matrixMultiply;
        private Matrix _matrix1;
        private Matrix _matrix2;

        public MatrixMultiplyForm()
        {
            InitializeComponent();
            QuestionControl.AnswerClickedHandler answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            questionControl.AnswerClicked += answerClickHandler;

            QuestionControl.CalculateClickedHandler calculateClickHandler = new QuestionControl.CalculateClickedHandler(CalculateButton_Clicked);
            questionControl.CalculateClicked += calculateClickHandler;

            _matrix1 = new Matrix(3, 3);
            _matrix2 = new Matrix(3, 3);
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            MatrixMultiply matrixMult = new MatrixMultiply();
            _matrixMultiply = matrixMult;
            _matrixMultiply.questEvent += _questHandler;
        }
        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {

        }
        public void CalculateButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии посчитать
            MessageBox.Show("Hi");
            _matrixMultiply.MatrixMult(_matrix1, _matrix2);
        }

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
        }

        private void MatrixMultiplyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            MessageBox.Show("Quest works");
        }

        public void FillEventHandler(object sender, FillEvents.FillEventArgs e)
        {
            MessageBox.Show("Fill works");
        }
    }
}