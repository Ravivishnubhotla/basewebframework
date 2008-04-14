using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.ControlHelper;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public abstract class BaseDataListPage<DomainType> : BaseDataManagePage
    {
        protected void ProcessGridCmd(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = ((Control)(e.CommandSource)).Parent.Parent as GridViewRow;
            if (row == null || row.RowType != DataControlRowType.DataRow)
                return;
            int id = GridViewHelper.GetDataKeyInGridViewRowCommandEvent(sender, e);
            DomainType obj = LoadDataByID(id);
            if (obj != null)
            {
                switch (e.CommandName)
                {
                    case "cmdView":
                        this.Response.Redirect(this.GetViewPageUrl()+"?"+this.GetIDQueryStringKey()+"=" + GetDomainID(obj));
                        break;
                    case "cmdDelete":
                        DeleteDataByID(GetDomainID(obj));
                        WebMessageBox.ShowOperationOkMessage("操作成功", "用户成功的删除了一条记录。", this.ResolveUrl(this.GetListPageUrl()));
                        break;
                    default:
                        break;
                }
            }
        }

        protected void GoToAddPage()
        {
            this.Response.Redirect(this.GetAddPageUrl());
        }

        protected abstract DomainType LoadDataByID(int id);

        protected abstract void DeleteDataByID(int id);

        protected abstract int GetDomainID(DomainType obj);

        //protected abstract GridView GridView1;
        //protected abstract GridView Pager;

    }
}
