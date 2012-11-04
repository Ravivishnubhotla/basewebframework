  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Uppers
{


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPUpperView")]
    public partial class UCSPUpperView : BaseUserControl
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

                 

              	this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);          	
              	this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);          	
              	this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);          	
 
 




                        //hidLogID.Text = id.ToString();


                        winSPUpperView.Show();

                    }
                    else
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "错误信息：数据不存在t";
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


        }



}

