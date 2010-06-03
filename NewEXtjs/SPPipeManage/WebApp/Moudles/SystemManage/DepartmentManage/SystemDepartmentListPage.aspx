<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemDepartmentListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage.SystemDepartmentListPage" %>

<%@ Register Src="UCSystemDepartmentAdd.ascx" TagName="UCSystemDepartmentAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemDepartmentEdit.ascx" TagName="UCSystemDepartmentEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function RefreshTreeList1() {
            RefreshList(<%= this.TreePanel1.ClientID %>);
        }

        function ShowMenu(node,menu,point) {
            menu.items.items[0].setVisible(true);
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length==0));
            menu.items.items[3].setVisible((node.childNodes.length>0));
            menu.items.items[4].setVisible((node.childNodes.length>0));
            menu.showAt(point);
        }



        function RefreshList(treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('Operation failed.', msg);
                                                    },
                                                    success: function(result) {
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
                                                        msg: 'Loading......'
                                                    }
                                                }
                                             );

        }

        var RefreshData = function(btn) {
            RefreshList(<%= this.TreePanel1.ClientID %>);
        };



        function ShowEditForm(id) {
               Ext.net.DirectMethods.UCSystemDepartmentEdit.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed.', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Loading...'
                                                                               }
                                                                }   
                );
        }


        function ShowAddForm(pid) {
            Ext.net.DirectMethods.UCSystemDepartmentAdd.Show(
                                                        pid,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('Operation failed.', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: 'Loading......'
                                                            }
                                                        });
        }


        function DeleteData(id) {
                        Ext.MessageBox.confirm('Warning','Are your sure to delete department?',
                    function(e) {
                        if (e == 'yes')
            Ext.net.DirectMethods.DeleteData(
                                                        id,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('Operation failed.', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('Operation Success.', 'Delete department Successful!', RefreshData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: 'Processing......'
                                                            }
                                                        });
                    }
                    );

        }   
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemDepartmentAdd ID="UCSystemDepartmentAdd1" runat="server" />
    <uc2:UCSystemDepartmentEdit ID="UCSystemDepartmentEdit1" runat="server" />
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{TreePanel1});" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="Add sub department" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="Edit department" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="Delete department" Icon="Delete">
                            <Listeners>
                    <Click Handler="DeleteData(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem1" runat="server" Text="Sub department sort" Icon="SortAscending">
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem2" runat="server" Text="Sub department autosort" Icon="SortAscending">
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Title="System department manage" Width="300" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="Add root department">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(0);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button2" runat="server" Icon="SortAscending" Text="Root department sort">
                                            </ext:Button>
                                            <ext:Button ID="Button5" runat="server" Icon="SortAscending" Text="Root department autosort">
                                            </ext:Button>
                                            <ext:Button ID="Button3" runat="server" IconCls="icon-expand-all" Text="Expand all">
                                            </ext:Button>
                                            <ext:Button ID="Button4" runat="server" IconCls="icon-collapse-all" Text="Collapse all">
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Root>
                                    <ext:TreeNode Text="System menu" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                </BottomBar>
                                <Listeners>
                                    <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cmenu},e.getPoint());" />
                                    <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '</b>', clear: true});" />
                                </Listeners>
                            </ext:TreePanel>
                            </ext:FitLayout>
                        </Content>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
