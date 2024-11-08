using System;
using System.Drawing;

namespace THQRGenerator.Models
{
    class DiemDanh
    {
        public int ID { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public int SoPhieu { get; set; }
        public string HoTen { get; set; }
        public string Ten
        {
            get
            {
                var idx = HoTen.LastIndexOf(' ');
                return HoTen.Substring(idx + 1);
            }
        }
        public string Info { get; set; }
        public string Phong { get; set; }
        public int Khoi { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public int TrinhDoVanHoa { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string TrinhDoChinhTri { get; set; }
        public byte[] Image { get; set; }
        public byte[] QRCode { get; set; }
    }
}
