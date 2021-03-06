﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPClientGroupReport.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.SPClientGroupReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
        <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="store1" runat="server" AutoLoad="true" OnRefreshData="store1_Refresh"  OnSubmitData="storeData_Submit">
        <Reader>
            <ext:JsonReader ReaderID="RID">
                <Fields>
                    <ext:RecordField Name="RID" Type="int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="DownTotalCount" Type="Int" />
                    <ext:RecordField Name="Price" Type="Float" />
                    <ext:RecordField Name="Amount" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
                <AjaxEventConfig IsUpload="true" />
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="下家组结算报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text=" ">
                                    </ext:ToolbarTextItem>
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
                                                                        <ext:ToolbarButton ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{gridPanelSPClientChannelSetting}.submitData(false);" />
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
                                <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true"
                                    Width="20">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:Column ColumnID="colClientName" DataIndex="ClientName" Header="通道名称" Sortable="true"
                                    Width="20">
                                    </ext:Column>    
                                <ext:Column ColumnID="colDownTotalCount" DataIndex="DownTotalCount" Header="点播数"   Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="结算价格"
                                    Sortable="true" Width="20">
                                </ext:Column>
                                 <ext:Column ColumnID="colAmount" DataIndex="Amount" Header="总计"
                                    Sortable="true" Width="20">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
 
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="100" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>   
</asp:Content>


