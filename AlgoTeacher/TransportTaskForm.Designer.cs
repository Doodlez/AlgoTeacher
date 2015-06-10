using UserControls;

namespace AlgoTeacher
{
    partial class TransportTaskForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ViewPanel = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.matrixGridView2 = new UserControls.MatrixGridView(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.matrixGridView1 = new UserControls.MatrixGridView(this.components);
            this.rotatingLabel1 = new UserControls.RotatingLabel();
            this.labelControl2 = new UserControls.RotatingLabel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.QuestionLabel = new DevExpress.XtraEditors.LabelControl();
            this.QuestPanel = new System.Windows.Forms.Panel();
            this.questionControlBase = new UserControls.QuestionControlBase();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).BeginInit();
            this.ViewPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.QuestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.tableLayoutPanel1);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(1118, 381);
            this.ViewPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.matrixGridView2, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.matrixGridView1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rotatingLabel1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 377);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(750, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(128, 30);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Потребители";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(727, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(174, 30);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Базисная матрица";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(271, 18);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(157, 30);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Цены перевозок";
            // 
            // matrixGridView2
            // 
            this.matrixGridView2.AllowUserToAddRows = false;
            this.matrixGridView2.AllowUserToDeleteRows = false;
            this.matrixGridView2.AllowUserToResizeColumns = false;
            this.matrixGridView2.AllowUserToResizeRows = false;
            this.matrixGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.matrixGridView2.BackgroundColor = System.Drawing.Color.White;
            this.matrixGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView2.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.matrixGridView2.Enabled = false;
            this.matrixGridView2.EnableHeadersVisualStyles = false;
            this.matrixGridView2.GridColor = System.Drawing.Color.White;
            this.matrixGridView2.Location = new System.Drawing.Point(703, 120);
            this.matrixGridView2.MultiSelect = false;
            this.matrixGridView2.Name = "matrixGridView2";
            this.matrixGridView2.ReadOnly = true;
            this.matrixGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView2.RowHeadersVisible = false;
            this.matrixGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixGridView2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.matrixGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView2.RowTemplate.Height = 50;
            this.matrixGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView2.Size = new System.Drawing.Size(222, 187);
            this.matrixGridView2.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(286, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 30);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Потребители";
            // 
            // matrixGridView1
            // 
            this.matrixGridView1.AllowUserToAddRows = false;
            this.matrixGridView1.AllowUserToDeleteRows = false;
            this.matrixGridView1.AllowUserToResizeColumns = false;
            this.matrixGridView1.AllowUserToResizeRows = false;
            this.matrixGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.matrixGridView1.BackgroundColor = System.Drawing.Color.White;
            this.matrixGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.matrixGridView1.Enabled = false;
            this.matrixGridView1.EnableHeadersVisualStyles = false;
            this.matrixGridView1.GridColor = System.Drawing.Color.White;
            this.matrixGridView1.Location = new System.Drawing.Point(239, 120);
            this.matrixGridView1.MultiSelect = false;
            this.matrixGridView1.Name = "matrixGridView1";
            this.matrixGridView1.ReadOnly = true;
            this.matrixGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.matrixGridView1.RowHeadersVisible = false;
            this.matrixGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.matrixGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.matrixGridView1.RowTemplate.Height = 50;
            this.matrixGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGridView1.Size = new System.Drawing.Size(222, 187);
            this.matrixGridView1.TabIndex = 6;
            this.matrixGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrixGridView1_CellContentClick);
            // 
            // rotatingLabel1
            // 
            this.rotatingLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rotatingLabel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotatingLabel1.Location = new System.Drawing.Point(664, 149);
            this.rotatingLabel1.Name = "rotatingLabel1";
            this.rotatingLabel1.NewText = "Производители";
            this.rotatingLabel1.RotateAngle = 270;
            this.rotatingLabel1.Size = new System.Drawing.Size(22, 129);
            this.rotatingLabel1.TabIndex = 10;
            this.rotatingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Location = new System.Drawing.Point(200, 149);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.NewText = "Производители";
            this.labelControl2.RotateAngle = 270;
            this.labelControl2.Size = new System.Drawing.Size(22, 129);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.QuestPanel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 381);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1118, 192);
            this.panelControl1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.QuestionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 188);
            this.panel1.TabIndex = 7;
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QuestionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.QuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionLabel.Location = new System.Drawing.Point(0, 0);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(792, 188);
            this.QuestionLabel.TabIndex = 5;
            this.QuestionLabel.Text = "Вопрос";
            // 
            // QuestPanel
            // 
            this.QuestPanel.Controls.Add(this.questionControlBase);
            this.QuestPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.QuestPanel.Location = new System.Drawing.Point(794, 2);
            this.QuestPanel.Name = "QuestPanel";
            this.QuestPanel.Size = new System.Drawing.Size(322, 188);
            this.QuestPanel.TabIndex = 6;
            // 
            // questionControlBase
            // 
            this.questionControlBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionControlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionControlBase.Location = new System.Drawing.Point(0, 0);
            this.questionControlBase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.questionControlBase.MaximumSize = new System.Drawing.Size(343, 2);
            this.questionControlBase.MinimumSize = new System.Drawing.Size(228, 102);
            this.questionControlBase.Name = "questionControlBase";
            this.questionControlBase.Size = new System.Drawing.Size(322, 102);
            this.questionControlBase.TabIndex = 4;
            // 
            // TransportTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 573);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ViewPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TransportTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Транспортная задача";
            this.Load += new System.EventHandler(this.TransportTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).EndInit();
            this.ViewPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.QuestPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl ViewPanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private MatrixGridView matrixGridView1;
        private QuestionControlBase questionControlBase;
        private DevExpress.XtraEditors.LabelControl QuestionLabel;
        private System.Windows.Forms.Panel QuestPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MatrixGridView matrixGridView2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private RotatingLabel labelControl2;
        private RotatingLabel rotatingLabel1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}