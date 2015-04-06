namespace AlgoTeacher
{
    partial class LanguageForm
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
            if ( disposing && (components != null) )
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
            this.LanguageLabel = new DevExpress.XtraEditors.LabelControl();
            this.LanguageComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.SelectButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageLabel.Location = new System.Drawing.Point(88, 26);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(230, 24);
            this.LanguageLabel.TabIndex = 0;
            this.LanguageLabel.Text = "Choose language, please:";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.Location = new System.Drawing.Point(88, 72);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LanguageComboBox.Size = new System.Drawing.Size(230, 22);
            this.LanguageComboBox.TabIndex = 1;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(366, 71);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(100, 23);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 130);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.LanguageLabel);
            this.Name = "LanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanguageForm";
            this.Load += new System.EventHandler(this.LanguageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LanguageComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl LanguageLabel;
        private DevExpress.XtraEditors.ComboBoxEdit LanguageComboBox;
        private DevExpress.XtraEditors.SimpleButton SelectButton;
    }
}