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
        private delegate void SetTextCallback(string text1);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;
   
        private readonly MatrixMultiply _logic;
        private Matrix _matrix1;
        private Matrix _matrix2;

        private Thread CaclThread;

        private bool pressed = false;

        private IQuest quest;

        public MatrixMultiplyForm()
        {
            InitializeComponent();

            // добавление обработчиков
            var answerClickHandler = new QuestionControl.AnswerClickedHandler(AnswerButton_Clicked);
            questionControl.AnswerClicked += answerClickHandler;

            var yesClickHandler = new YesNoQuestionControl.YesClickedHandler(YesButton_Clicked);
            yesNoQuestionControl.YesClicked += yesClickHandler;

            var noClickHandler = new YesNoQuestionControl.NoClickedHandler(NoButton_Clicked);
            yesNoQuestionControl.NoClicked += noClickHandler;
          
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply();
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;
        }
        // TODO: Исправить ошибку с несоответсвием числа параметров при установке нового значения QuestionLabel.Text
        // функция для установки вопроса из др потока
        private void SetQuestionText(string text)
        {
            if (QuestionLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetQuestionText);
                this.Invoke(d);
            }
            else
            {
                QuestionLabel.Text = text;
            }
        }

        private void SetupMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц
            //int[][] values1 = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            //int[][] values2 = { new[] { 9, 8, 7 }, new[] { 6, 5, 4 }, new[] { 3, 2, 1 } };

            // создание матриц
            //_matrix1 = new Matrix(_rows1, _columns1, values1);
            //_matrix2 = new Matrix(_rows2, _columns2, values2);

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

        //TODO: Проверка ответ (добавить корректный вопрос), если нельзя, то вывести вариант который можно.
        private void FirstQuest(bool answ)
        {
            layoutQuest.Visibility = LayoutVisibility.Never;
            layoutYesNo.Visibility = LayoutVisibility.Always;
            quest = new YesNoQuest("first", "Можно ли перемножить данные матрицы?", answ);
            QuestionLabel.Text = quest.Question;
        }

        //TODO: сделать 2-й тест
        private void SecondQuest()
        {
            layoutQuest.Visibility = LayoutVisibility.Always;
            layoutYesNo.Visibility = LayoutVisibility.Never;
            //quest = new IntegerValueQuest("first", "Можно ли перемножить данные матрицы?", answ);
            QuestionLabel.Text = quest.Question;
        }
        
        //TODO: поправить расположение матриц
        private void ThirdQuest()
        {
            pressed = false;
            SetQuestionText("");
            layoutQuest.Visibility = LayoutVisibility.Always;
            layoutYesNo.Visibility = LayoutVisibility.Never;

            CaclThread = new Thread(RunThird) { IsBackground = true };
            CaclThread.Start();
        }

        //TODO: настройка инициализации матриц
        private void MatrixMultiplyForm_Load(object sender, EventArgs e)
        {
            SetupMatrix();   
            // запуск квеста про возможность перемножения
            // нужно передать ответ, можно ли создать.
            bool answ = true;
            FirstQuest(answ);
           // CaclThread1.Join();          
        }

        //private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        //{
        //    if (e.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)

        //        e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
        //}
        
        // запускает в потоке (собственно сам процесс перемножения)
        //TODO: Сейчас может вылетать, если матрицы не могут быть перемножены.Нужно выполнять только если матицы м.б. перемножены
        void RunThird()
        {
           var res =  _logic.MatrixMult(_matrix1, _matrix2);
            if (res == null)
            {
                MessageBox.Show("Упс, ошибочка. Матрица не считается");
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

            // TODO: заполнение матрицы ответом (вместо закомментированого)
            //_matrixMultiplyAdapter.FillResultCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            //MessageBox.Show("Правильно!")
             SetQuestionText("");
            this.questionControl.CleanAnswer();
            
            pressed = false;
        }

        public void YesButton_Clicked(object sender, EventArgs e)
        {
            if (quest.CheckAnswer("True"))
            {
                MessageBox.Show("Правильно");
                ThirdQuest();
            }
            else
            {
                MessageBox.Show("Не правильно");
            }
        }

        private void NoButton_Clicked(object sender, EventArgs e)
        {
            if (quest.CheckAnswer("False"))
            {
                MessageBox.Show("Правильно");
                ThirdQuest();
            }
            else
            {
                MessageBox.Show("Не правильно");
            }
        }

        public void AnswerButton_Clicked(object sender, EventArgs e)
        {
            // Действия при нажатии ответ
            if (!quest.CheckAnswer(questionControl.GetAnswer()))
            {
                MessageBox.Show("Не правильно!");
                return;
            }
            MessageBox.Show("Правильно!Молодец!");
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
            //TODO: Добавить заполнение матрицы
            //_matrixMultiplyAdapter.FillResultCell(e.Coord.X,e.Coord.Y,e.Value);
        }
    }
}