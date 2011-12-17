<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.SPChannelListPage" %>

<%@ Register Src="UCSPChannelEdit.ascx" TagName="UCSPChannelEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPChannelView.ascx" TagName="UCSPChannelView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:resourcemanagerproxy id="ScriptManagerProxy1" runat="server">
    </ext:resourcemanagerproxy>
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
               win.setTitle('编辑通道');
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
                Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
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
            
                                                         
                                            
        }

    </script>
    <ext:store id="storeSPChannel" runat="server" autoload="true" remotesort="true" remotepaging="true"
        onrefreshdata="storeSPChannel_Refresh">
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
                    <ext:RecordField Name="IsMonitorRequest" Type="Boolean" />
                    <ext:RecordField Name="IsDisable" Type="Boolean" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="DefaultRate" Type="int" />
                    <ext:RecordField Name="UpperID" Type="int" />
                    <ext:RecordField Name="IsLogRequest" Type="Boolean" />
                    <ext:RecordField Name="IsParamsConvert" Type="Boolean" />
                    <ext:RecordField Name="HasFilters" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ucspchanneledit id="UCSPChannelEdit1" runat="server" />
    <uc3:ucspchannelview id="UCSPChannelView1" runat="server" />
    <ext:viewport id="viewPortMain" runat="server" layout="fit">
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
                        <ext:Column ColumnID="colIsMonitorRequest" DataIndex="IsMonitorRequest" Header="监控"
                            Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsDisable" DataIndex="IsDisable" Header="禁用" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colHasFilters" DataIndex="HasFilters" Header="过滤" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDefaultRate" DataIndex="DefaultRate" Header="扣率" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsLogRequest" DataIndex="IsLogRequest" Header="日志" Sortable="true">
                            <Renderer Fn="FormatBool" />
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
    </ext:viewport>
    <ext:window id="winQuickAddChannel" runat="server" title="Window" frame="true" width="800"
        constrainheader="true" height="600" maximizable="true" closable="true" resizable="true"
        modal="true" hidden="true">
        <AutoLoad Url="SPChannelQuickAdd.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:window>
    <ext:window id="winChannelEdit" runat="server" title="Window" frame="true" width="800"
        constrainheader="true" height="600" maximizable="true" closable="true" resizable="true"
        modal="true" hidden="true">
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
    </ext:window>
    <ext:window id="winChannelParamsManage" runat="server" title="Window" frame="true"
        width="700" constrainheader="true" height="350" maximizable="true" closable="true"
        resizable="true" modal="true" hidden="true">
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
    </ext:window>
    <ext:window id="winChannelFiltersManage" runat="server" title="Window" frame="true"
        width="700" constrainheader="true" height="350" maximizable="true" closable="true"
        resizable="true" modal="true" hidden="true">
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
    </ext:window>
    <ext:window id="winSycnParams" runat="server" title="Window" frame="true" width="700"
        constrainheader="true" height="350" maximizable="true" closable="true" resizable="true"
        modal="true" hidden="true">
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
    </ext:window>
    <ext:window id="winCodes" runat="server" title="Window" frame="true" width="700"
        icon="Script" constrainheader="true" height="350" maximizable="true" closable="true"
        resizable="true" modal="true" hidden="true">
        <AutoLoad Url="../Codes/SPChannelCodeListPage.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:window>
    <ext:window id="winParamsConvert" runat="server" title="winParamsConvert" frame="true"
        width="700" constrainheader="true" height="350" maximizable="true" closable="true"
        resizable="true" modal="true" hidden="true">
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
    </ext:window>
</asp:Content>
