<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DetailRecordView.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.DetailRecordView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh"
        OnSubmitData="storeData_Submit">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
        </AutoLoadParams>
        <AjaxEventConfig IsUpload="true"  Timeout="120000" />
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                        AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeData}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{GridPanel1}.submitData(false);" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                        </ColumnModel>
                        <View>
                            <ext:GridView ID="GridView1" runat="server" />
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
