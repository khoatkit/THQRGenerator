using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace THQRGenerator.Utils
{
    class ImageUtil
    {
        public static Image ScaleDown(Image img, double ratio)
        {
            if (img == null)
                return null;
            if (ratio > 1D)
                return img;
            int width = (int)Math.Round(ratio * img.Width);
            int height = (int)Math.Round(ratio * img.Height);
            return new Bitmap(img, new Size(width, height));
        }

        public static Image Rotate(Image img, int degree)
        {
            if (img == null)
                return null;
            RotateFlipType type;
            switch (degree)
            {
                case 90:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case 180:
                    type = RotateFlipType.Rotate180FlipNone;
                    break;
                case -90:
                case 270:
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    type = RotateFlipType.RotateNoneFlipNone;
                    break;
            }
            img.RotateFlip(type);
            return img;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public static byte[] Compress(Image img, long quality)
        {
            if (img == null)
                return null;
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 90L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, myImageCodecInfo, myEncoderParameters);
                return ms.ToArray();
            }
        }

        public static byte[] Transform(Image img, int quality, int maxImageSize)
        {
            if (img == null)
                return null;
            double ratio = 1D * maxImageSize / Math.Max(img.Width, img.Height);
            img = ScaleDown(img, ratio);
            if (img.Height < img.Width)
                img = Rotate(img, 90);
            return Compress(img, quality);
        }

        public static byte[] DefaultTransform(Image img)
        {
            return Transform(img, 90, 1500);
        }
        public static Bitmap FromByteArray(byte[] data)
        {
            if (data == null || data.Length == 0)
                return null;
            Bitmap result = new ImageConverter().ConvertFrom(data) as Bitmap;
            return result;
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public static byte[] ToByteArray(Image data)
        {
            using (var stream = new MemoryStream())
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(Encoder.Quality, 90L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                data.Save(stream, jpgEncoder, myEncoderParameters);
                return stream.ToArray();
            }
        }
    }
}
