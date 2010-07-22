<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportToday.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportToday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

        var decimalFormat = function(value) {
            return formatFloat(value, 2).toString() + "%";
        };

        var filterfn = function(rec, id) {
            return (rec.data.TotalCount > 0);
        }

    </script>

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
        <Listeners>
            <Load Handler="if(#{chkFilterNoCount}.getValue()) {#{Store1}.filterBy(filterfn);} else {#{Store1}.clearFilter();}" />
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="Store1"
                        StripeRows="true" Title="即时日报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="不显示0流量的通道">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:Checkbox ID="chkFilterNoCount" Checked="true" runat="server">
                                        <Listeners>
                                            <Check Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:Checkbox>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem runat="server" Text="今日数据汇总统计">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtTotalCount" runat="server" Text="总点播数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtInterceptCount" runat="server" Text="总扣量数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtDownCount" runat="server" Text="总转发下家数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtDownSycnCount" runat="server" Text="总同步下家数(条)：0">
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
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="TotalCount" Header="点播数(条)" Sortable="true">
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
