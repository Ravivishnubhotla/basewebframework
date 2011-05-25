<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.SPCodeList" %>

<%@ Register Src="UCSPClientChannelSettingInfoEdit.ascx" TagName="UCSPClientChannelSettingInfoEdit"
    TagPrefix="uc5" %>
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

        var change = function (value) {
            return String.format(template, (value) ? 'green' : 'red', FormatBool(value));
        }

        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }


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


    

        function processcmd(cmd, id) {

            if (cmd == "cmdParamsEdit") {
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
                    <ext:RecordField Name="ClientGroupName" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="AllowFilter" Type="Boolean" />
                    <ext:RecordField Name="AllowAndDisableArea" />
                    <ext:RecordField Name="SettlementPeriod" />
                    <ext:RecordField Name="DayLimitAndMonthLimit" />
                    <ext:RecordField Name="SendText" />
                    <ext:RecordField Name="Getway" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <uc5:UCSPClientChannelSettingInfoEdit ID="UCSPClientChannelSettingInfoEdit1" runat="server" />
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
                                    <ext:ToolbarTextItem Text="省份">
                                    </ext:ToolbarTextItem>
                                    <ext:TextField ID="txtProvince" runat="server">
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
                                <ext:Column ColumnID="colChannelClientCode" DataIndex="ChannelClientCode" Header="指令"
                                    Sortable="false" Width="120">
                                </ext:Column>
                                <ext:Column ColumnID="colAllowAndDisableArea" DataIndex="AllowAndDisableArea" Header="开通省份"
                                    Sortable="false" Width="120">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colSendText" DataIndex="SendText" Header="下发语" Sortable="false"
                                    Wrap="true" Width="120">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colGetway" DataIndex="Getway" Header="运营商" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colDayLimitAndMonthLimit" DataIndex="DayLimitAndMonthLimit"
                                    Header="日限月限" Sortable="false">
                                </ext:Column>
                                <ext:CommandColumn Header="设置管理" Width="50">
                                    <Commands>
                                        <ext:GridCommand Icon="Cog" Text="设置" ToolTip-Text="指令设置">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ServerConnect" CommandName="cmdParamsEdit" Text="设置" />
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Menu" />
                                        </ext:GridCommand>
                                    </Commands>
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
</asp:Content>
