<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.SPChannelListPage" %>
<%@ Register Src="UCSPChannelView.ascx" TagName="UCSPChannelView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';



        var showCommands = function(grid, toolbar, rowIndex, record)
        {

            if (record.data.IsParamsConvert != null && record.data.IsParamsConvert)
            {
                toolbar.items.items[0].menu.items.items[6].show();
            }

            else {
                toolbar.items.items[0].menu.items.items[6].hide();
            }

            if (record.data.HasFilters != null && record.data.HasFilters)
            {
                toolbar.items.items[0].menu.items.items[7].show();
            }
            else
            {
                toolbar.items.items[0].menu.items.items[7].hide();
            }


        };



        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPChannel.ClientID %>.reload();
        };
        
        function RefreshSPChannelData() {
            <%= this.storeSPChannel.ClientID %>.reload();
        }

        function ShowQuickAdd() {
              var win = <%= winQuickAddChannel.ClientID %>;
              win.setTitle('快速添加通道');
              win.show();
            win.maximize();
        }
        
     function CloseQuickAdd()
     {
        <%= winQuickAddChannel.ClientID %>.hide();
     }
                  
     function CloseEdit()
     {
        <%= winChannelEdit.ClientID %>.hide();
     }
 

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
 
               var win = <%= winChannelEdit.ClientID %>;
               win.autoLoad.params.ChannelID = id.id;
               win.setTitle(String.format('通道“{0}”编辑',id.data.Name));
               win.show();
               win.maximize();
            }
			
			            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPChannelView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认删除该条记录？ ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>',RefreshData);                
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
            
 
            
            if (cmd == "cmdManageParams") {
              var win = <%= winChannelParamsManage.ClientID %>;
              win.autoLoad.params.ChannelID = id.id;
              win.setTitle(String.format('通道“{0}”接收参数管理',id.data.Name));
              win.show();   
            }
            if (cmd == "cmdManageFilters") {
              var win = <%= winChannelFiltersManage.ClientID %>;
              win.autoLoad.params.ChannelID = id.id;
              win.setTitle(String.format('通道“{0}”过滤条件管理',id.data.Name));
              win.show();   
            }
            if (cmd == "cmdManageCoverts") {
              var win = <%= winParamsConvert.ClientID %>;
              win.autoLoad.params.ChannelID = id.id;
              win.setTitle(String.format('通道“{0}”数据转换管理',id.data.Name));
              win.show();   
            }           
             if (cmd == "cmdManageSycns") {
              var win = <%= winSycnParams.ClientID %>;
              win.autoLoad.params.ChannelID = id.id;
              win.setTitle(String.format('通道“{0}”同步参数管理',id.data.Name));
              win.show();   
            }    
            
                         if (cmd == "cmdManageCodes") {
              var win = <%= winCodes.ClientID %>;
              win.autoLoad.params.ChannelID = id.id;
              win.setTitle(String.format('通道“{0}”代码管理',id.data.Name));
              win.show();   
            }    
            
                   if (cmd == "cmdSendTestRequest") {

                var win = <%= this.winSendTestRequestForm.ClientID %>;
                

                win.setTitle(" 通道 "+id.data.Name+"  " + " 发送模拟数据 ");
                
                win.autoLoad.url = 'SPChannelSendTestRequestForm.aspx';
                
                win.autoLoad.params.ChannelID = id.data.Id;
        
                win.show();    
            }                                                    
                                            
        }

    </script>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPChannel_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="ChannelTypeName" />
                    <ext:RecordField Name="IsMonitorRequest" Type="Boolean" />
                    <ext:RecordField Name="IsDisable" Type="Boolean" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="DefaultRate" Type="int" />
                    <ext:RecordField Name="UpperID" Type="int" />
                    <ext:RecordField Name="IsLogRequest" Type="Boolean" />
                    <ext:RecordField Name="IsParamsConvert" Type="Boolean" />
                    <ext:RecordField Name="HasFilters" Type="Boolean" />
                    <ext:RecordField Name="StatusReportType" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc3:UCSPChannelView ID="UCSPChannelView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeSPChannel" StripeRows="true"
                Title="通道管理" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="快速添加通道" Icon="Add">
                                <Listeners>
                                    <Click Handler="ShowQuickAdd();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPChannel}.reload();" />
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
                        <ext:Column ColumnID="colID" DataIndex="Id" Width="30" Header="主键" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="编码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colChannelTypeName" DataIndex="ChannelTypeName" Header="通道类型"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsMonitorRequest" DataIndex="IsMonitorRequest" Header="监控"
                            Sortable="true" Width="30">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsDisable" DataIndex="IsDisable" Header="禁用" Sortable="true"
                            Width="30">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colHasFilters" DataIndex="HasFilters" Header="过滤" Sortable="true"
                            Width="30">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Sortable="true" Width="30">
                        </ext:Column>
                        <ext:Column ColumnID="colDefaultRate" DataIndex="DefaultRate" Header="扣率" Sortable="true"
                            Width="30">
                        </ext:Column>
                        <ext:Column ColumnID="colIsLogRequest" DataIndex="IsLogRequest" Header="日志" Sortable="true"
                            Width="30">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colStatusReportType" DataIndex="StatusReportType" Header="状态报告类型"
                            Width="60" Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="查看">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="DatabaseGo" CommandName="cmdManageParams" Text="接收参数管理">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="DatabaseLink" CommandName="cmdManageSycns" Text="同步参数管理">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Script" CommandName="cmdManageCodes" Text="代码管理">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="DatabaseRefresh" CommandName="cmdManageCoverts" Text="数据转换管理">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="DatabaseLightning" CommandName="cmdManageFilters" Text="过滤条件管理">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdSendTestRequest" Text="通道测试">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                            <PrepareToolbar Fn="showCommands" />
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPChannel" 
                        DisplayInfo="true" DisplayMsg="显示通道 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winQuickAddChannel" runat="server" Title="Window" Frame="true" Width="800"
        ConstrainHeader="true" Height="600" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelQuickAdd.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelEdit" runat="server" Title="Window" Frame="true" Width="800"
        ConstrainHeader="true" Height="600" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelEdit.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelParamsManage" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="350" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelParamsListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelFiltersManage" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="350" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelFiltersListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winSycnParams" runat="server" Title="Window" Frame="true" Width="700"
        ConstrainHeader="true" Height="350" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelSycnParamsListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winCodes" runat="server" Title="Window" Frame="true" Width="810"
        Icon="Script" ConstrainHeader="true" Height="430" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="../Codes/SPCodeTreeListPage.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winParamsConvert" runat="server" Title="winParamsConvert" Frame="true"
        Width="700" ConstrainHeader="true" Height="350" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SPChannelParamsConvertListPage.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
