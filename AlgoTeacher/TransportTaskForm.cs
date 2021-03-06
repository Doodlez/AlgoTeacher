﻿using System;
using System.Data;
using System.Drawing;
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
        public delegate void SetCallback();
        private delegate void SetFillMatrCallback(int a, int b, string s);

        private readonly QuestEvents.QuestEventHandler _questHandler;
        private readonly FillEvents.FillEventHandler _fillHandler;

        private int NumberOfFails = 0;
   
        private TransportTask _logic;
        private int _numberOfGivers, _numberOfTakers;
        private int[] _needsOfGivers, _needsOfTakers;
        private MyMatrix _pricesMatrix;

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

            
        }

        private void TransportTaskForm_Load(object sender, EventArgs e)
        {
            SetupTransportTask();

            _logic = new TransportTask(_numberOfGivers, _numberOfTakers, _needsOfGivers, _needsOfTakers, _pricesMatrix, _language);
            _logic.questEvent += _questHandler;
            _logic.fillEvent += _fillHandler;

            // Запуск первого уровня
            Quest1();
        }
      
        private void SetupTransportTask()
        {
            var giversTakers = TransportTask.GetGiversTakers(3, 6);
            _numberOfGivers = giversTakers[0];
            _numberOfTakers = giversTakers[1];

            var needs = TransportTask.GetRandomNeeds(_numberOfGivers, _numberOfTakers);
            _needsOfGivers = needs[0];
            _needsOfTakers = needs[1];
            
            _pricesMatrix = new MyMatrix(_numberOfGivers, _numberOfTakers, 1, 9);
            bool war;
            try
            {
                war = _pricesMatrix.AddRow(_needsOfTakers, _numberOfTakers);
                if (!war)
                {
                    MessageBox.Show("Проблема с добавлением строки");
                    return;
                }
                war = _pricesMatrix.AddColumn(_needsOfGivers, _numberOfGivers);
                if (!war)
                {
                    MessageBox.Show("Проблема с добавлением столбца");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            matrixGridView1.AddValues(IntToString(_pricesMatrix.Values, _pricesMatrix.RowsCount, _pricesMatrix.ColumnsCount),
                _pricesMatrix.RowsCount, _pricesMatrix.ColumnsCount);

            string[][] emptyStrings;
            emptyStrings = new string[_numberOfGivers + 1][];
            for (var i = 0; i < _numberOfGivers + 1; i++)
            {
                emptyStrings[i] = new string[_numberOfTakers + 1];
            }

            matrixGridView2.AddValues(emptyStrings,
                _numberOfGivers + 1, _numberOfTakers + 1);
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
            if (QuestPanel.InvokeRequired || questionControlBase.InvokeRequired)
            {
                SetCallback deleg = new SetCallback(InitQuestComponent);
                this.Invoke(deleg, new object[] {});
            }
            else 
            {
                QuestPanel.Controls.Clear();
                QuestPanel.Controls.Add(questionControlBase);
                questionControlBase.Dock = DockStyle.Fill;
            }
        }

        // TODO: переделать первый квест - North-West
        private void Quest1()
        {
            questionControlBase = new CoordinateIntegerQuestionControl();
            SetQuestControlEventHandler();
            InitQuestComponent();
            pressed = false;
            //QuestionLabel.Text = quest.Question;
            CaclThread = new Thread(RunQuest1)
            {
                IsBackground = true
            };
            CaclThread.Start();
        }

        // TODO: второй квест - ищем элемент с минимальным S
        private void Quest2()
        {
            questionControlBase = new CoordinateIntegerQuestionControl();
            SetQuestControlEventHandler();
            InitQuestComponent();
            pressed = false;
            //QuestionLabel.Text = quest.Question;
            CaclThread = new Thread(RunQuest2)
            {
                IsBackground = true
            };
            CaclThread.Start();
        }

        // TODO: ищем элемент, который выкинем из базиса 
        private void Quest3()
        {
            questionControlBase = new QuestionControlBase();
            SetQuestControlEventHandler();
            InitQuestComponent();
            pressed = false;
            QuestionLabel.Text = quest.Question;
        }
        // TODO: проверить пересчёт базисных значений 
        private void Quest4()
        {
            questionControlBase = new QuestionControlBase();
            SetQuestControlEventHandler();
            InitQuestComponent();
            pressed = false;
            QuestionLabel.Text = quest.Question;
        }

        // запускает в потоке (собственно сам процесс перемножения)
        void RunQuest1()
        {
            _logic.NorthWest();
            Quest2();
        }

        void RunQuest2()
        {
            //_logic.;
            Quest3();
        }

        // TODO: Проверить обработчики, если нужно переделать
        // обработка вычислений
        public void QuestEventHandler(object sender, QuestEvents.QuestEventArgs e)
        {
            quest = e.Quest;       
            x = e.Coord.X;
            y = e.Coord.Y;
            SetQuestionText(e.Quest.Question + "\r\n" + "Ответ: " + e.Quest.Answer + "\r\n" + x + " " + y);

            string answ = x + "," + y + "," + e.Quest.Answer;
            questionControlBase.SetAnswer(answ);
            questionControlBase.SetFocus();
            while (!pressed)
            {
                Thread.Sleep(100);
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
                Thread.Sleep(200);
                t = false;
            }
            MatrFillCell(e.Coord.X, e.Coord.Y, e.Value);
        }

        // заполнение результирующей матрицы
        private void MatrFillCell(int row, int col, string value)
        {
            try
            {

                if ( matrixGridView2.InvokeRequired )
                {
                    SetFillMatrCallback deleg = new SetFillMatrCallback(MatrFillCell);
                    this.Invoke(deleg, new object[] { row, col, value });
                }
                else
                {
                    matrixGridView2[col - 1, row - 1].Value = value;
                    matrixGridView2.Refresh();
                }
               

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
                    ChangeAndAwait(QuestionLabel, "Правильно! Молодец!", sleepTime);
                    NumberOfFails = 0;
                    pressed = true;
                    return;
                    //questionControlBase.SetFocus();
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

        private void matrixGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}