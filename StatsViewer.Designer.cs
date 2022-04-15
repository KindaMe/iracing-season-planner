namespace ir_planner
{
    partial class StatsViewer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LABEL_DESCRIPTION = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LABEL_2_NUM = new System.Windows.Forms.Label();
            this.LABEL_1_NUM = new System.Windows.Forms.Label();
            this.LABEL_3_NUM = new System.Windows.Forms.Label();
            this.LABEL_2_NAME = new System.Windows.Forms.Label();
            this.LABEL_1_NAME = new System.Windows.Forms.Label();
            this.LABEL_3_NAME = new System.Windows.Forms.Label();
            this.LABEL_MAIN_NAME = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.isOwnedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.counterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statsModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LABEL_DESCRIPTION, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LABEL_DESCRIPTION
            // 
            this.LABEL_DESCRIPTION.AutoSize = true;
            this.LABEL_DESCRIPTION.BackColor = System.Drawing.Color.Transparent;
            this.LABEL_DESCRIPTION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_DESCRIPTION.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LABEL_DESCRIPTION.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_DESCRIPTION.ForeColor = System.Drawing.Color.White;
            this.LABEL_DESCRIPTION.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LABEL_DESCRIPTION.Location = new System.Drawing.Point(5, 555);
            this.LABEL_DESCRIPTION.Margin = new System.Windows.Forms.Padding(5);
            this.LABEL_DESCRIPTION.Name = "LABEL_DESCRIPTION";
            this.LABEL_DESCRIPTION.Size = new System.Drawing.Size(415, 40);
            this.LABEL_DESCRIPTION.TabIndex = 13;
            this.LABEL_DESCRIPTION.Text = "DESCRIPTION";
            this.LABEL_DESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.LABEL_2_NUM, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_1_NUM, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_3_NUM, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_2_NAME, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_1_NAME, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_3_NAME, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.LABEL_MAIN_NAME, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(419, 269);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // LABEL_2_NUM
            // 
            this.LABEL_2_NUM.AutoSize = true;
            this.LABEL_2_NUM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_2_NUM.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_2_NUM.ForeColor = System.Drawing.Color.Gainsboro;
            this.LABEL_2_NUM.Location = new System.Drawing.Point(0, 50);
            this.LABEL_2_NUM.Margin = new System.Windows.Forms.Padding(0);
            this.LABEL_2_NUM.Name = "LABEL_2_NUM";
            this.LABEL_2_NUM.Size = new System.Drawing.Size(139, 65);
            this.LABEL_2_NUM.TabIndex = 8;
            this.LABEL_2_NUM.Text = "2";
            this.LABEL_2_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL_1_NUM
            // 
            this.LABEL_1_NUM.AutoSize = true;
            this.LABEL_1_NUM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_1_NUM.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_1_NUM.ForeColor = System.Drawing.Color.Gold;
            this.LABEL_1_NUM.Location = new System.Drawing.Point(139, 50);
            this.LABEL_1_NUM.Margin = new System.Windows.Forms.Padding(0);
            this.LABEL_1_NUM.Name = "LABEL_1_NUM";
            this.LABEL_1_NUM.Size = new System.Drawing.Size(139, 65);
            this.LABEL_1_NUM.TabIndex = 9;
            this.LABEL_1_NUM.Text = "1";
            this.LABEL_1_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL_3_NUM
            // 
            this.LABEL_3_NUM.AutoSize = true;
            this.LABEL_3_NUM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_3_NUM.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_3_NUM.ForeColor = System.Drawing.Color.Chocolate;
            this.LABEL_3_NUM.Location = new System.Drawing.Point(278, 50);
            this.LABEL_3_NUM.Margin = new System.Windows.Forms.Padding(0);
            this.LABEL_3_NUM.Name = "LABEL_3_NUM";
            this.LABEL_3_NUM.Size = new System.Drawing.Size(141, 65);
            this.LABEL_3_NUM.TabIndex = 0;
            this.LABEL_3_NUM.Text = "3";
            this.LABEL_3_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL_2_NAME
            // 
            this.LABEL_2_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LABEL_2_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_2_NAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_2_NAME.ForeColor = System.Drawing.Color.Gainsboro;
            this.LABEL_2_NAME.Location = new System.Drawing.Point(5, 125);
            this.LABEL_2_NAME.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.LABEL_2_NAME.Name = "LABEL_2_NAME";
            this.LABEL_2_NAME.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LABEL_2_NAME.Size = new System.Drawing.Size(129, 144);
            this.LABEL_2_NAME.TabIndex = 10;
            this.LABEL_2_NAME.Text = "SECOND";
            this.LABEL_2_NAME.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LABEL_1_NAME
            // 
            this.LABEL_1_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LABEL_1_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_1_NAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_1_NAME.ForeColor = System.Drawing.Color.Gold;
            this.LABEL_1_NAME.Location = new System.Drawing.Point(144, 115);
            this.LABEL_1_NAME.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LABEL_1_NAME.Name = "LABEL_1_NAME";
            this.LABEL_1_NAME.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LABEL_1_NAME.Size = new System.Drawing.Size(129, 154);
            this.LABEL_1_NAME.TabIndex = 11;
            this.LABEL_1_NAME.Text = "FIRST";
            this.LABEL_1_NAME.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LABEL_3_NAME
            // 
            this.LABEL_3_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LABEL_3_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_3_NAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_3_NAME.ForeColor = System.Drawing.Color.Chocolate;
            this.LABEL_3_NAME.Location = new System.Drawing.Point(283, 135);
            this.LABEL_3_NAME.Margin = new System.Windows.Forms.Padding(5, 20, 5, 0);
            this.LABEL_3_NAME.Name = "LABEL_3_NAME";
            this.LABEL_3_NAME.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LABEL_3_NAME.Size = new System.Drawing.Size(131, 134);
            this.LABEL_3_NAME.TabIndex = 12;
            this.LABEL_3_NAME.Text = "THIRD";
            this.LABEL_3_NAME.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LABEL_MAIN_NAME
            // 
            this.LABEL_MAIN_NAME.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.LABEL_MAIN_NAME, 3);
            this.LABEL_MAIN_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LABEL_MAIN_NAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_MAIN_NAME.ForeColor = System.Drawing.Color.White;
            this.LABEL_MAIN_NAME.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LABEL_MAIN_NAME.Location = new System.Drawing.Point(5, 5);
            this.LABEL_MAIN_NAME.Margin = new System.Windows.Forms.Padding(5);
            this.LABEL_MAIN_NAME.Name = "LABEL_MAIN_NAME";
            this.LABEL_MAIN_NAME.Size = new System.Drawing.Size(409, 40);
            this.LABEL_MAIN_NAME.TabIndex = 15;
            this.LABEL_MAIN_NAME.Text = "TITLE";
            this.LABEL_MAIN_NAME.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isOwnedDataGridViewCheckBoxColumn,
            this.counterDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.statsModelBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView1.Location = new System.Drawing.Point(8, 283);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(8);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(409, 259);
            this.dataGridView1.TabIndex = 3;
            // 
            // isOwnedDataGridViewCheckBoxColumn
            // 
            this.isOwnedDataGridViewCheckBoxColumn.DataPropertyName = "IsOwned";
            this.isOwnedDataGridViewCheckBoxColumn.HeaderText = "IsOwned";
            this.isOwnedDataGridViewCheckBoxColumn.Name = "isOwnedDataGridViewCheckBoxColumn";
            this.isOwnedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isOwnedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // counterDataGridViewTextBoxColumn
            // 
            this.counterDataGridViewTextBoxColumn.DataPropertyName = "Counter";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.counterDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.counterDataGridViewTextBoxColumn.FillWeight = 25.38071F;
            this.counterDataGridViewTextBoxColumn.HeaderText = "";
            this.counterDataGridViewTextBoxColumn.Name = "counterDataGridViewTextBoxColumn";
            this.counterDataGridViewTextBoxColumn.ReadOnly = true;
            this.counterDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 174.6193F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statsModelBindingSource
            // 
            this.statsModelBindingSource.DataSource = typeof(ir_planner.StatsModel);
            // 
            // StatsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatsViewer";
            this.Size = new System.Drawing.Size(425, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statsModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LABEL_DESCRIPTION;
        private System.Windows.Forms.Label LABEL_2_NUM;
        private System.Windows.Forms.Label LABEL_1_NUM;
        private System.Windows.Forms.Label LABEL_2_NAME;
        private System.Windows.Forms.Label LABEL_1_NAME;
        private System.Windows.Forms.Label LABEL_MAIN_NAME;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource statsModelBindingSource;
        private System.Windows.Forms.Label LABEL_3_NUM;
        private System.Windows.Forms.Label LABEL_3_NAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOwnedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn counterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}
