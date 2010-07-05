<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientToDayReportPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientToDayReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    <Listeners>
    <DocumentReady Handler="#{storeSPChannel}.reload();" />
    </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../Channels/SPChannelHandlerByClientID.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="channels" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AutoLoadParams>
            <ext:Parameter Name="ClinetID" Mode="Raw" Value="#{hidId}.getValue()">
            </ext:Parameter>
        </AutoLoadParams>
    </ext:Store>
    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData">
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
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="Store1"
                        StripeRows="true" Title="即时统计" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                                                       <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannel"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="Name" ValueField="Id"
                                        EmptyText="全部" /> 
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
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
</asp:Content>
