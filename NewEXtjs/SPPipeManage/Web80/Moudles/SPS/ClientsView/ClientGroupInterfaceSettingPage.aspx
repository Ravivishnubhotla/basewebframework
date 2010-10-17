<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupInterfaceSettingPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupInterfaceSettingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshSPClientList();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }

  
        function RefreshSPClientList() {
            <%= this.storeSPClient.ClientID %>.reload();
        };

        var RefreshSPClientData = function(btn) {
            <%= this.storeSPClient.ClientID %>.reload();
        };
 
        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientChannelSettingEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

  
        }

    </script>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true" OnRefreshData="storeSPClient_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Alias" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="RecieveDataUrl" />
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="ClientGroupName" />
                    <ext:RecordField Name="SPCode" />
                    <ext:RecordField Name="InterfaceList" />
                    <ext:RecordField Name="SyncDataUrl" />
                    <ext:RecordField Name="DisplayName" />
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
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeSPClient"
                        StripeRows="true" Title="所有通道" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="RefreshSPClientList();" />
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
                                <ext:Column ColumnID="colChannelID" DataIndex="DisplayName" Header="通道名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colCommandType" DataIndex="SPCode" Header="指令" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colRecieveDataUrl" DataIndex="SyncDataUrl" Header="同步地址" Sortable="true">
                                </ext:Column>
                                <ext:CommandColumn Header="通道管理" Width="160">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdParamsEdit" Text="编辑通道名称">
                                            <ToolTip Text="编辑通道名称" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ServerConnect" CommandName="cmdParamsEdit" Text="设置同步地址">
                                            <ToolTip Text="设置同步地址" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="TelephoneGo" CommandName="cmdTest" Text="发送测试数据">
                                            <ToolTip Text="发送测试数据" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClient"
                                DisplayInfo="true" DisplayMsg="显示通道 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="false">
                                <Template ID="Template1" runat="server">
                        <p><b>通道接口文档：</b><br /> {InterfaceList}</p>
 
                        
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
</asp:Content>
