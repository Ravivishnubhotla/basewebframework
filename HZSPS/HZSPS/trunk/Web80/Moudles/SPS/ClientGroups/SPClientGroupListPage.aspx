<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientGroupListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.SPClientGroupListPage" %>

<%@ Register Src="UCSPClientGroupAdd.ascx" TagName="UCSPClientGroupAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPClientGroupEdit.ascx" TagName="UCSPClientGroupEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPUser}.reload();"></DocumentReady>
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

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
        
                var showCommands = function(grid, toolbar, rowIndex, record)
        {

            if (record.data.UserIsLocked != null && record.data.UserIsLocked)
            {
                toolbar.items.items[0].menu.items.items[0].hide();
                toolbar.items.items[0].menu.items.items[1].show();
            }

            else {
                toolbar.items.items[0].menu.items.items[0].show();
                toolbar.items.items[0].menu.items.items[1].hide();

            }

        };

        function RefreshSPClientGroupList() {
            <%= this.storeSPClientGroup.ClientID %>.reload();
        };

        var RefreshSPClientGroupData = function(btn) {
            <%= this.storeSPClientGroup.ClientID %>.reload();
        };
        
                function CloseChangePwd() {
                var win = <%= this.winChangePwd.ClientID %>;
 
        
                win.hide();
                }

                function ShowAddSPClientGroupForm() {
                Coolite.AjaxMethods.UCSPClientGroupAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientGroupData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientGroupEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientGroupData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            };


                               if (cmd == "cmdClientGroupPriceReport") {

                var win = <%= this.winClientGroupPriceReport.ClientID %>;
                

                win.setTitle(" 下家组 "+id.data.Name+"  " + " 结算报表 ");
                
                //win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ClientGroupID = id.data.Id;
        
                win.show();    
            };
            
            
                                           if (cmd == "cmdClientGroupPriceReport1") {

                var win = <%= this.winClientGroupPriceReport1.ClientID %>;
                

                win.setTitle(" 下家组 "+id.data.Name+"  " + " 结算报表 ");
                
                //win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ClientGroupID = id.data.Id;
        
                win.show();    
            };


            

                                    if (cmd == "cmdClientManage") {

                var win = <%= this.winClientmanage.ClientID %>;
                

                win.setTitle(" 下家组 "+id.data.Name+"  " + " 下家管理 ");
                
                //win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ClientGroupID = id.data.Id;
        
                win.show();    
            };

            if (cmd == "cmdChangePassword") 
            {
                var win = <%= this.winChangePwd.ClientID %>;
                
                win.setTitle(" 修改用户“"+id.data.UserLoginID+"” 登录密码 ");
                
                win.autoLoad.url = '<%= this.ResolveUrl("~/Moudles/SystemManage/UserManage/SystemUserChangePwd.aspx") %>';
                
                win.autoLoad.params.UserID = id.data.UserID;
        
                win.show();  
            };
            
            
            if (cmd == "cmdShowLoginLog") {

                var win = <%= this.winShowLoginLog.ClientID %>;
                
                win.setTitle(" 显示用户“"+id.data.UserLoginID+"” 安全日志 ");
                
                win.autoLoad.url = '<%= this.ResolveUrl("~/Moudles/SystemManage/LogViews/SystemLogList.aspx") %>';
                
                win.autoLoad.params.ParentID = id.data.UserID;
        
                win.show();    
            };             
            
    
            
            if (cmd == "cmdLock") {
                Ext.MessageBox.confirm('警告','确认要锁定当前下家登陆用户 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.LockLoginUser(
                                                                id.data.UserID,true,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功锁定当前下家登陆用户！',RefreshSPClientGroupData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            };
            
                        if (cmd == "cmdUnlock") {
                Ext.MessageBox.confirm('警告','确认要解锁当前下家登陆用户 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.LockLoginUser(
                                                                id.data.UserID,false,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功解锁当前下家登陆用户！',RefreshSPClientGroupData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            };
            
        }

    </script>
    <ext:Store ID="storeSPClientGroup" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPClientGroup_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserIsLocked" Type="Boolean" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="AssigedUserLoginID" />
                    <ext:RecordField Name="ClientList" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:Store ID="storeSPUser" runat="server" AutoLoad="true" OnRefreshData="storeSystemUser_Refresh">
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
    <uc1:UCSPClientGroupAdd ID="UCSPClientGroupAdd1" runat="server" />
    <uc2:UCSPClientGroupEdit ID="UCSPClientGroupEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientGroup" runat="server" StoreID="storeSPClientGroup"
                        StripeRows="true" Title="下家组管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientGroupForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:TextField ID="txtSreachName" runat="server" EmptyText="输入下家组名" />
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="搜索" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPClientGroup}.reload();" />
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
                                <ext:Column ColumnID="colID" DataIndex="Id" Header="主键" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colAssigedUserLoginID" Width="60" DataIndex="AssigedUserLoginID" Header="分配">
                                </ext:Column>
                                <ext:Column ColumnID="colUserID" DataIndex="UserName"  Width="80" Header="关联用户登录ID">
                                </ext:Column>
                                <ext:Column ColumnID="colUserIsLocked" DataIndex="UserIsLocked"  Header="用户状态" Sortable="false"
                                    Width="38">
                                    <Renderer Fn="showUserStatus" />
                                </ext:Column>
                                <ext:CommandColumn Header="下家组管理" Width="160">
                                    <Commands>
                                        <ext:SplitCommand Icon="cog" CommandName="Split" Text="用户管理">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand CommandName="cmdLock" Icon="Lock" Text="锁定用户" />
                                                    <ext:MenuCommand CommandName="cmdUnlock" Icon="LockOpen" Text="解锁用户" />
                                                    <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="更改密码">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="ScriptCode" CommandName="cmdShowLoginLog" Text="查看安全日志">
                                                    </ext:MenuCommand>
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="用户管理" />
                                        </ext:SplitCommand>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdClientManage" Text="下家管理">
                                            <ToolTip Text="下家管理" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="Money" CommandName="cmdClientGroupPriceReport" Text="结算报表">
                                            <ToolTip Text="结算报表" />
                                        </ext:GridCommand>
                                    </Commands>
                                    <PrepareToolbar Fn="showCommands" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientGroup"
                                DisplayInfo="true" DisplayMsg="显示下家组 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的下家组" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <p><b>下家指令列表：</b><br /> {ClientList}</p>
                        
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winClientmanage" runat="server" Title="Window" Frame="true" Width="850"
        ConstrainHeader="true" Height="480" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Clients/SPClientListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winClientGroupPriceReport" runat="server" Title="Window" Frame="true"
        Width="850" ConstrainHeader="true" Height="390" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Clients/SPClientGroupReportContainer.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winClientGroupPriceReport1" runat="server" Title="Window" Frame="true"
        Width="850" ConstrainHeader="true" Height="390" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Clients/SPClientGroupReportContainer1.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
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
