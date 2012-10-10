using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.Utility;

namespace SPSWeb.images
{
    /// <summary>
    /// Summary description for CheckCode
    /// </summary>
    /// <summary>
    /// Summary description for CheckCode
    /// </summary>
    public class CheckCode : IHttpHandler
    {
        public const string Key_CheckCode = "CheckCode";

        public static void SetCheckCode(string checkCode)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(Key_CheckCode, checkCode));
        }

        public static string GetCheckCode()
        {
            if (HttpContext.Current.Request.Cookies[Key_CheckCode] == null)
            {
                return "";
            }
            if (string.IsNullOrEmpty(HttpContext.Current.Request.Cookies[Key_CheckCode].Value))
            {
                return "";
            }
            return HttpContext.Current.Request.Cookies[Key_CheckCode].Value;
        }


        public void ProcessRequest(HttpContext context)
        {

            string checkCode = StringUtil.GetRandNumber(5);

            SetCheckCode(checkCode);

            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            using (Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    try
                    {
                        //生成随机生成器
                        Random random = new Random();
                        //清空图片背景色
                        g.Clear(Color.White);
                        //画图片的背景噪音线
                        for (int i = 0; i < 25; i++)
                        {
                            int x1 = random.Next(image.Width);
                            int x2 = random.Next(image.Width);
                            int y1 = random.Next(image.Height);
                            int y2 = random.Next(image.Height);
                            g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                        }
                        Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                        g.DrawString(checkCode, font, brush, 2, 2);
                        //画图片的前景噪音点
                        for (int i = 0; i < 100; i++)
                        {
                            int x = random.Next(image.Width);
                            int y = random.Next(image.Height);
                            image.SetPixel(x, y, Color.FromArgb(random.Next()));
                        }
                        //画图片的边框线
                        g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        context.Response.ClearContent();
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(ms.ToArray());
                    }
                    finally
                    {
                        g.Dispose();
                        image.Dispose();
                    }
                }
            }

            ;


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}