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
    public partial class TransportTaskForm : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SetQuestionCallback(string text);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;

        private int NumberOfFails = 0;
   
        private readonly TransportTask _logic;
        private int _numberOfGivers, _numberOfTakers;
        private int[] _needsOfGivers, _needsOfTakers;
        private Matrix _pricesMatrix;

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

        public TransportTaskForm(string language)
        {
            _language = language;
            text = File.ReadAllLines(path + _language + @"\matrix_mult\text.txt", Encoding.Default);
            buttons_text = File.ReadAllLines(path + _language + @"\matrix_mult\buttons_text.txt", Encoding.Default);

            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
          
            _questHandler = new QuestEvents.QuestEventHandler(QuestEventHandler);
            _fillHandler = new FillEvents.FillEventHandler(FillEventHandler);

            // TODO: Добавить содание логики + добавление в обработчиков логики
            _logic = new TransportTask(_numberOfGivers, _numberOfTakers, _needsOfGivers, _needsOfTakers, _pricesMatrix);
            //_logic.questEvent += _questHandler;
            //_logic.fillEvent += _fillHandler;

        }

        private void TransportTaskForm_Load(object sender, EventArgs e)
        {
            // TODO: переделать настройку матрицы, для транспортной задачи
            SetupTransportTask();

            //TODO: при генерации таблицы нужно подготовить ответ к первому тесту
            bool answ = false;

            int giversSum = 0, takersSum = 0;
            for (int i = 0; i < _numberOfGivers; i++)
                giversSum += _needsOfGivers[i];
            for (int i = 0; i < _numberOfTakers; i++)
                takersSum += _needsOfTakers[i];

            if (giversSum == takersSum)
                answ = true;
            else
                answ = false;

            // Запуск первого уровня
            Quest1(answ);
        }
      
        private void SetupTransportTask()
        {
            var random = new Random();
            _numberOfGivers = TransportTask.GetGiversTakers(3, 7)[0];
            _numberOfTakers = TransportTask.GetGiversTakers(3, 7)[1];

            _needsOfGivers = TransportTask.GetRandomNeeds(_numberOfGivers, _numberOfTakers)[0];
            _needsOfTakers = TransportTask.GetRandomNeeds(_numberOfGivers, _numberOfTakers)[1];
            
            _pricesMatrix = new Matrix(_numberOfGivers, _numberOfTakers, 1, 9);
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

        // TODO: переделать первый квест - замкнутая или нет задача? 
        private void Quest1(bool answ)
        {
            throw new NotImplementedException("Вопрос о запкнутости не реализован");
            //questionControlBase = new TwoVariantsQuestionControl();
            //SetQuestControlEventHandler();
            //questionControlBase.SetAnswer(answ.ToString());
            //InitQuestComponent();
            //pressed = false;
            //quest = new YesNoQuest("first", text[0], answ);
            //QuestionLabel.Text = quest.Question;
        }

        // TODO: переделать второй квест - что добавить для замкнутости? 
        private void Quest2(bool answ)
        {
            throw new NotImplementedException("Вопрос о запкнутости не реализован");
            //questionControlBase = new TwoVariantsQuestionControl();
            //SetQuestControlEventHandler();
            //questionControlBase.SetAnswer(answ.ToString());
            //InitQuestComponent();
            //pressed = false;
            //quest = new YesNoQuest("first", text[0], answ);
            //QuestionLabel.Text = quest.Question;
        }

        // TODO: переделать третий квест - Северозападный угол? 
        private void Quest3()
        {
            throw new NotImplementedException("Вопрос о С-З не добавлен");
            //questionControlBase = new SizeQuestionControl();
            //SetQuestControlEventHandler();
            //questionControlBase.SetAnswer(answ);
            //InitQuestComponent();
            //pressed = false;
            //quest = new IntegerIntegerValueQuest("second", text[1], answ);
            //QuestionLabel.Text = quest.Question;
        }
        // TODO: переделать 4-й квест - Сам алгоритм 
        private void Quest4()
        {
            throw new NotImplementedException("Оставшееся решение транспортной задачи");
            //questionControlBase = new QuestionControl();
            //SetQuestControlEventHandler();
            //InitQuestComponent();
            //pressed = false;
            //SetupResultMatrix();
            //SetQuestionText(" ");
            //CaclThread = new Thread(RunThird) { IsBackground = true };
            //CaclThread.Start();
        }

        // запускает в потоке (собственно сам процесс перемножения)
        void RunThird()
        {
           //var res = _logic.MatrixMult(_matrix1, _matrix2);
           //if (res == null)
           // {
           //     ChangeAndAwait(QuestionLabel, text[2], sleepTime);
           // }
           // else
           // {
           //     ChangeAndAwait(QuestionLabel, text[3], sleepTime);
           //     DialogResult = DialogResult.Cancel;
           // }
        }

        // TODO: Проверить обработчики, если нужно переделать
        // обработка вычислений
        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            SetQuestionText(e.Quest.Question + "\r\n" + "Ответ: " + e.Quest.Answer);
            quest = e.Quest;
            questionControlBase.SetAnswer(e.Quest.Answer);
            x = e.Coord.X;
            y = e.Coord.Y;
            questionControlBase.SetFocus();
            while (!pressed)
            {
                System.Threading.Thread.Sleep(100);
            }
            
            MatrFillCell(e.Coord.X, e.Coord.Y, e.Quest.Answer);
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
            MatrFillCell(e.Coord.X, e.Coord.Y, e.Value);
        }

        // заполнение результирующей матрицы
        private void MatrFillCell(int row, int col, string value)
        {
            try
            {
                matrixGridView1[col - 1, row - 1].Value = value;
                matrixGridView1.Refresh();

            }
            catch (Exception e)
            {
                var ex = e;
            }
        }
        
        // TODO: Добавит вызовы квестов
        // обработка правильный ответов
        public void GoodAnswer_Send(object sender, EventArgs e)
        {
            switch (questState)
            {
                case 1:
                    ChangeAndAwait(QuestionLabel, text[5], sleepTime);
                    
                    pressed = true;
                    questState = 2;
                    //Quest2(...);
                    questionControlBase.SetFocus();
                    return;
                case 2:
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    pressed = true;
                    questState = 3;
                    questionControlBase.SetFocus();
                    //Quest3();
                    return;
                case 3:
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    pressed = true;
                    questState = 4;
                    questionControlBase.SetFocus();
                    //Quest4();
                    return;
                case 4:
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    NumberOfFails = 0;
                    pressed = true;
                    return;
            }
        }

        // TODO: ПОправить обработку неправильных ответов
        // Обработка не правильных ответов
        public void BadAnswer_Send(object sender, EventArgs e)
        {
            questionControlBase.SetFocus();
            switch (questState)
            {
                case 1:
                    ChangeAndAwait(QuestionLabel, text[6], sleepTime);
                    //SetupMatrix();
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
                        throw new NotImplementedException("Подсказка 1 не реализована");
                    }
                    if (NumberOfFails == 2)
                    {
                        throw new NotImplementedException("Подсказка 2 не реализована");
                    }
                    if (NumberOfFails == 3)
                    {
                        throw new NotImplementedException("Подсказка 4 не реализована");
                    }
                    if (NumberOfFails == 4)
                    {
                        ChangeAndAwait(QuestionLabel, "Дружок, всё плохо! Посмотри обучение ещё раз.", 2500); 
                        this.Close();
                    }
                    return;
                case 4:
                    ChangeAndAwait(QuestionLabel, "Не правильно! Будь внимательнее!", sleepTime);
                    QuestionLabel.Text = quest.Question;
                    questionControlBase.ClearControl();
                    NumberOfFails++;
                    if (NumberOfFails > 0)
                    {
                        throw new NotImplementedException("Подсказка 1 не реализована");
                    }
                    if (NumberOfFails == 2)
                    {
                        throw new NotImplementedException("Подсказка 2 не реализована");
                    }
                    if (NumberOfFails == 3)
                    {
                        throw new NotImplementedException("Подсказка 4 не реализована");
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

        private string[][] IntToString(int[][] values, int rows, int cols)
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
    }
}