using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;


namespace Legendigital.Common.Web.Moudles.SPS.Memos
{
   [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPMemoEdit")]
    public partial class UCSPMemoEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPMemoWrapper obj = SPMemoWrapper.FindById(id);

                if (obj != null)
                {
					              	this.txtTitle.Text = obj.Title.ToString();          	
              	this.txtMemoContent.Text = obj.MemoContent.ToString();
          	      if(obj.CreateDate.HasValue)
              	        this.txtCreateDate.SelectedDate = obj.CreateDate.Value;          	
 



                    hidId.Text = id.ToString();


                    winSPMemoEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPMemo_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPMemoWrapper obj = SPMemoWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Title = this.txtTitle.Text.Trim();
                obj.MemoContent = this.txtMemoContent.Text.Trim();
                obj.CreateDate = this.txtCreateDate.SelectedDate;


                SPMemoWrapper.Update(obj);

                winSPMemoEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }

}