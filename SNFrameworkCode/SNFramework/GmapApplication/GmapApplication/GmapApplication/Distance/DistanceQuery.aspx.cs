using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Parameter = Ext.Net.Parameter;

namespace GmapApplication.Distance
{
    public partial class DistanceQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnQuery_Click(object sender, DirectEventArgs e)
        //{
        //    this.pnlMap.AutoLoad.Url = "ShowDirections.aspx";
        //    this.pnlMap.AutoLoad.Mode = LoadMode.IFrame;
        //    this.pnlMap.AutoLoad.NoCache = true;
        //    this.pnlMap.AutoLoad.Params.Clear();
        //    this.pnlMap.AutoLoad.Params.Add(new Parameter("Start",txtStart.Text.Trim()));
        //    this.pnlMap.AutoLoad.Params.Add(new Parameter("End", txtEnd.Text.Trim()));
        //    this.pnlMap.LoadContent();
        //}
    }
}