<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.SPCodeList" %>
<%@ Register Src="../Clients/UCSPClientEdit.ascx" TagName="UCSPClientEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPClientChannelSettingInfoEdit.ascx" TagName="UCSPClientChannelSettingInfoEdit"
    TagPrefix="uc5" %>
 <%@ Register Src="UCSPClientChannelSettingBaseEdit.ascx" TagName="UCSPClientChannelSettingBaseEdit"
    TagPrefix="uc7" %>   

    <%@ Register Src="UCSPClientChannelQuery.ascx" TagName="UCSPClientChannelQuery"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannel}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:Store ID="storeSPClientGroup" runat="server" AutoLoad="false" OnRefreshData="storeSPClientGroup_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <style type="text/css">
        .x-grid3-td-fullName .x-grid3-cell-inner
        {
            font-family: tahoma, verdana;
            display: block;
            font-weight: normal;
            font-style: normal;
            color: #385F95;
            white-space: normal;
        }
        .x-grid3-row-body p
        {
            margin: 5px 5px 10px 5px !important;
            width: 99%;
            color: Gray;
        }
    </style>
    <script type="text/javascript">

       var template = '<span style="color:{0};">{1}</span>';

       var change = function(value) {
           return String.format(template, (value) ? 'green' : 'red', FormatBool(value));
       };

        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };


        function RefreshSPClientChannelSettingList() {
            <%= this.storeSPClientChannelSetting.ClientID %>.reload();
        };

        var RefreshSPClientChannelSettingData = function(btn) {
            <%= this.storeSPClientChannelSetting.ClientID %>.reload();
        };
        
 

         function prepareToolbar(grid, toolbar, rowIndex, record){
            if(record.get("SyncData")!=null && record.get("SyncData")){
                toolbar.items.itemAt(0).items.itemAt(1).show();
            }
            else{
                toolbar.items.itemAt(0).items.itemAt(1).hide();
            }
        }
 

        var showCommands = function(grid, toolbar, rowIndex, record) {

            if (record.data.SyncData != null && record.data.SyncData) {
                toolbar.items.items[0].menu.items.items[2].show();
 
            } else {
                toolbar.items.items[0].menu.items.items[2].hide();
 

            }

 
        };


    

        function processcmd(cmd, id) {

            if (cmd == "cmdSetCode") {
                Coolite.AjaxMethods.UCSPClientChannelSettingInfoEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }
            

            if (cmd == "cmdSetSycn") {
                Coolite.AjaxMethods.UCSPClientChannelSettingBaseEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            
            
            if (cmd == "cmdQueryData") {
                Coolite.AjaxMethods.UCSPClientChannelQuery.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }
            

            if (cmd == "cmdClientEdit") {
                Coolite.AjaxMethods.UCSPClientEdit.Show(id.data.ClinetID_ID,
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

            
          if (cmd == "cmdTest") {

                var win = <%= this.winSendTestRequestForm.ClientID %>;
                

                win.setTitle("  "+id.data.Name + "  " + " 发送模拟数据 ");
                
                win.autoLoad.url = '../Channels/SPChannelSendTestRequestForm.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
                win.autoLoad.params.ChannleID = id.data.ChannelID_ID;

        
                win.show();    
            } 
            
            
           if (cmd == "cmdTestClient") {

                var win = <%= this.WindwinSendClientTestRequestFormow1.ClientID %>;
                

                win.setTitle("  "+id.data.Name + "  " + " 下家发送模拟数据 ");
                
                win.autoLoad.url = 'SPChannelClientSendClientTestRequestForm.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
        
                win.show();    
            }  

 
 

 
 


 

       

        }
        function columnWrap(val){
    return '<div style="white-space:normal !important;">'+ val +'</div>';
}

    </script>
    <ext:Store ID="storeSPClientChannelSetting" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPClientChannelSetting_Refresh">
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
                    <ext:RecordField Name="InterceptRate" Type="int" />
                    <ext:RecordField Name="ChannelClientCode" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ClinetID_ID" />
                    <ext:RecordField Name="MoCode" />
                    <ext:RecordField Name="ChannelID_ID" />
                    <ext:RecordField Name="ClientGroupName" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="AllowFilter" Type="Boolean" />
                    <ext:RecordField Name="DayLimitAndMonthLimit" />
                    <ext:RecordField Name="DayTotalLimitInfo" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <uc5:UCSPClientChannelSettingInfoEdit ID="UCSPClientChannelSettingInfoEdit1" runat="server" />
     <uc6:UCSPClientChannelQuery ID="UCSPClientChannelQuery1" runat="server" />   
      <uc7:UCSPClientChannelSettingBaseEdit ID="UCSPClientChannelSettingBaseEdit1" runat="server" />      
        <uc2:UCSPClientEdit ID="UCSPClientEdit1" runat="server" />
    
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeSPClientChannelSetting"
                        AutoScroll="true" StripeRows="true" Title="指令管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannel"
                                        TypeAhead="true" Mode="Local" Editable="false" DisplayField="Name" ValueField="Id"
                                        EmptyText="全部">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="指令">
                                    </ext:ToolbarTextItem>
                                    <ext:TextField ID="txtMO" runat="server">
                                    </ext:TextField>
                                    <ext:ToolbarTextItem Text="端口号">
                                    </ext:ToolbarTextItem>
                                    <ext:TextField ID="txtPort" runat="server">
                                    </ext:TextField>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="搜索" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPClientChannelSetting}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <View>
                            <ext:GridView ForceFit="true" ID="GridView1" EnableRowBody="false">
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClientName" DataIndex="ClientName" Header="下家名" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClientGroupName" DataIndex="ClientGroupName" Header="下家组"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colMoCode" DataIndex="MoCode" Header="指令" Sortable="false"
                                    Width="120">
                                </ext:Column>
                                <ext:Column ColumnID="colDayLimitAndMonthLimit" DataIndex="DayLimitAndMonthLimit"
                                    Header="日限月限" Sortable="True">
                                </ext:Column>
                                <ext:Column ColumnID="colDayTotalLimitInfo" DataIndex="DayTotalLimitInfo" Header="日总限"
                                    Sortable="True">
                                </ext:Column>
                                <ext:CommandColumn Header="设置管理" Width="50">
                                    <Commands>
                                        <ext:GridCommand Icon="Cog" Text="设置" ToolTip-Text="指令设置">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdSetCode" Text="设置" />
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdSetSycn" Text="同步地址" />
                                                    <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdTest" Text="通道测试" />
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdClientEdit" Text="下家编辑" />
                                                    <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdTestClient" Text="下家测试" />
                                                    <ext:MenuCommand Icon="Find" CommandName="cmdQueryData" Text="查询" />
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Menu" />
                                        </ext:GridCommand>
                                    </Commands>
                                    <PrepareToolbar Fn="showCommands" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientChannelSetting"
                                DisplayInfo="true" DisplayMsg="显示指令 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的指令" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="380" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="WindwinSendClientTestRequestFormow1" runat="server" Title="下家模拟数据测试"
        Frame="true" Width="640" ConstrainHeader="true" Height="380" Maximizable="true"
        Closable="true" Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
