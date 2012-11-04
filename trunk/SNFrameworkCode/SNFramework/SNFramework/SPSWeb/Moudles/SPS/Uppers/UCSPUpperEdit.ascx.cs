  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Uppers
{




    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPUpperEdit")]
    public partial class UCSPUpperEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPUpperWrapper obj = SPUpperWrapper.FindById(id);

                if (obj != null)
                {
					this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);          	
              	    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);          	
              	    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);          	
 



                    hidId.Text = id.ToString();


                    winSPUpperEdit.Show();

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

        protected void btnSaveSPUpper_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPUpperWrapper obj = SPUpperWrapper.FindById(int.Parse(hidId.Text.Trim()));
          obj.Name = this.txtName.Text.Trim();        	
          obj.Code = this.txtCode.Text.Trim();        	
          obj.Description = this.txtDescription.Text.Trim();

          obj.LastModifyBy = CurrentLoginUser.UserID;
          obj.LastModifyAt = System.DateTime.Now;
          obj.LastModifyComment = "更新上家。";         	


                SPUpperWrapper.Update(obj);

                winSPUpperEdit.Hide();
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

