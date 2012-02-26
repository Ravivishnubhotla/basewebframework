<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupToDayReportPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupToDayReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        function ShowProviceChart(channleValue, tbProviceChart) {
            if (channleValue != null && channleValue != '') {
                tbProviceChart.show();
            }
            else {
                tbProviceChart.hide();           
            }
        }

        function showProvince(clientID,storeClient) { 
            var win = <%= this.winRrovinceReport.ClientID %>;
 
                win.autoLoad.params.ChannleID = storeClient.getById(clientID).data.DefaultChannelID;
                win.autoLoad.params.ClientID = clientID;
                //win.autoLoad.params.StartDate = record.data.ReportDate;
                //win.autoLoad.params.EndDate = record.data.ReportDate;
                win.autoLoad.params.DataType = "downcountdetail";
                win.autoLoad.params.IsClientShow = "1"; 
            win.show(); 
        }
    </script>
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
        <Listeners>
            <Load Handler="#{storeTodayReport}.reload();" />
        </Listeners>
    </ext:Store>
    <ext:Store ID="storeTodayReport" runat="server" OnRefreshData="storeTodayReport_RefreshData">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="CHour" />
                    <ext:RecordField Name="Count" Type="Int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeTodayReport"
                        StripeRows="true" Title="即时统计" Icon="Table">
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
                                            <Select Handler="this.triggers[0].show();ShowProviceChart(this.getValue(),#{tbProviceChart});" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();ShowProviceChart(this.getValue(),#{tbProviceChart}); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarButton ID='tbProviceChart' runat="server" Text="省份分布" Icon="ChartBar"
                                        Hidden="true">
                                        <Listeners>
                                            <Click Handler="showProvince(#{cmbClientID}.getValue(),#{storeSPClient});" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeTodayReport}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarTextItem ID="txtTotalCount" runat="server" Text="共计:">
                                    </ext:ToolbarTextItem>
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
                                <ext:Column ColumnID="colReportDate" DataIndex="CHour" Header="小时" Sortable="true"
                                    Width="80">
                                </ext:Column>
                                <ext:Column ColumnID="colUpTotalCount" DataIndex="Count" Header="点播数" Sortable="true">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
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
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
</asp:Content>
