<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReportClientRecordDateRange.aspx.cs" Inherits="SPSWeb.Moudles.SPS.ClientView.ReportClientRecordDateRange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPDayReport" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPDayReport_Refresh" GroupField="ReportDate">
        <SortInfo Direction="DESC" Field="ReportDate" />
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="CodeID_MoCode" />
                    <ext:RecordField Name="DownTotalCount" Type="int" />
                    <ext:RecordField Name="DownSycnSuccess" Type="int" />
                    <ext:RecordField Name="DownSycnFailed" Type="int" />
                    <ext:RecordField Name="DownNotSycn" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig Timeout="120000">
        </DirectEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPDayReport" runat="server" StoreID="storeSPDayReport"
                StripeRows="true" Title="汇总报表" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:DateField ID="dfStart" FieldLabel="开始时间" LabelWidth="60" AllowBlank="false"
                                Width="150" runat="server" />
                            <ext:ToolbarSpacer />
                            <ext:DateField ID="dfEnd" FieldLabel="结束时间" LabelWidth="60" AllowBlank="false" Width="150"
                                runat="server" />
                            <ext:Button ID='btnRefresh' runat="server" Text="查询" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPDayReport}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnToggleGroups" runat="server" Text="收起/展开 分组" Icon="TableSort"
                                AutoPostBack="false">
                                <Listeners>
                                    <Click Handler="#{gridPanelSPDayReport}.getView().toggleAllGroups();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <View>
                    <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                        ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                </View>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true"
                            Groupable="True">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                        </ext:Column>
                        <ext:Column ColumnID="colCodeID" DataIndex="CodeID_MoCode" Header="代码" Sortable="true"
                            Groupable="True">
                        </ext:Column>
                        <ext:GroupingSummaryColumn ColumnID="colDownTotalCount" Header="同步数" DataIndex="DownTotalCount"
                            Sortable="true" Groupable="False" SummaryType="Sum">
                        </ext:GroupingSummaryColumn>
                        <ext:GroupingSummaryColumn ColumnID="colDownSycnSuccess" Header="同步成功数" DataIndex="DownSycnSuccess"
                            Sortable="true" SummaryType="Sum" Groupable="False">
                        </ext:GroupingSummaryColumn>
                        <ext:GroupingSummaryColumn ColumnID="colDownSycnFailed" Header="同步失败数" DataIndex="DownSycnFailed"
                            Sortable="true" SummaryType="Sum" Groupable="False">
                        </ext:GroupingSummaryColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
                <Plugins>
                    <ext:GroupingSummary ID="GroupingSummary1" runat="server">
                    </ext:GroupingSummary>
                </Plugins>
                <BottomBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:DisplayField ID="lblTotalDownTotalCount" FieldLabel="总下家数" LabelWidth="60" runat="server"
                                Text="-" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server" />
                            <ext:DisplayField ID="lblTotalDownSycnSuccess" FieldLabel="总同步成功数" LabelWidth="90"
                                runat="server" Text="-" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server" />
                            <ext:DisplayField ID="lblTotalDownSycnFailed" FieldLabel="总同步失败数" LabelWidth="90"
                                runat="server" Text="-" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator6" runat="server" />
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPDayReport.ClientID %>.reload();
        };
        
 
        function processcmd(cmd, id) {

 
        }


        
 

    </script>
</asp:Content>

