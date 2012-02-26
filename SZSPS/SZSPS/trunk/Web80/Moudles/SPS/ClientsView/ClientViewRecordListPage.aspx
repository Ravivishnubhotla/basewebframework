<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientViewRecordListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientViewRecordListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="docTypeID" Value="1" Mode="Value" />
            <ext:Parameter Name="searchCondition" Value="NA" Mode="Value" />
        </BaseParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" TrackMouseOver="true">
                        <ColumnModel ID="ColumnModel1" runat="server">
                        </ColumnModel>
                        <View>
                            <ext:GridView ID="GridView1" runat="server"  AutoFill="true"/>
                        </View>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="30" DisplayInfo="true"
                                DisplayMsg="Displaying items {0} - {1} total: {2}" EmptyMsg="No items" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
