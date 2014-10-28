using System;
using System.Threading;
using System.Collections.Generic;
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

            
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply();
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;
        }

        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {
            // Действия при загрузке
            // Ввод размеров
            MatrixSizeForm sizeForm = new MatrixSizeForm();
            sizeForm.ShowDialog();

            int rows1 = 1;
            int rows2 = 1;
            int cols1 = 1;
            int cols2 = 1;

            if (sizeForm.DialogResult == DialogResult.OK)
            {
                rows1 = sizeForm.Rows1;
                rows2 = sizeForm.Rows2;
                cols1 = sizeForm.Columns1;
                cols2 = sizeForm.Columns2;
            }
            else
            {
                Close();
            }

            int[][] values1 = { new[] { 0, 0, 0, 0 }, new[] { 0, 1, 2, 3 }, new[] { 0, 4, 5, 6 }, new[] { 0, 7, 8, 9 } };
            int[][] values2 = { new[] { 0, 0, 0, 0 }, new[] { 0, 9, 8, 7 }, new[] { 0, 6, 5, 4 }, new[] { 0, 3, 2, 1 } };

            workbookView1.GetLock();
            var cells = workbookView1.ActiveWorkbook.Worksheets[0].Cells;
            FillSheetWithStartMatrixes(values1, values2, cells);
            workbookView1.ReleaseLock();

            _matrix1 = new Matrix(rows1, cols1, values1);
            _matrix2 = new Matrix(rows2, cols2, values2);

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

        private void FillSheetWithStartMatrixes(int[][] values1, int[][] values2, SpreadsheetGear.IRange range)
        {
            for ( var i = 1; i < values1.Length; i++ )
            {
                for ( var j = 1; j < values1[i].Length; j++ )
                {
                    range[i - 1, j - 1].Value = values1[i][j];
                }
            }

            for ( var i = 1; i < values2.Length; i++ )
            {
                for ( var j = 1; j < values2[i].Length; j++ )
                {
                    range[i - 1, j + values1[0].Length].Value = values2[i][j];
                }
            }
        }
    }
}