using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
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

                SysDictionaryWrapper.RefreshCache();

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


        private List<QueryFilter> GetQueryFilter(StoreRefreshDataEventArgs e)
        {
            //string s = e.Parameters[this.GridFilters1.ParamPrefix];

            List<QueryFilter> queryFilters = new List<QueryFilter>();

            //if (string.IsNullOrEmpty(s))
            //{
            //    return queryFilters;
            //}



            //FilterConditions fc = new FilterConditions(s);



            //foreach (FilterCondition condition in fc.Conditions)
            //{
            //    Comparison comparison = condition.Comparison;
            //    string field = condition.Name;
            //    FilterType type = condition.FilterType;

 
            //    switch (condition.FilterType)
            //    {
            //        case FilterType.Boolean:

            //            break;
            //        case FilterType.Date:

            //            break;
            //        case FilterType.List:

            //            List<string> inValues  = new List<string>();

            //            foreach (string s1 in condition.ValuesList)
            //            {
            //                inValues.Add(s1);
            //            }

            //            if(inValues.Count>0)
            //            {
            //                QueryFilter filter = new QueryFilter(SystemDictionaryWrapper.PROPERTY_NAME_SYSTEMDICTIONARYCATEGORYID, string.Join(",",inValues.ToArray()),FilterFunction.In);
            //                queryFilters.Add(filter);
            //            }


 
            //            break;
            //        case FilterType.Numeric:

            //            break;
            //        case FilterType.String:
 
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }


            //}

            return queryFilters;

        }



        protected void storeSystemDictionary_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e,this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            List<SystemDictionaryWrapper> datas = null;

            if(DictionaryGroup!=null)
            {
                datas = SystemDictionaryWrapper.FindAllByOrderByAndFilterAndSystemDictionaryGroupID(recordSortor.OrderByColumnName, recordSortor.IsDesc, DictionaryGroup, pageQueryParams);
            }
            else
            {
                datas = SystemDictionaryWrapper.FindAllByOrderByAndFilter(new List<QueryFilter>(), recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
            }

            storeSystemDictionary.DataSource = datas;
            e.Total = pageQueryParams.RecordCount;

            storeSystemDictionary.DataBind();

        }


        public SystemDictionaryGroupWrapper DictionaryGroup
        {
            get
            {
                if(this.Request.QueryString["DictionaryGroupID"]!=null)
                {
                    return
                        SystemDictionaryGroupWrapper.FindById(int.Parse(this.Request.QueryString["DictionaryGroupID"]));
                }
                return null;
            }
        }
    }

}
