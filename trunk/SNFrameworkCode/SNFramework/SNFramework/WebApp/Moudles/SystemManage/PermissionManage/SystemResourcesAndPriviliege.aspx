<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemResourcesAndPriviliege.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.SystemResourcesAndPriviliege" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{treeMain});" />
        </Listeners>
    </ext:ResourceManagerProxy>
        <script type="text/javascript">

        function RefreshTreeList1() {
            RefreshList(<%= this.treeMain.ClientID %>);
        }

 



        function RefreshList(treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
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
                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                    }
                                                }
                                             );

        }

        var RefreshData = function(btn) {
            RefreshList(<%= this.treeMain.ClientID %>);
        };



        function ShowEditForm(id) {
               Ext.net.DirectMethods.UCSystemDepartmentEdit.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                                               }
                                                                }   
                );
        }


        function ShowAddForm(pid) {
            Ext.net.DirectMethods.UCSystemDepartmentAdd.Show(
                                                        pid,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                            }
                                                        });
        }


        function DeleteData(id) {
                        Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
                        if (e == 'yes')
            Ext.net.DirectMethods.DeleteData(
                                                        id,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>', RefreshData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                            }
                                                        });
                    }
                    );

        }   
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Icon=UserHome Title="资源管理" Width="300" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="treeMain" runat="server" Header="false" RootVisible="false"
                                AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="添加根资源">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(0);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button3" runat="server" IconCls="icon-expand-all" Text="展开全部">
                                            </ext:Button>
                                            <ext:Button ID="Button4" runat="server" IconCls="icon-collapse-all" Text="收起全部">
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
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>

</asp:Content>
