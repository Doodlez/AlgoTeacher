﻿using UserControls;

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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.QuestionLabel = new DevExpress.XtraEditors.LabelControl();
            this.QuestPanel = new System.Windows.Forms.Panel();
            this.questionControlBase = new UserControls.QuestionControlBase();
            this.matrixGridView3 = new UserControls.MatrixGridView(this.components);
            this.matrixGridView2 = new UserControls.MatrixGridView(this.components);
            this.matrixGridView1 = new UserControls.MatrixGridView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).BeginInit();
            this.ViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.QuestPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).BeginInit();
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
            this.ViewPanel.Size = new System.Drawing.Size(1090, 273);
            this.ViewPanel.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.QuestPanel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 273);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1090, 256);
            this.panelControl1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.QuestionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 252);
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
            this.QuestionLabel.Size = new System.Drawing.Size(764, 252);
            this.QuestionLabel.TabIndex = 5;
            this.QuestionLabel.Text = "Вопрос";
            // 
            // QuestPanel
            // 
            this.QuestPanel.Controls.Add(this.questionControlBase);
            this.QuestPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.QuestPanel.Location = new System.Drawing.Point(766, 2);
            this.QuestPanel.Name = "QuestPanel";
            this.QuestPanel.Size = new System.Drawing.Size(322, 252);
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
            this.matrixGridView3.Enabled = false;
            this.matrixGridView3.EnableHeadersVisualStyles = false;
            this.matrixGridView3.GridColor = System.Drawing.Color.White;
            this.matrixGridView3.Location = new System.Drawing.Point(803, 41);
            this.matrixGridView3.MultiSelect = false;
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
            this.matrixGridView2.Enabled = false;
            this.matrixGridView2.EnableHeadersVisualStyles = false;
            this.matrixGridView2.GridColor = System.Drawing.Color.White;
            this.matrixGridView2.Location = new System.Drawing.Point(433, 41);
            this.matrixGridView2.MultiSelect = false;
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
            this.matrixGridView1.Enabled = false;
            this.matrixGridView1.EnableHeadersVisualStyles = false;
            this.matrixGridView1.GridColor = System.Drawing.Color.White;
            this.matrixGridView1.Location = new System.Drawing.Point(70, 41);
            this.matrixGridView1.MultiSelect = false;
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
            // MatrixMultiplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 529);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ViewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MatrixMultiplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatrixMultiplyForm";
            this.Load += new System.EventHandler(this.MatrixMultiplyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPanel)).EndInit();
            this.ViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.QuestPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl ViewPanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private MatrixGridView matrixGridView1;
        private MatrixGridView matrixGridView3;
        private MatrixGridView matrixGridView2;
        private QuestionControlBase questionControlBase;
        private DevExpress.XtraEditors.LabelControl QuestionLabel;
        private System.Windows.Forms.Panel QuestPanel;
        private System.Windows.Forms.Panel panel1;
    }
}