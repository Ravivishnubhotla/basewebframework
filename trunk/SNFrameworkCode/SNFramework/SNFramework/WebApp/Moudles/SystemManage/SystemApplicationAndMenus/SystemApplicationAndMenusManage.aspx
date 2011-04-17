<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationAndMenusManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.SystemApplicationAndMenusManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="false" RemotePaging="true"
        RemoteSort="true" OnRefreshData="storeSystemApplication_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationCode" />
                    <ext:RecordField Name="LocaLocalizationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{GridPanel1}.getSelectionModel().selectFirstRow();" />
        </Listeners>
    </ext:Store>
    <script type="text/javascript">
        var FormatBool = function (value) {
            if (value)
                return '是';
            else
                return '否';
        }

        function SelectApplication(app, tree) {
            tree.setTitle(app.data.LocaLocalizationName + " 子菜单管理");


            Ext.net.DirectMethods.GetTreeNodes(
                                                app.id.toString(),
                                                {
                                                    failure: function (msg) {
                                                        Ext.Msg.alert('Operation failed', msg);
                                                    },
                                                    success: function (result) {
                                                        var nodes = eval(result);
                                                        if (nodes.length > 0) {
                                                            tree.initChildren(nodes);
                                                        }
                                                        else {
                                                            tree.getRootNode().removeChildren();
                                                        }

                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '加载中......',
                                                        target: 'customtarget',
                                                        customTarget: '<%= TreePanel1.ClientID %>.el'
                                                    }
                                                }
                                             );
        }

    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Frame="true" Title="应用菜单管理">
                <Items>
                    <ext:BorderLayout ID="BorderLayout1" runat="server">
                        <West Split="true" Collapsible="true">
                            <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true"
                                Title="系统应用管理" Width="390" Frame="true" AutoScroll="true" AutoExpandColumn="colLocaLocalizationName">
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ColumnID="colLocaLocalizationName" Header="名称" Width="80" Sortable="true"
                                            DataIndex="LocaLocalizationName" />
                                        <ext:Column ColumnID="colSystemApplicationCode" Header="编码" Width="120" Sortable="true"
                                            DataIndex="SystemApplicationCode" />
                                        <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="系统应用" Width="65">
                                            <Renderer Fn="FormatBool" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        <Listeners>
                                            <RowSelect Buffer="100" Handler="SelectApplication(this.getSelected(),#{TreePanel1});" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10" StoreID="storeSystemApplication" />
                                </BottomBar>
                            </ext:GridPanel>
                        </West>
                        <Center>
                            <ext:TreePanel ID="TreePanel1" runat="server" Title="菜单管理" AutoScroll="true" Frame="true"
                                RootVisible="false">
                                     <TopBar>
                                     <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="ToolbarButton1" runat="server" Icon="Add" Text="Add root menu">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(#{cbApplication}.getValue(),'');" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton2" runat="server" Icon="SortAscending" Text="Root menu sort">
                                                <Listeners>
                                                    <Click Handler="showReorderForm(0,#{storeSubMenus},#{cbApplication}.getValue(),#{hidSortPMenuID},#{hidSortAppID});" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton5" runat="server" Icon="SortAscending" Text="Root menu auto sort">
                                                <Listeners>
                                                    <Click Handler="AutoReorder(0,#{cbApplication}.getValue());" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton3" runat="server" IconCls="icon-expand-all" Text="Expand all">
                                                <Listeners>
                                                    <Click Handler="#{TreePanel1}.root.expand(true);" />
                                                </Listeners>
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip1" IDMode="Ignore" runat="server" Html="Expand All" />
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton4" runat="server" IconCls="icon-collapse-all" Text="Collapse all">
                                                <Listeners>
                                                    <Click Handler="#{TreePanel1}.root.collapse(true);" />
                                                </Listeners>
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip2" IDMode="Ignore" runat="server" Html="Collapse All" />
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                     
                                     </TopBar>                              
                                <Root >
                                    <ext:TreeNode Text="Root" Expanded="true">
                                        <Nodes>
                                            <ext:TreeNode Text="Folder 1" Qtip="Rows dropped here will be appended to the folder">
                                                <Nodes>
                                                    <ext:TreeNode Text="Subleaf 1" Qtip="Subleaf 1 Quick Tip" Leaf="true" />
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Folder 2" Qtip="Rows dropped here will be appended to the folder">
                                                <Nodes>
                                                    <ext:TreeNode Text="Subleaf 2" Qtip="Subleaf 2 Quick Tip" Leaf="true" />
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Leaf 1" Qtip="Leaf 1 Quick Tip" Leaf="true" />
                                        </Nodes>
                                    </ext:TreeNode>
                                </Root>
                            </ext:TreePanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
