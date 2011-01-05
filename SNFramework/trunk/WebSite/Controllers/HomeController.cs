using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    [HandleError]
    public class HomeController : BaseMVCControler
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

        public FileContentResult GetValidateImage()
        {
            int validateStringLength = 5;

            Bitmap bmp = new Bitmap(200, 60);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.YellowGreen), 0, 0, 200, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();

            //合法随机显示字符列表
            string strLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder s = new StringBuilder();

            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < validateStringLength; i++)
            {
                s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
                g.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(Color.Blue), i * 38, r.Next(0, 15));
            }

            //生成干扰线条
            Pen pen = new Pen(new SolidBrush(Color.Blue), 1);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(pen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            }

            this.Session[Session_Key_ValidateString] = s.ToString();

            MemoryStream ms = new MemoryStream();

            bmp.Save(ms, ImageFormat.Gif);

            return File(ms.GetBuffer(), "image/JPEG");
        }

        

        
    }
}
