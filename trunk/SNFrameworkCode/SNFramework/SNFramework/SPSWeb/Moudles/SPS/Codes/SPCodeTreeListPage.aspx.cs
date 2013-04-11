using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using SPS.Bussiness.Wrappers;
using TreeNode = System.Web.UI.WebControls.TreeNode;
using TreeNodeCollection = System.Web.UI.WebControls.TreeNodeCollection;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeTreeListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            if (ChannelID != null)
            {
                this.cmbChannel.Hidden = true;
                this.cmbClient.Hidden = true;
                this.btnAdd.Disabled = false;
            }
            else
            {
                this.cmbChannel.Hidden = false;
                this.cmbClient.Hidden = false;
                this.btnAdd.Disabled = true;     
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
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

            Ext.Net.TreeNode root = new Ext.Net.TreeNode();
            root.Text = "root";
            root.Icon = Icon.Folder;

            nodes.Add(root);

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

            if (ChannelID != null)
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
                    Ext.Net.TreeNode mainNode = new Ext.Net.TreeNode();
                    mainNode.Text = allcodes[i].MoCode;
                    mainNode.NodeID = "nod" + allcodes[i].Id.ToString();
                    mainNode.Icon = Icon.Script;
                    mainNode.CustomAttributes.Add(new ConfigItem("MoCode", allcodes[i].MoCode, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("ChannelName", allcodes[i].ChannelID_Name, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("ChannelID", allcodes[i].ChannelID.Id.ToString(), ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("AssignedClientName", allcodes[i].AssignedClientName, ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("CodeID", allcodes[i].Id.ToString(), ParameterMode.Value));
                    mainNode.CustomAttributes.Add(new ConfigItem("Disable", allcodes[i].IsDiable.ToString(), ParameterMode.Value));
                    GenerateSubTreeNode(mainNode, allcodes[i], allcodes);
                    root.Nodes.Add(mainNode);
                }

            }


            return nodes.ToJson();

        }

        private static void GenerateSubTreeNode(Ext.Net.TreeNode mainNode, SPCodeWrapper spCodeWrapper, List<SPCodeWrapper> allcodes)
        {
            List<SPCodeWrapper> subcodes = spCodeWrapper.GetAllSubCode(allcodes);

            foreach (SPCodeWrapper subCode in subcodes)
            {
                Ext.Net.TreeNode subNode = new Ext.Net.TreeNode();
                subNode.Text = subCode.MoCode;
                subNode.NodeID = "nod" + subCode.Id.ToString();
                subNode.Icon = Icon.Script;
                subNode.CustomAttributes.Add(new ConfigItem("MoCode", subCode.MoCode, ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("ChannelName", subCode.ChannelID_Name, ParameterMode.Value));
                mainNode.CustomAttributes.Add(new ConfigItem("ChannelID", subCode.ChannelID.Id.ToString(), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("AssignedClientName", subCode.AssignedClientName, ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("CodeID", subCode.Id.ToString(), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("Disable", subCode.IsDiable.ToString(), ParameterMode.Value));
                GenerateSubTreeNode(subNode, subCode, allcodes);
                mainNode.Nodes.Add(subNode);
            }
        }
    }
}