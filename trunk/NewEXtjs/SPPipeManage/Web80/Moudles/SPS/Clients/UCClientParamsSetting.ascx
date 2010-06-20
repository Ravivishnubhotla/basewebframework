<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCClientParamsSetting.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCClientParamsSetting" %>
<%@ Register Src="UCSPSendClientParamsAdd.ascx" TagName="UCSPSendClientParamsAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPSendClientParamsEdit.ascx" TagName="UCSPSendClientParamsEdit"
    TagPrefix="uc2" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>

<script type="text/javascript">
 
        function RefreshSPSendClientParamsList() {
            <%= this.storeSPSendClientParams.ClientID %>.reload();
        };

        var RefreshSPSendClientParamsData = function(btn) {
            <%= this.storeSPSendClientParams.ClientID %>.reload();
        };
        
        function ShowAddSPSendClientParamsForm(clientID) {
                Coolite.AjaxMethods.UCSPSendClientParamsAdd.Show( clientID,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPSendClientParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processSPSendClientParamscmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPSendClientParamsEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPSendClientParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选SPSendClientParams ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.UCClientParamsSetting.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除下家参数！',RefreshSPSendClientParamsData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

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
    <BaseParams>
        <ext:Parameter Name="clientID" Value="#{hidClientSelect}.getValue()" Mode="Raw">
        </ext:Parameter>
    </BaseParams>
</ext:Store>
<uc1:UCSPSendClientParamsAdd ID="UCSPSendClientParamsAdd1" runat="server" />
<uc2:UCSPSendClientParamsEdit ID="UCSPSendClientParamsEdit1" runat="server" />
<ext:Window ID="winSPChannelParamsList" runat="server" Icon="ApplicationAdd" Title="下家参数设置"
    Width="720" Height="460" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false"
    ConstrainHeader="true" Resizable="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <Items>
                <ext:GridPanel ID="gridPanelSPSendClientParams" runat="server" StoreID="storeSPSendClientParams"
                    StripeRows="true" Header="false" Icon="Table">
                    <TopBar>
                        <ext:Toolbar ID="tbTop" runat="server">
                            <Items>
                                <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                    <Listeners>
                                        <Click Handler="ShowAddSPSendClientParamsForm(#{hidClientSelect}.getValue());" />
                                    </Listeners>
                                </ext:ToolbarButton>
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
                            <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="是否可用" Sortable="true">
                                <Renderer Fn="FormatBool" />
                            </ext:Column>
                            <ext:Column ColumnID="colIsRequired" DataIndex="IsRequired" Header="是否必须" Sortable="true">
                                <Renderer Fn="FormatBool" />
                            </ext:Column>
                            <ext:Column ColumnID="colMappingParams" DataIndex="MappingParams" Header="映射字段" Sortable="true">
                            </ext:Column>
                            <ext:CommandColumn Header="下家参数管理" Width="160">
                                <Commands>
                                    <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit">
                                        <ToolTip Text="编辑" />
                                    </ext:GridCommand>
                                    <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete">
                                        <ToolTip Text="删除" />
                                    </ext:GridCommand>
                                </Commands>
                            </ext:CommandColumn>
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
        <Listeners>
        <Show Handler="RefreshSPSendClientParamsList();" />
    </Listeners>
</ext:Window>
