namespace UserControls
{
    partial class SizeQuestionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ColumnsTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RowsTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AnswerButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ColumnsTextEdit);
            this.layoutControl1.Controls.Add(this.RowsTextEdit);
            this.layoutControl1.Controls.Add(this.AnswerButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(825, 232, 246, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(281, 170);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ColumnsTextEdit
            // 
            this.ColumnsTextEdit.Location = new System.Drawing.Point(108, 84);
            this.ColumnsTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ColumnsTextEdit.MaximumSize = new System.Drawing.Size(0, 39);
            this.ColumnsTextEdit.MinimumSize = new System.Drawing.Size(31, 39);
            this.ColumnsTextEdit.Name = "ColumnsTextEdit";
            this.ColumnsTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColumnsTextEdit.Properties.Appearance.Options.UseFont = true;
            this.ColumnsTextEdit.Properties.AutoHeight = false;
            this.ColumnsTextEdit.Size = new System.Drawing.Size(140, 39);
            this.ColumnsTextEdit.StyleController = this.layoutControl1;
            this.ColumnsTextEdit.TabIndex = 8;
            // 
            // RowsTextEdit
            // 
            this.RowsTextEdit.Location = new System.Drawing.Point(108, 36);
            this.RowsTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowsTextEdit.MaximumSize = new System.Drawing.Size(0, 39);
            this.RowsTextEdit.MinimumSize = new System.Drawing.Size(31, 39);
            this.RowsTextEdit.Name = "RowsTextEdit";
            this.RowsTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RowsTextEdit.Properties.Appearance.Options.UseFont = true;
            this.RowsTextEdit.Properties.AutoHeight = false;
            this.RowsTextEdit.Size = new System.Drawing.Size(140, 39);
            this.RowsTextEdit.StyleController = this.layoutControl1;
            this.RowsTextEdit.TabIndex = 5;
            // 
            // AnswerButton
            // 
            this.AnswerButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerButton.Appearance.Options.UseFont = true;
            this.AnswerButton.Location = new System.Drawing.Point(12, 127);
            this.AnswerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AnswerButton.MinimumSize = new System.Drawing.Size(31, 32);
            this.AnswerButton.Name = "AnswerButton";
            this.AnswerButton.Size = new System.Drawing.Size(236, 32);
            this.AnswerButton.StyleController = this.layoutControl1;
            this.AnswerButton.TabIndex = 6;
            this.AnswerButton.Text = "Ответ";
            this.AnswerButton.Click += new System.EventHandler(this.AnswerButton_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(260, 171);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.RowsTextEdit;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem1.CustomizationFormText = "Число строк";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 48);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(1, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(240, 48);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Число строк";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(240, 24);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.AnswerButton;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(1, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(240, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ColumnsTextEdit;
            this.layoutControlItem4.CustomizationFormText = "Число столбцов";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(240, 43);
            this.layoutControlItem4.Text = "Число столбцов";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 16);
            // 
            // SecondStageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SecondStageControl";
            this.Size = new System.Drawing.Size(281, 170);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit RowsTextEdit;
        private DevExpress.XtraEditors.SimpleButton AnswerButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit ColumnsTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
