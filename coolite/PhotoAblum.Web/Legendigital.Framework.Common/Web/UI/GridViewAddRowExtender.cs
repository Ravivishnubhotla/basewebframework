using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Web.ControlHelper;
using Legendigital.Framework.Common.Web.Designer;


namespace Legendigital.Framework.Common.Web.UI
{
    /// <summary>
    /// 允许表格动态添加行的GridView扩展控件
    /// </summary>
    [Designer(typeof(Designer.GridViewExtenderDesigner))]
    public class GridViewAddRowExtender : Control
    {

        public const string AttributesNameIsSaveControlData = "IsSaveControlData";

        private GridView extenderGrid = null;
        private List<string> ControlIDLists
        {
            get
            {
                if (ViewState["ControlIDLists"] == null)
                    ViewState["ControlIDLists"] = new List<string>();
                return (List<string>)this.ViewState["ControlIDLists"];
            }

            set { ViewState["ControlIDLists"] = value; }
        }

        [Themeable(false)]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(GridView))]
        [TypeConverter(typeof(GridViewIDConverter))]
        [Description("The GridView that is extended.")]
        public string TargetGridViewID
        {
            get { return (string)ViewState["TargetGridViewID"]; }

            set { ViewState["TargetGridViewID"] = value; }
        }

        private readonly string ControlValueItenTableName = "ControlValueItenTable";

        [Browsable(false)]
        private DataTable ControlValueItenTable
        {
            get
            {
                if (this.ViewState[ControlValueItenTableName] == null)
                    InitalData();
                return (DataTable)ViewState[ControlValueItenTableName];
            }
            set
            {
                ViewState[ControlValueItenTableName] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (string.IsNullOrEmpty(this.TargetGridViewID.Trim()))
                throw new ArgumentNullException("TargetGridViewID", "TargetGridViewID not allow null.");

            extenderGrid = (GridView)this.Parent.FindControl(TargetGridViewID);

            extenderGrid.RowDataBound += new GridViewRowEventHandler(OnRowDataBound);

        }


        private void OnRowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null || e.Row.DataItem.GetType() != typeof(DataRowView))
            {
                return;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].ColumnSpan == this.extenderGrid.Columns.Count)
                {
                    return;
                }
                else
                {
                    foreach (string controlID in this.ControlIDLists)
                    {
                        Control c = GridViewHelper.FindControlInRow(controlID, e.Row);
                        if (c != null)
                            SaveDataToControl(c, (DataRowView)(e.Row.DataItem));
                    }
                }
            }
        }


        public T FindControlInRow<T>(string controlid, GridViewRow row) where T : Control
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

        private void SaveDataToControl(Control c, DataRowView dr)
        {
            if (c is Label)
                ((Label)c).Text = dr[c.ID].ToString();
            if (c is HiddenField)
                ((HiddenField)c).Value = dr[c.ID].ToString();
            if (c is TextBox)
                ((TextBox)c).Text = dr[c.ID].ToString();
            if (c is DropDownList)
                ((DropDownList)c).SelectedValue = dr[c.ID].ToString();
            if (c is HtmlInputText)
                ((HtmlInputText)c).Value = dr[c.ID].ToString();
            if (c is HtmlInputFile)
                ((HtmlInputFile)c).Value = dr[c.ID].ToString();
            if (c is HtmlInputCheckBox)
            {
                string boolValue = dr[c.ID].ToString();
                if (boolValue == "")
                {
                    ((HtmlInputCheckBox)c).Checked = false;
                }
                else
                {
                    ((HtmlInputCheckBox)c).Checked = bool.Parse(boolValue);
                }
            }

            if (c is HtmlTextArea)
                ((HtmlTextArea)c).Value = dr[c.ID].ToString();
            if (c is HtmlInputHidden)
                ((HtmlInputHidden)c).Value = dr[c.ID].ToString();
            if (c is HtmlSelect)
                ((HtmlSelect)c).Value = dr[c.ID].ToString();
            if (c is CheckBox)
            {
                string boolValue = dr[c.ID].ToString();
                if (boolValue == "")
                {
                    ((CheckBox)c).Checked = false;
                }
                else
                {
                    ((CheckBox)c).Checked = bool.Parse(boolValue);
                }
            }
        }

        private void InitalData()
        {
            ArrayList al = new ArrayList();
            al.Add("1");
            extenderGrid.DataSource = al;
            extenderGrid.DataBind();
            extenderGrid.DataKeyNames = new string[] { "GridViewRowDataID" };

            foreach (GridViewRow row in extenderGrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell s in row.Cells)
                    {
                        foreach (Control c in s.Controls)
                        {
                            if (!(c is WebControl) && !(c is HtmlControl))
                                continue;
                            if (c is WebControl)
                            {
                                WebControl wc = (WebControl)c;
                                if (wc.Attributes[AttributesNameIsSaveControlData] != null && wc.Attributes[AttributesNameIsSaveControlData].ToUpper() == bool.FalseString.ToUpper())
                                    continue;
                            }
                            if (c is HtmlControl)
                            {
                                HtmlControl wc = (HtmlControl)c;
                                if (wc.Attributes[AttributesNameIsSaveControlData] != null && wc.Attributes[AttributesNameIsSaveControlData].ToUpper() == bool.FalseString.ToUpper())
                                    continue;
                            }
                            if (c is Label)
                                ControlIDLists.Add(c.ID);
                            if (c is HiddenField)
                                ControlIDLists.Add(c.ID);
                            if (c is TextBox)
                                ControlIDLists.Add(c.ID);
                            if (c is DropDownList)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlInputText)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlInputFile)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlInputCheckBox)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlTextArea)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlInputHidden)
                                ControlIDLists.Add(c.ID);
                            if (c is HtmlSelect)
                                ControlIDLists.Add(c.ID);
                            if (c is CheckBox)
                                ControlIDLists.Add(c.ID);
                        }
                    }
                }
            }

            DataTable dt = new DataTable(ControlValueItenTableName);
            foreach (string s in ControlIDLists)
            {
                DataColumn dc = new DataColumn(s, typeof(string));
                dc.DefaultValue = "";
                dt.Columns.Add(dc);
            }

            DataColumn dckey = new DataColumn("GridViewRowDataID", typeof(int));
            dckey.AutoIncrement = true;
            dckey.AutoIncrementSeed = 1;
            dckey.AutoIncrementStep = 1;
            dt.Columns.Add(dckey);
            dt.PrimaryKey = new DataColumn[] { dckey };
            dt.AcceptChanges();

            this.ControlValueItenTable = dt;

            BindData();
        }

        public GridViewRow AddNewRow()
        {
            if (!(this.extenderGrid.Rows.Count == 1 && this.extenderGrid.Rows[0].Cells[0].ColumnSpan == this.extenderGrid.Columns.Count))
                this.SaveData();
            return AddNewRow(GetNewRow());
        }

        public DataRow GetNewRow()
        {
            return this.ControlValueItenTable.NewRow();
        }

        public GridViewRow AddNewRow(DataRow dr)
        {
            this.ControlValueItenTable.Rows.Add(dr);
            this.ControlValueItenTable.AcceptChanges();
            BindData();
            return this.extenderGrid.Rows[this.extenderGrid.Rows.Count - 1];
        }

        private void SaveData()
        {
            ControlValueItenTable.Rows.Clear();
            foreach (GridViewRow row in extenderGrid.Rows)
            {
                if (row.Cells[0].ColumnSpan == this.extenderGrid.Columns.Count)
                    continue;
                string[] getValues = new string[ControlIDLists.Count];
                for (int i = 0; i < ControlIDLists.Count; i++)
                {
                    getValues[i] = GetControlValueStringFromGridViewRow(ControlIDLists[i], row);
                }
                ControlValueItenTable.Rows.Add(getValues);
            }
            ControlValueItenTable.AcceptChanges();
        }

        private static string GetControlValueStringFromGridViewRow(string controlid, GridViewRow row)
        {
            foreach (TableCell cell in row.Cells)
            {
                Control c = cell.FindControl(controlid);
                if (c is Label)
                    return ((Label)c).Text;
                if (c is HiddenField)
                    return ((HiddenField)c).Value;
                if (c is TextBox)
                    return ((TextBox)c).Text;
                if (c is DropDownList)
                    return ((DropDownList)c).SelectedValue;
                if (c is HtmlInputText)
                    return ((HtmlInputText)c).Value;
                if (c is HtmlInputFile)
                    return ((HtmlInputFile)c).Value;
                if (c is HtmlInputCheckBox)
                    return ((HtmlInputCheckBox)c).Checked.ToString();
                if (c is HtmlTextArea)
                    return ((HtmlTextArea)c).Value;
                if (c is HtmlInputHidden)
                    return ((HtmlInputHidden)c).Value;
                if (c is HtmlSelect)
                    return ((HtmlSelect)c).Value;
                if (c is CheckBox)
                    return ((CheckBox)c).Checked.ToString();
                Console.WriteLine(c);
            }
            throw new Exception("can not find control!");
        }


        public void DeleteRow(int rowIndex)
        {
            if (!(this.extenderGrid.Rows.Count == 1 && this.extenderGrid.Rows[0].Cells[0].ColumnSpan == this.extenderGrid.Columns.Count))
            {
                this.ControlValueItenTable.Rows.RemoveAt(rowIndex);
                this.ControlValueItenTable.AcceptChanges();
                BindData();
            }
        }
        public void DeleteRow(List<int> rowIndexs)
        {
            for (int i = 0; i < rowIndexs.Count; i++)
            {
                if (!(this.extenderGrid.Rows.Count == 1 && this.extenderGrid.Rows[0].Cells[0].ColumnSpan == this.extenderGrid.Columns.Count))
                {
                    this.ControlValueItenTable.Rows.RemoveAt(rowIndexs[i] - i);
                    this.ControlValueItenTable.AcceptChanges();
                    BindData();
                }
            }
        }


        public void ClearAll()
        {
            if (!(this.extenderGrid.Rows.Count == 1 && this.extenderGrid.Rows[0].Cells[0].ColumnSpan == this.extenderGrid.Columns.Count))
            {
                this.ControlValueItenTable.Clear();
                this.ControlValueItenTable.AcceptChanges();
                BindData();
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //if (!this.Page.IsPostBack)
            //{

            //}
            //else
            //{
            if (this.extenderGrid.Rows.Count == 1 && (this.extenderGrid.Rows[0].Cells[0].ColumnSpan == this.extenderGrid.Rows[0].Cells.Count))
                this.BindData();
            else
                SaveData();
            //}
        }

        private void BindData()
        {
            DataBindHelper.BindDataTableToGridView(this.extenderGrid, this.ControlValueItenTable);
        }
    }
}