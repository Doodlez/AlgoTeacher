using UserControls;

namespace AlgoTeacher
{
    partial class MatrixMultiplyForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ViewPanel = new DevExpress.XtraEditors.PanelControl();
            this.matrixGridView3 = new UserControls.MatrixGridView(this.components);
            this.matrixGridView2 = new UserControls.MatrixGridView(this.components);
            this.matrixGridView1 = new UserControls.MatrixGridView(this.components);
            this.QuestionLabel = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.sizeQuestionControl = new UserControls.SizeQuestionControl();
            this.yesNoQuestionControl = new UserControls.YesNoQuestionControl();
            this.questionControl = new UserControls.QuestionControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutQuest = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutYesNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSecondStage = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).BeginInit();
            this.ViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutQuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutYesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSecondStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.matrixGridView3);
            this.ViewPanel.Controls.Add(this.matrixGridView2);
            this.ViewPanel.Controls.Add(this.matrixGridView1);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(1170, 243);
            this.ViewPanel.TabIndex = 1;
            // 
            // matrixGridView3
            // 
            this.matrixGridView3.AllowUserToAddRows = false;
            this.matrixGridView3.AllowUserToDeleteRows = false;
            this.matrixGridView3.AllowUserToResizeColumns = false;
            this.matrixGridView3.AllowUserToResizeRows = false;
            this.matrixGridView3.BackgroundColor = System.Drawing.Color.White;
            this.matrixGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView3.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView3.DefaultCellStyle = dataGridViewCellStyle1;
            this.matrixGridView3.EnableHeadersVisualStyles = false;
            this.matrixGridView3.GridColor = System.Drawing.Color.White;
            this.matrixGridView3.Location = new System.Drawing.Point(688, 27);
            this.matrixGridView3.Name = "matrixGridView3";
            this.matrixGridView3.ReadOnly = true;
            this.matrixGridView3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView3.RowHeadersVisible = false;
            this.matrixGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView3.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.matrixGridView3.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.matrixGridView3.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.matrixGridView3.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixGridView3.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.matrixGridView3.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.matrixGridView3.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView3.RowTemplate.Height = 50;
            this.matrixGridView3.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView3.Size = new System.Drawing.Size(222, 185);
            this.matrixGridView3.TabIndex = 8;
            // 
            // matrixGridView2
            // 
            this.matrixGridView2.AllowUserToAddRows = false;
            this.matrixGridView2.AllowUserToDeleteRows = false;
            this.matrixGridView2.AllowUserToResizeColumns = false;
            this.matrixGridView2.AllowUserToResizeRows = false;
            this.matrixGridView2.BackgroundColor = System.Drawing.Color.White;
            this.matrixGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView2.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.matrixGridView2.EnableHeadersVisualStyles = false;
            this.matrixGridView2.GridColor = System.Drawing.Color.White;
            this.matrixGridView2.Location = new System.Drawing.Point(334, 27);
            this.matrixGridView2.Name = "matrixGridView2";
            this.matrixGridView2.ReadOnly = true;
            this.matrixGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView2.RowHeadersVisible = false;
            this.matrixGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixGridView2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowTemplate.Height = 50;
            this.matrixGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView2.Size = new System.Drawing.Size(222, 185);
            this.matrixGridView2.TabIndex = 7;
            // 
            // matrixGridView1
            // 
            this.matrixGridView1.AllowUserToAddRows = false;
            this.matrixGridView1.AllowUserToDeleteRows = false;
            this.matrixGridView1.AllowUserToResizeColumns = false;
            this.matrixGridView1.AllowUserToResizeRows = false;
            this.matrixGridView1.BackgroundColor = System.Drawing.Color.White;
            this.matrixGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.matrixGridView1.EnableHeadersVisualStyles = false;
            this.matrixGridView1.GridColor = System.Drawing.Color.White;
            this.matrixGridView1.Location = new System.Drawing.Point(23, 27);
            this.matrixGridView1.Name = "matrixGridView1";
            this.matrixGridView1.ReadOnly = true;
            this.matrixGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView1.RowHeadersVisible = false;
            this.matrixGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowTemplate.Height = 50;
            this.matrixGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView1.Size = new System.Drawing.Size(222, 185);
            this.matrixGridView1.TabIndex = 6;
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QuestionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.QuestionLabel.Location = new System.Drawing.Point(12, 12);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(735, 24);
            this.QuestionLabel.StyleController = this.layoutControl1;
            this.QuestionLabel.TabIndex = 3;
            this.QuestionLabel.Text = "Вопрос";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.sizeQuestionControl);
            this.layoutControl1.Controls.Add(this.yesNoQuestionControl);
            this.layoutControl1.Controls.Add(this.questionControl);
            this.layoutControl1.Controls.Add(this.QuestionLabel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(717, 192, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1166, 308);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // sizeQuestionControl
            // 
            this.sizeQuestionControl.AnswerButtonEnabled = true;
            this.sizeQuestionControl.Location = new System.Drawing.Point(1054, 12);
            this.sizeQuestionControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sizeQuestionControl.Name = "sizeQuestionControl";
            this.sizeQuestionControl.Size = new System.Drawing.Size(100, 284);
            this.sizeQuestionControl.TabIndex = 6;
            // 
            // yesNoQuestionControl
            // 
            this.yesNoQuestionControl.Location = new System.Drawing.Point(980, 12);
            this.yesNoQuestionControl.MaximumSize = new System.Drawing.Size(262, 300);
            this.yesNoQuestionControl.MinimumSize = new System.Drawing.Size(70, 58);
            this.yesNoQuestionControl.Name = "yesNoQuestionControl";
            this.yesNoQuestionControl.NoButtonEnabled = true;
            this.yesNoQuestionControl.Size = new System.Drawing.Size(70, 284);
            this.yesNoQuestionControl.TabIndex = 5;
            this.yesNoQuestionControl.YesButtonEnabled = true;
            // 
            // questionControl
            // 
            this.questionControl.AnswerButtonEnabled = true;
            this.questionControl.Location = new System.Drawing.Point(751, 12);
            this.questionControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.questionControl.MaximumSize = new System.Drawing.Size(300, 300);
            this.questionControl.MinimumSize = new System.Drawing.Size(80, 102);
            this.questionControl.Name = "questionControl";
            this.questionControl.Size = new System.Drawing.Size(225, 284);
            this.questionControl.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutQuest,
            this.layoutYesNo,
            this.layoutSecondStage});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1166, 308);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.QuestionLabel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(739, 288);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutQuest
            // 
            this.layoutQuest.Control = this.questionControl;
            this.layoutQuest.CustomizationFormText = "layoutQuest";
            this.layoutQuest.Location = new System.Drawing.Point(739, 0);
            this.layoutQuest.Name = "layoutQuest";
            this.layoutQuest.Size = new System.Drawing.Size(229, 288);
            this.layoutQuest.Text = "layoutQuest";
            this.layoutQuest.TextSize = new System.Drawing.Size(0, 0);
            this.layoutQuest.TextToControlDistance = 0;
            this.layoutQuest.TextVisible = false;
            // 
            // layoutYesNo
            // 
            this.layoutYesNo.Control = this.yesNoQuestionControl;
            this.layoutYesNo.CustomizationFormText = "layoutYesNo";
            this.layoutYesNo.Location = new System.Drawing.Point(968, 0);
            this.layoutYesNo.Name = "layoutYesNo";
            this.layoutYesNo.Size = new System.Drawing.Size(74, 288);
            this.layoutYesNo.Text = "layoutYesNo";
            this.layoutYesNo.TextSize = new System.Drawing.Size(0, 0);
            this.layoutYesNo.TextToControlDistance = 0;
            this.layoutYesNo.TextVisible = false;
            this.layoutYesNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutSecondStage
            // 
            this.layoutSecondStage.Control = this.sizeQuestionControl;
            this.layoutSecondStage.CustomizationFormText = "layoutSecondStage";
            this.layoutSecondStage.Location = new System.Drawing.Point(1042, 0);
            this.layoutSecondStage.MinSize = new System.Drawing.Size(104, 24);
            this.layoutSecondStage.Name = "layoutSecondStage";
            this.layoutSecondStage.Size = new System.Drawing.Size(104, 288);
            this.layoutSecondStage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutSecondStage.Text = "layoutSecondStage";
            this.layoutSecondStage.TextSize = new System.Drawing.Size(0, 0);
            this.layoutSecondStage.TextToControlDistance = 0;
            this.layoutSecondStage.TextVisible = false;
            this.layoutSecondStage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 243);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1170, 312);
            this.panelControl1.TabIndex = 4;
            // 
            // MatrixMultiplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 555);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ViewPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MatrixMultiplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatrixMultiplyForm";
            this.Load += new System.EventHandler(this.MatrixMultiplyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).EndInit();
            this.ViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutQuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutYesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSecondStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl ViewPanel;
        private DevExpress.XtraEditors.LabelControl QuestionLabel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private YesNoQuestionControl yesNoQuestionControl;
        private QuestionControl questionControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutQuest;
        private DevExpress.XtraLayout.LayoutControlItem layoutYesNo;
        private UserControls.SizeQuestionControl sizeQuestionControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutSecondStage;
        private MatrixGridView matrixGridView1;
        private MatrixGridView matrixGridView3;
        private MatrixGridView matrixGridView2;
    }
}