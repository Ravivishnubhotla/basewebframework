using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;

namespace Legendigital.Common.Web.Moudles.SystemManage.LogViews
{
    public partial class TextLogList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPChannel.Reload();
        }


        protected void storeFiles_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            DataTable dt = GetFiles(this.Server.MapPath("~/Logs/"), "*.log");

             PagedDataSource objPds = new PagedDataSource(); 
             objPds.DataSource = dt.DefaultView; 
             objPds.AllowPaging = true; 
             objPds.PageSize = limit;
            objPds.CurrentPageIndex = pageIndex-1;






            storeFiles.DataSource = objPds;
            e.TotalCount = dt.Rows.Count;

            storeFiles.DataBind();

        }


        private DataTable GetFiles(string path,string name)
        {
            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("FileID")   { ColumnName = "FileID",    DataType = typeof(int) },
                new DataColumn("NID")   { ColumnName = "NID",    DataType = typeof(int) },
                new DataColumn("FilePath")   { ColumnName = "FilePath",    DataType = typeof(string) },
                new DataColumn("FileName")     { ColumnName = "FileName",      DataType = typeof(string) },
                new DataColumn("FileExt")    { ColumnName = "FileExt",     DataType = typeof(string) }
            });

            string[] fileNames = Directory.GetFiles(path, name);

            int i = 0;

            foreach (string fileName in fileNames)
            {
                i++;

                DataRow dr = table.NewRow();
                
                dr.BeginEdit();

                dr["FileID"] = fileName.GetHashCode();
                dr["NID"] = i.ToString();
                dr["FilePath"] = fileName;
                dr["FileName"] = Path.GetFileName(fileName);
                dr["FileExt"] = Path.GetExtension(fileName);

                dr.EndEdit();

                table.Rows.Add(dr);
            }
  
            table.AcceptChanges();

            return table;
        }
    }
}