<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDetailPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="50" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="LinkID" />
                    <ext:RecordField Name="Mobile" />
                    <ext:RecordField Name="Mo" />
                    <ext:RecordField Name="SpNumber" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="City" />
                    <ext:RecordField Name="OperatorType" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="Count" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <Items>
            <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                StoreID="storeData" AutoScroll="true">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeData}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.submitData(false);" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="接收时间" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLinkID" DataIndex="LinkID" Header="唯一标识" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMobile" DataIndex="Mobile" Header="手机号码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMo" DataIndex="Mo" Header="上行指令" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSpNumber" DataIndex="SpNumber" Header="通道号码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colProvince" DataIndex="Province" Header="省份" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCity" DataIndex="City" Header="地市" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colOperatorType" DataIndex="OperatorType" Header="运营商" Sortable="true">
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <View>
                    <ext:GridView ID="GridView1" runat="server" />
                </View>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="50" DisplayInfo="true"
                        StoreID="storeData" DisplayMsg="显示记录 {0} - {1} 共: {2}" EmptyMsg="没有记录" />
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
