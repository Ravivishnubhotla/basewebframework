using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Ads
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdPackView")]
    public partial class UCSPAdPackView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPAdPackWrapper obj = SPAdPackWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblID.Text = obj.Id.ToString();
                    this.lblSPAdID.Text = obj.SPAdID.ToString();
                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);





                    //hidLogID.Text = id.ToString();


                    winSPAdPackView.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }


    }



}