<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupViewDaySum.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupViewDaySum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>

    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="false" OnRefreshData="storeSPClient_OnRefresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="DisplayName" Mapping="DisplayName" />
                    <ext:RecordField Name="DefaultChannelID" Mapping="DefaultChannelID" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="DataType" Mode="Value" Value="GetAllClientByClientGroup">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Store ID="store1" runat="server" AutoLoad="false" OnRefreshData="store1_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="RID">
                <Fields>
                    <ext:RecordField Name="RID" Type="int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="DownCount" Type="Int" />
                    <ext:RecordField Name="DownSycnCount" Type="Int" />
                    <ext:RecordField Name="Price" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script type="text/javascript">
   var gridCommand = function(command, record, row, col) {
       if (command == 'cmdChartProvince') {
                
               var win = <%= this.winRrovinceReport.ClientID %>;

                var cmbclient = <%= this.cmbClientID.ClientID %>;

                var clientID = cmbclient.getValue();

               var storeClient = <%= this.storeSPClient.ClientID %>;

                win.setTitle("通道 【" + cmbclient.getText()   +"】  日期：【" +  Ext.util.Format.date(record.data.ReportDate,'Y-m-d') + "】省份分布 ");
                
 
                
                win.autoLoad.params.ChannleID = storeClient.getById(clientID).data.DefaultChannelID;
                win.autoLoad.params.ClientID = clientID;
                win.autoLoad.params.StartDate = record.data.ReportDate;
                win.autoLoad.params.EndDate = record.data.ReportDate;
                win.autoLoad.params.DataType = "downcountdetail";
                win.autoLoad.params.IsClientShow = "1";        

        win.show(); 
            }
        };
  </script>

    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="日报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbClientID" runat="server" AllowBlank="true" StoreID="storeSPClient"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="DisplayName"
                                        ValueField="Id" EmptyText="全部">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();if(#{cmbClientID}.getValue()!='') {#{gridPanelSPClientChannelSetting}.colModel.setHidden(5, false);} else {#{gridPanelSPClientChannelSetting}.colModel.setHidden(5, true);}" />
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
                                <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true"
                                    Width="20">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:Column ColumnID="colChannelName" DataIndex="ChannelName" Header="通道" Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colDownCount" DataIndex="DownCount" Header="点播数" Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colDownSycnCount" DataIndex="DownSycnCount" Header="同步下发数"
                                    Sortable="true" Width="20">
                                </ext:Column>
                                <ext:CommandColumn ColumnID="colChart" Header="统计" Width="100" Hidden="true">
                                    <Commands>
                                        <ext:GridCommand Icon="ChartBar" CommandName="cmdChartProvince" Text="省份分布">
                                            <ToolTip Text="省份分布" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <Listeners>
                            <Command Fn="gridCommand" />
                        </Listeners>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winRrovinceReport" runat="server" Title="数据省份分布报表" Frame="true" Width="640"
        ConstrainHeader="true" Height="480" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Reports/DataProviceReport.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ClientID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="StartDate" Mode="Raw" Value="2009-1-1">
                </ext:Parameter>
                <ext:Parameter Name="EndDate" Mode="Raw" Value="2009-1-1">
                </ext:Parameter>
                <ext:Parameter Name="DataType" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="IsClientShow" Mode="Raw" Value="1">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
