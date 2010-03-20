<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.ApplicationManage.SystemApplicationListPage" %>

<%@ Register Src="UCSystemApplicationAdd.ascx" TagName="UCSystemApplicationAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemApplicationEdit.ascx" TagName="UCSystemApplicationEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1"   runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }

        var RefreshData = function(btn) {
            <%= this.storeSystemApplication.ClientID %>.reload();
        };
        
        function showAddForm() {
                Coolite.AjaxMethods.UCSystemApplicationAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSystemApplicationEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选记录 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除系统应用！',RefreshData);            
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

    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemApplication_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemApplicationAdd ID="UCSystemApplicationAdd1" runat="server" />
    <uc2:UCSystemApplicationEdit ID="UCSystemApplicationEdit2" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true"
                        Title="系统应用列表" Icon="Table" AutoExpandColumn="colSystemApplicationDescription">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="showAddForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSystemApplication}.reload();" />
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
                                <ext:Column DataIndex="SystemApplicationID" Header="主键" Sortable="true">
                                </ext:Column>
                                <ext:Column DataIndex="SystemApplicationName" Header="名称" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colSystemApplicationDescription" DataIndex="SystemApplicationDescription"
                                    Header="描述">
                                </ext:Column>
                                <ext:Column DataIndex="SystemApplicationUrl" Header="链接">
                                </ext:Column>
                                <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="是否为系统应用" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
                                <ext:CommandColumn Width="60">
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
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemApplication"
                                DisplayInfo="true" DisplayMsg="显示系统应用 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的系统应用" />
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
