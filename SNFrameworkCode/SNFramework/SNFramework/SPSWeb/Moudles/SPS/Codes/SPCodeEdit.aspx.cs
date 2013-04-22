using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Code;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            SPCodeWrapper obj = SPCodeWrapper.FindById(Convert.ToInt32(this.Request.QueryString["CodeID"]));

            if (obj != null)
            {
                this.hidSPCodeID.Text = obj.Id.ToString();
                this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);

                this.chkIsMatchCase.Checked = obj.IsMatchCase.HasValue && obj.IsMatchCase.Value;

                this.txtMO.Text = ValueConvertUtil.ConvertStringValue(obj.Mo);

                this.lblCodeType.Text = obj.MoCode;

                this.txtSPCode.Text = ValueConvertUtil.ConvertStringValue(obj.SPCode);

                this.chkIsDiable.Checked = obj.IsDiable;

                this.chkLimitProvince.Checked =  obj.LimitProvince.HasValue &&  obj.LimitProvince.Value;


                if (obj.LimitProvince.HasValue && obj.LimitProvince.Value)
                {
                    if (!string.IsNullOrEmpty(obj.LimitProvinceArea))
                    {
                        WebUIHelper.SetSelectMutilItems(this.mfLimitProvinceArea, ",", obj.LimitProvinceArea);
                    }
                }

                this.chkHasPhoneLimit.Checked = obj.HasPhoneLimit;
                this.chkHasFilters.Checked = obj.HasFilters;
                this.chkHasParamsConvert.Checked = obj.HasParamsConvert;

                if(obj.Price.HasValue)
                    this.nfPrice.Value = obj.Price;
                else
                    this.nfPrice.Value = 0;

            }
        }


        protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPCodeWrapper obj = SPCodeWrapper.FindById(int.Parse(hidSPCodeID.Text.Trim()));

                obj.Description = this.txtDescription.Text.Trim();

                obj.IsMatchCase = chkIsMatchCase.Checked;

                if (!chkIsMatchCase.Checked)
                    obj.Mo = this.txtMO.Text.Trim();
                else
                    obj.Mo = this.txtMO.Text;
                obj.MOLength = obj.Mo.Length;

                obj.SPCode = this.txtSPCode.Text.Trim();
                obj.SPCodeLength = obj.SPCode.Length;

                obj.IsDiable = this.chkIsDiable.Checked;

                obj.LimitProvince = this.chkLimitProvince.Checked;

                string oldLimitProvinceArea = obj.LimitProvinceArea;





                obj.LimitProvinceArea = WebUIHelper.GetSelectMutilItems(this.mfLimitProvinceArea,",");


                if (obj.LimitProvinceArea != oldLimitProvinceArea)
                {
                    List<PhoneLimitAreaAssigned>  phoneLimitAreas = new List<PhoneLimitAreaAssigned>();

                    string[] provinces = obj.LimitProvinceArea.Split((",").ToCharArray());

                    foreach (string province in provinces)
                    {
                        phoneLimitAreas.Add(new PhoneLimitAreaAssigned() { AreaName = province, LimitCount = 0 });
                    }

                    obj.DayTotalLimitInProvinceAssignedCount = SerializeUtil.ToJson(phoneLimitAreas);
                }

                obj.HasPhoneLimit = this.chkHasPhoneLimit.Checked;

                obj.HasFilters = this.chkHasFilters.Checked;
                obj.HasParamsConvert = this.chkHasParamsConvert.Checked;
                obj.HasPhoneLimit = this.chkHasPhoneLimit.Checked;

                obj.Price = Convert.ToDecimal(this.nfPrice.Text.Trim());

                SPCodeWrapper.Update(obj);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
            }

        }
    }
}