using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Adapters;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
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

        private WorkbookView _workbookView;
        private MatrixMultiplyAdapter _matrixMultiplyAdapter;

        private IQuest quest;

        private int _rows1 = 3;
        private int _columns1 = 3;
        private int _rows2 = 3;
        private int _columns2 = 3;

        public MatrixMultiplyForm()
        {
            InitializeComponent();

            var answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            //questionControl.AnswerClicked += answerClickHandler;

            var calculateClickHandler = new QuestionControl.CalculateClickedHandler(CalculateButton_Clicked);
            //questionControl.CalculateClicked += calculateClickHandler;

            
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
            //MatrixSizeForm sizeForm = new MatrixSizeForm();
            //sizeForm.ShowDialog();

            //if (sizeForm.DialogResult == DialogResult.OK)
            //{
            //    _rows1 = sizeForm.Rows1;
            //    _rows2 = sizeForm.Rows2;
            //    _columns1 = sizeForm.Columns1;
            //    _columns2 = sizeForm.Columns2;
            //}

            //else
            //{
            //    Close();
            //

            int[][] values1 = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            int[][] values2 = { new[] { 9, 8, 7 }, new[] { 6, 5, 4 }, new[] { 3, 2, 1 } };
           // TODO: Чтение матриц
            _matrix1 = new Matrix(_rows1, _columns1, values1);
            _matrix2 = new Matrix(_rows2, _columns2, values2);

            List<int[]> rowlist1 = new List<int[]>();
            for (int i = 0; i < _matrix1.RowsCount ; i++ )
            {
                rowlist1.Add(_matrix1.Values[i]);
            }

            DataTable tab = new DataTable();
            for (int i = 0; i < _matrix1.ColumnsCount; i++)
            {
                DataColumn col = new DataColumn();
                tab.Columns.Add(col);
            }

            foreach (var intse in rowlist1)
            {
                DataRow row = tab.NewRow();
                for (int i = 0; i < tab.Columns.Count; i++)
                {
                    row[i] = intse[i];
                }
                tab.Rows.Add(row);
            }

            List<int[]> rowlist2 = new List<int[]>();
            for (int i = 0; i < _matrix2.RowsCount; i++)
            {
                rowlist2.Add(_matrix2.Values[i]);
            }

            DataTable tab2 = new DataTable();
            for (int i = 0; i < _matrix2.ColumnsCount; i++)
            {
                DataColumn col = new DataColumn();
                tab2.Columns.Add(col);
            }

            foreach (var intse in rowlist2)
            {
                DataRow row = tab2.NewRow();
                for (int i = 0; i < tab2.Columns.Count; i++)
                {
                    row[i] = intse[i];
                }
                tab2.Rows.Add(row);
            }

            gridControl1.DataSource = tab;
            gridControl2.DataSource = tab2;
            foreach (GridColumn col in gridView1.Columns)
            {
                col.AppearanceCell.Font = new Font("Arial", 16, FontStyle.Bold);
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
            }

            foreach (GridColumn col in gridView2.Columns)
            {
                col.AppearanceCell.Font = new Font("Arial", 16, FontStyle.Bold);
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
            }

            gridControl1.Size = new Size(_matrix1.ColumnsCount * 50,_matrix1.RowsCount * 50);
            gridControl2.Size = new Size(_matrix2.ColumnsCount * 50, _matrix2.RowsCount * 50);
            
            CaclThread = new Thread(Run) { IsBackground = true };
            CaclThread.Start();
           // gridView1.Columns[0];
            //var matrix1_values = _matrixMultiplyAdapter.ReadInitialMatrixValues(1, 1, _rows1, _rows2);
            //var matrix2_values = _matrixMultiplyAdapter.ReadInitialMatrixValues(1, _columns1 + 2, _rows2, _columns2);

            //_matrix1 = new Matrix(_rows1, _columns1, matrix1_values);
            //_matrix2 = new Matrix(_rows2, _columns2, matrix2_values);

            //if (_matrix1 == null || _matrix2 == null) return;

            //_matrixMultiplyAdapter.MakeBordersForMatrix(1, _columns1 + _columns2 + 3, _rows1, _columns2);

            // Действия при нажатии посчитать
        }

        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            if (e.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)

                e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        void Run()
        {
            _logic.MatrixMult(_matrix1, _matrix2);
        }

        public void CalculateButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void MatrixMultiplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            //MessageBox.Show("Quest works");
            //QuestionLabel.Text = e.Quest.Question + "Ответ: " + e.Quest.Answer;
            quest = e.Quest;
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }

            _matrixMultiplyAdapter.FillResultCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            QuestionLabel.Text = "";
            this.questionControl1.CleanAnswer();
            
            pressed = false;
        }

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
            if (!quest.CheckAnswer(questionControl1.GetAnswer()))
            {
                MessageBox.Show("не правильно!");
                return;
            }
            pressed = true;
        }

        public void FillEventHandler(object sender, FillEvents.FillEventArgs e)
        {
            // добавлено замедление заполнения
            bool t = true;
            while (t)
            {
                System.Threading.Thread.Sleep(200);
                t = false;
            }
            //_matrixMultiplyAdapter.FillResultCell(e.Coord.X,e.Coord.Y,e.Value);
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