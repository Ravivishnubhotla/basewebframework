<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportChannel.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

        var decimalFormat = function(value) {
            return formatFloat(value, 2).toString() + "%";
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
                    <ext:RecordField Name="TotalCount" Type="Int" />
                    <ext:RecordField Name="DownCount" Type="Int" />
                    <ext:RecordField Name="InterceptCount" Type="Int" />
                    <ext:RecordField Name="DownSycnCount" Type="Int" />
                    <ext:RecordField Name="InterceptRate" Type="Float" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="ClientName" />
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
                        StripeRows="true" Title="通道数据报表" Icon="Table">
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
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="TotalCount" Header="总点播数(条)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptSuccess" DataIndex="InterceptCount" Header="扣量数(条)"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDownSuccess" DataIndex="DownCount" Header="转发下家数(条)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDownSuccess" DataIndex="DownSycnCount" Header="同步下家数(条)"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣量率" Sortable="true">
                                    <Renderer Fn="decimalFormat" />
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
