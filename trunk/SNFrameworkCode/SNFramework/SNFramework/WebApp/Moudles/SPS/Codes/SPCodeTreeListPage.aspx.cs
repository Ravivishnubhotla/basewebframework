using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.Wrappers;
using TreeNode = Ext.Net.TreeNode;
using TreeNodeCollection = Ext.Net.TreeNodeCollection;

namespace Legendigital.Common.WebApp.Moudles.SPS.Codes
{
    public partial class SPCodeTreeListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            if(ChannelID!=null)
            {
                this.cmbChannel.Hidden = true;
                this.cmbClient.Hidden = true;
            }

        }

        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }


        [DirectMethod]
        public string GetTreeNodes(string searchfilters)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = "root";
            root.Icon = Icon.Folder;

            nodes.Add(root);

            //if (menus == null || menus.Count == 0)
            //    return nodes;
            List<SPCodeWrapper> allcodes = null;

            Dictionary<string, string> search = null; 


            if (!string.IsNullOrEmpty(searchfilters))
            {
                search = JSON.Deserialize<Dictionary<string, string>>(searchfilters);
            }

            int? channelID = null;
            int? clientID = null;
            string mo = string.Empty;
            string spnumber = string.Empty;

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search["ChannelID"]))
                {
                    channelID = Convert.ToInt32(search["ChannelID"]);
                }
                if (!string.IsNullOrEmpty(search["ClientID"]))
                {
                    clientID = Convert.ToInt32(search["ClientID"]);
                }
                if (!string.IsNullOrEmpty(search["Mo"]))
                {
                    mo = search["Mo"];
                }
                if (!string.IsNullOrEmpty(search["SpNumber"]))
                {
                    spnumber = search["SpNumber"];
                }
            }

            if(ChannelID!=null)
            {
                allcodes = SPCodeWrapper.FindAllByChannelIDAndClientIDAndMoAndSpNumber(ChannelID.Id, null, mo, spnumber);
            }
            else
            {
                allcodes = SPCodeWrapper.FindAllByChannelIDAndClientIDAndMoAndSpNumber(channelID, clientID, mo, spnumber);
            }

            for (int i = 0; i < allcodes.Count; i++)
            {
                if (allcodes[i].GetParentCode(allcodes) == allcodes[i])
                {
                    TreeNode mainNode = new TreeNode();
                    mainNode.Text = allcodes[i].MoCode;
                    mainNode.NodeID = "nod" + allcodes[i].Id.ToString();
                    mainNode.Icon = Icon.Script;
                    mainNode.CustomAttributes.Add(new ConfigItem("MoCode", allcodes[i].MoCode, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("ChannelName", allcodes[i].ChannelID_Name, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("AssignedClientName", allcodes[i].AssignedClientName, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("CodeID", allcodes[i].Id.ToString(), ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("Disable", allcodes[i].IsDiable.ToString(), ParameterMode.Value));
                    GenerateSubTreeNode(mainNode, allcodes[i], allcodes);
                    root.Nodes.Add(mainNode); 
                }
        
            }


            return nodes.ToJson();

        }

        private static void GenerateSubTreeNode(TreeNode mainNode, SPCodeWrapper spCodeWrapper, List<SPCodeWrapper> allcodes)
        {
            List<SPCodeWrapper> subcodes = spCodeWrapper.GetAllSubCode(allcodes);

            foreach (SPCodeWrapper subCode in subcodes)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = subCode.MoCode;
                subNode.NodeID = "nod" + subCode.Id.ToString();
                subNode.Icon = Icon.Script;
                subNode.CustomAttributes.Add(new ConfigItem("MoCode", subCode.MoCode, ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("ChannelName", subCode.ChannelID_Name, ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("AssignedClientName", subCode.AssignedClientName, ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("CodeID", subCode.Id.ToString(), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("Disable", subCode.IsDiable.ToString(), ParameterMode.Value));
                GenerateSubTreeNode(subNode, subCode, allcodes);
                mainNode.Nodes.Add(subNode);
            }
        }
    }
}