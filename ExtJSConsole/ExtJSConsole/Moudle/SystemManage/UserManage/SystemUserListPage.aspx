<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemUserListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.UserManage.SystemUserListPage" %>

<%@ Register Src="UCSystemUserAdd.ascx" TagName="UCSystemUserAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserEdit.ascx" TagName="UCSystemUserEdit" TagPrefix="uc2" %>
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
            <%= this.storeSystemUser.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemUserAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemUserEdit.Show(id.id,
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
                            Ext.net.DirectMethods.DeleteRecord(
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
        <Reader>
            <ext:JsonReader IDProperty="UserID">
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
    <ext:ViewPort ID="viewPortMain" runat="server" Layout="fit">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemUser" runat="server" StoreID="storeSystemUser"
                        StripeRows="true" Title="系统用户管理" Icon="Table">
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
                                            <Click Handler="#{storeSystemUser}.reload();" />
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
                                <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="登录ID" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserName" DataIndex="UserName" Header="用户名" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserEmail" DataIndex="UserEmail" Header="邮件" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserStatus" DataIndex="UserStatus" Header="状态" Sortable="true"
                                    Width="35">
                                </ext:Column>
                                <ext:Column ColumnID="colUserCreateDate" DataIndex="UserCreateDate" Header="创建日期"
                                    Sortable="true" Width="60">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:Column ColumnID="colUserType" DataIndex="UserType" Header="类型" Sortable="true"
                                    Width="35">
                                </ext:Column>
                                <ext:Column ColumnID="colComments" DataIndex="Comments" Header="备注" Sortable="true"
                                    Width="60">
                                </ext:Column>
                                <ext:Column ColumnID="colIsApproved" DataIndex="IsApproved" Header="通过" Sortable="true"
                                    Width="35">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
                                <ext:Column ColumnID="colIsLockedOut" DataIndex="IsLockedOut" Header="锁定" Sortable="true"
                                    Width="35">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
                                <ext:Column ColumnID="colLastActivityDate" DataIndex="LastActivityDate" Header="上次活动时间"
                                    Sortable="true" Width="60">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:CommandColumn ColumnID="colManage" Header="系统用户管理" Width="60">
                                    <Commands>
                                    <ext:SplitCommand Text="管理" Icon="ApplicationEdit">
                                    <Menu>
                                    <Items>
                                    
                                                        <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑"></ext:MenuCommand>
                                                        
                                                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                            </ext:MenuCommand>
                                            
                                                                                           <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="修改密码">
                                            </ext:MenuCommand>
                                                                                                    <ext:MenuCommand Icon="Lock" CommandName="cmdLock" Text="解锁">
                                       
                                            </ext:MenuCommand>
                                    </Items>
                                    
                                    </Menu>
                                    
                                    </ext:SplitCommand>

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
    </ext:ViewPort>
</asp:Content>
