using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SPS.Memos
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPMemoEdit")]
    public partial class UCSPMemoEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPMemoWrapper obj = SPMemoWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtTitle.Text = obj.Title.ToString();
                    this.txtMemoContent.Text = obj.MemoContent.ToString();




                    hidId.Text = id.ToString();


                    winSPMemoEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在！";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPMemo_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPMemoWrapper obj = SPMemoWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Title = this.txtTitle.Text.Trim();
                obj.MemoContent = this.txtMemoContent.Text.Trim();


                SPMemoWrapper.Update(obj);

                winSPMemoEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}