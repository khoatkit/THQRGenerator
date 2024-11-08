using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THQRGenerator.Models;
using THQRGenerator.Utils;

namespace THQRGenerator.Forms
{
    public partial class KiemKeForm : Form
    {
        public KiemKeForm()
        {
            InitializeComponent();
        }

        private SqlConnection Connection => new SqlConnection("Data Source=192.168.90.9; Initial Catalog=CAPNUOCTANHOA; User Id=sa; Password=db9@tanhoa;");

        private async Task<List<string>> GetDot()
        {
            using (var conn = Connection)
            {
                var sQuery = "select distinct left(lotrinh,2) from TB_DULIEUKHACHHANG";
                var result = await conn.QueryAsync<string>(sQuery);
                var list = result.AsList();
                list.Sort();
                //list.Insert(0, "");
                return list;
            }
        }

        private async Task<List<DiemDanh>> GetDanhBo(string dot, string may)
        {
            using (var conn = Connection)
            {
                var loTrinh = $"{dot}{may}%";
                var sQuery = "select DANHBO HoTen,isnull(DiaChiHoaDon,SONHA+' '+TENDUONG) Info from TB_DULIEUKHACHHANG WHERE LOTRINH LIKE @LOTRINH ORDER BY LOTRINH;";
                var result = await conn.QueryAsync<DiemDanh>(sQuery, new { loTrinh });
                return result.AsList();
            }
        }

        private async Task ExportPdf(string dot, string may, string savePath)
        {
            var diemDanh = await GetDanhBo(dot, may);
            if (diemDanh.Count == 0)
                return;
            var danhBos = diemDanh.Select(i => i.HoTen).AsList();
            var count = await UpdateDanhBo(danhBos);
            if (count < 0)
            {
                MessageBox.Show("Lỗi cập nhật!");
                return;
            }
            foreach (var d in diemDanh)
            {
                d.QRCode = QRCodeUtil.ToByteArray("https://service.cskhtanhoa.com.vn/khachhang/thongtin?danhbo=" + d.HoTen.Replace(" ", ""), true);
                if (d.HoTen.Length == 11)
                    d.HoTen = d.HoTen.Insert(7, "  ").Insert(4, "  ");
            }
            var sourceList = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("DiemDanh", diemDanh)
                };
            var paramList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Dot", dot),
                    new KeyValuePair<string, string>("May", may)
                };
            ReportUtil.ExportReportPdf(@"Reports\DanhBoReport318x363.rdlc", sourceList, paramList, $"{dot}{may}", savePath);
            lblExportStat.Text = $"Đã xuất D{dot} M{may}";
        }

        private async Task<int> UpdateDanhBo(List<string> danhBo)
        {
            using (var conn = Connection)
            {
                var sQuery = "update TB_DULIEUKHACHHANG set QRIn=1 where DANHBO in @danhBo;";
                var result = await conn.ExecuteAsync(sQuery, new { danhBo });
                return result;
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.RowCount == 0) return;
                var diemDanh = dgvList.DataSource as List<DiemDanh>;
                var danhBos = diemDanh.Select(i => i.HoTen).AsList();
                var count = await UpdateDanhBo(danhBos);
                if (count < 0)
                {
                    MessageBox.Show("Lỗi cập nhật!");
                    return;
                }
                foreach (var d in diemDanh)
                {
                    d.QRCode = QRCodeUtil.ToByteArray("https://service.cskhtanhoa.com.vn/khachhang/thongtin?danhbo=" + d.HoTen.Replace(" ",""), true);
                    if (d.HoTen.Length == 11)
                        d.HoTen = d.HoTen.Insert(7, "  ").Insert(4, "  ");
                }
                var sourceList = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("DiemDanh", diemDanh)
                };
                using (var viewer = new RdlcViewer("KiemKeReportA4", sourceList))
                    viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DanhBoForm_Load(object sender, EventArgs e)
        {
            cbxTu.DataSource = new string[] { "1", "1.001", "2.001", "3.001", "4.001", "5.001", "6.001", "7.001", "8.001", "9.001"};
            cbxDen.DataSource = new string[] { "1.000", "2.000", "3.000", "4.000", "5.000", "6.000", "7.000", "8.000", "9.000", "10.000" };
            dgvList.AutoGenerateColumns = false;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            //dgvList.DataSource = list;
        }

        private void cbxDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnView_Click(sender, e);
        }

        private void cbxMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnView_Click(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var savePath = lblSavePath.Text;
                lblExportStat.Text = "";
                if (savePath == "." || string.IsNullOrWhiteSpace(savePath))
                {
                    MessageBox.Show("Chưa chọn nơi lưu!");
                    return;
                }
                var tuStr = cbxTu.Text;
                var denStr = cbxDen.Text;
                if (string.IsNullOrEmpty(tuStr) || string.IsNullOrEmpty(denStr))
                {
                    MessageBox.Show("Chưa chọn khoảng số để in!");
                    return;
                }
                var tu = Convert.ToInt32(tuStr.Replace(".", ""));
                var den = Convert.ToInt32(denStr.Replace(".", ""));
                var diemDanh = new List<DiemDanh>();
                for (int i = tu; i <= den; i++)
                {
                    diemDanh.Add(new DiemDanh() { HoTen = i.ToString("000000") });
                }
                if (diemDanh.Count == 0)
                    return;
                foreach (var d in diemDanh)
                {
                    //d.QRCode = QRCodeUtil.ToByteArray("https://old.cskhtanhoa.com.vn:1803/home/kiemke/" + d.HoTen, true);
                    d.QRCode = QRCodeUtil.ToByteArray("https://old.cskhtanhoa.com.vn:1803/home/kiemke/" + d.HoTen, false);
                    d.Info = $"Mã QR: {d.HoTen}";
                }
                var sourceList = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("DiemDanh", diemDanh)
                };
                //KiemKeReportA4
                //KiemKeReportA4_S
                ReportUtil.ExportReportPdf(@"Reports\KiemKeReportA4_SS.rdlc", sourceList, null, $"{tu}_{den}", savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    lblSavePath.Text = dialog.SelectedPath;
                else
                    lblSavePath.Text = "";
            }
        }

    }
}
