
namespace THQRGenerator.Forms
{
    partial class DanhBoForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExportStat = new System.Windows.Forms.Label();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMay = new System.Windows.Forms.ComboBox();
            this.cbxDotDen = new System.Windows.Forms.ComboBox();
            this.cbxDotTu = new System.Windows.Forms.ComboBox();
            this.cbxDot = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(870, 479);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 63);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.Size = new System.Drawing.Size(864, 413);
            this.dgvList.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "HoTen";
            this.Column1.HeaderText = "Danh bộ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Info";
            this.Column2.HeaderText = "Địa chỉ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 450;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblExportStat);
            this.panel1.Controls.Add(this.lblSavePath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxMay);
            this.panel1.Controls.Add(this.cbxDotDen);
            this.panel1.Controls.Add(this.cbxDotTu);
            this.panel1.Controls.Add(this.cbxDot);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnSavePath);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblExportStat
            // 
            this.lblExportStat.AutoSize = true;
            this.lblExportStat.Location = new System.Drawing.Point(628, 30);
            this.lblExportStat.Name = "lblExportStat";
            this.lblExportStat.Size = new System.Drawing.Size(12, 17);
            this.lblExportStat.TabIndex = 15;
            this.lblExportStat.Text = ".";
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(137, 0);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(12, 17);
            this.lblSavePath.TabIndex = 14;
            this.lblSavePath.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Máy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đợt";
            // 
            // cbxMay
            // 
            this.cbxMay.FormattingEnabled = true;
            this.cbxMay.Location = new System.Drawing.Point(72, 22);
            this.cbxMay.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMay.Name = "cbxMay";
            this.cbxMay.Size = new System.Drawing.Size(60, 24);
            this.cbxMay.TabIndex = 10;
            this.cbxMay.SelectedIndexChanged += new System.EventHandler(this.cbxMay_SelectedIndexChanged);
            // 
            // cbxDotDen
            // 
            this.cbxDotDen.FormattingEnabled = true;
            this.cbxDotDen.Location = new System.Drawing.Point(560, 23);
            this.cbxDotDen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDotDen.Name = "cbxDotDen";
            this.cbxDotDen.Size = new System.Drawing.Size(60, 24);
            this.cbxDotDen.TabIndex = 9;
            this.cbxDotDen.SelectedIndexChanged += new System.EventHandler(this.cbxDot_SelectedIndexChanged);
            // 
            // cbxDotTu
            // 
            this.cbxDotTu.FormattingEnabled = true;
            this.cbxDotTu.Location = new System.Drawing.Point(492, 23);
            this.cbxDotTu.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDotTu.Name = "cbxDotTu";
            this.cbxDotTu.Size = new System.Drawing.Size(60, 24);
            this.cbxDotTu.TabIndex = 9;
            this.cbxDotTu.SelectedIndexChanged += new System.EventHandler(this.cbxDot_SelectedIndexChanged);
            // 
            // cbxDot
            // 
            this.cbxDot.FormattingEnabled = true;
            this.cbxDot.Location = new System.Drawing.Point(4, 22);
            this.cbxDot.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDot.Name = "cbxDot";
            this.cbxDot.Size = new System.Drawing.Size(60, 24);
            this.cbxDot.TabIndex = 9;
            this.cbxDot.SelectedIndexChanged += new System.EventHandler(this.cbxDot_SelectedIndexChanged);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(140, 19);
            this.btnView.Margin = new System.Windows.Forms.Padding(4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 28);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(276, 19);
            this.btnSavePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(100, 28);
            this.btnSavePath.TabIndex = 8;
            this.btnSavePath.Text = "Chọn nơi lưu";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(384, 19);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 28);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Xuất PDF";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(208, 19);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 28);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // DanhBoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 479);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DanhBoForm";
            this.Text = "DanhBo";
            this.Load += new System.EventHandler(this.DanhBoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMay;
        private System.Windows.Forms.ComboBox cbxDot;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label lblExportStat;
        private System.Windows.Forms.ComboBox cbxDotDen;
        private System.Windows.Forms.ComboBox cbxDotTu;
    }
}