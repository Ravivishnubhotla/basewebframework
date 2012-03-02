<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataProviceReport.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.DataProviceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Store ID="storeData" runat="server" AutoLoad="true" OnRefreshData="storeData_Refresh">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="ProvinceName" />
                    <ext:RecordField Name="DataCount" Type="Int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
        <Load Handler="#{txtTotalCount}.setText('共计：'+this.sum('DataCount'));" />
        </Listeners>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="grdReport" runat="server" StoreID="storeData" StripeRows="true"
                        Title="数据省份分布报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem ID="lblTitle" runat="server" Text="通道 【】 到 【】 时段【】数据分布 ">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarTextItem ID="txtTotalCount" runat="server" Text="共计:">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeData}.reload();" />
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
                                <ext:Column ColumnID="colProvinceName" DataIndex="ProvinceName" Header="省份" Sortable="true"
                                    Width="80">
                                </ext:Column>
                                <ext:Column ColumnID="colDataCount" DataIndex="DataCount" Header="数据量" Sortable="true">
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
