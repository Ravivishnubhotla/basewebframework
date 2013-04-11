using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace SNFramework.BSF.Moudles.SystemManage.FileManage
{
    public partial class DialogFileUploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">实际存储名称</param>
        /// <param name="fileClientName">原始名称</param>
        [DirectMethod]
        public void DeleteFile(string fileName, string fileClientName)
        {
            try
            {
                System.IO.File.Delete(fileName);
                X.Msg.Notify("提示", fileClientName + "已删除!").Show();
            }
            catch (Exception ex)
            {
                X.Msg.Notify("提示", fileClientName + "删除失败!").Show();
            }
        }
    }
}