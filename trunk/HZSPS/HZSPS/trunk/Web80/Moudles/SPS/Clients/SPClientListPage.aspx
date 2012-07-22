<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.SPClientListPage" %>

<%@ Register Src="UCSPClientAdd.ascx" TagName="UCSPClientAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPClientEdit.ascx" TagName="UCSPClientEdit" TagPrefix="uc2" %>
<%@ Register Src="UCClientParamsSetting.ascx" TagName="UCClientParamsSetting" TagPrefix="uc3" %>
<%@ Register Src="UCSPSendClientParamsClone.ascx" TagName="UCSPSendClientParamsClone"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
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

        function RefreshSPClientList() {
            <%= this.storeSPClient.ClientID %>.reload();
        };

        var RefreshSPClientData = function(btn) {
            <%= this.storeSPClient.ClientID %>.reload();
        };
        
        function ShowAddSPClientForm() {
                Coolite.AjaxMethods.UCSPClientAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }



        function ShowAddToSPClientGroup() {
                
                var win = <%= this.winSPClientAddToGroup.ClientID %>;
        
                win.show();   

        }

                function CloseAddToSPClientGroup() {
                
                var win = <%= this.winSPClientAddToGroup.ClientID %>;
        
                win.hide();   

        }


                function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

 
        

        var decimalFormat1 = function(value) {
            return formatFloat(value, 2).toString(); 
        };


        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }
            
            


            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要将所选下家从下家组中移除 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.RemoveFromGroup(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功把下家从下家组中移除！',RefreshSPClientData);            
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




            if (cmd == "cmdLock") {
                Ext.MessageBox.confirm('警告','确认要将所选下家登录用户锁定 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.LockLoginUser(
                                                                id.id,true,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功把下家登录用户锁定！',RefreshSPClientData);            
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


            if (cmd == "cmdUnlock") {
                Ext.MessageBox.confirm('警告','确认要将所选下家登录用户解锁 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.LockLoginUser(
                                                                id.id,false,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功把下家登录用户解锁！',RefreshSPClientData);            
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

            if (cmd == "cmdChangePassword") 
            {
                                var win = <%= this.winChangePwd.ClientID %>;
                
                win.setTitle(" 修改用户“"+id.data.UserLoginID+"” 登录密码 ");
                
                win.autoLoad.url = '<%= this.ResolveUrl("~/Moudles/SystemManage/UserManage/SystemUserChangePwd.aspx") %>';
                
                win.autoLoad.params.UserID = id.data.UserID;
        
                win.show();  
                
                
 
            }
            
            
            if (cmd == "cmdShowLoginLog") {

                var win = <%= this.winShowLoginLog.ClientID %>;
                
                win.setTitle(" 显示用户“"+id.data.UserLoginID+"” 安全日志 ");
                
                win.autoLoad.url = '<%= this.ResolveUrl("~/Moudles/SystemManage/LogViews/SystemLogList.aspx") %>';
                
                win.autoLoad.params.ParentID = id.data.UserID;
        
                win.show();    
            } 

            
                        if (cmd == "cmdParams") {
                Coolite.AjaxMethods.UCClientParamsSetting.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
                
                
        
                
                
                
            }
            





            
             if (cmd == "cmdParamsClone") {
                Coolite.AjaxMethods.UCSPSendClientParamsClone.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
             }
                  
        }

    </script>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSPClient_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Alias" />
                    <ext:RecordField Name="InterceptRate" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="RecieveDataUrl" />
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="UserIsLocked" Type="Boolean" />
                    <ext:RecordField Name="ClientGroupName" />
                    <ext:RecordField Name="ChannelClientCode" />
                    <ext:RecordField Name="Price" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientAdd ID="UCSPClientAdd1" runat="server" />
    <uc2:UCSPClientEdit ID="UCSPClientEdit1" runat="server" />
    <uc3:UCClientParamsSetting ID="UCClientParamsSetting1" runat="server" />
    <uc5:UCSPSendClientParamsClone ID="UCSPSendClientParamsClone1" runat="server" />
    <ext:Hidden ID="hidSearchText" runat="server">
    </ext:Hidden>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClient" runat="server" StoreID="storeSPClient" StripeRows="true"
                        Title="下家管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnAddToClientGroup' runat="server" Text="添加到下家组" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddToSPClientGroup();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:TextField ID="txtSreachName" runat="server" EmptyText="输入下家名" />
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查找" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{hidSearchText}.setValue(#{txtSreachName}.getValue());#{storeSPClient}.reload();" />
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
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colAlias" DataIndex="Alias" Header="下家显示名" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelClientCode" DataIndex="ChannelClientCode" Header="指令"
                                    Width="120" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Width="35" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣率" Width="35"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colRecieveDataUrl" DataIndex="RecieveDataUrl" Header="接收数据接口"
                                    Hidden="true" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserID" DataIndex="UserLoginID" Header="关联用户" Width="55"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClientGroupName" DataIndex="ClientGroupName" Header="所属下家组"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserIsLocked" DataIndex="UserIsLocked" Header="用户状态" Sortable="false"
                                    Width="50">
                                    <Renderer Fn="showUserStatus" />
                                </ext:Column>
                                <ext:CommandColumn Header="下家管理" Width="160">
                                    <Commands>
                                        <ext:SplitCommand Icon="cog" CommandName="Split" Text="下家管理">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑" />
                                                    <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="移出下家组" />
                                                    <ext:MenuCommand CommandName="cmdLock" Icon="Lock" Text="锁定用户" />
                                                    <ext:MenuCommand CommandName="cmdUnlock" Icon="LockOpen" Text="解锁用户" />
                                                    <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="更改密码">
                                                    </ext:MenuCommand>
                                                    <ext:MenuCommand Icon="ScriptCode" CommandName="cmdShowLoginLog" Text="查看安全日志">
                                                    </ext:MenuCommand>
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Split" />
                                        </ext:SplitCommand>
                                        <ext:GridCommand Icon="ServerEdit" CommandName="cmdParams" Text="参数管理" Hidden="true">
                                            <ToolTip Text="参数管理" />
                                        </ext:GridCommand>
                                    </Commands>
                                    <PrepareToolbar Fn="showCommands" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" Msg="处理中..." />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="storeSPClient"
                                DisplayInfo="true" DisplayMsg="显示下家 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的下家" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winSPClientAddToGroup" runat="server" Title="添加到下家组" Frame="true"
        Width="320" ConstrainHeader="true" Height="240" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="SPClientAddToGroup.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
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
