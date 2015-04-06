using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoTeacher
{
    public partial class LanguageForm : Form
    {
        public string SelectedLanguage;

        public LanguageForm()
        {
            InitializeComponent();
        }

        private void LanguageForm_Load(object sender, EventArgs e)
        {
            LanguageComboBox.Properties.Items.Add("Русский");
            LanguageComboBox.Properties.Items.Add("English");
            //LanguageComboBox.Properties.Items.Add("Deutsch");
            //LanguageComboBox.Properties.Items.Add("Français");
            //LanguageComboBox.Properties.Items.Add("Español");
            //LanguageComboBox.Properties.Items.Add("Italiano");
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            var language = LanguageComboBox.SelectedItem.ToString();

            switch ( language )
            {
                case "Русский":
                    SelectedLanguage = "rus";
                    break;
                case "English":
                    SelectedLanguage = "eng";
                    break;
                case "Deutsch":
                    SelectedLanguage = "ger";
                    break;
                case "Français":
                    SelectedLanguage = "fra";
                    break;
                case "Español":
                    SelectedLanguage = "esp";
                    break;
                default:
                    SelectedLanguage = "ita";
                    break;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
