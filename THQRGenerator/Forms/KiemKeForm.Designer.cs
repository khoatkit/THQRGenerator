
namespace THQRGenerator.Forms
{
    partial class KiemKeForm
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
            this.cbxDen = new System.Windows.Forms.ComboBox();
            this.cbxTu = new System.Windows.Forms.ComboBox();
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
            this.panel1.Controls.Add(this.cbxDen);
            this.panel1.Controls.Add(this.cbxTu);
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
            this.lblSavePath.Location = new System.Drawing.Point(3, 0);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(12, 17);
            this.lblSavePath.TabIndex = 14;
            this.lblSavePath.Text = ".";
            // 
            // cbxDen
            // 
            this.cbxDen.FormattingEnabled = true;
            this.cbxDen.Location = new System.Drawing.Point(426, 23);
            this.cbxDen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDen.Name = "cbxDen";
            this.cbxDen.Size = new System.Drawing.Size(60, 24);
            this.cbxDen.TabIndex = 9;
            this.cbxDen.SelectedIndexChanged += new System.EventHandler(this.cbxDot_SelectedIndexChanged);
            // 
            // cbxTu
            // 
            this.cbxTu.FormattingEnabled = true;
            this.cbxTu.Location = new System.Drawing.Point(358, 23);
            this.cbxTu.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTu.Name = "cbxTu";
            this.cbxTu.Size = new System.Drawing.Size(60, 24);
            this.cbxTu.TabIndex = 9;
            this.cbxTu.SelectedIndexChanged += new System.EventHandler(this.cbxDot_SelectedIndexChanged);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(6, 19);
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
            this.btnSavePath.Location = new System.Drawing.Point(142, 19);
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
            this.btnExport.Location = new System.Drawing.Point(250, 19);
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
            this.btnPrint.Location = new System.Drawing.Point(74, 19);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 28);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // KiemKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 479);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KiemKeForm";
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
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label lblExportStat;
        private System.Windows.Forms.ComboBox cbxDen;
        private System.Windows.Forms.ComboBox cbxTu;
    }
}