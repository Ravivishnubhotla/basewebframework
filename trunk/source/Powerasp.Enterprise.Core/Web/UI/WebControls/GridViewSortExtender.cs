using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.Web.UI.WebControls
{
    /// <summary>
    /// The GridViewSortExtender is used to add a sort indicator to a <see cref="GridView"/>.
    /// The sort indicator is an image that is shown in the sort column and displays the sort direction.
    /// </summary>
    [Designer(typeof(GridViewExtenderDesigner))]
    public class GridViewSortExtender : Control
    {
        /// <summary>
        /// Image that is displayed when SortDirection is ascending.
        /// </summary>
        [DefaultValue("")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        [Description("Image that is displayed when SortDirection is ascending.")]
        public string AscendingImageUrl
        {
            get { return this.ViewState["AscendingImageUrl"] != null ? (string)this.ViewState["AscendingImageUrl"] : ""; }
            set { this.ViewState["AscendingImageUrl"] = value; }
        }

        /// <summary>
        /// Image that is displayed when SortDirection is descending.
        /// </summary>
        [DefaultValue("")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        [Description("Image that is displayed when SortDirection is descending.")]
        public string DescendingImageUrl
        {
            get { return this.ViewState["DescendingImageUrl"] != null ? (string)this.ViewState["DescendingImageUrl"] : ""; }
            set { this.ViewState["DescendingImageUrl"] = value; }
        }

        /// <summary>
        /// The GridView that is extended.
        /// </summary>
        [DefaultValue("")]
        [IDReferenceProperty(typeof(GridView))]
        [TypeConverter(typeof(GridViewIDConverter))]
        [Description("The GridView that is extended.")]
        public string ExtendeeID
        {
            get { return this.ViewState["Extendee"] != null ? (string)this.ViewState["Extendee"] : ""; }
            set { this.ViewState["Extendee"] = value; }
        }

        /// <summary>
        /// Adds an event handler to the DataBound event of the extended GridView.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnInit(e);

            GridView extendee = this.Parent.FindControl(this.ExtendeeID) as GridView;
            // && !String.IsNullOrEmpty(extendee.SortExpression)
            if (extendee != null && extendee.AllowSorting && extendee.HeaderRow != null)
            {
                int field = GetSortField(extendee);
                if (field >= 0)
                {
                    Image img = new Image();
                    img.ImageUrl = extendee.SortDirection == SortDirection.Ascending ? this.AscendingImageUrl : this.DescendingImageUrl;
                    img.ImageAlign = ImageAlign.AbsMiddle;

                    extendee.HeaderRow.Cells[field].Controls.Add(img);

                    //extendee.Sorting += new GridViewSortEventHandler(OnGridView_Sorting);
                }
            }



        }


        //protected void OnGridView_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    //GridView extendee = this.Parent.FindControl(this.ExtendeeID) as GridView;
        //    //if (extendee != null && extendee.AllowSorting)
        //    //{
        //    //    this.GridViewSortDirection = e.SortDirection.ToString();
        //    //    this.GridViewSortExpression = e.SortExpression;
        //    //}
        //}

        [Browsable(false)]
        public string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "ASC"; }

            set { ViewState["SortDirection"] = value; }
        }
        [Browsable(false)]
        public string GridViewSortExpression
        {
            get { return ViewState["SortExpression"] as string ?? string.Empty; }

            set { ViewState["SortExpression"] = value; }
        }



        /// <summary>
        /// Returns the index of the sort-column.
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        private int GetSortField(GridView extendee)
        {
            int i = 0;
            if (extendee.SortExpression == "")
                return -1;
            foreach (DataControlField field in extendee.Columns)
            {
                if (field.SortExpression == extendee.SortExpression)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }

    /// <summary>
    /// Designer for <see cref="GridViewSortExtender"/>.
    /// </summary>
    public class GridViewExtenderDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return "<div style=\"background-color: #C8C8C8; border: groove 2 Gray;\"><b>GridViewExtender</b> - " + this.Component.Site.Name + "</div>";
        }
    }


}
