using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Quest;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using SpreadsheetGear.Windows.Forms;
using UserControls;
using System.Web;


//TODO: добавить функции выделения строки, столбца, ячейки цветом
namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SetQuestionCallback(string text);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;
   
        private readonly MatrixMultiply _logic;
        private Matrix _matrix1;
        private Matrix _matrix2;

        private Matrix _matrixRes;
        public DataTable resTab;

        private Thread CaclThread;

        private bool pressed = false;

        private IQuest quest;

        public MatrixMultiplyForm()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            // добавление обработчиков
            //var answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            //questionControl.AnswerClicked += answerClickHandler;

            var yesClickHandler = new YesNoQuestionControl.YesClickedHandler(YesButton_Clicked);
            yesNoQuestionControl.YesClicked += yesClickHandler;

            var noClickHandler = new YesNoQuestionControl.NoClickedHandler(NoButton_Clicked);
            yesNoQuestionControl.NoClicked += noClickHandler;

            var answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            questionControl.AnswerClicked += answerClickHandler;

           var secondStageClickHandler = new SizeQuestionControl.AnswerClickedHandler(SecondStageAnswer_Clicked);
           sizeQuestionControl.AnswerClicked += secondStageClickHandler;
          
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply();
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;
            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[0].Cells[0].Value = 1;
            //dataGridView1.Rows[0].Cells[1].Value = 2;
            //dataGridView1.Rows[1].Cells[0].Value = 3;
            //dataGridView1.Rows[1].Cells[1].Value = 4;
            //dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Green;
            //dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Green;
        }

        private void SetupMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц

            _matrix1 = new Matrix();
            Thread.Sleep(100);
            _matrix2 = new Matrix();

            matrixGridView1.AddValues(_matrix1.Values, _matrix1.RowsCount, _matrix1.ColumnsCount);
            matrixGridView2.AddValues(_matrix2.Values, _matrix2.RowsCount, _matrix2.ColumnsCount);
        }

        private void SetupResultMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц
            _matrixRes = new Matrix(_matrix1.RowsCount, _matrix2.ColumnsCount);
            matrixGridView3.AddValues(_matrixRes.Values, _matrixRes.RowsCount, _matrixRes.ColumnsCount);
        }

        // функция для установки вопроса из др потока
        public void SetQuestionText(string text)
        {
            try
            {
                if (QuestionLabel.InvokeRequired)
                {
                    SetQuestionCallback deleg = new SetQuestionCallback(SetQuestionText);
                    this.Invoke(deleg, new object[] { text });
                }
                else
                {
                    QuestionLabel.Text = text;
                }
            }
            catch (Exception ex) {
                var e = ex;
            }
        }

        private void FirstQuest(bool answ)
        {
            pressed = false;
            layoutQuest.Visibility = LayoutVisibility.Never;
            layoutYesNo.Visibility = LayoutVisibility.Always;
            quest = new YesNoQuest("first", "Можно ли перемножить данные матрицы?", answ);
            QuestionLabel.Text = quest.Question;
        }

        private void SecondQuest(string answ)
        {
            pressed = false;
            layoutQuest.Visibility = LayoutVisibility.Never;
            layoutYesNo.Visibility = LayoutVisibility.Never;
            layoutSecondStage.Visibility = LayoutVisibility.Always;
            quest = new IntegerIntegerValueQuest("second", "Каковы будут размерности данной матрицы?", answ);
            QuestionLabel.Text = quest.Question;
        }
        
        //TODO: поправить расположение матриц
        private void ThirdQuest()
        {
            pressed = false;
            SetupResultMatrix();
            SetQuestionText(" ");
            layoutQuest.Visibility = LayoutVisibility.Always;
            layoutYesNo.Visibility = LayoutVisibility.Never;
            layoutSecondStage.Visibility = LayoutVisibility.Never;

            CaclThread = new Thread(RunThird) { IsBackground = true };
            CaclThread.Start();
        }

        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {
            SetupMatrix();   
            // запуск квеста про возможность перемножения
            // нужно передать ответ, можно ли создать.
            bool answ;

            if (_matrix1.ColumnsCount == _matrix2.RowsCount)
            {
                answ = true;
            }
            else
            {
                answ = false;
            }

            FirstQuest(answ);
           // CaclThread1.Join();          
        }

        // запускает в потоке (собственно сам процесс перемножения)
        void RunThird()
        {
           var res = _logic.MatrixMult(_matrix1, _matrix2);
           if (res == null)
            {
                MessageBox.Show("Упс, ошибочка. Матрица не считается");
            }
            else
            {
                MessageBox.Show("Молодец, ты справился!");
                DialogResult = DialogResult.Cancel;
            }
        }

        // обработка вычисления.
        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            //MessageBox.Show("Quest works");
            
            SetQuestionText(e.Quest.Question + "Ответ: " + e.Quest.Answer);
            quest = e.Quest;
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }
        
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            MessageBox.Show("Правильно!");
             SetQuestionText(" ");

            this.questionControl.CleanAnswer();
            
            pressed = false;
        }

        private void ResultMatrFillCell(int row, int col, string value)
        {
            try
            {
                matrixGridView3[col - 1, row - 1].Value = value;
                matrixGridView3.Refresh();

            }
            catch (Exception e)
            {
                var ex = e;
            }
        }
        
        public void YesButton_Clicked(object sender, EventArgs e)
        {
            if (quest.CheckAnswer("True"))
            {
                MessageBox.Show("Молодец, ты прав! Переходим к следующему заданию.");
                SecondQuest(_matrix1.RowsCount + " " + _matrix2.ColumnsCount);
            }
            else
            {
                MessageBox.Show("Неправильный ответ. Попробуй еще раз.\r\nИ повнимательнее!");
                SetupMatrix();
            }
        }

        private void NoButton_Clicked(object sender, EventArgs e)
        {
            if (quest.CheckAnswer("False"))
            {
                MessageBox.Show("Молодец, ты прав! Переходим к следующему заданию.");
                SetupMatrix();
                while (_matrix1.ColumnsCount != _matrix2.RowsCount)
                {
                    SetupMatrix();
                }
                SecondQuest(_matrix1.RowsCount + " " + _matrix2.ColumnsCount);
            }
            else
            {
                MessageBox.Show("Неправильный ответ. Попробуй еще раз.\r\nИ повнимательнее!");
                SetupMatrix();
            }
        }

        //TODO: Реализовать обработку кнопок sizeQuestionControl

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {

            // Действия при нажатии ответ
            if (!quest.CheckAnswer(questionControl.GetAnswer()))
            //if (!quest.CheckAnswer(sizeQuestionControl.GetRowsAnswer() + " " + sizeQuestionControl.GetColumnsAnswer()))
            {
                MessageBox.Show("Не правильно!");
                return;
            }
            MessageBox.Show("Правильно! Молодец!");
            pressed = true;
        }

        public void SecondStageAnswer_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
            if (!quest.CheckAnswer(sizeQuestionControl.GetRowsAnswer() + " " + sizeQuestionControl.GetColumnsAnswer()))
            {
                MessageBox.Show("Не правильно!");
                return;
            }
            MessageBox.Show("Правильно! Молодец!");
            pressed = true;
            ThirdQuest();
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
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Value);
        }

        public void HighlightColumn(GridView gridView, int col)
        {
            gridView.Columns[col].AppearanceCell.BackColor = Color.Firebrick;
        }

        //private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        //{
        //    GridView View = sender as GridView;
        //    if (e.RowHandle >= 0)
        //    {
        //        string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
        //        if (category == "Beverages")
        //        {
        //            e.Appearance.BackColor = Color.Salmon;
        //            e.Appearance.BackColor2 = Color.SeaShell;
        //        }
        //    }
        //}
    }
}