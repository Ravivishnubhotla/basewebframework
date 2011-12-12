<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemOrginationDepartmentManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage.SystemOrginationDepartmentManage" %>

<%@ Register Src="UCSystemOrganizationAdd.ascx" TagName="UCSystemOrganizationAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSystemOrganizationEdit.ascx" TagName="UCSystemOrganizationEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{treeMain});" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <script type="text/javascript">

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };
        
        function ShowMenu(node,menu,point) {
            menu.items.items[0].setVisible(true);
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length==0));
            menu.showAt(point);
        }
        
        function RefreshList(treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                {
                                                    failure: function (msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                    },
                                                    success: function (result) {
                                                        var nodes = eval(result);
                                                        if (nodes.length > 0) {
                                                            treepanel.initChildren(nodes);
                                                        }
                                                        else {
                                                            treepanel.getRootNode().removeChildren();
                                                        }
                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                    }
                                                }
                                             );

        }

        function ShowAddForm(pid) {
            Ext.net.DirectMethods.UCSystemOrganizationAdd.Show(
                                                        pid,
                                                        {
                                                            failure: function (msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                            }
                                                        });
        } 
          function RefreshTreeList1() {
            RefreshList(<%= this.treeMain.ClientID %>);
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemOrganizationAdd ID="UCSystemOrganizationAdd1" runat="server" />
    <uc2:UCSystemOrganizationEdit ID="UCSystemOrganizationEdit1" runat="server" />
    <ext:Hidden ID="hidSelectOrgID" runat="server">
    </ext:Hidden>
    <ext:Menu ID="cOrg" runat="server">
        <Items>
            <ext:MenuItem ID="AddItems" runat="server" Text="<%$ Resources:msgAddSubOrg %>" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="<%$ Resources:msgEditOrg %>" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="<%$ Resources:msgDeleteOrg %>"
                Icon="Delete">
                <Listeners>
                    <Click Handler="DeleteData(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Icon="Package" Title="<%$ Resources:msgPanelOrgManage %>"
                        Width="300" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="treeMain" runat="server" Header="false" RootVisible="false" AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="<%$ Resources:msgAddRootOrg %>">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(0);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button3" runat="server" IconCls="icon-expand-all" Text="<%$ Resources : GlobalResource, msgCollapseAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.expand(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button4" runat="server" IconCls="icon-collapse-all" Text="<%$ Resources : GlobalResource, msgExpandAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.collapse(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Root>
                                    <ext:TreeNode Text="<%$ Resources : msgRootNodeText  %>" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                </BottomBar>
                                <Listeners>
                                    <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cOrg},e.getPoint());" />
                                    <Click Handler="<%$ Resources : msgOrgStatusBar  %>" />
                                </Listeners>
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
                <East Split="true" Collapsible="true">
                    <ext:Panel ID="pnlEast" runat="server" Icon="Package" Title="122121" Width="650"
                        Layout="fit" Disabled="true">
                        <Content>
                            <ext:TabPanel ID="TabPanel1" runat="server" Frame="true">
                                <Items>
                                    <ext:Panel ID="Tab2" Title="12233" Icon="UserKey" runat="server" Layout="FitLayout">
                                        <Items>
                                        </Items>
                                        <Listeners>
                                        </Listeners>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </Content>
                    </ext:Panel>
                </East>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
