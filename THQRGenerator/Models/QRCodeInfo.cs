using System.Drawing;

namespace THQRGenerator.Models
{
    class QRCodeInfo
    {
        public string NoiDung { get; set; }
        public string MoTa { get; set; }
        public byte[] QRCodeByteArray { get; set; }
    }
}
