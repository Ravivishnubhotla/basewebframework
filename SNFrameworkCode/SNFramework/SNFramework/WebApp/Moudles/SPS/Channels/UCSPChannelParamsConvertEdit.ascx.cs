using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{



    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsConvertEdit")]
    public partial class UCSPChannelParamsConvertEdit : System.Web.UI.UserControl
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
            //        this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
            //        this.txtParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);
            //        this.txtParamsConvertTo.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertTo);
            //        this.txtParamsConvertType.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertType);
            //        this.txtParamsConvertCondition.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsConvertCondition);
            //        this.txtChannelID.Text = obj.ChannelID.ToString();
            //        this.txtCreateBy.Text = obj.CreateBy.ToString();
            //        this.txtCreateAt.Text = obj.CreateAt.ToString();
            //        this.txtLastModifyBy.Text = obj.LastModifyBy.ToString();
            //        this.txtLastModifyAt.Text = obj.LastModifyAt.ToString();




            //        hidId.Text = id.ToString();


            //        winSPChannelParamsConvertEdit.Show();

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
            //    ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            //    return;
            //}
        }

        protected void btnSaveSPChannelParamsConvert_Click(object sender, DirectEventArgs e)
        {
            //try
            //{
            //    SPChannelParamsConvertWrapper obj = SPChannelParamsConvertWrapper.FindById(int.Parse(hidId.Text.Trim()));
            //    obj.Name = this.txtName.Text.Trim();
            //    obj.ParamsValue = this.txtParamsValue.Text.Trim();
            //    obj.ParamsConvertTo = this.txtParamsConvertTo.Text.Trim();
            //    obj.ParamsConvertType = this.txtParamsConvertType.Text.Trim();
            //    obj.ParamsConvertCondition = this.txtParamsConvertCondition.Text.Trim();
 
            //    obj.CreateBy = Convert.ToInt32(this.txtCreateBy.Text.Trim());
            //    obj.CreateAt = UIHelper.SaftGetDateTime(this.txtCreateAt.Text.Trim());
            //    obj.LastModifyBy = Convert.ToInt32(this.txtLastModifyBy.Text.Trim());
            //    obj.LastModifyAt = UIHelper.SaftGetDateTime(this.txtLastModifyAt.Text.Trim());


            //    SPChannelParamsConvertWrapper.Update(obj);

            //    winSPChannelParamsConvertEdit.Hide();
            //    ResourceManager.AjaxSuccess = true;
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