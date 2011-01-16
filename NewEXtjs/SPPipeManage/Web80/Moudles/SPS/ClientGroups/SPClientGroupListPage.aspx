<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientGroupListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.SPClientGroupListPage" %>

<%@ Register Src="UCSPClientGroupAdd.ascx" TagName="UCSPClientGroupAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPClientGroupEdit.ascx" TagName="UCSPClientGroupEdit" TagPrefix="uc2" %>
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

        function RefreshSPClientGroupList() {
            <%= this.storeSPClientGroup.ClientID %>.reload();
        };

        var RefreshSPClientGroupData = function(btn) {
            <%= this.storeSPClientGroup.ClientID %>.reload();
        };
        
        function ShowAddSPClientGroupForm() {
                Coolite.AjaxMethods.UCSPClientGroupAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientGroupData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientGroupEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientGroupData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }


                               if (cmd == "cmdClientGroupPriceReport") {

                var win = <%= this.winClientGroupPriceReport.ClientID %>;
                

                win.setTitle(" 下家组 "+id.data.Name+"  " + " 结算报表 ");
                
                //win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ClientGroupID = id.data.Id;
        
                win.show();    
            }


            

                                    if (cmd == "cmdClientManage") {

                var win = <%= this.winClientmanage.ClientID %>;
                

                win.setTitle(" 下家组 "+id.data.Name+"  " + " 下家管理 ");
                
                //win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ClientGroupID = id.data.Id;
        
                win.show();    
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选SPClientGroup ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除下家组！',RefreshSPClientGroupData);            
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
    <ext:Store ID="storeSPClientGroup" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPClientGroup_Refresh">
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
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="ClientList" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientGroupAdd ID="UCSPClientGroupAdd1" runat="server" />
    <uc2:UCSPClientGroupEdit ID="UCSPClientGroupEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientGroup" runat="server" StoreID="storeSPClientGroup"
                        StripeRows="true" Title="下家组管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientGroupForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPClientGroup}.reload();" />
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
                                <ext:Column ColumnID="colID" DataIndex="Id" Header="主键" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserID" DataIndex="UserName" Header="关联用户登录ID">
                                </ext:Column>
                                <ext:CommandColumn Header="下家组管理" Width="160">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Hidden="true">
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdClientManage" Text="下家管理">
                                            <ToolTip Text="下家管理" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon=Money CommandName="cmdClientGroupPriceReport" Text="结算报表">
                                            <ToolTip Text="结算报表" />
                                        </ext:GridCommand>              
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientGroup"
                                DisplayInfo="true" DisplayMsg="显示下家组 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的下家组" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <p><b>下家指令列表：</b><br /> {ClientList}</p>
                        
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winClientmanage" runat="server" Title="Window" Frame="true" Width="850"
        ConstrainHeader="true" Height="480" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Clients/SPClientListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
        <ext:Window ID="winClientGroupPriceReport" runat="server" Title="Window" Frame="true" Width="850"
        ConstrainHeader="true" Height="390" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Clients/SPClientGroupReportContainer.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
