using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;

namespace Legendigital.Framework.Common.Web.ControlHelper
{
    public static class GridViewHelper
    {
        public static T FindTypedControlInRow<T>(string controlid, GridViewRow row) where T : Control
        {
            foreach (TableCell cell in row.Cells)
            {
                Control c = cell.FindControl(controlid);
                if (c != null)
                {
                    return (T)c;
                }
            }
            return default(T);
        }

        public static Control FindControlInRow(string controlid, GridViewRow row)
        {
            foreach (TableCell cell in row.Cells)
            {
                Control c = cell.FindControl(controlid);
                if (c != null)
                {
                    return (Control)c;
                }
            }
            return null;
        }

        public static int GetDataKeyInGridViewRowCommandEvent(object sender, GridViewCommandEventArgs e)
        {
            GridView grd = (GridView)sender;
            GridViewRow row = ((Control)(e.CommandSource)).Parent.Parent as GridViewRow;
            return int.Parse(grd.DataKeys[row.RowIndex].Value.ToString());
        }


        public static void ExportGrid(GridView gv, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }

        


    }
}