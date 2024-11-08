using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using THQRGenerator.Models;

namespace THQRGenerator.Utils
{
    class QRCodeUtil
    {
        public static Bitmap ToBitmap(string data, bool logo = false)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage;
            if (logo)
                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, Properties.Resources.HoaSen3, 35, 1, true);
            else
                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, true);
            return qrCodeImage;
        }
        public static byte[] ToByteArray(string data, bool logo = false)
        {
            var qrCodeImage = ToBitmap(data, logo);
            var bytes = ImageUtil.ToByteArray(qrCodeImage);
            qrCodeImage.Dispose();
            return bytes;
        }
        public static QRCodeInfo ToQRCodeInfo(string noidDung, string moTa)
        {
            return new QRCodeInfo()
            {
                NoiDung = noidDung,
                MoTa = moTa,
                QRCodeByteArray = ToByteArray(noidDung, true)
            };
        }

        public static string Encrypt(string toEncrypt)
        {
            string key = "tanho@2022";
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static void ExportQrToFile(int count)
        {
            //var str = "https://service.cskhtanhoa.com.vn/KhachMoi/Index?id=";
            //for (int i = 357; i <= count; i++)
            //{
            //    var data = str + Encrypt(i.ToString());
            //    var img = ToBitmap(data, true);
            //    img.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            //    //File.AppendAllText(@"lst.txt", data + Environment.NewLine);
            //}

            //var str = "https://service.cskhtanhoa.com.vn/info.aspx?id=";
            //for (int i = 1; i <= count; i++)
            //{
            //    var img = ToBitmap(str + i.ToString(), false);
            //    img.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            //}

            var str = "https://service.cskhtanhoa.com.vn/info.aspx?id=";
            var lst = new string[] { "001", "002", "004", "016", "017", "019", "020", "021", "022", "023", "024", "025", "026", "030", "035", "036", "038", "044", "045", "047", "048", "050", "052", "056", "062", "063", "065", "068", "069", "072", "073", "074", "075", "076", "077", "078", "079", "081", "082", "084", "086", "087", "088", "089", "090", "091", "092", "094", "097", "098", "100", "101", "102", "103", "104", "105", "106", "107", "108", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "123", "124", "125", "126", "127", "129", "130", "131", "132", "135", "137", "138", "140", "141", "143", "144", "145", "146", "147", "148", "149", "150", "154", "155", "156", "157", "158", "159", "160", "161", "162", "163", "164", "165", "167", "169", "170", "172", "174", "176", "179", "182", "183", "184", "187", "188", "190", "192", "193", "194", "196", "197", "198", "199", "201", "202", "203", "204", "205", "207", "208", "209", "210", "211", "212", "213", "214", "215", "216", "219", "222", "223", "224", "225", "226", "227", "229", "230", "232", "233", "234", "236", "237", "239", "240", "241", "243", "246", "249", "250", "251", "252", "253", "255", "257", "258", "259", "265", "266", "267", "270", "271", "273", "275", "277", "279", "281", "283", "284", "285", "286", "287", "294", "295", "296", "298", "300", "301", "302", "304", "305", "306", "307", "308", "309", "310", "311", "312", "314", "315", "318", "319", "322", "324", "325", "326", "327", "328", "330", "332", "333", "335", "337", "338", "339", "340", "341", "342", "344", "345", "346", "347", "348", "349", "350", "351", "353", "354", "355", "357", "358", "360", "361", "362", "367", "370", "372", "375", "378", "382", "383", "385", "386", "387", "388", "389", "392", "393", "398", "399", "403", "404", "405", "406", "407", "408", "412", "413", "414", "417", "418", "419", "420", "422", "424", "427", "430", "431", "432", "434", "435", "436", "437", "438", "439", "440", "441", "445", "446", "448", "449", "451", "452", "453", "454", "455", "456", "457", "458", "459", "460", "461", "463", "464", "465", "466", "467", "468", "469", "470", "471", "472", "473", "474", "475", "476", "477", "478", "479", "480", "481" };
            foreach (var item in lst)
            {
                var img = ToBitmap(str + item, false);
                img.Save(item + ".jpg", ImageFormat.Jpeg);
            }

            //https://hochiminh.capnuoctanhoa.com.vn/
            //var img = ToBitmap("https://play.google.com/store/apps/details?id=com.tanhoa.tanhoacrm", true);
            //img.Save("QR_PlayStore.png");
            //img = ToBitmap("https://apps.apple.com/app/t%C3%A2n-h%C3%B2a-crm/id6450414018", true);
            //img.Save("QR_AppStore.png");

            //var img = ToBitmap("https://hochiminh.capnuoctanhoa.com.vn", true);
            //img.Save("QR_HoChiMinh.png");

            //https://api.qrserver.com/v1/create-qr-code/?size=600x600&data=
        }
    }
}
