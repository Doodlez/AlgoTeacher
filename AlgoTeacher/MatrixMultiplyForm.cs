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

namespace AlgoTeacher
{
    public partial class MatrixMultiplyForm : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SetQuestionCallback(string text);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;


        private int NumberOfFails = 0;
   
        private readonly MatrixMultiply _logic;
        private MyMatrix _matrix1;
        private MyMatrix _matrix2;

        private MyMatrix _myMatrixRes;
        public DataTable resTab;

        private Thread CaclThread;

        private bool pressed = false;

        private IQuest quest;

        private string _language;
        private string path = @"..\..\Questions\";
        private string[] text;
        private string[] buttons_text;

        private int questState = 1;

        private int x, y;

        private int sleepTime = 1000;

        public MatrixMultiplyForm(string language)
        {
            _language = language;
            text = File.ReadAllLines(path + _language + @"\transport_task\text.txt", Encoding.Default);
            buttons_text = File.ReadAllLines(path + _language + @"\transport_task\buttons_text.txt", Encoding.Default);

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
        private string GetFormula(int n)
        {
            string result = "C" + x.ToString() + y.ToString() + " = ";
            for (int i = 1; i <= n; i++)
            {
                result += "A" + x.ToString() + i.ToString();
                result += " * ";
                result += "B" + i.ToString() + y.ToString();
                if (i != n) result += " + ";
            }
            return result;
        }

        // Третий уровень помощи
        private string GetExtendedFormula(MyMatrix matrix1, MyMatrix matrix2)
        {
            string result = "C" + x.ToString() + y.ToString() + " = ";
            for (int i = 1; i <= matrix1.ColumnsCount; i++)
            {
                result += matrix1.Values[x - 1][i - 1].ToString();
                result += " * ";
                result += matrix2.Values[i - 1][y - 1].ToString();
                if (i != matrix1.ColumnsCount) result += " + ";
            }
            return result;
        }

        // генерация размерности и рандомная генерация значений матриц
        private void SetupMatrix()
        {
            _matrix1 = new MyMatrix();
            Thread.Sleep(100);
            _matrix2 = new MyMatrix();

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
            _myMatrixRes = new MyMatrix(_matrix1.RowsCount, _matrix2.ColumnsCount);
            matrixGridView3.AddValues(EmptyStringArray(_myMatrixRes.RowsCount, _myMatrixRes.ColumnsCount), 
                _myMatrixRes.RowsCount, _myMatrixRes.ColumnsCount);
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
            questionControlBase = new TwoVariantsQuestionControl();
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
                ChangeAndAwait(QuestionLabel, text[2], sleepTime);
            }
            else
            {
                ChangeAndAwait(QuestionLabel, text[3], sleepTime);
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
            matrixGridView3.HighlightCell(e.Coord.X, e.Coord.Y);
            questionControlBase.SetFocus();
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }
            
            ResultMatrFillCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
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
                    ChangeAndAwait(QuestionLabel, text[5], sleepTime);
                    
                    pressed = true;
                    questState = 2;
                    while (_matrix1.ColumnsCount != _matrix2.RowsCount)
                    {
                        SetupMatrix();
                    }
                    SecondQuest(_matrix1.RowsCount + ", " + _matrix2.ColumnsCount);
                    questionControlBase.SetFocus();
                    return;
                case 2:
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    pressed = true;
                    questState = 3;
                    questionControlBase.SetFocus();
                    ThirdQuest();
                    return;
                case 3:
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    NumberOfFails = 0;
                    pressed = true;
                    return;
            }
        }

        // Обработка не правильных ответов
        public void BadAnswer_Send(object sender, EventArgs e)
        {
            questionControlBase.SetFocus();
            switch (questState)
            {
                case 1:
                    ChangeAndAwait(QuestionLabel, text[6], sleepTime);
                    SetupMatrix();
                    return;
                case 2:
                    ChangeAndAwait(QuestionLabel, "Не правильно!", sleepTime);
                    questionControlBase.ClearControl();
                    QuestionLabel.Text = quest.Question;
                    return;
                case 3:
                    ChangeAndAwait(QuestionLabel, "Не правильно! Будь внимательнее!", sleepTime);
                    QuestionLabel.Text = quest.Question;
                    questionControlBase.ClearControl();
                    NumberOfFails++;
                    if (NumberOfFails > 0)
                    {
                        matrixGridView1.HighlightRow(x);
                        matrixGridView2.HighlightColumn(y);
                    }
                    if (NumberOfFails == 2)
                    {
                        QuestionLabel.Text = "Смотри, чтобы получить элемент " +
                                             "(" + x.ToString() + "," + y.ToString() + ") \r\n" +
                                             " воспользуйся формулой: \r\n" + GetFormula(_matrix1.ColumnsCount);
                        QuestionLabel.Update();
                    }
                    if (NumberOfFails == 3)
                    {
                        QuestionLabel.Text = "Внимательнее, в данном случае элемент " +
                                             "(" + x.ToString() + "," + y.ToString() + ") \r\n" +
                                             " получается следующим образом: \r\n" + GetExtendedFormula(_matrix1,_matrix2);
                        QuestionLabel.Update();
                    }
                    if (NumberOfFails == 4)
                    {
                        ChangeAndAwait(QuestionLabel, "Дружок, всё плохо! Посмотри обучение ещё раз.", 2500); 
                        this.Close();
                    }
                    return;
            }
        }

        private void ChangeAndAwait(Control control, string str, int time)
        {
            Invoke((Action)(() => { control.Text = str; control.Update();}));
            System.Threading.Thread.Sleep(time);
        }

        private void ViewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}