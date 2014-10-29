﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Adapters;
using SpreadsheetGear.Windows.Forms;
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

        private readonly WorkbookView _workbookView;
        private MatrixMultiplyAdapter _matrixMultiplyAdapter;

        public MatrixMultiplyForm()
        {
            InitializeComponent();
            MatrixMultiplyWorkbookView.GetLock();
            _workbookView = MatrixMultiplyWorkbookView;
            _matrixMultiplyAdapter = new MatrixMultiplyAdapter(_workbookView);
            MatrixMultiplyWorkbookView.ReleaseLock();

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

            _matrixMultiplyAdapter.MakeBordersForInitialMatrixes(rows1, cols1, rows2, cols2);

            // TODO: Чтение матриц
            //_matrix1 = new Matrix(rows1, cols1, values1);
            //_matrix2 = new Matrix(rows2, cols2, values2);
        }

        void Run()
        {
            _logic.MatrixMult(_matrix1, _matrix2);
        }

        public void CalculateButton_Clicked(object sender, EventArgs e)
        {
            if ( _matrix1 == null || _matrix2 == null) return;

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

        //private void FillSheetWithStartMatrixes(int[][] values1, int[][] values2, SpreadsheetGear.IRange range)
        //{
        //    for ( var i = 1; i < values1.Length; i++ )
        //    {
        //        for ( var j = 1; j < values1[i].Length; j++ )
        //        {
        //            range[i - 1, j - 1].Value = values1[i][j];
        //        }
        //    }

        //    for ( var i = 1; i < values2.Length; i++ )
        //    {
        //        for ( var j = 1; j < values2[i].Length; j++ )
        //        {
        //            range[i - 1, j + values1[0].Length - 1].Value = values2[i][j];
        //        }
        //    }
        //}
    }
}