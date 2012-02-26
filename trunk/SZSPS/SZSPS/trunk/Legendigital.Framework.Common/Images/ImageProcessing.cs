using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Legendigital.Framework.Common.Images
{
    public static class ImageProcessing
    {
        public const long CompressionLZW = (long)(EncoderValue.CompressionLZW);

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }

        private static Image[] SplitImage(Image img)
        {
            List<Image> imgArray = new List<Image>();
            for (int i = 0; i < img.GetFrameCount(FrameDimension.Page); i++)
            {
                img.SelectActiveFrame(FrameDimension.Page, i);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Tiff);
                imgArray.Add(Image.FromStream(ms));
            }
            return imgArray.ToArray();
        }




        public static int GetTifPageCount(Image tif)
        {
            return tif.GetFrameCount(FrameDimension.Page);
        }


        public static byte[] MergeImage(List<byte[]> tiffFiles, long compressionValue)
        {
            List<Image> imgs = new List<Image>();

            foreach (byte[] tifFile in tiffFiles)
            {
                Image img = Image.FromStream(new MemoryStream(tifFile));

                int pageCount = GetTifPageCount(img);

                if(pageCount == 1)
                {
                    imgs.Add(img);
                }
                else if (pageCount>1)
                {
                    Image[] spImages = SplitImage(img);
                    imgs.AddRange(spImages);
                }
            }
            return MergeImage(imgs.ToArray(), compressionValue);
        }

        private static byte[] MergeImage(Image[] joinImages, long compressionValue)
        {
            MemoryStream ms = new MemoryStream();

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(Encoder.Compression, compressionValue);

            Bitmap tifPage = (Bitmap)joinImages[0];

            ImageCodecInfo info = GetEncoderInfo("image/tiff");

            int frame = 0;

            foreach (Image imageFile in joinImages)
            {
                if (frame == 0)
                {
                    tifPage.Save(ms, info, ep);
                }
                else
                {
                    ep.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);

                    tifPage.SaveAdd(imageFile, ep);
                }

                if (frame == joinImages.Length - 1)
                {
                    ep.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
                    tifPage.SaveAdd(ep);
                }

                frame++;
            }
            return ms.ToArray();
        }

        public static byte[] MergeImage(List<byte[]> files, long compressionValue, int[] ids)
        {
            List<Image> imgs = new List<Image>();

            foreach (byte[] tifFile in files)
            {
                Image img = Image.FromStream(new MemoryStream(tifFile));

                int pageCount = GetTifPageCount(img);

                if (pageCount == 1)
                {
                    imgs.Add(img);
                }
                else if (pageCount > 1)
                {
                    Image[] spImages = SplitImage(img);
                    imgs.AddRange(spImages);
                }
            }

            List<Image> cimgs = new List<Image>();

            foreach (int id in ids)
            {
                cimgs.Add(imgs[id]);
            }

            return MergeImage(cimgs.ToArray(), compressionValue);
        }
    }
}
