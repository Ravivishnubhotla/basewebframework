<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemRoleListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.RoleManage.SystemRoleListPage" %>

<%@ Register Src="UCSystemRoleAdd.ascx" TagName="UCSystemRoleAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemRoleEdit.ascx" TagName="UCSystemRoleEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemRole.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemRoleAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemRoleEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选系统角色 ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除系统角色！',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>

    <ext:Store ID="storeSystemRole" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemRole_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="RoleID">
                <Fields>
                    <ext:RecordField Name="RoleID" Type="int" />
                    <ext:RecordField Name="RoleName" />
                    <ext:RecordField Name="RoleDescription" />
                    <ext:RecordField Name="RoleIsSystemRole" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <uc1:UCSystemRoleAdd ID="UCSystemRoleAdd1" runat="server" />
    <uc2:UCSystemRoleEdit ID="UCSystemRoleEdit1" runat="server" /> 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemRole" runat="server" StoreID="storeSystemRole"
                StripeRows="true" Title="系统角色管理" Icon="Table" AutoExpandColumn="colRoleDescription">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemRole}.reload();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <View>
                    <ext:GridView ForceFit="true" ID="GridView1">
                        <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                    </ext:GridView>
                </View>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn>
                        </ext:RowNumbererColumn>
                        <ext:Column DataIndex="RoleID" Header="主键" Sortable="true">
                        </ext:Column>
                        <ext:Column DataIndex="RoleName" Header="角色名" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colRoleDescription" DataIndex="RoleDescription" Header="描述"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column DataIndex="RoleIsSystemRole" Header="是否为系统角色" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn Header="系统角色管理" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                    <ToolTip Text="编辑" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                    <ToolTip Text="删除" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdAssignedMenu" Text="分配应用">
                                    <ToolTip Text="分配应用" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdAssignedMenu" Text="菜单权限">
                                    <ToolTip Text="菜单权限" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="GroupKey" CommandName="cmdAssignedPermission" Text="系统权限">
                                    <ToolTip Text="系统权限" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemRole"
                        DisplayInfo="true" DisplayMsg="显示系统角色 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的系统角色" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
