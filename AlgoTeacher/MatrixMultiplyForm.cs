using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Adapters;
using AlgoTeacher.Logic.Quest;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout.Utils;
using SpreadsheetGear.Windows.Forms;
using UserControls;

//TODO: Поправить матрицы: выравнивание + лишняя строка
//TODO: Поправить матрицы :появление лишних столбцов

//TODO: добавить функции выделения строки, столбца, ячейки цветом

//TODO: Сохранить настроеный grid как контрол(XtraUserControl).

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

           var secondStageClickHandler = new SecondStageControl.AnswerClickedHandler(SecondStageAnswer_Clicked);
           secondStageControl.AnswerClicked += secondStageClickHandler;
          
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply();
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;
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

        private void SetupMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц

            _matrix1 = new Matrix();
            Thread.Sleep(100);
            _matrix2 = new Matrix();

            List<int[]> rowlist1 = new List<int[]>();
            List<int[]> rowlist2 = new List<int[]>();

            for (int i = 0; i < _matrix1.RowsCount; i++)
            {
                rowlist1.Add(_matrix1.Values[i]);
            }

            for (int i = 0; i < _matrix2.RowsCount; i++)
            {
                rowlist2.Add(_matrix2.Values[i]);
            }

            DataTable tab = new DataTable();
            DataTable tab2 = new DataTable();
            
            for (int i = 0; i < _matrix1.ColumnsCount; i++)
            {
                DataColumn col = new DataColumn();
                tab.Columns.Add(col);
            }

            for (int i = 0; i < _matrix2.ColumnsCount; i++)
            {
                DataColumn col = new DataColumn();
                tab2.Columns.Add(col);
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

            // настройка матриц
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

            gridControl1.Size = new Size(_matrix1.ColumnsCount * 50, _matrix1.RowsCount * 50);
            gridControl2.Size = new Size(_matrix2.ColumnsCount * 50, _matrix2.RowsCount * 50);
        }

        private void SetupResultMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц
            _matrixRes = new Matrix(_matrix1.RowsCount,_matrix2.ColumnsCount);

             resTab = new DataTable();
            
            for (int i = 0; i < _matrixRes.ColumnsCount; i++)
            {
                DataColumn col = new DataColumn();
                resTab.Columns.Add(col);
            }

            List<int[]> rowlist = new List<int[]>();

            for (int i = 0; i < _matrixRes.RowsCount; i++)
            {
                rowlist.Add(_matrixRes.Values[i]);
            }

            foreach (var intse in rowlist)
            {
                DataRow row = resTab.NewRow();
                for (int i = 0; i < resTab.Columns.Count; i++)
                {
                    row[i] = intse[i];
                }
                resTab.Rows.Add(row);
            }    
            gridControl3.DataSource = resTab;

            // настройка матриц
            foreach (GridColumn col in gridView3.Columns)
            {
                col.AppearanceCell.Font = new Font("Arial", 16, FontStyle.Bold);
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
            }

            foreach (GridColumn col in gridView3.Columns)
            {
                col.AppearanceCell.Font = new Font("Arial", 16, FontStyle.Bold);
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.Options.UseTextOptions = true;
            }

            gridControl3.Size = new Size(_matrixRes.ColumnsCount * 50, _matrixRes.RowsCount * 50);
            
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
        
            //_matrixMultiplyAdapter.FillResultCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            //MessageBox.Show("Правильно!")
             SetQuestionText(" ");

            this.questionControl.CleanAnswer();
            
            pressed = false;
        }

        private void ResultMatrFillCell(int row, int col, string value)
        {
            try
            {
                
                //gridView3.BeginDataUpdate();
                gridView3.SetRowCellValue(row - 1, gridView3.Columns[col - 1], value);
                gridView3.RefreshData();
                //gridView3.EndDataUpdate();
                
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

        //TODO: Реализовать обработку кнопок secondStageControl

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
            if (!quest.CheckAnswer(questionControl.GetAnswer()))
            //if (!quest.CheckAnswer(secondStageControl.GetRowsAnswer() + " " + secondStageControl.GetColumnsAnswer()))
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
            if (!quest.CheckAnswer(secondStageControl.GetRowsAnswer() + " " + secondStageControl.GetColumnsAnswer()))
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
    }
}