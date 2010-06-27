<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDayTotal.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportDayTotal" %>

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
                                    <ext:ToolbarTextItem Text="  日期:  ">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportDate" runat="server">
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
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="通道" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="UpSuccess" Header="总成功数(条)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDownSuccess" DataIndex="DownSuccess" Header="同步成功数(条)" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptSuccess" DataIndex="InterceptSuccess" Header="扣量成功数(条)"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣量率" Sortable="true">
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
