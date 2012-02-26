using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;


namespace Legendigital.Common.Web.Moudles.SPS.Upers
{

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPUperEdit")]
    public partial class UCSPUperEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPUperWrapper obj = SPUperWrapper.FindById(id);

                if (obj != null)
                {
  	
              	this.txtName.Text = obj.Name.ToString();          	
              	this.txtDescription.Text = obj.Description.ToString();          	
         	
 



                    hidId.Text = id.ToString();


                    winSPUperEdit.Show();

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

        protected void btnSaveSPUper_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPUperWrapper obj = SPUperWrapper.FindById(int.Parse(hidId.Text.Trim()));

                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();

                SPUperWrapper.Update(obj);

                winSPUperEdit.Hide();
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