<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemMoudleListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.MoudleManage.SystemMoudleListPage" %>

<%@ Register Src="UCSystemMoudleAdd.ascx" TagName="UCSystemMoudleAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemMoudleEdit.ascx" TagName="UCSystemMoudleEdit" TagPrefix="uc2" %>
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
            <%= this.storeSystemMoudle.ClientID %>.reload();
        };
        
        function showAddForm() {
                Coolite.AjaxMethods.UCSystemMoudleAdd.Show( 
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
                Coolite.AjaxMethods.UCSystemMoudleEdit.Show(id.id,
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
                Ext.MessageBox.confirm('警告','确认要删除所选系统模块 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除系统模块！',RefreshData);            
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

    <ext:Store ID="storeSystemMoudle" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemMoudle_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="MoudleID">
                <Fields>
										<ext:RecordField Name="MoudleID" Type="int" />
		<ext:RecordField Name="MoudleNameCn" />			
		<ext:RecordField Name="MoudleNameEn" />			
		<ext:RecordField Name="MoudleNameDb" />			
		<ext:RecordField Name="MoudleDescription" />			
				<ext:RecordField Name="ApplicationID" Type="int" />
				<ext:RecordField Name="MoudleIsSystemMoudle" Type="Boolean" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemMoudleAdd ID="UCSystemMoudleAdd1" runat="server" />
    <uc2:UCSystemMoudleEdit ID="UCSystemMoudleEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemMoudle" runat="server" StoreID="storeSystemMoudle" StripeRows="true"
                        Title="系统模块管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="showAddForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSystemMoudle}.reload();" />
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
												<ext:Column DataIndex="MoudleID" Header="主键" Sortable="true">
                                </ext:Column>
		<ext:Column DataIndex="MoudleNameCn" Header="显示名" Sortable="true">
                                </ext:Column>			
		<ext:Column DataIndex="MoudleNameEn" Header="编码" Sortable="true">
                                </ext:Column>			
		<ext:Column DataIndex="MoudleNameDb" Header="数据库名" Sortable="true">
                                </ext:Column>			
		<ext:Column DataIndex="MoudleDescription" Header="描述" Sortable="true">
                                </ext:Column>			
				<ext:Column DataIndex="ApplicationID" Header="所属系统应用" Sortable="true">
                                </ext:Column>
				<ext:Column DataIndex="MoudleIsSystemMoudle" Header="是否为系统模块" Sortable="true">
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
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemMoudle"
                                DisplayInfo="true" DisplayMsg="显示系统模块 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的系统模块" />
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
