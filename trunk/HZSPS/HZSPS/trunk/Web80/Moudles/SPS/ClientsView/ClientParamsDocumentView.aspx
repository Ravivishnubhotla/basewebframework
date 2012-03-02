<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientParamsDocumentView.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientParamsDocumentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
 
         var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }
 
        function RefreshSPSendClientParamsList() {
            <%= this.storeSPSendClientParams.ClientID %>.reload();
        };

        var RefreshSPSendClientParamsData = function(btn) {
            <%= this.storeSPSendClientParams.ClientID %>.reload();
        };
        
 
</script>

    <ext:Hidden ID="hidClientSelect" runat="server">
    </ext:Hidden>
    <ext:Store ID="storeSPSendClientParams" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPSendClientParams_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="IsRequired" Type="Boolean" />
                    <ext:RecordField Name="ClientID" Type="int" />
                    <ext:RecordField Name="MappingParams" />
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
                    <ext:GridPanel ID="gridPanelSPSendClientParams" runat="server" StoreID="storeSPSendClientParams"
                        StripeRows="true" Header="false" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPSendClientParams}.reload();" />
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
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="编码" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" Msg="加载中..." />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPSendClientParams"
                                DisplayInfo="true" DisplayMsg="显示下家参数 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的下家参数" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processSPSendClientParamscmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
