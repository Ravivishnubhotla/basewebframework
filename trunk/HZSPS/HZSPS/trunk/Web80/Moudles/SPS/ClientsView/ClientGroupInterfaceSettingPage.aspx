<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupInterfaceSettingPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupInterfaceSettingPage" %>
<%@ Register Src="UCClientSycnInfoSetting.ascx" TagName="UCClientSycnInfoSetting"
    TagPrefix="uc5" %>
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
        };
        



  
        function RefreshSPClientList() {
            <%= this.storeSPClient.ClientID %>.reload();
        };

        var RefreshSPClientData = function(btn) {
            <%= this.storeSPClient.ClientID %>.reload();
        };
 
        function processcmd(cmd, id) {
 



            if (cmd == "cmdParamsEdit") {
                //alert(id.data.DefaultClientChannelSettingID);
                Coolite.AjaxMethods.UCClientSycnInfoSetting.Show(id.data.DefaultClientChannelSettingID,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '加载中...'
                                                                    }
                                                                }              
                );
            }
            


            
            if (cmd == "cmdTestClient") {

                var win = <%= this.WindwinSendClientTestRequestFormow1.ClientID %>;
                

               win.setTitle("  "+id.data.Name + "  " + " 下家发送模拟数据 ");
                
               win.autoLoad.url = '../ClientChannelSettings/SPChannelClientSendClientTestRequestForm.aspx';
                
               win.autoLoad.params.ChannleClientID = id.data.Id;
        
               win.show();    
           }  
        }
                function columnWrap(val){
    return '<div style="white-space:normal !important;">'+ val +'</div>';
}

    </script>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true" OnRefreshData="storeSPClient_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Alias" />
                    <ext:RecordField Name="RecieveDataUrl" />
                    <ext:RecordField Name="SPCode" />
                    <ext:RecordField Name="InterfaceList" />
                    <ext:RecordField Name="SyncDataUrl" />
                    <ext:RecordField Name="DisplayName" />
                    <ext:RecordField Name="AllowAndDisableArea" />
                    <ext:RecordField Name="SettlementPeriod" />
                    <ext:RecordField Name="DayLimitAndMonthLimit" />
                    <ext:RecordField Name="SendText" />
                    <ext:RecordField Name="Getway" />
                    <ext:RecordField Name="DefaultClientChannelSettingID" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
            <EventMask ShowMask="true" />
        </AjaxEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc5:UCClientSycnInfoSetting ID="UCClientSycnInfoSetting1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeSPClient"
                        StripeRows="true" Title="所有通道" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="端口号">
                                    </ext:ToolbarTextItem>
                                    <ext:TextField ID="txtPort" runat="server">
                                    </ext:TextField>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPClient}.filter('DisplayName',#{txtPort}.getValue());" />
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
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colRecieveDataUrl" DataIndex="SyncDataUrl" Header="同步地址" Sortable="true">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colAllowAndDisableArea" DataIndex="AllowAndDisableArea" Header="开通省份"
                                    Sortable="false" Width="120">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colSendText" DataIndex="SendText" Header="下发语" Sortable="false"
                                    Wrap="true" Width="120">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colGetway" DataIndex="Getway" Header="运营商" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colDayLimitAndMonthLimit" DataIndex="DayLimitAndMonthLimit"
                                    Header="日限月限" Sortable="false">
                                </ext:Column>
                                <ext:CommandColumn Header="通道管理" Width="50">
                                    <Commands>
                                        <ext:GridCommand Icon="Cog" Text="设置" ToolTip-Text="指令设置">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ServerConnect" CommandName="cmdParamsEdit" Text="设置" />
                                                    <ext:MenuCommand Icon="TelephoneGo" Hidden="True" CommandName="cmdTestClient" Text="发送测试数据" />
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Menu" />
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
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
        <ext:Window ID="WindwinSendClientTestRequestFormow1" runat="server" Title="下家模拟数据测试"
        Frame="true" Width="640" ConstrainHeader="true" Height="320" Maximizable="true"
        Closable="true" Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
