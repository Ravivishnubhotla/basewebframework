<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChannelParamsManage.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.UCChannelParamsManage" %>
<%@ Register Src="UCSPChannelParamsAdd.ascx" TagName="UCSPChannelParamsAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPChannelParamsEdit.ascx" TagName="UCSPChannelParamsEdit" TagPrefix="uc2" %>

<script type="text/javascript">
        function RefreshSPChannelParamsList() {
            <%= this.storeSPChannelParams.ClientID %>.reload();
        };

        var RefreshSPChannelParamsData = function(btn) {
            <%= this.storeSPChannelParams.ClientID %>.reload();
        };
        
        function ShowAddSPChannelParamsForm(channelID) {
                Coolite.AjaxMethods.UCSPChannelParamsAdd.Show( channelID,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processSPChannelParamscmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPChannelParamsEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选通道参数 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.UCChannelParamsManage.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除通道参数！',RefreshSPChannelParamsData);            
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

<ext:Hidden ID="hidChannelSelect" runat="server">
</ext:Hidden>
<ext:Store ID="storeSPChannelParams" runat="server" AutoLoad="false" RemoteSort="true"
    OnRefreshData="storeSPChannelParams_Refresh">
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
                <ext:RecordField Name="ParamsType" />
                <ext:RecordField Name="ChannelID" Type="int" />
                <ext:RecordField Name="ParamsMappingName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <BaseParams>
        <ext:Parameter Name="channelID" Value="#{hidChannelSelect}.getValue()" Mode="Raw">
        </ext:Parameter>
    </BaseParams>
</ext:Store>
<uc1:UCSPChannelParamsAdd ID="UCSPChannelParamsAdd1" runat="server" />
<uc2:UCSPChannelParamsEdit ID="UCSPChannelParamsEdit1" runat="server" />
<ext:Window ID="winSPChannelParamsList" runat="server" Icon="ApplicationAdd" Title="通道参数设置"
    Width="720" Height="460" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false"
    ConstrainHeader="true" Resizable="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:GridPanel ID="gridPanelSPChannelParams" runat="server" StoreID="storeSPChannelParams"
                StripeRows="true" Header="false" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                <Listeners>
                                    <Click Handler="ShowAddSPChannelParamsForm(#{hidChannelSelect}.getValue());" />
                                </Listeners>
                            </ext:ToolbarButton>
                            <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPChannelParams}.reload();" />
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
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="参数名" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="是否启用" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsRequired" DataIndex="IsRequired" Header="是否必须" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colParamsType" DataIndex="ParamsType" Header="参数类型" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colParamsMappingName" DataIndex="ParamsMappingName" Header="参数映射字段"
                            Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn Header="通道参数管理" Width="160">
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
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPChannelParams"
                        DisplayInfo="true" DisplayMsg="显示通道参数 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道参数" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processSPChannelParamscmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </ext:FitLayout>
    </Body>
    <Listeners>
        <Show Handler="RefreshSPChannelParamsList();" />
    </Listeners>
</ext:Window>
