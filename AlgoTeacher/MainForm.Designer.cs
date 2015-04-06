namespace AlgoTeacher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.GreetingControl = new DevExpress.XtraEditors.LabelControl();
            this.StartButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TaskComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskComboBox
            // 
            this.TaskComboBox.Location = new System.Drawing.Point(352, 223);
            this.TaskComboBox.Name = "TaskComboBox";
            this.TaskComboBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TaskComboBox.Properties.Appearance.Options.UseFont = true;
            this.TaskComboBox.Properties.AutoHeight = false;
            this.TaskComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TaskComboBox.Size = new System.Drawing.Size(266, 35);
            this.TaskComboBox.TabIndex = 0;
            // 
            // GreetingControl
            // 
            this.GreetingControl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GreetingControl.Location = new System.Drawing.Point(130, 100);
            this.GreetingControl.Name = "GreetingControl";
            this.GreetingControl.Size = new System.Drawing.Size(0, 24);
            this.GreetingControl.TabIndex = 1;
            // 
            // StartButton
            // 
            this.StartButton.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Appearance.Options.UseFont = true;
            this.StartButton.Location = new System.Drawing.Point(130, 224);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 30);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 372);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.GreetingControl);
            this.Controls.Add(this.TaskComboBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaskComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit TaskComboBox;
        private DevExpress.XtraEditors.LabelControl GreetingControl;
        private DevExpress.XtraEditors.SimpleButton StartButton;
    }
}

