using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.Web.Moudles.SPS.Memos
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPMemoAdd")]
    public partial class UCSPMemoAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPMemoAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPMemo_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPMemoWrapper obj = new SPMemoWrapper();
                obj.Title = this.txtTitle.Text.Trim();
                obj.MemoContent = this.txtMemoContent.Text.Trim();
                obj.CreateDate = this.txtCreateDate.SelectedDate;





                SPMemoWrapper.Save(obj);

                winSPMemoAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

    }

}