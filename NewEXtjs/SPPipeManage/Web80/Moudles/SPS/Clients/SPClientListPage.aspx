<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.SPClientListPage" %>

<%@ Register Src="UCSPClientAdd.ascx" TagName="UCSPClientAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPClientEdit.ascx" TagName="UCSPClientEdit" TagPrefix="uc2" %>
<%@ Register Src="UCClientParamsSetting.ascx" TagName="UCClientParamsSetting" TagPrefix="uc3" %>
<%@ Register Src="UCSPSendClientParamsClone.ascx" TagName="UCSPSendClientParamsClone"
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
        }

        function RefreshSPClientList() {
            <%= this.storeSPClient.ClientID %>.reload();
        };

        var RefreshSPClientData = function(btn) {
            <%= this.storeSPClient.ClientID %>.reload();
        };
        
        function ShowAddSPClientForm() {
                Coolite.AjaxMethods.UCSPClientAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientEdit.Show(id.id,
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

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选下家 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除下家！',RefreshSPClientData);            
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
                Coolite.AjaxMethods.UCClientParamsSetting.Show(id.id,
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
            
            
             if (cmd == "cmdParamsClone") {
                Coolite.AjaxMethods.UCSPSendClientParamsClone.Show(id.id,
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
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSPClient_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
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
                    <ext:RecordField Name="RecieveDataUrl" />
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientAdd ID="UCSPClientAdd1" runat="server" />
    <uc2:UCSPClientEdit ID="UCSPClientEdit1" runat="server" />
    <uc3:UCClientParamsSetting ID="UCClientParamsSetting1" runat="server" />
    <uc5:UCSPSendClientParamsClone ID="UCSPSendClientParamsClone1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClient" runat="server" StoreID="storeSPClient" StripeRows="true"
                        Title="下家管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPClient}.reload();" />
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
                                <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colRecieveDataUrl" DataIndex="RecieveDataUrl" Header="接收数据接口"
                                    Hidden="true" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserID" DataIndex="UserLoginID" Header="关联用户" Sortable="true">
                                </ext:Column>
                                <ext:CommandColumn Header="下家管理" Width="160">
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
                                        <ext:GridCommand Icon="ControlRecord" CommandName="cmdParamsClone" Hidden="true"
                                            Text="参数复制">
                                            <ToolTip Text="参数复制" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" Msg="处理中..." />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="storeSPClient"
                                DisplayInfo="true" DisplayMsg="显示下家 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的下家" />
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
