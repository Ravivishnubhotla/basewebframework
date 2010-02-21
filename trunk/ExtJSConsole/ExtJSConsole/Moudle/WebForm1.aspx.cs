using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using ExtJSConsole.WebCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SortDirection=Coolite.Ext.Web.SortDirection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace ExtJSConsole.Moudle
{
    public partial class WebForm1 : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Ext.IsAjaxRequest)
                return;
        }

        [AjaxMethod]
        public void NewRecord()
        {
            this.WebUserControl51.Show();
        }

        [AjaxMethod]
        public void ShowSearch()
        {
            this.WebUserControl31.Show();
        }

        [AjaxMethod]
        public void DeleteSelect()
        {
            RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;

            ArrayList ids = new ArrayList();
            foreach (SelectedRow row in sm.SelectedRows)
            {
                ids.Add(int.Parse(row.RecordID));
            }

            SystemApplicationWrapper.PatchDeleteByIDs(ids.ToArray());

            ReLoadData();
        }

        [AjaxMethod]
        public void Processcmd(string cmdName, int id)
        {
            if(cmdName.ToUpper() == "EDIT")
            {
                SystemApplicationWrapper systemApplicationWrapper = SystemApplicationWrapper.FindById(id);
                if (systemApplicationWrapper!=null)
                {
                    this.WebUserControl11.BindDate(systemApplicationWrapper);
                    this.WebUserControl11.Show();
                }
                else
                {
                    Ext.Msg.Alert("错误", "数据不存在");
                }
            }
        }

        public List<QueryFilter> SimpleFilter
        {
            get
            {
                if (this.ViewState["SimpleFilter"] == null)
                    this.ViewState["SimpleFilter"] = new List<QueryFilter>();
                return (List<QueryFilter>)this.ViewState["SimpleFilter"];
            }
            set
            {
                this.ViewState["SimpleFilter"] = value;
            }
        }



        public void ReLoadData()
        {
            this.GridPanel1.Reload();
        }


        protected void Store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            //Console.WriteLine(e.Parameters["xxx"].ToString());
            int recordCount = 0;
            string sortFieldName = "";
            if(e.Sort!=null)
                sortFieldName = e.Sort;
            Store1.DataSource = SystemApplicationWrapper.SelectMethod(e.Start, e.Limit, sortFieldName, (e.Dir == SortDirection.DESC), out recordCount);
            e.TotalCount = recordCount;

            Store1.DataBind();
        }

    }
}
