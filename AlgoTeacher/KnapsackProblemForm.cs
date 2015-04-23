using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoTeacher.Logic;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class KnapsackProblemForm : DevExpress.XtraEditors.XtraForm
    {
        private string _language;
        private readonly KnapsackProblem _logic;
        private string path = @"..\..\Questions\";
        private string[] text;

        public KnapsackProblemForm(string language)
        {
            InitializeComponent();
            _language = language;
            _logic = new KnapsackProblem();
            
            text = File.ReadAllLines(path + _language + @"\knapsack_problem_form\form_text.txt", Encoding.Default);
            this.CapacityNameLabel.Text = text[0];
            this.WeightLabel.Text = text[1];
            this.ValueLabel.Text = text[2];
            this.AnswerLabel.Text = text[3];
        }

        private void KnapsackProblemForm_Load(object sender, EventArgs e)
        {
            _logic.MakeRandomWeights();
            _logic.MakeRandomValues();

            this.Thing1Weight.Text = _logic.Weights[0].ToString();
            this.Thing2Weight.Text = _logic.Weights[1].ToString();
            this.Thing3Weight.Text = _logic.Weights[2].ToString();

            this.Thing1Value.Text = _logic.Values[0].ToString();
            this.Thing2Value.Text = _logic.Values[1].ToString();
            this.Thing3Value.Text = _logic.Values[2].ToString();
        }
    }
}