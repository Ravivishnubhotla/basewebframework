<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPClientCodeList.aspx.cs" Inherits="SPSWeb.Moudles.SPS.ClientView.SPClientCodeList" %>
<%@ Register Src="~/Moudles/SPS/Clients/UCSPClientCodeRelationEdit.ascx" TagName="UCSPClientCodeRelationEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatStatus = function(value) {
            if (value)
                return '<font color=Green>启用</font>';
            else
                return '<font color=Red>停用</font>';
        };
        
        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
                };


        var RefreshData = function(btn) {
            <%= this.storeSPClientCodeRelation.ClientID %>.reload();
        };

        function RefreshSPClientCodeRelationList() {
            <%= this.storeSPClientCodeRelation.ClientID %>.reload();
        };
        
 

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPClientCodeRelationEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                }              
                );
            }
            
        }
        var showTip = function() {
            var rowIndex = <%= gridPanelSPClientCodeRelation.ClientID %> .view.findRowIndex(this.triggerElement),
                cellIndex = <%= gridPanelSPClientCodeRelation.ClientID %> .view.findCellIndex(this.triggerElement),
                record = <%= storeSPClientCodeRelation.ClientID %> .getAt(rowIndex),
                fieldName = <%= gridPanelSPClientCodeRelation.ClientID %> .getColumnModel().getDataIndex(cellIndex),
                data = record.get(fieldName);

            if(fieldName=='IsEnable')
                data = record.get('DataRange');
            
            this.body.dom.innerHTML = data;
        };
    </script>
    <ext:Store ID="storeSPClientCodeRelation" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPClientCodeRelation_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="CodeID" Type="int" />
                    <ext:RecordField Name="CodeID_MoCode" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="SycnRetryTimes" />
                    <ext:RecordField Name="SyncType" />
                    <ext:RecordField Name="SycnDataUrl" />
                    <ext:RecordField Name="SycnOkMessage" />
                    <ext:RecordField Name="SycnFailedMessage" />
                    <ext:RecordField Name="StartDate" Type="Date" />
                    <ext:RecordField Name="EndDate" Type="Date" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="DataRange" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCSPClientCodeRelationEdit ID="UCSPClientCodeRelationEdit1" ShowForClient="True"
        runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPClientCodeRelation" runat="server" StoreID="storeSPClientCodeRelation"
                TrackMouseOver="true" StripeRows="true" Title="代码管理" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPClientCodeRelation}.reload();" />
                                </Listeners>
                            </ext:Button>
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
                        <ext:Column ColumnID="colMoCode" DataIndex="CodeID_MoCode" Header="代码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSyncData" DataIndex="SyncData" Header="同步" Width="20" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="状态" Width="20" Sortable="true">
                            <Renderer Fn="FormatStatus" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="39">
                            <Commands>
                                <ext:SplitCommand Text="操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="同步设置">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdChannelTest" Text="通道测试">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPClientCodeRelation"
                        DisplayInfo="true" DisplayMsg="显示代码 {0} - {1} 共 {2}" EmptyMsg="没有分配的代码" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:ToolTip ID="RowTip" runat="server" Target="={#{gridPanelSPClientCodeRelation}.getView().mainBody}"
        Anchor="left" Delegate=".x-grid3-cell" TrackMouse="true">
        <Listeners>
            <Show Fn="showTip" />
        </Listeners>
    </ext:ToolTip>
</asp:Content>

