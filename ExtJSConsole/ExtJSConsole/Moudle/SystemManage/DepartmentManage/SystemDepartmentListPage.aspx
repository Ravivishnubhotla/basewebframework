<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemDepartmentListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.DepartmentManage.SystemDepartmentListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function RefreshList(treepanel) {
            Coolite.AjaxMethods.GetTreeNodes(
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('操作失败', msg);
                                                    },
                                                    success: function(result) {
                                                        var nodes = eval(result);
                                                        treepanel.root.ui.remove();
                                                        treepanel.initChildren(nodes);
                                                        treepanel.root.render();
                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '正在加载部门......'
                                                    }
                                                }
                                             );

        }





        function ShowEditForm(id) {

        }


        function ShowAddForm(pid) {

        }



    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{TreePanel1});" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="添加子部门" Icon="Add">
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="编辑部门" Icon="Anchor">
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="删除部门" Icon="Delete">
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem1" runat="server" Text="子部门排序" Icon="SortAscending">
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem2" runat="server" Text="子部门自动排序" Icon="SortAscending">
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Title="系统部门管理" Width="300">
                        <Body>
                            <ext:FitLayout ID="FitLayout1" runat="server">
                                <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                    AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar ID="ToolBar1" runat="server">
                                            <Items>
                                                <ext:ToolbarButton ID="ToolbarButton1" runat="server" Icon="Add" Text="添加根部门">
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton2" runat="server" Icon="SortAscending" Text="根部门排序">
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton5" runat="server" Icon="SortAscending" Text="根部门自动排序">
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton3" runat="server" IconCls="icon-expand-all" Text="全部展开">
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton4" runat="server" IconCls="icon-collapse-all"
                                                    Text="全部收起">
                                                </ext:ToolbarButton>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                        <ext:TreeNode Text="系统菜单" Expanded="true" Icon="Folder">
                                        </ext:TreeNode>
                                    </Root>
                                    <BottomBar>
                                        <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                    </BottomBar>
                                    <Listeners>
                                        <ContextMenu Handler="e.preventDefault();node.select();" />
                                        <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '</b>', clear: true});" />
                                    </Listeners>
                                </ext:TreePanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
