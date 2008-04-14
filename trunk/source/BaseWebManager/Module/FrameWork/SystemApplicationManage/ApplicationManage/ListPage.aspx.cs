using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BaseWebManager.UC;
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ListFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Web.ControlHelper;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class ListPage : SystemApplicationListUIPage
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListBind();
            }
        }

        private void ListBind()
        {
            int record = 0;
            List<SystemApplication> list =
                 systemApplicationServiceInstance.GetAll(this.Pager.StartRecordIndex - 1, this.Pager.PageSize, out record);
            DataBindHelper.BindListDataToGridView<SystemApplication>(this.GridView1, list);
            this.Pager.RecordCount = record;

        }



        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            ListBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.GoToAddPage();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Sort")
                return;
            this.ProcessGridCmd(sender, e);
            ListBind();
        }

        //protected void GridView1_Sorted(object sender, EventArgs e)
        //{
        //    this.Response.Write(this.GridView1.SortExpression + "_______" + this.GridView1.SortDirection);
        //    //this.GridView1.s
        //    //ListBind();
        //}

        //protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    this.Response.Write(this.GridView1.SortExpression + "_______" + this.GridView1.SortDirection);
        //    //ListBind();
        //}
    }


}