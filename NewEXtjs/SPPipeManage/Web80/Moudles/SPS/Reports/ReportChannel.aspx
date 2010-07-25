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

        var filterfn = function(rec, id) {
            return (rec.data.TotalCount > 0);
        }



//        var prepareCellCommandTotalCount = function(grid, command, record, row, col, value) {
//            if (command.command == 'TotalCountDetail' && record.data.TotalCount > 0) {
//                if (record.data.TotalCount == 9421) {
//                    alert(record);
//                }
//                command.hidden = false;
//                command.hideMode = 'display'; //you can try 'visibility' also                
//            }
//        };


//        var prepareCellCommandDownCount = function(grid, command, record, row, col, value) {
//            if (command.command == 'DownCountDetail' && record.data.DownCount > 0) {
//                if (row > 0) {
//                    command.hidden = false;
//                    command.hideMode = 'display'; //you can try 'visibility' also
//                }
//                else {
//                    alert('111');
//                }

//            }
//        };


//        var prepareCellCommandInterceptCount = function(grid, command, record, row, col, value) {
//        if (command.command == 'InterceptCountDetail' && record.data.InterceptCount > 0) {
//            command.hidden = false;
//                command.hideMode = 'display'; //you can try 'visibility' also                
//            }
//        };


//        var prepareCellCommandDownSycnCount = function(grid, command, record, row, col, value) {
//        if (command.command == 'DownSycnCountDetail' && record.data.DownSycnCount > 0) {
//            command.hidden = false;
//                command.hideMode = 'display'; //you can try 'visibility' also                
//            }
//        };
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
    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData" GroupField="ReportDate">
        <SortInfo Direction="DESC" Field="ReportDate" />
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
                    <ext:RecordField Name="ReportDate" Type="Date" DateFormat="Y-m-dTh:i:s" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{txtTotalCount}.setText('总点播数(条)：'+this.sum('TotalCount'));#{txtInterceptCount}.setText('总扣量数(条)：'+this.sum('InterceptCount'));#{txtDownCount}.setText('总转发下家数(条)：'+this.sum('DownCount'));#{txtDownSycnCount}.setText('总同步下家数(条)：'+this.sum('DownSycnCount'));if(#{chkFilterNoCount}.getValue()) {#{Store1}.filterBy(filterfn);} else {#{Store1}.clearFilter();}" />
        </Listeners>
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
                        StripeRows="true" Title="汇总报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannelAdd"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="Name" ValueField="Id"
                                        EmptyText="全部" Visible="false" />
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
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="数据汇总统计">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtTotalCount" runat="server" Text="总点播数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtInterceptCount" runat="server" Text="总扣量数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtDownCount" runat="server" Text="总转发下家数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtDownSycnCount" runat="server" Text="总同步下家数(条)：0">
                                    </ext:ToolbarTextItem>
                                                                        <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                                                        <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem2" runat="server" Text="不显示0流量的通道">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:Checkbox ID="chkFilterNoCount" Checked=false runat="server">
                                        <Listeners>
                                            <Check Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:Checkbox>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colReportDate" Header="日期" Sortable="true" DataIndex="ReportDate"
                                    Width="50">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:GroupingSummaryColumn ColumnID="colChannelID" Header="通道" DataIndex="ChannelName"
                                    Groupable="true" Hideable="false" SummaryType="None" Sortable="false">
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colClinetID" Header="下家" DataIndex="ClientName"
                                    Groupable="true" Hideable="false" SummaryType="None" Sortable="false">
                                    <SummaryRenderer Handler="return '总计';" />
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colUpSuccess" Header="总点播数(条)" DataIndex="TotalCount"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false" Width="80">
<%--                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="TotalCountDetail" Hidden=true>
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" />--%>
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colInterceptSuccess" Header="扣量数(条)" DataIndex="InterceptCount"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false">
<%--                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="InterceptCountDetail" Hidden=true>
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                        
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandInterceptCount" />--%>
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colDownCount" Header="转发下家数(条)" DataIndex="DownCount"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false">
<%--                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="DownCountDetail" Hidden=true>
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                                                                
                                    </Commands><PrepareCommand Fn="prepareCellCommandDownCount" />--%>
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colDownSycnCount" Header="同步下家数(条)" DataIndex="DownSycnCount"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false">
<%--                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="DownSycnCountDetail" Hidden=true>
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                        
                                    </Commands><PrepareCommand Fn="prepareCellCommandDownSycnCount" />--%>
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colInterceptRate" Header="扣量率" DataIndex="InterceptRate"
                                    Groupable="false" Hideable="false" SummaryType="None" Sortable="false">
                                    <Renderer Fn="decimalFormat" />
                                </ext:GroupingSummaryColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <View>
                            <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" ShowGroupName="false"
                                EnableNoGroups="true" HideGroupedColumn="true" />
                        </View>
                        <Plugins>
                            <ext:GroupingSummary ID="GroupingSummary1" runat="server" />
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
