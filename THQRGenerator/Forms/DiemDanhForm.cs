using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Shapes;
using THQRGenerator.Models;
using THQRGenerator.Utils;
using THQRGenerator.WebAPI;

namespace THQRGenerator.Forms
{
    public partial class DiemDanhForm : Form
    {
        DiemDanh selectedRow;
        List<DiemDanh> diemDanhs;
        public DiemDanhForm()
        {
            InitializeComponent();
            GetListDiemDanh();
            dgvData.AutoGenerateColumns = false;
            cbxKhoiFilter.SelectedIndex = 0;
        }

        private void FilterListDiemDanh()
        {
            List<DiemDanh> diemDanhFilter;
            int khoi = cbxKhoiFilter.SelectedIndex - 1;
            if (khoi == -1)
                diemDanhFilter = diemDanhs;
            else
                diemDanhFilter = diemDanhs.FindAll(i => i.Khoi == khoi);
            diemDanhFilter = diemDanhs.FindAll(i => i.ID == 6 || i.ID == 20 || i.ID == 56);// || i.ID == 63 || i.ID == 72
            var sum = diemDanhFilter.Count;
            var chuaDiemDanh = 0;
            var daDiemDanh = 0;
            var daRaNgoai = 0;
            foreach (var i in diemDanhFilter)
            {
                if (!i.Check1)
                    chuaDiemDanh++;
                else if (i.Check2)
                    daDiemDanh++;
                else
                    daRaNgoai++;
            }
            lblCount.Text = "Chưa điểm danh: " + chuaDiemDanh;
            lblCount2.Text = "Đã điểm danh: " + daDiemDanh;
            lblCount3.Text = "Đã ra ngoài: " + daRaNgoai;
            //save and load position
            int firstRow = -1;
            int currentRow = -1;
            if (dgvData.Rows.Count > 0)
            {
                firstRow = dgvData.FirstDisplayedScrollingRowIndex;
                if (dgvData.CurrentCell != null)
                    currentRow = dgvData.CurrentCell.RowIndex;
            }
            dgvData.DataSource = diemDanhFilter;
            int maxIndex = dgvData.Rows.Count - 1;
            currentRow = currentRow > maxIndex ? maxIndex : currentRow;
            firstRow = firstRow > maxIndex ? maxIndex : firstRow;
            if (currentRow > -1)
            {
                dgvData.ClearSelection();
                dgvData.Rows[currentRow].Cells[0].Selected = true;
            }
            if (firstRow > -1)
                dgvData.FirstDisplayedScrollingRowIndex = firstRow;
        }

        private async void GetListDiemDanh()
        {
            diemDanhs = await DiemDanhAPI.GetListDiemDanh();
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else
            {
                diemDanhs.Sort((x, y) =>
                {
                    //int result = decimal.Compare(x.Khoi, y.Khoi);
                    //if (result == 0)
                    //    result = string.Compare(x.Ten, y.Ten);
                    int result = decimal.Compare(x.ID, y.ID);
                    return result;
                });
                FilterListDiemDanh();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            var diemDanh = dgvData.DataSource as List<DiemDanh>;
            foreach (var d in diemDanh)
                d.QRCode = QRCodeUtil.ToByteArray(d.ID.ToString());
            var sources = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DiemDanh", diemDanh)
            };
            //using (var viewer = new RdlcViewer("DiemDanhReport", sources))
            //using (var viewer = new RdlcViewer("QRDiemDanhCongDoanReport", sources))
            using (var viewer = new RdlcViewer("QRDiemDanhCoDongReport", sources))
                viewer.ShowDialog();
        }

        private void BtnPrintList_Click(object sender, EventArgs e)
        {
            var diemDanh = dgvData.DataSource as List<DiemDanh>;
            foreach (var d in diemDanh)
                d.QRCode = QRCodeUtil.ToByteArray(d.ID.ToString());
            var sources = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DiemDanh", diemDanh)
            };
            using (var viewer = new RdlcViewer("DiemDanhListReport", sources))
                viewer.ShowDialog();
        }

        private DiemDanh GetDataCapNhat()
        {
            var id = string.IsNullOrEmpty(lblID.Text) ? 0 : int.Parse(lblID.Text);
            var soPhieu = string.IsNullOrEmpty(tbxSoPhieu.Text) ? 0 : int.Parse(tbxSoPhieu.Text);
            return new DiemDanh
            {
                ID = id,
                SoPhieu = soPhieu,
                HoTen = tbxHoTen.Text,
                Khoi = cbxKhoi.SelectedIndex,
                Info = tbxInfo.Text,
                Image = ImageUtil.DefaultTransform(ptbImage.Image)
            };
        }

        private async void BtnInsert_Click(object sender, EventArgs e)
        {
            var data = GetDataCapNhat();
            var result = await DiemDanhAPI.InsertDiemDanh(data);
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else if (!result)
                MessageBox.Show("Lỗi thêm dữ liệu điểm danh");
            else
            {
                GetListDiemDanh();
                MessageBox.Show("Thêm dữ liệu điểm danh thành công");
            }
                
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;
            var data = GetDataCapNhat();
            var result = await DiemDanhAPI.UpdateDiemDanh(data);
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else if (!result)
                MessageBox.Show("Lỗi cập nhật dữ liệu điểm danh");
            else
            {
                GetListDiemDanh();
                MessageBox.Show("Cập nhật dữ liệu điểm danh thành công");
            }
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var img = new Bitmap(dialog.FileName);
                        ptbImage.Image = img;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void DgvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                selectedRow = null;
                return;
            }
            selectedRow = dgvData.Rows[e.RowIndex].DataBoundItem as DiemDanh;
            lblID.Text = selectedRow.ID.ToString();
            tbxSoPhieu.Text = selectedRow.SoPhieu.ToString();
            tbxHoTen.Text = selectedRow.HoTen;
            cbxKhoi.SelectedIndex = selectedRow.Khoi;
            tbxInfo.Text = selectedRow.Info;
            ptbImage.Image = ImageUtil.FromByteArray(selectedRow.Image);
            ptbQrCode.Image = QRCodeUtil.ToBitmap(selectedRow.ID.ToString());
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            GetListDiemDanh();
        }

        private void DgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var data = dgvData.Rows[e.RowIndex].DataBoundItem as DiemDanh;
            var color = !data.Check1 ? Color.White : data.Check2 ? Color.LightGreen : Color.LightPink;
            dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu điểm danh không?", "Chú ý", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            var result = await DiemDanhAPI.DeleteDiemDanh(selectedRow.ID);
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else if (!result)
                MessageBox.Show("Lỗi xóa dữ liệu điểm danh");
            else
            {
                GetListDiemDanh();
                MessageBox.Show("Xóa dữ liệu điểm danh thành công");
            }
        }

        private void CbxKhoiFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diemDanhs == null)
                return;
            FilterListDiemDanh();
        }

        private async void BtnCheck_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;
            var result = await DiemDanhAPI.CheckDiemDanh(selectedRow.ID, selectedRow.Check2);
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else if (!result)
                MessageBox.Show("Lỗi cập nhật dữ liệu điểm danh");
            else
            {
                GetListDiemDanh();
                MessageBox.Show("Cập nhật dữ liệu điểm danh thành công");
            }
        }

        private async void BtnUnCheck_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
                return;
            var result = await DiemDanhAPI.UnCheckDiemDanh(selectedRow.ID);
            var error = DiemDanhAPI.Error;
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);
            else if (!result)
                MessageBox.Show("Lỗi cập nhật dữ liệu điểm danh");
            else
            {
                GetListDiemDanh();
                MessageBox.Show("Cập nhật dữ liệu điểm danh thành công");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = Enumerable.Range(1, 200).ToArray();
            foreach (var i in arr)
                File.WriteAllBytes(@"D:/" + i.ToString("000") + ".jpg", QRCodeUtil.ToByteArray(i.ToString()));
        }

        private void btnKQTT_Click(object sender, EventArgs e)
        {
            int TongSo = 0, Nu = 0, DangVien = 0, U30 = 0, U40 = 0, U50 = 0, U60 = 0,
                MaxTuoi = 0, MinTuoi = 999, PTTH = 0, TrungCap = 0, DaiHoc = 0, CaoHoc = 0,
                SCCT = 0, TCCT = 0, CCCT = 0, CNCT = 0, CapUy = 0, CongNhan = 0, CoMat = 0;
            double PNu = 0, PDangVien = 0, PU30 = 0, PU40 = 0, PU50 = 0, PU60 = 0,
                ATuoi = 0, PPTTH = 0, PTrungCap = 0, PDaiHoc = 0, PCaoHoc = 0, PSCCT = 0,
                PTCCT = 0, PCCCT = 0, PCNCT = 0, PCapUy = 0, PCongNhan = 0, PCoMat = 0;
            string MaxTuoiTen = ".", MinTuoiTen = ".";
            var diemDanh = dgvData.DataSource as List<DiemDanh>;
            TongSo = diemDanh.Count;
            if (TongSo == 0)
            {
                MessageBox.Show("Chưa có ai điểm danh!");
                return;
            }
            foreach (var d in diemDanh)
            {
                if (d.Check1)// && d.Check2
                {
                    CoMat++;
                    if (!d.GioiTinh)
                        Nu++;
                    if (d.NgayVaoDang == new DateTime(2000, 1, 1))
                        DangVien++;
                    var now = DateTime.Now;
                    var tuoi = now.Year - d.NgaySinh.Year;
                    if (now.AddYears(-tuoi) < d.NgaySinh)
                        tuoi--;
                    if (tuoi < 30)
                        U30++;
                    else if (tuoi <= 40)
                        U40++;
                    else if (tuoi <= 50)
                        U50++;
                    else if (tuoi <= 60)
                        U60++;
                    ATuoi += tuoi;
                    if (MaxTuoi < tuoi)
                    {
                        MaxTuoi = tuoi;
                        MaxTuoiTen = $"{d.HoTen} đại biểu Công đoàn thuộc {d.Phong}";
                    }
                    if (MinTuoi > tuoi)
                    {
                        MinTuoi = tuoi;
                        MinTuoiTen = $"{d.HoTen} đại biểu Công đoàn thuộc {d.Phong}";
                    }
                    if (d.TrinhDoVanHoa == 12)
                        PTTH++;
                    switch (d.TrinhDoChuyenMon)
                    {
                        case "Trung cấp":
                        case "Cao đẳng":
                            TrungCap++;
                            break;
                        case "Đại học":
                            DaiHoc++;
                            break;
                        case "Cao học":
                            CaoHoc++;
                            break;
                    }
                    switch (d.TrinhDoChinhTri)
                    {
                        case "Sơ cấp":
                            SCCT++;
                            break;
                        case "Trung cấp":
                            TCCT++;
                            break;
                        case "Cử nhân":
                            CNCT++;
                            break;
                        case "Cao cấp":
                            CCCT++;
                            break;
                    }
                    switch (d.Khoi)
                    {
                        case 1:
                            CapUy++;
                            break;
                        case 2:
                            CongNhan++;
                            break;
                    }
                }
            }
            ATuoi = Math.Round(1.0 * ATuoi / CoMat, 2);
            PNu = Math.Round(100.0 * Nu / CoMat, 2);
            PDangVien = Math.Round(100.0 * DangVien / CoMat, 2);
            PU30 = Math.Round(100.0 * U30 / CoMat, 2);
            PU40 = Math.Round(100.0 * U40 / CoMat, 2);
            PU50 = Math.Round(100.0 * U50 / CoMat, 2);
            PU60 = Math.Round(100.0 * U60 / CoMat, 2);
            PPTTH = Math.Round(100.0 * PTTH / CoMat, 2);
            PTrungCap = Math.Round(100.0 * TrungCap / CoMat, 2);
            PDaiHoc = Math.Round(100.0 * DaiHoc / CoMat, 2);
            PCaoHoc = Math.Round(100.0 * CaoHoc / CoMat, 2);
            PSCCT = Math.Round(100.0 * SCCT / CoMat, 2);
            PTCCT = Math.Round(100.0 * TCCT / CoMat, 2);
            PCCCT = Math.Round(100.0 * CCCT / CoMat, 2);
            PCNCT = Math.Round(100.0 * CNCT / CoMat, 2);
            PCapUy = Math.Round(100.0 * CapUy / CoMat, 2);
            PCongNhan = Math.Round(100.0 * CongNhan / CoMat, 2);
            PCoMat = Math.Round(100.0 * CoMat / TongSo, 2);
            var param = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("TongSo", TongSo.ToString()),
                new KeyValuePair<string, string>("Nu", Nu.ToString()),
                new KeyValuePair<string, string>("PNu", PNu.ToString()),
                new KeyValuePair<string, string>("DangVien", DangVien.ToString()),
                new KeyValuePair<string, string>("PDangVien", PDangVien.ToString()),
                new KeyValuePair<string, string>("U30", U30.ToString()),
                new KeyValuePair<string, string>("PU30", PU30.ToString()),
                new KeyValuePair<string, string>("U40", U40.ToString()),
                new KeyValuePair<string, string>("PU40", PU40.ToString()),
                new KeyValuePair<string, string>("U50", U50.ToString()),
                new KeyValuePair<string, string>("PU50", PU50.ToString()),
                new KeyValuePair<string, string>("U60", U60.ToString()),
                new KeyValuePair<string, string>("PU60", PU60.ToString()),
                new KeyValuePair<string, string>("ATuoi", ATuoi.ToString()),
                new KeyValuePair<string, string>("MaxTuoi", MaxTuoi.ToString()),
                new KeyValuePair<string, string>("MaxTuoiTen", MaxTuoiTen),
                new KeyValuePair<string, string>("MinTuoi", MinTuoi.ToString()),
                new KeyValuePair<string, string>("MinTuoiTen", MinTuoiTen),
                new KeyValuePair<string, string>("PTTH", PTTH.ToString()),
                new KeyValuePair<string, string>("TrungCap", TrungCap.ToString()),
                new KeyValuePair<string, string>("DaiHoc", DaiHoc.ToString()),
                new KeyValuePair<string, string>("CaoHoc", CaoHoc.ToString()),
                new KeyValuePair<string, string>("PPTTH", PPTTH.ToString()),
                new KeyValuePair<string, string>("PTrungCap", PTrungCap.ToString()),
                new KeyValuePair<string, string>("PDaiHoc", PDaiHoc.ToString()),
                new KeyValuePair<string, string>("PCaoHoc", PCaoHoc.ToString()),
                new KeyValuePair<string, string>("SCCT", SCCT.ToString()),
                new KeyValuePair<string, string>("TCCT", TCCT.ToString()),
                new KeyValuePair<string, string>("CCCT", CCCT.ToString()),
                new KeyValuePair<string, string>("CNCT", CNCT.ToString()),
                new KeyValuePair<string, string>("PSCCT", PSCCT.ToString()),
                new KeyValuePair<string, string>("PTCCT", PTCCT.ToString()),
                new KeyValuePair<string, string>("PCCCT", PCCCT.ToString()),
                new KeyValuePair<string, string>("PCNCT", PCNCT.ToString()),
                new KeyValuePair<string, string>("CapUy", CapUy.ToString()),
                new KeyValuePair<string, string>("CongNhan", CongNhan.ToString()),
                new KeyValuePair<string, string>("PCapUy", PCapUy.ToString()),
                new KeyValuePair<string, string>("PCongNhan", PCongNhan.ToString()),
                new KeyValuePair<string, string>("CoMat", CoMat.ToString()),
                new KeyValuePair<string, string>("PCoMat", PCoMat.ToString())
            };
            using (var viewer = new RdlcViewer("KQTT_CongDoan", null, param))
                viewer.ShowDialog();
        }
    }
}
