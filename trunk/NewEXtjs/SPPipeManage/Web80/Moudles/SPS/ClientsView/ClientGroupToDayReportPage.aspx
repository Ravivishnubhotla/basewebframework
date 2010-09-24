<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupToDayReportPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupToDayReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();#{storeTodayReport}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../Clients/SPClientsHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="datas" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="DataType" Mode="Value" Value="GetAllClientByClientGroup">
            </ext:Parameter>
        </BaseParams>
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
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="Name" ValueField="Id"
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
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
</asp:Content>
