<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClientChannleView.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientChannleView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }

        function RefreshSPChannelList() {
            <%= this.storeSPChannel.ClientID %>.reload();
        };

        var RefreshSPChannelData = function(btn) {
            <%= this.storeSPChannel.ClientID %>.reload();
        };
        



    </script>

    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="Area" />
                    <ext:RecordField Name="Operator"   />
                    <ext:RecordField Name="ChannelCode" />
                    <ext:RecordField Name="FuzzyCommand" />
                    <ext:RecordField Name="AccurateCommand" />
                    <ext:RecordField Name="Port" />
                    <ext:RecordField Name="ChannelType" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="Rate" Type="int" />
                    <ext:RecordField Name="Status" Type="int" />
                    <ext:RecordField Name="CStatusString" />
                    <ext:RecordField Name="CreateTime" Type="Date" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                            <ext:RecordField Name="InterfaceUrl" />            
                    
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
                    <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeSPChannel" StripeRows="true"
                        Title="通道管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPChannel}.reload();" />
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
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelCode" DataIndex="InterfaceUrl" Header="接口链接" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colStatus" DataIndex="CStatusString" Header="状态" Sortable="true"
                                    Width="50">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPChannel"
                                DisplayInfo="true" DisplayMsg="显示通道 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <p><b>接口链接：</b> {InterfaceUrl}</p>
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>

