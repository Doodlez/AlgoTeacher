using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;
using AlgoTeacher.Properties;

namespace AlgoTeacher
{
    public partial class MainForm : Form
    {
        public IntroForm IntroForm;
        public InformationForm InformationForm;
        public MyTask MyTask;
        private string _language;
        private LanguageForm _languageForm;

        const string Path = @"..\..\Questions\";
        private string Dir;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _languageForm = new LanguageForm();
            _languageForm.ShowDialog();

            _language = _languageForm.SelectedLanguage;

            //string introText = File.ReadAllText(Path + _language + @"\intro_form\intro_text.txt", Encoding.Default);
            //string[] introButtonsText = File.ReadAllLines(Path + _language + @"\intro_form\intro_form_buttons.txt", Encoding.Default);
            //string[] infoButtonsText = File.ReadAllLines(Path + _language + @"\info_form\info_form_buttons.txt", Encoding.Default);
            //string[] infoButtonNoText = File.ReadAllLines(Path + _language + @"\info_form\info_form_no_button.txt", Encoding.Default);
            //List<string> helpsText = new List<string>();
            //var helpsText1 = File.ReadAllText(Path + _language + @"\helps_text_1.txt", Encoding.Default);
            //var helpsText2 = File.ReadAllText(Path + _language + @"\helps_text_2.txt", Encoding.Default);
            //var helpsText3 = File.ReadAllText(Path + _language + @"\helps_text_3.txt", Encoding.Default);
            //helpsText.Add(helpsText1);
            //helpsText.Add(helpsText2);
            //helpsText.Add(helpsText3);

            //TaskHelp testHelp = new TaskHelp("test", helpsText);
            var taskNames = File.ReadAllLines(Path + _language + @"\task_names.txt", Encoding.Default);
            //MyTask testTask = new MyTask(taskNames[0], typeof(MatrixMultiplyForm), _language, introText, introButtonsText, infoButtonsText, infoButtonNoText, testHelp);
            //MyTask testTask2 = new MyTask(taskNames[1], typeof(KnapsackProblemForm), _language, introText, introButtonsText, infoButtonsText, infoButtonNoText, testHelp);

            //TaskCollection tasks = new TaskCollection(testTask);
            //TaskCollection tasks2 = new TaskCollection(testTask2);

            TaskComboBox.Properties.Items.Add(taskNames[0]);
            TaskComboBox.Properties.Items.Add(taskNames[1]);

            var mainFormText = File.ReadAllLines(Path + _language + @"\main_form\main_form_text.txt", Encoding.Default);
            GreetingControl.Text = mainFormText[0];
            StartButton.Text = mainFormText[1];
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.Properties.Items.Count != 0)
            {
                switch (TaskComboBox.SelectedIndex)
                {
                    case 0:
                        Dir = "matrix_mult_form";
                        break;

                    case 1:
                        Dir = "knapsack_problem_form";
                        break;
                }

                string introText = File.ReadAllText(Path + _language + @"\intro_form\" + Dir + @"\intro_text.txt", Encoding.Default);
                string[] introButtonsText = File.ReadAllLines(Path + _language + @"\intro_form\intro_form_buttons.txt", Encoding.Default);
                string[] infoButtonsText = File.ReadAllLines(Path + _language + @"\info_form\info_form_buttons.txt", Encoding.Default);
                string[] infoButtonNoText = File.ReadAllLines(Path + _language + @"\info_form\info_form_no_button.txt", Encoding.Default);
                List<string> helpsText = new List<string>();
                var helpsText1 = File.ReadAllText(Path + _language + @"\" + Dir + @"\helps_text_1.txt", Encoding.Default);
                var helpsText2 = File.ReadAllText(Path + _language + @"\" + Dir + @"\helps_text_2.txt", Encoding.Default);
                var helpsText3 = File.ReadAllText(Path + _language + @"\" + Dir + @"\helps_text_3.txt", Encoding.Default);
                helpsText.Add(helpsText1);
                helpsText.Add(helpsText2);
                helpsText.Add(helpsText3);

                TaskHelp testHelp = new TaskHelp("test", helpsText);
                var taskNames = File.ReadAllLines(Path + _language + @"\task_names.txt", Encoding.Default);
                var testTasks = new MyTask[2];
                testTasks[0] = new MyTask(taskNames[0], typeof(MatrixMultiplyForm), _language, introText, introButtonsText, infoButtonsText, infoButtonNoText, testHelp);
                testTasks[1] = new MyTask(taskNames[1], typeof(KnapsackProblemForm), _language, introText, introButtonsText, infoButtonsText, infoButtonNoText, testHelp);

                TaskCollection tasks = new TaskCollection(testTasks[0]);
                TaskCollection tasks2 = new TaskCollection(testTasks[1]);

                var mainFormText = File.ReadAllLines(Path + _language + @"\main_form\main_form_text.txt", Encoding.Default);
                GreetingControl.Text = mainFormText[0];
                StartButton.Text = mainFormText[1];

                this.Hide();
                MyTask selectedTask = testTasks[TaskComboBox.SelectedIndex];
                selectedTask.ShowIntro();
                this.Show();
            }
        }
    }
}
