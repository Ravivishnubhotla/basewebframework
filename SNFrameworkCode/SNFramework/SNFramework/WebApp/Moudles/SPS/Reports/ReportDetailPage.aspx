<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDetailPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh"
        OnSubmitData="storeData_Submit">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="50" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                AutoScroll="true">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <listeners>
                                            <Click Handler="#{storeData}.reload();" />
                                        </listeners>
                            </ext:Button>
                            <ext:Button ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                <listeners>
                                            <Click Handler="#{GridPanel1}.submitData(false);" />
                                        </listeners>
                            </ext:Button>
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
                        DisplayMsg="显示记录 {0} - {1} 共: {2}" EmptyMsg="没有记录" />
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
