<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelDefaultSycnParamsListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelDefaultSycnParamsListPage" %>

<%@ Register Src="UCSPClientChannelParamsAdd.ascx" TagName="UCSPClientChannelParamsAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPClientChannelParamsEdit.ascx" TagName="UCSPClientChannelParamsEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function (value) {
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

        function ShowAddSPSendClientParamsForm() {
            Coolite.AjaxMethods.UCSPClientChannelParamsAdd.Show(
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshSPSendClientParamsData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '加载中...'
                                                                    }
                                                                });

        }

        function PatchAdd() {
                             Coolite.AjaxMethods.PatchAdd(
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function (result) {
                                                                        Ext.Msg.alert('操作成功', '成功批量添加下家参数！', RefreshSPSendClientParamsData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中...'
                                                                    }
                                                                }
                                                            );           
        }


        function processSPSendClientParamscmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientChannelParamsEdit.Show(id.id,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshSPSendClientParamsData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '加载中...'
                                                                    }
                                                                }
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告', '确认要删除所选SPSendClientParams ? ',
                    function (e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function (result) {
                                                                        Ext.Msg.alert('操作成功', '成功删除下家参数！', RefreshSPSendClientParamsData);
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCSPClientChannelParamsEdit ID="UCSPClientChannelParamsEdit1" runat="server" />
    <uc1:UCSPClientChannelParamsAdd ID="UCSPClientChannelParamsAdd1" runat="server" />
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
                    <ext:RecordField Name="ClientChannelSettingID" Type="int" />
                    <ext:RecordField Name="MappingParams" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
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
                                            <Click Handler="ShowAddSPSendClientParamsForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPSendClientParams}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnPatchAdd' runat="server" Text="批量添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="PatchAdd();" />
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
                                <ext:CommandColumn Header="参数管理" Width="160">
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
    </ext:ViewPort>
 

</asp:Content>
