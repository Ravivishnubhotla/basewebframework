using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Web.Designer;

namespace Legendigital.Framework.Common.Web.UI
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
            if (extendee != null && extendee.AllowSorting && extendee.HeaderRow != null && !String.IsNullOrEmpty(extendee.SortExpression))
            {
                int field = GetSortField(extendee);
                if (field >= 0)
                {
                    Image img = new Image();
                    img.ImageUrl = extendee.SortDirection == SortDirection.Ascending ? this.AscendingImageUrl : this.DescendingImageUrl;
                    img.ImageAlign = ImageAlign.TextTop;

                    extendee.HeaderRow.Cells[field].Controls.Add(img);

                    GridViewSortExpression = extendee.SortExpression;
                    GridViewSortDirection = extendee.SortDirection;
                }
            }
        }


        [Browsable(false)]
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["SortDirection"]==null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["SortDirection"];
            }

            set { ViewState["SortDirection"] = value; }
        }

        [Browsable(false)]
        public string GridViewSortExpression
        {
            get
            {
                if (ViewState["SortExpression"] == null)
                {
                    ViewState["SortExpression"] = string.Empty;
                }
                return (string)ViewState["SortExpression"];
            }

            set
            {
                ViewState["SortExpression"] = value;
            }
        }



        /// <summary>
        /// Returns the index of the sort-column.
        /// </summary>
        /// <param name="extendee"></param>
        /// <returns></returns>
        private int GetSortField(GridView extendee)
        {
            int i = 0;
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

}