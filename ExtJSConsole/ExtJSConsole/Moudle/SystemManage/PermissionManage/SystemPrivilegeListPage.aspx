<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemPrivilegeListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.PermissionManage.SystemPrivilegeListPage" %>
<%@ Register Src="UCSystemPrivilegeAdd.ascx" TagName="UCSystemPrivilegeAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemPrivilegeEdit.ascx" TagName="UCSystemPrivilegeEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1"   runat="server">
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
            <%= this.storeSystemPrivilege.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemPrivilegeAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemPrivilegeEdit.Show(id.id,
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
                Ext.MessageBox.confirm('警告','确认要删除所选SystemPrivilege ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除SystemPrivilege！',RefreshData);            
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

    <ext:Store ID="storeSystemPrivilege" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemPrivilege_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="PrivilegeID">
                <Fields>
										<ext:RecordField Name="PrivilegeID" Type="int" />
		<ext:RecordField Name="PrivilegeCnName" />			
		<ext:RecordField Name="PrivilegeEnName" />			
		<ext:RecordField Name="Description" />			
		<ext:RecordField Name="PrivilegeCategory" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemPrivilegeAdd ID="UCSystemPrivilegeAdd1" runat="server" />
    <uc2:UCSystemPrivilegeEdit ID="UCSystemPrivilegeEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server" Layout=fit>
 
                <Items>
                    <ext:GridPanel ID="gridPanelSystemPrivilege" runat="server" StoreID="storeSystemPrivilege" StripeRows="true"
                        Title="SystemPrivilege管理" Icon="Table">
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
                                            <Click Handler="#{storeSystemPrivilege}.reload();" />
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
												<ext:Column ColumnID="colPrivilegeID" DataIndex="PrivilegeID" Header="主键" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colPrivilegeCnName" DataIndex="PrivilegeCnName" Header="权限名" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colPrivilegeEnName" DataIndex="PrivilegeEnName" Header="权限编码" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colPrivilegeCategory" DataIndex="PrivilegeCategory" Header="权限类别名" Sortable="true">
                                </ext:Column>			
 
                                <ext:CommandColumn ColumnID="colManage" Header="SystemPrivilege管理" Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" >
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemPrivilege"
                                DisplayInfo="true" DisplayMsg="显示SystemPrivilege {0} - {1} 共 {2}" EmptyMsg="没有符合条件的SystemPrivilege" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                            
                        </Listeners>
                    </ext:GridPanel>
                </Items>
  
    </ext:ViewPort>
</asp:Content>

