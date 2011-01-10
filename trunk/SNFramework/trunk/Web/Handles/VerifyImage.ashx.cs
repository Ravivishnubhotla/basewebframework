using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Web.AppCode;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;

namespace Web.Handles
{
    /// <summary>
    /// Summary description for VerifyImage
    /// </summary>
    public class VerifyImage : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/gif";
            //建立Bitmap对象，绘图
            Bitmap basemap = new Bitmap(200, 60);
            Graphics graph = Graphics.FromImage(basemap);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();
            string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ";
            string letter;
            StringBuilder s = new StringBuilder();

            //添加随机的五个字母
            for (int x = 0; x < 5; x++)
            {
                letter = letters.Substring(r.Next(0, letters.Length - 1), 1);
                s.Append(letter);
                graph.DrawString(letter, font, new SolidBrush(Color.Black), x * 38, r.Next(0, 15));
            }

            //混淆背景
            Pen linePen = new Pen(new SolidBrush(Color.Black), 2);
            for (int x = 0; x < 6; x++)
                graph.DrawLine(linePen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));

            //将图片保存到输出流中       
            basemap.Save(context.Response.OutputStream, ImageFormat.Gif);
            context.Session[BasePage.Session_Key_ValidateString] = s.ToString();   //如果没有实现IRequiresSessionState，则这里会出错，也无法生成图片
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return true; }
        }

    }
}