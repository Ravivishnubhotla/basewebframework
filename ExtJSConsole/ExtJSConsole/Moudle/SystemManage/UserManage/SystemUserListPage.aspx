<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemUserListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.UserManage.SystemUserListPage" %>
<%@ Register Src="UCSystemUserAdd.ascx" TagName="UCSystemUserAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserEdit.ascx" TagName="UCSystemUserEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1"   runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemUser.ClientID %>.reload();
        };
        
        function showAddForm() {
                Coolite.AjaxMethods.UCSystemUserAdd.Show( 
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
                Coolite.AjaxMethods.UCSystemUserEdit.Show(id.id,
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
                Ext.MessageBox.confirm('警告','确认要删除所选系统用户 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除系统用户！',RefreshData);            
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

    <ext:Store ID="storeSystemUser" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemUser_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="UserID">
                <Fields>
										<ext:RecordField Name="UserID" Type="int" />
		<ext:RecordField Name="UserLoginID" />			
		<ext:RecordField Name="UserName" />			
		<ext:RecordField Name="UserEmail" />			
		<ext:RecordField Name="UserPassword" />			
		<ext:RecordField Name="UserStatus" />			
				<ext:RecordField Name="UserCreateDate" Type="Date" />
		<ext:RecordField Name="UserType" />			
				<ext:RecordField Name="PasswordFormat" Type="int" />
		<ext:RecordField Name="Comments" />			
				<ext:RecordField Name="IsApproved" Type="Boolean" />
				<ext:RecordField Name="IsLockedOut" Type="Boolean" />
				<ext:RecordField Name="LastActivityDate" Type="Date" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemUserAdd ID="UCSystemUserAdd1" runat="server" />
    <uc2:UCSystemUserEdit ID="UCSystemUserEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemUser" runat="server" StoreID="storeSystemUser" StripeRows="true"
                        Title="系统用户管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="showAddForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSystemUser}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
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
												<ext:Column ColumnID="colUserID" DataIndex="UserID" Header="主键" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="登录ID" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colUserName" DataIndex="UserName" Header="用户名" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colUserEmail" DataIndex="UserEmail" Header="邮件" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colUserPassword" DataIndex="UserPassword" Header="密码" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colUserStatus" DataIndex="UserStatus" Header="用户状态" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colUserCreateDate" DataIndex="UserCreateDate" Header="创建日期" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colUserType" DataIndex="UserType" Header="用户类型" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colPasswordFormat" DataIndex="PasswordFormat" Header="密码格式" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colComments" DataIndex="Comments" Header="备注" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colIsApproved" DataIndex="IsApproved" Header="是否通过" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colIsLockedOut" DataIndex="IsLockedOut" Header="是否锁定" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colLastActivityDate" DataIndex="LastActivityDate" Header="上次活动时间" Sortable="true">
                                </ext:Column>
 
                                <ext:CommandColumn ColumnID="colManage" Header="系统用户管理" Width="60">
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
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemUser"
                                DisplayInfo="true" DisplayMsg="显示系统用户 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的系统用户" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                            
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>

