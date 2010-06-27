<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportChannel.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }


        var pctChange = function(value) {
            return String.format(template, (value > 0) ? "green" : "green", formatFloat(value, 2).toString() + "%");
        };
    </script>

    <ext:Store ID="storeSPChannelAdd" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../Channels/SPChannelHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="channels" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData">
        <Reader>
            <ext:JsonReader ReaderID="ReportID">
                <Fields>
                    <ext:RecordField Name="ReportID" Type="Int" />
                    <ext:RecordField Name="ReportDate" Type="Date" DateFormat="Y-m-dTh:i:s" />
                    <ext:RecordField Name="UpTotalCount" Type="Int" />
                    <ext:RecordField Name="UpSuccess" Type="Int" />
                    <ext:RecordField Name="InterceptTotalCount" Type="Int" />
                    <ext:RecordField Name="InterceptSuccess" Type="Int" />
                    <ext:RecordField Name="DownSuccess" Type="Int" />
                    <ext:RecordField Name="InterceptSuccess" Type="Int" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="LastChange" Type="Date" DateFormat="Y-m-dTh:i:s" />
                    <ext:RecordField Name="InterceptRate" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannelAdd}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="Store1"
                        StripeRows="true" Title="数据日报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannelAdd"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="Name" ValueField="Id"
                                        EmptyText="全部" />
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
                                <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true" Width=80>
                                </ext:Column>
                                <ext:Column ColumnID="colUpTotalCount" DataIndex="UpTotalCount" Header="总数（下行数）"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="UpSuccess" Header="总数（成功数)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col1" DataIndex="InterceptRate" Header="总数（成功率)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col23" DataIndex="UpTotalCount" Header="同步数（下行数）" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col25" DataIndex="UpSuccess" Header="同步数（成功数)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col26" DataIndex="InterceptRate" Header="同步数（成功率)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col33" DataIndex="UpTotalCount" Header="扣量（下行数）" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col35" DataIndex="UpSuccess" Header="扣量（成功数)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="col36" DataIndex="InterceptRate" Header="扣量（成功率)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣量率" Sortable="true" Width=50>
                                    <Renderer Fn="pctChange" />
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
