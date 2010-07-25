<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClientViewRecordListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientViewRecordListPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Store ID="store1" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="store1_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="MobileNumber" />
                    <ext:RecordField Name="RequestContent" />
                    <ext:RecordField Name="Values" />
                    <ext:RecordField Name="Linkid" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>


    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="明细数据查看" Icon="Table">
                        <View>
                            <ext:GridView ForceFit="true" ID="GridView1">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="日期" Sortable="true"
                                    Width="20">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
