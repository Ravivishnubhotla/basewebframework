﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage
{

    public partial class SystemDictionaryListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;


            this.gridPanelSystemDictionary.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SystemDictionaryWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemDictionary_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
  
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;

            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSystemDictionary.DataSource = SystemDictionaryWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemDictionary.DataBind();

        }
    }

}
