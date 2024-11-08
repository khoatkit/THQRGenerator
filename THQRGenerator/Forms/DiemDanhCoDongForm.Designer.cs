
namespace THQRGenerator.Forms
{
    partial class DiemDanhCoDongForm
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.tbxSoPhieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptbQrCode = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxHoTen = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrintList = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCount2 = new System.Windows.Forms.Label();
            this.lblCount3 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUnCheck = new System.Windows.Forms.Button();
            this.btnKQTT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(512, 188);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 28);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "QR";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxInfo.Location = new System.Drawing.Point(227, 73);
            this.tbxInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(360, 106);
            this.tbxInfo.TabIndex = 1;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(315, 188);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(60, 28);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(379, 188);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 28);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2});
            this.dgvData.Location = new System.Drawing.Point(12, 222);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(945, 352);
            this.dgvData.TabIndex = 4;
            this.dgvData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvData_RowEnter);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvData_RowPrePaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SoPhieu";
            this.Column3.HeaderText = "Số phiếu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "HoTen";
            this.Column4.HeaderText = "Họ tên";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Info";
            this.Column2.HeaderText = "Thông tin";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 500;
            // 
            // ptbImage
            // 
            this.ptbImage.Location = new System.Drawing.Point(12, 13);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(134, 169);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage.TabIndex = 5;
            this.ptbImage.TabStop = false;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(12, 188);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(134, 28);
            this.btnImage.TabIndex = 3;
            this.btnImage.Text = "Chọn hình";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.BtnImage_Click);
            // 
            // tbxSoPhieu
            // 
            this.tbxSoPhieu.Location = new System.Drawing.Point(487, 12);
            this.tbxSoPhieu.Name = "tbxSoPhieu";
            this.tbxSoPhieu.Size = new System.Drawing.Size(100, 23);
            this.tbxSoPhieu.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số phiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông tin";
            // 
            // ptbQrCode
            // 
            this.ptbQrCode.Location = new System.Drawing.Point(750, 9);
            this.ptbQrCode.Name = "ptbQrCode";
            this.ptbQrCode.Size = new System.Drawing.Size(207, 207);
            this.ptbQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbQrCode.TabIndex = 5;
            this.ptbQrCode.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(224, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(182, 17);
            this.lblID.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Họ tên";
            // 
            // tbxHoTen
            // 
            this.tbxHoTen.Font = new System.Drawing.Font("Arial", 10F);
            this.tbxHoTen.Location = new System.Drawing.Point(227, 42);
            this.tbxHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.tbxHoTen.Name = "tbxHoTen";
            this.tbxHoTen.Size = new System.Drawing.Size(179, 23);
            this.tbxHoTen.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(445, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnPrintList
            // 
            this.btnPrintList.Location = new System.Drawing.Point(580, 188);
            this.btnPrintList.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(60, 28);
            this.btnPrintList.TabIndex = 0;
            this.btnPrintList.Text = "DSách";
            this.btnPrintList.UseVisualStyleBackColor = true;
            this.btnPrintList.Click += new System.EventHandler(this.BtnPrintList_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(155, 188);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 28);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Tải DL";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(593, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(151, 23);
            this.lblCount.TabIndex = 9;
            // 
            // lblCount2
            // 
            this.lblCount2.BackColor = System.Drawing.Color.LightGreen;
            this.lblCount2.Location = new System.Drawing.Point(593, 39);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(151, 23);
            this.lblCount2.TabIndex = 10;
            // 
            // lblCount3
            // 
            this.lblCount3.BackColor = System.Drawing.Color.LightPink;
            this.lblCount3.Location = new System.Drawing.Point(592, 66);
            this.lblCount3.Name = "lblCount3";
            this.lblCount3.Size = new System.Drawing.Size(151, 23);
            this.lblCount3.TabIndex = 11;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(596, 92);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(147, 28);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Điểm danh ra/vào";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.Location = new System.Drawing.Point(596, 126);
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.Size = new System.Drawing.Size(147, 28);
            this.btnUnCheck.TabIndex = 2;
            this.btnUnCheck.Text = "Bỏ điểm danh";
            this.btnUnCheck.UseVisualStyleBackColor = true;
            this.btnUnCheck.Click += new System.EventHandler(this.BtnUnCheck_Click);
            // 
            // btnKQTT
            // 
            this.btnKQTT.Location = new System.Drawing.Point(648, 188);
            this.btnKQTT.Margin = new System.Windows.Forms.Padding(4);
            this.btnKQTT.Name = "btnKQTT";
            this.btnKQTT.Size = new System.Drawing.Size(60, 28);
            this.btnKQTT.TabIndex = 0;
            this.btnKQTT.Text = "KQTT";
            this.btnKQTT.UseVisualStyleBackColor = true;
            this.btnKQTT.Click += new System.EventHandler(this.btnKQTT_Click);
            // 
            // DiemDanhCoDongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 586);
            this.Controls.Add(this.lblCount3);
            this.Controls.Add(this.lblCount2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSoPhieu);
            this.Controls.Add(this.ptbQrCode);
            this.Controls.Add(this.ptbImage);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnUnCheck);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbxHoTen);
            this.Controls.Add(this.btnKQTT);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.btnPrintList);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DiemDanhCoDongForm";
            this.Text = "DiemDanh";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.PictureBox ptbImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TextBox tbxSoPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptbQrCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxHoTen;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnPrintList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblCount2;
        private System.Windows.Forms.Label lblCount3;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUnCheck;
        private System.Windows.Forms.Button btnKQTT;
    }
}