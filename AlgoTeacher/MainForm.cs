using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Interface;
using AlgoTeacher.Logic;

namespace AlgoTeacher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MyTask testTask = new MyTask("Test", typeof(MatrixMultiplyForm));

            TaskCollection tasks = new TaskCollection(testTask);

            TaskComboBox.Properties.Items.Add(tasks[0]);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.Properties.Items.Count != 0)
            {
                MyTask selectTask = (MyTask)TaskComboBox.EditValue;
                selectTask.ShowForm();
            }
        }
    }
}
