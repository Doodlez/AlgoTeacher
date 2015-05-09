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
using DevExpress.XtraEditors.Controls;

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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _languageForm = new LanguageForm();
            _languageForm.ShowDialog();

            _language = _languageForm.SelectedLanguage;
            var taskNames = File.ReadAllLines(Path + _language + @"\task_names.txt", Encoding.Default);

            TaskComboBox.Properties.Items.Add(taskNames[0]);
            TaskComboBox.Properties.Items.Add(taskNames[1]);

            var mainFormText = File.ReadAllLines(Path + _language + @"\main_form\main_form_text.txt", Encoding.Default);
            GreetingControl.Text = mainFormText[0];
            StartButton.Text = mainFormText[1];
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.SelectedIndex < 0)
            {
                // нужно ли выводить сообщение
                TaskComboBox.Properties.BorderStyle = BorderStyles.Flat;
                TaskComboBox.Properties.Appearance.BorderColor = Color.Red;
                return;
            }
            if (TaskComboBox.Properties.Items.Count != 0)
            {
                var taskNames = File.ReadAllLines(Path + _language + @"\task_names.txt", Encoding.Default);
                var testTasks = new MyTask[2];
                testTasks[0] = new MyTask("matrix_mult", taskNames[0], typeof(MatrixMultiplyForm), _language);
                testTasks[1] = new MyTask("knapsack_problem", taskNames[1], typeof(KnapsackProblemForm), _language);


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

        private void TaskComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TaskComboBox.SelectedIndex >= 0)
            {
                TaskComboBox.Properties.BorderStyle = BorderStyles.NoBorder;
                TaskComboBox.Properties.Appearance.BorderColor = Color.Empty;
            }
        }
    }
}
