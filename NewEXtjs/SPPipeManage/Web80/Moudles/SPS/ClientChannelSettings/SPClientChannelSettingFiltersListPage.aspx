<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientChannelSettingFiltersListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.SPClientChannelSettingFiltersListPage" %>

<%@ Register Src="UCSPClientChannelSettingFiltersAdd.ascx" TagName="UCSPClientChannelSettingFiltersAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPClientChannelSettingFiltersEdit.ascx" TagName="UCSPClientChannelSettingFiltersEdit"
    TagPrefix="uc2" %>
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

        function RefreshSPClientChannelSettingFiltersList() {
            <%= this.storeSPClientChannelSettingFilters.ClientID %>.reload();
        };

        var RefreshSPClientChannelSettingFiltersData = function(btn) {
            <%= this.storeSPClientChannelSettingFilters.ClientID %>.reload();
        };
        
        function ShowAddSPClientChannelSettingFiltersForm() {
                Coolite.AjaxMethods.UCSPClientChannelSettingFiltersAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingFiltersData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientChannelSettingFiltersEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingFiltersData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选过滤省份 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除过滤省份！',RefreshSPClientChannelSettingFiltersData);            
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
    <ext:Store ID="storeSPClientChannelSettingFilters" runat="server" AutoLoad="true"
        RemoteSort="true" OnRefreshData="storeSPClientChannelSettingFilters_Refresh">
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
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="ParamsName" />
                    <ext:RecordField Name="FilterType" />
                    <ext:RecordField Name="FilterValue" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="ClientChannelSettingID" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientChannelSettingFiltersAdd ID="UCSPClientChannelSettingFiltersAdd1"
        runat="server" />
    <uc2:UCSPClientChannelSettingFiltersEdit ID="UCSPClientChannelSettingFiltersEdit1"
        runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSettingFilters" runat="server" StoreID="storeSPClientChannelSettingFilters"
                        StripeRows="true" Title="省份过滤管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientChannelSettingFiltersForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPClientChannelSettingFilters}.reload();" />
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
      
                                <ext:Column ColumnID="colFilterValue" DataIndex="FilterValue" Header="过滤省份" Sortable="true">
                                </ext:Column>
                                <ext:CommandColumn Header="管理" Width="160">
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
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientChannelSettingFilters"
                                DisplayInfo="true" DisplayMsg="显示SPClientChannelSettingFilters {0} - {1} 共 {2}"
                                EmptyMsg="没有符合条件的过滤省份" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
