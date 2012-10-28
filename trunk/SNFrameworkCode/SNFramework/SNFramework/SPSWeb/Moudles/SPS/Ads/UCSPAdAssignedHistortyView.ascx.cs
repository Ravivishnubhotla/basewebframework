  

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


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdAssignedHistortyView")]
    public partial class UCSPAdAssignedHistortyView : System.Web.UI.UserControl
    {


            protected void Page_Load(object sender, EventArgs e)
            {

            }


            [DirectMethod]
            public void Show(int id)
            {
                try
                {
                    SPAdAssignedHistortyWrapper obj = SPAdAssignedHistortyWrapper.FindById(id);

                    if (obj != null)
                    {

                 

              	this.lblSPAdID.Text = obj.SPAdID.ToString();          	
              	this.lblSPAdPackID.Text = obj.SPAdPackID.ToString();          	
              	this.lblSPClientID.Text = obj.SPClientID.ToString();          	
              	this.lblStartDate.Text = obj.StartDate.ToString();          	
              	this.lblEndDate.Text = obj.EndDate.ToString();          	
              	this.lblCreateBy.Text = obj.CreateBy.ToString();          	
              	this.lblCreateAt.Text = obj.CreateAt.ToString();          	
              	this.lblLastModifyBy.Text = obj.LastModifyBy.ToString();          	
              	this.lblLastModifyAt.Text = obj.LastModifyAt.ToString();          	
              	this.lblLastModifyComment.Text = ValueConvertUtil.ConvertStringValue(obj.LastModifyComment);          	
 




                        //hidLogID.Text = id.ToString();


                        winSPAdAssignedHistortyView.Show();

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

