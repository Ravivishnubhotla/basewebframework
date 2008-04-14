using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.Web.ControlHelper
{
    public static class DataBindHelper
    {
        public static void BindListDataToGridView<T>(GridView gridView, List<T> list)
        {
            if (list.Count == 0)
            {
                list.Add((T)Activator.CreateInstance(typeof(T)));
                gridView.DataSource = list;
                gridView.DataBind();
                int columnCount = gridView.Rows[0].Cells.Count;
                gridView.Rows[0].Cells.Clear();
                gridView.Rows[0].Cells.Add(new TableCell());
                gridView.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridView.Rows[0].Cells[0].Text = gridView.EmptyDataText;
                gridView.Rows[0].ApplyStyle(gridView.EmptyDataRowStyle);
            }
            else
            {
                gridView.DataSource = list;
                gridView.DataBind();
            }
        }

        public static void BindDataTableToGridView(GridView gridView, DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                DataTable tb = dt.Clone();
                tb.Rows.Add(tb.NewRow());
                gridView.DataSource = tb;
                gridView.DataBind();
                int columnCount = gridView.Rows[0].Cells.Count;
                gridView.Rows[0].Cells.Clear();
                gridView.Rows[0].Cells.Add(new TableCell());
                gridView.Rows[0].Cells[0].ColumnSpan = columnCount;
                gridView.Rows[0].Cells[0].Text = gridView.EmptyDataText;
                gridView.Rows[0].ApplyStyle(gridView.EmptyDataRowStyle);
            }
            else
            {
                gridView.DataSource = dt;
                gridView.DataBind();
            }
        }
    }
}
