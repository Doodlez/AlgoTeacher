namespace UserControls
{
    partial class CoordinateIntegerQuestionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.AnswerTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AnswerButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.XTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.YTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.YTextEdit);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.XTextEdit);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.AnswerTextEdit);
            this.layoutControl1.Controls.Add(this.AnswerButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.layoutControl1.Location = new System.Drawing.Point(-8, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1549, 556, 246, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(358, 201);
            this.layoutControl1.TabIndex = 8;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // AnswerTextEdit
            // 
            this.AnswerTextEdit.Location = new System.Drawing.Point(12, 114);
            this.AnswerTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AnswerTextEdit.MinimumSize = new System.Drawing.Size(35, 39);
            this.AnswerTextEdit.Name = "AnswerTextEdit";
            this.AnswerTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerTextEdit.Properties.Appearance.Options.UseFont = true;
            this.AnswerTextEdit.Properties.AutoHeight = false;
            this.AnswerTextEdit.Size = new System.Drawing.Size(334, 39);
            this.AnswerTextEdit.StyleController = this.layoutControl1;
            this.AnswerTextEdit.TabIndex = 5;
            this.AnswerTextEdit.EditValueChanged += new System.EventHandler(this.AnswerTextEdit_EditValueChanged);
            // 
            // AnswerButton
            // 
            this.AnswerButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerButton.Appearance.Options.UseFont = true;
            this.AnswerButton.Location = new System.Drawing.Point(12, 157);
            this.AnswerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AnswerButton.MinimumSize = new System.Drawing.Size(35, 32);
            this.AnswerButton.Name = "AnswerButton";
            this.AnswerButton.Size = new System.Drawing.Size(334, 32);
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
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(358, 201);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.AnswerTextEdit;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(338, 43);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(60, 43);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(338, 43);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.AnswerButton;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 145);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(60, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(338, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(338, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(60, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(338, 64);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Location = new System.Drawing.Point(12, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 24);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "X";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(16, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // XTextEdit
            // 
            this.XTextEdit.Location = new System.Drawing.Point(28, 76);
            this.XTextEdit.Name = "XTextEdit";
            this.XTextEdit.Size = new System.Drawing.Size(157, 22);
            this.XTextEdit.StyleController = this.layoutControl1;
            this.XTextEdit.TabIndex = 8;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.XTextEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(16, 64);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(161, 28);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(177, 64);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(18, 28);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Location = new System.Drawing.Point(207, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 24);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Y";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl2;
            this.layoutControlItem5.Location = new System.Drawing.Point(195, 64);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(16, 28);
            this.layoutControlItem5.Text = "Y";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // YTextEdit
            // 
            this.YTextEdit.Location = new System.Drawing.Point(223, 76);
            this.YTextEdit.Name = "YTextEdit";
            this.YTextEdit.Size = new System.Drawing.Size(123, 22);
            this.YTextEdit.StyleController = this.layoutControl1;
            this.YTextEdit.TabIndex = 10;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.YTextEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(211, 64);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(127, 28);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 92);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(338, 10);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CoordinateIntegerQuestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Location = new System.Drawing.Point(70, 20);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(54, 122);
            this.Name = "CoordinateIntegerQuestionControl";
            this.Size = new System.Drawing.Size(350, 201);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnswerTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton AnswerButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit AnswerTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit YTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit XTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}
