using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class YesNoQuestionControl : DevExpress.XtraEditors.XtraUserControl
    {
        public YesNoQuestionControl()
        {
            InitializeComponent();
        }

        public delegate void YesClickedHandler(object sender, EventArgs e);
        public event YesClickedHandler YesClicked;

        public delegate void NoClickedHandler(object sender, EventArgs e);
        public event NoClickedHandler NoClicked;

        private delegate void SetTextCallback(string text1);
        private delegate void SetCleanCallback();

        public bool YesButtonEnabled
        {
            get { return YesButton.Enabled; }
            set { YesButton.Enabled = value; }
        }

        public bool NoButtonEnabled
        {
            get { return NoButton.Enabled; }
            set { NoButton.Enabled = value; }
        }

        protected virtual void OnNoButtonClicked(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (NoClicked != null)
            {
                NoClicked(sender, e);  
            }
        }

        public void SetYesButtonTextLabel(string value)
        {
            if (this.YesButton.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetYesButtonTextLabel);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                YesButton.Text = value;
            }
        }

        public void SetNoButtonTextLabel(string value)
        {
            if (this.YesButton.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetNoButtonTextLabel);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                NoButton.Text = value;
            }
        }

        protected virtual void OnYesClicked(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (YesClicked != null)
            {
                YesClicked(sender, e);
            }
        }

        protected virtual void OnNoClicked(object sender, EventArgs e)
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (NoClicked != null)
            {
                NoClicked(sender, e);
            }
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            OnYesClicked(sender, e);
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            OnNoClicked(sender, e);
        }
    }
}