﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.TerminologyManage
{
    public partial class SystemTerminologyListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.gridPanelSystemTerminology.Reload();
        }

        protected void storeSystemTerminology_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSystemTerminology.DataSource = SystemTerminologyWrapper.FindAllByCode(TerminologyCode);
 
            storeSystemTerminology.DataBind();
        }


        protected void Save_SystemTerminology(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            List<SystemTerminologyWrapper> allSavedata = JSON.Deserialize<List<SystemTerminologyWrapper>>(json);

            foreach (SystemTerminologyWrapper systemTerminology in allSavedata)
            {
                SystemTerminologyWrapper up = SystemTerminologyWrapper.FindById(systemTerminology.Id);

                up.Text = systemTerminology.Text;
                up.Description = systemTerminology.Description;


                SystemTerminologyWrapper.Update(up);
            }

            SystemTerminologyWrapper.ResetData();
        }

        public string TerminologyCode
        {
            get
            {
                if (this.Request.QueryString["TerminologyCode"] != null)
                {
                    if (this.Request.QueryString["TerminologyCode"].ToLower().StartsWith("[l]"))
                        return this.Request.QueryString["TerminologyCode"].Remove(0,3);
                    return this.Request.QueryString["TerminologyCode"];
                }
                return "";
            }
        }
    }
}