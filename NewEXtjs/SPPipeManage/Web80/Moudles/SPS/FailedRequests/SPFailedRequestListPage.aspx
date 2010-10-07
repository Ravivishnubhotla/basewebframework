<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPFailedRequestListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.FailedRequests.SPFailedRequestListPage" %>

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

        function RefreshSPFailedRequestList() {
            <%= this.storeSPFailedRequest.ClientID %>.reload();
        };

        var RefreshSPFailedRequestData = function(btn) {
            <%= this.storeSPFailedRequest.ClientID %>.reload();
        };
        




    </script>
    <ext:Store ID="storeSPFailedRequest" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPFailedRequest_Refresh">
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
                    <ext:RecordField Name="RecievedContent" />
                    <ext:RecordField Name="RecievedDate" Type="Date" />
                    <ext:RecordField Name="RecievedIP" />
                    <ext:RecordField Name="RecievedSendUrl" />
                    <ext:RecordField Name="ChannelID" Type="int" />
                    <ext:RecordField Name="ClientID" Type="int" />
                    <ext:RecordField Name="FailedMessage" />
                    <ext:RecordField Name="IsProcessed" Type="Boolean" />
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
                    <ext:GridPanel ID="gridPanelSPFailedRequest" runat="server" StoreID="storeSPFailedRequest"
                        StripeRows="true" Title="失败请求管理管理" Icon="Table" AutoExpandColumn="colRecievedSendUrl">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ComboBox ID="cmbProcessType" Editable="false" runat="server" AllowBlank="True"
                                        SelectedIndex="2" Width="85">
                                        <Items>
                                            <ext:ListItem Value="0" Text="全部请求"></ext:ListItem>
                                            <ext:ListItem Value="1" Text="已处理请求"></ext:ListItem>
                                            <ext:ListItem Value="2" Text="未处理请求"></ext:ListItem>
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:TextField ID="txtUrl" runat="server" AllowBlank="true" Width="90">
                                    </ext:TextField>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPFailedRequest}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnProcessAll' runat="server" Text="处理所有选中记录" Icon="Package">
                                        <AjaxEvents>
                                            <Click OnEvent="btnProcessAll_Click" Success="Ext.MessageBox.alert('操作成功', '处理所有选中记录.',callback);function callback(id) {#{storeSPFailedRequest}.reload();};">
                                                <EventMask ShowMask="true" Msg="处理中..." />
                                                <Confirmation ConfirmRequest="true" Message="确认处理所有选中记录？" Title="确认操作" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="Values" Value="Ext.encode(#{gridPanelSPFailedRequest}.getRowsValues())"
                                                        Mode="Raw" />
                                                </ExtraParams>
                                            </Click>
                                        </AjaxEvents>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <View>
                            <ext:GridView ForceFit="true" ID="GridView1">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colID" DataIndex="Id" Header="主键" Sortable="true" Width="30">
                                </ext:Column>
                                <ext:Column ColumnID="colRecievedDate" DataIndex="RecievedDate" Header="日期" Sortable="true"
                                    Width="70">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                                <ext:Column ColumnID="colRecievedIP" DataIndex="RecievedIP" Header="IP地址" Sortable="true"
                                    Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colRecievedSendUrl" DataIndex="RecievedSendUrl" Header="请求Url地址"
                                    Sortable="true" Width="200">
                                </ext:Column>
                                <ext:Column ColumnID="colFailedMessage" DataIndex="FailedMessage" Header="错误信息" Width="60"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colIsProcessed" DataIndex="IsProcessed" Header="处理" Sortable="true"
                                    Width="30">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPFailedRequest"
                                DisplayInfo="true" DisplayMsg="显示失败请求 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的失败请求" />
                        </BottomBar>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <p><b>请求链接：</b> {RecievedSendUrl}</p>
                        <p><b>参数列表：</b> {RecievedContent}</p>
 
                        
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
