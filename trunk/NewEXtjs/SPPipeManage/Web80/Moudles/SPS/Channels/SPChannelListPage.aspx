<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelListPage" %>

<%@ Register Src="UCSPChannelAdd.ascx" TagName="UCSPChannelAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPChannelEdit.ascx" TagName="UCSPChannelEdit" TagPrefix="uc2" %>
<%@ Register Src="UCChannelParamsManage.ascx" TagName="UCChannelParamsManage" TagPrefix="uc3" %>
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
        
        function ShowAddSPChannelForm() {
                Coolite.AjaxMethods.UCSPChannelAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPChannelEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选通道 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除通道！',RefreshSPChannelData);            
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
            
            if (cmd == "cmdParams") {
                Coolite.AjaxMethods.UCChannelParamsManage.Show(id.id,
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
        }

    </script>

    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSPChannel_Refresh">
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
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPChannelAdd ID="UCSPChannelAdd1" runat="server" />
    <uc2:UCSPChannelEdit ID="UCSPChannelEdit1" runat="server" />
    <uc3:UCChannelParamsManage ID="UCChannelParamsManage1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeSPChannel" StripeRows="true"
                        Title="通道管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPChannelForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
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
                                <ext:Column ColumnID="colArea" DataIndex="Area" Header="支持省份" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelCode" DataIndex="ChannelCode" Header="通道编码" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colFuzzyCommand" DataIndex="FuzzyCommand" Header="提交别名" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colPort" DataIndex="Port" Header="端口" Sortable="true" Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelType" DataIndex="ChannelType" Header="通道类型" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="单价" Sortable="true" Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colRate" DataIndex="Rate" Header="分成比例" Sortable="true" Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colStatus" DataIndex="CStatusString" Header="状态" Sortable="true"
                                    Width="50">
                                </ext:Column>
                                <ext:CommandColumn Header="通道管理" Width="150">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" Hidden="true">
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ServerEdit" CommandName="cmdParams" Text="参数管理">
                                            <ToolTip Text="参数管理" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
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
                        <p><b>描述：</b> {Description}</p>
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
