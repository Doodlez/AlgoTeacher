using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AlgoTeacher
{
    public partial class KnapsackProblemForm : DevExpress.XtraEditors.XtraForm
    {
        private string _language;

        public KnapsackProblemForm(string language)
        {
            InitializeComponent();
            _language = language;
        }
    }
}