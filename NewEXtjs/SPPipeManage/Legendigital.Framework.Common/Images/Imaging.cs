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
    public class Imaging
    {
        #region Const

        private const long CompressionValue = (long)(EncoderValue.CompressionLZW);//.CompressionLZW);

        #endregion

        #region private code

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


        public static Image[] SplitImage(Image img)
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

        public static Image ScaleImage(Image img, int xWith, int yHeight)
        {
            Image imgScale = new Bitmap(xWith, yHeight, PixelFormat.Format24bppRgb);
            
            Graphics g = Graphics.FromImage(imgScale);

            g.DrawImage(img, 0, 0, xWith, yHeight);
            
            g.Dispose();

            MemoryStream ms = new MemoryStream();

            imgScale.Save(ms, ImageFormat.Png);

            return Image.FromStream(ms);
        } 

        #endregion

        #region public

        public static byte[] SaveToMultipage(Image[] joinImages)
        {
            MemoryStream ms = new MemoryStream();

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)CompressionValue);

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

        public static Image GenerateTextImage(string text, Font drawFont, int width, int height, bool hasBorder)
        {
            float borderWidth = 0.0F;
            float fontAreaWidth;

            if (hasBorder)
            {
                borderWidth = 1.0F;
            }

            fontAreaWidth = (width - (text.Length + 1) * borderWidth) / text.Length;

            Bitmap newImage = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(newImage);

            if (hasBorder)
            {
                g.DrawRectangle(new Pen(Color.Black), borderWidth, borderWidth, width - 2 * borderWidth,
                                height - 2 * borderWidth);
            }

            int i = 0;

            foreach (char c in text.ToCharArray())
            {
                SizeF rectangleF = MeasureString(c.ToString(), drawFont);
                float x = (i + 1) * borderWidth + fontAreaWidth * i + (fontAreaWidth - rectangleF.Width) / 2;
                g.DrawString(c.ToString(), drawFont, new SolidBrush(Color.Black), x,
                             borderWidth + (height - rectangleF.Height) / 2);

                if (hasBorder)
                {
                    g.DrawLine(new Pen(Color.Black), (i + 1) * borderWidth + (i + 1) * fontAreaWidth, borderWidth,
                               (i + 1) * borderWidth + (i + 1) * fontAreaWidth, height);
                }

                i++;
            }

            g.Dispose();

            return newImage;
        }

        private static SizeF MeasureString(string str, Font drawFont)
        {
            Bitmap image = new Bitmap(800, 600);

            Graphics g = Graphics.FromImage(image);

            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF sf = g.MeasureString(str, drawFont);

            g.Dispose();

            return sf;
        }

        public static byte[] JoinImages(byte[] imageFirst, byte[] imageSecond)
        {
            Image imgFirst = null, imgSecond = null;
            imgFirst = Image.FromStream(new MemoryStream(imageFirst));

            if (imageSecond != null)
            { imgSecond = Image.FromStream(new MemoryStream(imageSecond)); }

            List<Image> imgArray = new List<Image>();

            imgArray.AddRange(SplitImage(imgFirst));

            if (imageSecond != null)
            { imgArray.AddRange(SplitImage(imgSecond)); }

            return SaveToMultipage(imgArray.ToArray());
        }

        //public static byte[] BuildMark(byte[] imgFile, byte[] markFile, ImageFormat imageFormat, float x, float y,bool convertTo1bpp)
        //{
        //    return BuildMark(ByteArrayToImage(imgFile), ByteArrayToImage(markFile), x, y, convertTo1bpp);
        //}

        //public static Bitmap ConvertTo1bpp(Bitmap img)
        //{
        //    BitmapData bmdo = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);
        //    // and the new 1bpp bitmap    
        //    Bitmap bm = new Bitmap(img.Width, img.Height, PixelFormat.Format1bppIndexed);
        //    BitmapData bmdn = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
        //    // scan through the pixels Y by X    
        //    for (int y = 0; y < img.Height; y++)
        //    {
        //        for (int x = 0; x < img.Width; x++)
        //        {
        //            // generate the address of the colour pixel            
        //            int index = y * bmdo.Stride + x * 4;
        //            // check its brightness            
        //            if (Color.FromArgb(Marshal.ReadByte(bmdo.Scan0, index + 2), Marshal.ReadByte(bmdo.Scan0, index + 1), Marshal.ReadByte(bmdo.Scan0, index)).GetBrightness() > 0.5F)
        //            {
        //                SetIndexedPixel(x, y, bmdn, true);
        //                // set it if its bright.           
        //            }
        //        }
        //    }
        //    // tidy up    
        //    bm.UnlockBits(bmdn);
        //    img.UnlockBits(bmdo);
        //    bm.SetResolution(img.HorizontalResolution, img.VerticalResolution);
        //    return bm;
        //}

        //private static void SetIndexedPixel(int x, int y, BitmapData bmd, bool pixel)
        //{
        //    int index = y * bmd.Stride + (x >> 3);
        //    byte p = Marshal.ReadByte(bmd.Scan0, index);
        //    byte mask = (byte)(0x80 >> (x & 0x7));
        //    if (pixel)
        //    {
        //        p |= mask;
        //    }
        //    else
        //    {
        //        p &= (byte)(mask ^ 0xFF);
        //    }

        //    Marshal.WriteByte(bmd.Scan0, index, p);
        //}


        //public static byte[] BuildMark(Image imgFile, Image markFile, float x, float y, bool convertTo1bpp)
        //{
        //    //Image[] images = SplitImage(imgFile);

        //    byte[] result = null;
        //    Bitmap bmp = new Bitmap(imgFile);

        //    Graphics gPrimalClothing = Graphics.FromImage(bmp);

        //    gPrimalClothing.DrawImage(markFile, x, y);
        //    gPrimalClothing.Dispose();

        //    bmp.SetResolution(imgFile.HorizontalResolution, imgFile.VerticalResolution);

        //    if (convertTo1bpp)
        //    {
        //        result = ImageToByteArray(ConvertTo1bpp(bmp), ImageFormat.Tiff);
        //    }
        //    else
        //    {
        //        result = ImageToByteArray(bmp, ImageFormat.Tiff);
        //    }

        //    return JoinImages(result, null);
        //}

        //public static byte[] AppendMark(Image imgFile, Image markFile, int topMarkMargin, int leftMarkMargin, int bottomMarkMargin, bool convertTo1bpp)
        //{
        //    byte[] result = null;
        //    int width = imgFile.Width;
        //    int height = topMarkMargin + markFile.Height + bottomMarkMargin + imgFile.Height;

        //    Bitmap imageCloth = new Bitmap(width, height);

        //    Graphics g = Graphics.FromImage(imageCloth);
        //    g.Clear(Color.White);

        //    g.DrawImage(markFile, leftMarkMargin, topMarkMargin, markFile.Width, markFile.Height);
        //    g.DrawImage(imgFile, 0, topMarkMargin + markFile.Height + bottomMarkMargin, imgFile.Width, imgFile.Height);

        //    g.Dispose();

        //    imageCloth.SetResolution(imgFile.HorizontalResolution, imgFile.VerticalResolution);


        //    if (convertTo1bpp)
        //    {
        //        result = ImageToByteArray(ConvertTo1bpp(imageCloth), ImageFormat.Tiff);
        //    }
        //    else
        //    {
        //        result = ImageToByteArray(imageCloth, ImageFormat.Tiff);
        //    }

        //    return JoinImages(result, null);

        //}


        public static Image ByteArrayToImage(byte[] imageContent)
        {
            return Image.FromStream(new MemoryStream(imageContent));
        }

        public static byte[] ImageToByteArray(Image image, ImageFormat imageFormat)
        {

            if (image.GetFrameCount(FrameDimension.Page) > 1)
            {
                if (imageFormat != ImageFormat.Tiff)
                {
                    throw new Exception("Invalid image format!");
                }

                Image[] pages = SplitImage(image);
                return SaveToMultipage(pages);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, imageFormat);
                return ms.ToArray();
            }
        }

        #endregion
    }
}
