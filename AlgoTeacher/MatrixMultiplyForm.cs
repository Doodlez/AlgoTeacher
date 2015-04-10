using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using AlgoTeacher.Logic.Quest;
using DevExpress.XtraLayout.Utils;
using UserControls;
using System.IO;

// TODO: Выделение матриц при вопросах
// TODO: Поправить переносы строк в вопросах

namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SetQuestionCallback(string text);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;

        private bool FirstAlgoStep = true;
        private int NumberOfFails = 0;
   
        private readonly MatrixMultiply _logic;
        private Matrix _matrix1;
        private Matrix _matrix2;

        private Matrix _matrixRes;
        public DataTable resTab;

        private Thread CaclThread;

        private bool pressed = false;

        private IQuest quest;

        private string _language;
        private string path = @"C:\Users\1234\Documents\Диплом\AlgoTeacher\AlgoTeacher\Questions\";
        private string[] text;
        private string[] buttons_text;

        private int questState = 1;

        private int x, y;

        public MatrixMultiplyForm(string language)
        {
            _language = language;
            text = File.ReadAllLines(path + _language + @"\matrix_mult_form\text.txt", Encoding.Default);
            buttons_text = File.ReadAllLines(path + _language + @"\matrix_mult_form\buttons_text.txt", Encoding.Default);

            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
          
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            _logic = new MatrixMultiply(language);
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;

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
            // Запуск первого уровня
            FirstQuest(answ);
        }
        
        // Ворой уровень помощи
        private string GetFormula()
        {
            string result = "C" + x.ToString() + y.ToString() + " = ";
            for (int i = 1; i <= _matrix1.ColumnsCount; i++)
            {
                result += "A" + x.ToString() + i.ToString();
                result += " * ";
                result += "B" + i.ToString() + y.ToString();
                if (i != _matrix1.ColumnsCount) result += " + ";
            }
            return result;
        }

        // Третий уровень помощи
        private string GetExtendedFormula()
        {
            string result = "C" + x.ToString() + y.ToString() + " = ";
            for (int i = 1; i <= _matrix1.ColumnsCount; i++)
            {
                result += _matrix1.Values[x - 1][i - 1].ToString();
                result += " * ";
                result += _matrix2.Values[i - 1][y - 1].ToString();
                if (i != _matrix1.ColumnsCount) result += " + ";
            }
            return result;
        }

        // генерация размерности и рандомная генерация значений матриц
        private void SetupMatrix()
        {
            _matrix1 = new Matrix();
            Thread.Sleep(100);
            _matrix2 = new Matrix();

            matrixGridView1.AddValues(IntToString(_matrix1.Values, _matrix1.RowsCount, _matrix1.ColumnsCount), 
                _matrix1.RowsCount, _matrix1.ColumnsCount);
            matrixGridView2.AddValues(IntToString(_matrix2.Values, _matrix2.RowsCount, _matrix2.ColumnsCount), 
                _matrix2.RowsCount, _matrix2.ColumnsCount);
        }

        private string[][] IntToString(int[][] values, int rows,int cols)
        {
            var res = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                res[i] = new string[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res[i][j] = values[i][j].ToString();
                }
            }

            return res;
        }

        private string[][] EmptyStringArray(int rows, int cols)
        {
            var res = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                res[i] = new string[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res[i][j] = " ";
                }
            }

            return res;
        }

        private void SetupResultMatrix()
        {
            // генерация размерности и рандомная генерация значений матриц
            _matrixRes = new Matrix(_matrix1.RowsCount, _matrix2.ColumnsCount);
            matrixGridView3.AddValues(EmptyStringArray(_matrixRes.RowsCount, _matrixRes.ColumnsCount), 
                _matrixRes.RowsCount, _matrixRes.ColumnsCount);
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

        private void SetQuestControlEventHandler()
        {
            var goodAnswerHandler = new QuestionControlBase.GoodAnswerHandler(GoodAnswer_Send);
            questionControlBase.GoodAnswer += goodAnswerHandler;
            var badAnswerHandler = new QuestionControlBase.BadAnswerHandler(BadAnswer_Send);
            questionControlBase.BadAnswer += badAnswerHandler;
        }

        private void InitQuestComponent()
        {
            QuestPanel.Controls.Clear();
            QuestPanel.Controls.Add(questionControlBase);
            questionControlBase.Dock = DockStyle.Fill;
        }

        private void FirstQuest(bool answ)
        {
            questionControlBase = new YesNoQuestionControl();
            SetQuestControlEventHandler();
            questionControlBase.SetAnswer(answ.ToString());
            InitQuestComponent();
            pressed = false;
            quest = new YesNoQuest("first", text[0], answ);
            QuestionLabel.Text = quest.Question;
        }

        private void SecondQuest(string answ)
        {
            questionControlBase = new SizeQuestionControl();
            SetQuestControlEventHandler();
            questionControlBase.SetAnswer(answ);
            InitQuestComponent();
            pressed = false;
            quest = new IntegerIntegerValueQuest("second", text[1], answ);
            QuestionLabel.Text = quest.Question;
        }
        
        private void ThirdQuest()
        {
            questionControlBase = new QuestionControl();
            SetQuestControlEventHandler();
            InitQuestComponent();
            pressed = false;
            SetupResultMatrix();
            SetQuestionText(" ");
            CaclThread = new Thread(RunThird) { IsBackground = true };
            CaclThread.Start();
        }

        // запускает в потоке (собственно сам процесс перемножения)
        void RunThird()
        {
           var res = _logic.MatrixMult(_matrix1, _matrix2);
           if (res == null)
            {
                MessageBox.Show(text[2]);
            }
            else
            {
                MessageBox.Show(text[3]);
                DialogResult = DialogResult.Cancel;
            }
        }

        // обработка вычислений
        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            matrixGridView3.ClearHighlight();
            matrixGridView1.ClearHighlight();
            matrixGridView2.ClearHighlight();
            SetQuestionText(e.Quest.Question + "\r\n" + "Ответ: " + e.Quest.Answer);
            quest = e.Quest;
            questionControlBase.SetAnswer(e.Quest.Answer);
            x = e.Coord.X;
            y = e.Coord.Y;
            if (FirstAlgoStep)
            {
                FirstAlgoStep = false;
                matrixGridView1.HighlightRow(e.Coord.X);
                matrixGridView2.HighlightColumn(e.Coord.Y);
            }
            matrixGridView3.HighlightCell(e.Coord.X, e.Coord.Y);
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }
            
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
            //MessageBox.Show(text[4]);
            SetQuestionText(" ");

            this.questionControlBase.ClearControl();
            
            pressed = false;
        }

        // Обработчик заполнения матрицы
        public void FillEventHandler(object sender, FillEvents.FillEventArgs e)
        {
            // добавлено замедление заполнения
            bool t = true;
            while (t)
            {
                System.Threading.Thread.Sleep(200);
                t = false;
            }
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Value);
        }

        // заполнение результирующей матрицы
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
        
        // обработка правильный ответов
        public void GoodAnswer_Send(object sender, EventArgs e)
        {
            switch (questState)
            {
                case 1:
                    MessageBox.Show(text[5]);
                    questState = 2;
                    while (_matrix1.ColumnsCount != _matrix2.RowsCount)
                    {
                        SetupMatrix();
                    }
                    SecondQuest(_matrix1.RowsCount + ", " + _matrix2.ColumnsCount);
                    return;
                case 2:
                    MessageBox.Show("Правильно! Молодец!");
                    pressed = true;
                    questState = 3;
                    ThirdQuest();
                    return;
                case 3:
                    MessageBox.Show("Правильно! Молодец!");
                    NumberOfFails = 0;
                    pressed = true;
                    return;
            }
        }

        // Обработка не правильных ответов
        public void BadAnswer_Send(object sender, EventArgs e)
        {
            switch (questState)
            {
                case 1:
                    MessageBox.Show(text[6]);
                    SetupMatrix();
                    return;
                case 2:
                    MessageBox.Show("Не правильно!");
                    return;
                case 3:
                    MessageBox.Show("Не правильно! Будь внимательнее!");
                    NumberOfFails++;
                    if (NumberOfFails > 0)
                    {
                        matrixGridView1.HighlightRow(x);
                        matrixGridView2.HighlightColumn(y);
                    }
                    return;
            }
        }
    }
}