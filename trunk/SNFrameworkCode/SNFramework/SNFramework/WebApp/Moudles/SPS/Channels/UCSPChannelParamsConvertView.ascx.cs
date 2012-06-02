using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsConvertView")]
    public partial class UCSPChannelParamsConvertView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            //try
            //{
            //    SPChannelParamsConvertWrapper obj = SPChannelParamsConvertWrapper.FindById(id);

            //    if (obj != null)
            //    {



            //        this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
            //        this.lblParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);
            //        this.lblParamsConvertTo.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertTo);
            //        this.lblParamsConvertType.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertType);
            //        this.lblParamsConvertCondition.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertCondition);
            //        this.lblChannelID.Text = obj.ChannelID.ToString();
            //        this.lblCreateBy.Text = obj.CreateBy.ToString();
            //        this.lblCreateAt.Text = obj.CreateAt.ToString();
            //        this.lblLastModifyBy.Text = obj.LastModifyBy.ToString();
            //        this.lblLastModifyAt.Text = obj.LastModifyAt.ToString();





            //        //hidLogID.Text = id.ToString();


            //        winSPChannelParamsConvertView.Show();

            //    }
            //    else
            //    {
            //        ResourceManager.AjaxSuccess = false;
            //        ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ResourceManager.AjaxSuccess = false;
            //    ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            //    return;
            //}
        }


    }




}