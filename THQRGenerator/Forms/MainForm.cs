using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using THQRGenerator.Models;
using THQRGenerator.Utils;

namespace THQRGenerator.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dgvNoiDung.AutoGenerateColumns = false;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            var qrCodeInfos = dgvNoiDung.DataSource as QRCodeInfo[];
            var sources = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("QRCodeInfos", qrCodeInfos)
            };
            using (var viewer = new RdlcViewer("QRCodeReport", sources))
                viewer.ShowDialog();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Chọn file dữ liệu",
                Filter = "Excel file|*.xlsx;*.xls",
                InitialDirectory = @"D:\"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            var table = ExcelUtil.Import(dialog.FileName);
            var i = table.Rows.Count;
            var qrCodeInfos = new QRCodeInfo[i];
            for (i--; i >= 0; i--)
                qrCodeInfos[i] = QRCodeUtil.ToQRCodeInfo(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
            dgvNoiDung.DataSource = qrCodeInfos;
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            FormUtil.ScaleDataGridViewColumns(dgvNoiDung, factor);
        }
    }
}
