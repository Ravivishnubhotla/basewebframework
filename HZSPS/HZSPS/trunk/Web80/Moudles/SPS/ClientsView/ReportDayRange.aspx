﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDayRange.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ReportDayRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

        var decimalFormat = function (value) {
            return formatFloat(value, 2).toString() + "%";
        };
    </script>
    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData" GroupField="ReportDate">
        <SortInfo Direction="DESC" Field="ReportDate" />
        <Reader>
            <ext:JsonReader ReaderID="ReportID">
                <Fields>
                    <ext:RecordField Name="ReportID" Type="Int" />
                    <ext:RecordField Name="DownTotalCount" Type="Int" />
                    <ext:RecordField Name="DownSuccess" Type="Float" />
                    <ext:RecordField Name="ClientChannelName" />
                    <ext:RecordField Name="MoCode" />
                    <ext:RecordField Name="ReportDate" Type="Date" DateFormat="Y-m-dTh:i:s" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{txtDownCount}.setText('总点播数(条)：'+this.sum('DownTotalCount'));#{txtDownSycnCount}.setText('总同步成功数(条)：'+this.sum('DownSuccess'));" />
        </Listeners>
        <AjaxEventConfig Timeout="300000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
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
                                    <ext:ToolbarTextItem ID="txtDownCount" runat="server" Text="总点播数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="txtDownSycnCount" runat="server" Text="总同步成功数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
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
                                <ext:GroupingSummaryColumn ColumnID="colChannelID" Header="通道" DataIndex="ClientChannelName"
                                    Groupable="true" Hideable="false" SummaryType="None" Sortable="false">
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colMoCode" Header="指令" DataIndex="MoCode"
                                    Groupable="false" Hideable="false" SummaryType="None" Sortable="false">
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colDownCount" Header="总点播数" DataIndex="DownTotalCount"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false">
                                </ext:GroupingSummaryColumn>
                                <ext:GroupingSummaryColumn ColumnID="colDownSycnCount" Header="同步成功数" DataIndex="DownSuccess"
                                    Groupable="false" Hideable="false" SummaryType="Sum" Sortable="false">
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
