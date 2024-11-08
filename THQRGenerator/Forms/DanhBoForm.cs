using Dapper;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using THQRGenerator.Models;
using THQRGenerator.Utils;

namespace THQRGenerator.Forms
{
    public partial class DanhBoForm : Form
    {
        public DanhBoForm()
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

        private async Task<List<string>> GetMay()
        {
            using (var conn = Connection)
            {
                var sQuery = "select distinct substring(lotrinh,3,2) from TB_DULIEUKHACHHANG";
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
            //var diemDanh = await GetDanhBo(dot, may);
            var diemDanh = new List<DiemDanh>() {
                new DiemDanh(){ HoTen = "13041800664", Info = "104 PHO QUANG(313B-315 NAM KY KHOI NGHIA, PHUONG VO THI SAU, QUAN 3, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13041811393", Info = "C/C SKY CENTER SO 5B PHO QUANG(112 LY PHUC MAN, PHUONG BINH THUAN, QUAN 7, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13061416010", Info = "1/10/2 NGHIA PHAT" },
                new DiemDanh(){ HoTen = "13132153588", Info = "96 BAU CAT 3" },
                new DiemDanh(){ HoTen = "13152180237", Info = "31-33 PHAN HUY ICH" },
                new DiemDanh(){ HoTen = "13152185888", Info = "THUA 32(TANG 4, 27A HOANG VIET, PHUONG 4, QUAN TAN BINH, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13152221403", Info = "02 TRUONG CHINH(102 DUONG PHAN VAN HON, PHUONG TAN THOI NHAT, QUAN 12, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13162404518", Info = "88N1 HUONG LO 3(TOA NHA A&B, SO 76A LE LAI, PHUONG BEN THANH, QUAN 1, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13162404523", Info = "KHU A2 LIEN HOP TDTT & DC TAN(64 HOANG QUOC VIET, PHUONG PHU MY, QUAN 7,THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13162404524", Info = "KHU A2 SON KY(64 HOANG QUOC VIET, PHUONG PHU MY, QUAN 7, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13162404525", Info = "KHU A7 KHU LIEN HOP TDTT & DC TAN THANG(SO 68, DUONG N1, PHUONG SON KY, QUAN TAN PHU, TP.HO CHI MINH)" },
                new DiemDanh(){ HoTen = "13172380516", Info = "683A AU CO(112 LY PHUC MAN, PHUONG BINH THUAN, QUAN 7, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13172395095", Info = "685 AU CO" },
                new DiemDanh(){ HoTen = "13182486080", Info = "53 NGUYEN SON(18 VO DUY NINH, PHUONG 22, QUAN BINH THANH, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13182486081", Info = "53 NGUYEN SON(18 VO DUY NINH, PHUONG 22, QUAN BINH THANH , THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13192596726", Info = " 262/13;262/15-17 LUY BAN BICH(112 LY PHUC MAN, PHUONG BINH THUAN, QUAN 7, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13192597417", Info = "291/2 LUY BAN BICH" },
                new DiemDanh(){ HoTen = "13202700130", Info = "33 LUONG MINH NGUYET(24 THOAI NGOC HAU, PHUONG HOA THANH, QUAN TAN PHU, THANH PHO HO CHI MINH, VIET NAM)" },
                new DiemDanh(){ HoTen = "13222891768", Info = "CC LO A BAU CAT 2" },
                new DiemDanh(){ HoTen = "13222891785", Info = "C/CU LO M KHU CX BAU CAT II" }
            };
            if (diemDanh.Count == 0)
                return;
            //var danhBos = diemDanh.Select(i => i.HoTen).AsList();
            //var count = await UpdateDanhBo(danhBos);
            //if (count < 0)
            //{
            //    MessageBox.Show("Lỗi cập nhật!");
            //    return;
            //}
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
            ReportUtil.ExportReportPdf(@"Reports\DanhBoReportA4.rdlc", sourceList, paramList, $"{dot}{may}", savePath);
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
                var dot = cbxDot.Text;
                var may = cbxMay.Text;
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
                using (var viewer = new RdlcViewer("DanhBoReport318x363", sourceList, paramList, $"{dot}{may}"))
                    viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DanhBoForm_Load(object sender, EventArgs e)
        {
            var dots = await GetDot();
            cbxDot.DataSource = dots;
            cbxDotTu.DataSource = new List<string>(dots);
            cbxDotDen.DataSource = new List<string>(dots);
            cbxMay.DataSource = await GetMay();
            dgvList.AutoGenerateColumns = false;
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            var list = await GetDanhBo(cbxDot.Text, cbxMay.Text);
            dgvList.DataSource = list;
        }

        private void cbxDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnView_Click(sender, e);
        }

        private void cbxMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnView_Click(sender, e);
        }

        private async void btnExport_Click(object sender, EventArgs e)
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
                //var dotTu = cbxDotTu.Text;
                //var dotDen = cbxDotDen.Text;
                //var dots = cbxDot.DataSource as List<string>;
                //dots = dots.Where(i => i.CompareTo(dotTu) >= 0 && i.CompareTo(dotDen) <= 0).ToList();
                //var mays = cbxMay.DataSource as List<string>;
                //foreach (var dot in dots)
                //    foreach (var may in mays)
                await ExportPdf("00", "00", savePath);
                
                //var diemDanh = new List<DiemDanh>();
                //for (int i = 1; i < 1001; i++)
                //{
                //    diemDanh.Add(new DiemDanh() { HoTen = $"THW{i:000000}" });
                //}
                //if (diemDanh.Count == 0)
                //    return;
                //foreach (var d in diemDanh)
                //{
                //    d.QRCode = QRCodeUtil.ToByteArray("https://service.cskhtanhoa.com.vn/khachhang/thongtin?danhbo=" + d.HoTen.Replace(" ", ""), true);
                //    d.Info = $"Mã QR: {d.HoTen}";
                //}
                //var sourceList = new List<KeyValuePair<string, object>>
                //{
                //    new KeyValuePair<string, object>("DiemDanh", diemDanh)
                //};
                //var paramList = new List<KeyValuePair<string, string>>
                //{
                //    new KeyValuePair<string, string>("Dot", "00"),
                //    new KeyValuePair<string, string>("May", "00")
                //};
                //ReportUtil.ExportReportPdf(@"Reports\DanhBoReport318x363_DuPhong.rdlc", sourceList, paramList, "0000", savePath);
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
