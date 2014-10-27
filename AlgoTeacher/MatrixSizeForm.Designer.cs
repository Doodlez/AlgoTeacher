namespace AlgoTeacher
{
    partial class MatrixSizeForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxRows1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxColumns1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxRows2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxColumns2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ReadyButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRows1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxColumns1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRows2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxColumns2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Location = new System.Drawing.Point(79, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(302, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Выберите размерности исходных матриц";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Location = new System.Drawing.Point(22, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "1-я матрица";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(22, 198);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "2-я матрица";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl4.Location = new System.Drawing.Point(137, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Число строк";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Location = new System.Drawing.Point(281, 89);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(110, 18);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Число столбцов";
            // 
            // comboBoxRows1
            // 
            this.comboBoxRows1.Location = new System.Drawing.Point(137, 139);
            this.comboBoxRows1.Name = "comboBoxRows1";
            this.comboBoxRows1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxRows1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxRows1.TabIndex = 5;
            // 
            // comboBoxColumns1
            // 
            this.comboBoxColumns1.Location = new System.Drawing.Point(281, 139);
            this.comboBoxColumns1.Name = "comboBoxColumns1";
            this.comboBoxColumns1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxColumns1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxColumns1.TabIndex = 6;
            // 
            // comboBoxRows2
            // 
            this.comboBoxRows2.Location = new System.Drawing.Point(137, 199);
            this.comboBoxRows2.Name = "comboBoxRows2";
            this.comboBoxRows2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxRows2.Size = new System.Drawing.Size(100, 20);
            this.comboBoxRows2.TabIndex = 7;
            // 
            // comboBoxColumns2
            // 
            this.comboBoxColumns2.Location = new System.Drawing.Point(281, 196);
            this.comboBoxColumns2.Name = "comboBoxColumns2";
            this.comboBoxColumns2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxColumns2.Size = new System.Drawing.Size(100, 20);
            this.comboBoxColumns2.TabIndex = 8;
            // 
            // ReadyButton
            // 
            this.ReadyButton.Location = new System.Drawing.Point(209, 257);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(100, 34);
            this.ReadyButton.TabIndex = 9;
            this.ReadyButton.Text = "Готово";
            this.ReadyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // MatrixSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 324);
            this.Controls.Add(this.ReadyButton);
            this.Controls.Add(this.comboBoxColumns2);
            this.Controls.Add(this.comboBoxRows2);
            this.Controls.Add(this.comboBoxColumns1);
            this.Controls.Add(this.comboBoxRows1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "MatrixSizeForm";
            this.Text = "MatrixSizeForm";
            this.Load += new System.EventHandler(this.MatrixSizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRows1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxColumns1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxRows2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxColumns2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxRows1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxColumns1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxRows2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxColumns2;
        private DevExpress.XtraEditors.SimpleButton ReadyButton;
    }
}