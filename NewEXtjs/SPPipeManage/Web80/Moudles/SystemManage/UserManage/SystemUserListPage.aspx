<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemUserListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SystemManage.UserManage.SystemUserListPage" %>

<%@ Register Src="UCSystemUserAdd.ascx" TagName="UCSystemUserAdd" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

       var template = '<span style="color:{0};">{1}</span>';

       var showUserStatus = function(value) {
           return String.format(template, (value) ? 'red' : 'green', FormatBool(value));
       };
                var FormatBool = function(value) {
                    if (value)
                        return '锁定';
                    else
                        return '正常';
                };
        
 
        
          var IntailLockedOut = function(grid, toolbar, rowIndex, record)
          {

              if (record.data.IsLockedOut)
              {
                  toolbar.items.items[0].menu.items.items[2].hide();
                  toolbar.items.items[0].menu.items.items[3].show();
              }

              else {
                  toolbar.items.items[0].menu.items.items[2].show();
                  toolbar.items.items[0].menu.items.items[3].hide();

              }

          };

          
                          function CloseChangePwd() {
                var win = <%= this.winChangePwd.ClientID %>;
 
        
                win.hide();
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
                                                                                msg: '处理中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {
 

            if (cmd == "cmdShowLoginLog") {

                var win = <%= this.winShowLoginLog.ClientID %>;
                
                win.setTitle(" 显示用户“"+id.data.UserLoginID+"” 安全日志 ");
                
                win.autoLoad.url = '../LogViews/SystemLogList.aspx';
                
                win.autoLoad.params.ParentID = id.id;
        
                win.show();    
            }  
            
            if (cmd == "cmdDelete") 
            {
                Ext.MessageBox.confirm('警告','确定要删除用户？',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '删除用户成功！',RefreshData);            
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
            if (cmd == "btnLock"||cmd == "btnUnlock") 
            {
                            Coolite.AjaxMethods.LockUser
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) 
                                                                    { 
                                                                       <%= this.storeSystemUser.ClientID %>.reload();            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                            );
            }
            if (cmd == "cmdChangePassword") 
            {
                
                                                var win = <%= this.winChangePwd.ClientID %>;
                
                win.setTitle(" 修改用户“"+id.data.UserLoginID+"” 登录密码 ");
                
                win.autoLoad.url = '<%= this.ResolveUrl("~/Moudles/SystemManage/UserManage/SystemUserChangePwd.aspx") %>';
                
                win.autoLoad.params.UserID = id.data.UserID;
        
                win.show();  
                
                
 
            }
 
        }

    </script>
    <ext:Store ID="storeSystemUser" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemUser_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
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
 
    <ext:ViewPort ID="viewPortMain" runat="server" Layout="fit">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemUser" runat="server" StoreID="storeSystemUser"
                        StripeRows="true" Title="商务用户管理" Icon="Table">
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
                                <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="登录名" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserCreateDate" DataIndex="UserCreateDate" Header="创建日期"
                                    Sortable="true" Width="60">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:Column Header="状态" Width="30" DataIndex="IsLockedOut">
                                    <Renderer Fn="showUserStatus" />
                                </ext:Column>
                                <ext:CommandColumn ColumnID="colManage" Header="用户管理" Width="60">
                                    <Commands>
                                        <ext:SplitCommand Text="操作" Icon="ApplicationEdit">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="更改密码">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="Lock" CommandName="btnLock" Text="锁定">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="LockOpen" CommandName="btnUnlock" Text="解锁">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="ScriptCode" CommandName="cmdShowLoginLog" Text="查看安全日志">
                                                    </ext:MenuCommand>
                                                </Items>
                                            </Menu>
                                        </ext:SplitCommand>
                                    </Commands>
                                    <PrepareToolbar Fn="IntailLockedOut" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUser"
                                DisplayInfo="true" DisplayMsg="显示用户 {0} - {1} 共 {2}" EmptyMsg="没用符合条件的用户" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winShowLoginLog" runat="server" Title="Window" Frame="true" Width="720"
        ConstrainHeader="true" Height="350" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../LogViews/SystemLogList.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="LogType" Mode="Value" Value="安全日志">
                </ext:Parameter>
                <ext:Parameter Name="ParentType" Mode="Value" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ParentID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>


            <ext:Window ID="winChangePwd" runat="server" Title="Window" Frame="true" Width="390"
        ConstrainHeader="true" Height="170" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../LogViews/SystemLogList.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="UserID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
