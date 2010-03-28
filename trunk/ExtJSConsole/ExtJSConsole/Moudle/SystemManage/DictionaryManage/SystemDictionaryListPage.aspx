<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemDictionaryListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.DictionaryManage.SystemDictionaryListPage" %>
<%@ Register Src="UCSystemDictionaryAdd.ascx" TagName="UCSystemDictionaryAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemDictionaryEdit.ascx" TagName="UCSystemDictionaryEdit" TagPrefix="uc2" %>
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
            <%= this.storeSystemDictionary.ClientID %>.reload();
        };
        
        function showAddForm() {
                Coolite.AjaxMethods.UCSystemDictionaryAdd.Show( 
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
                Coolite.AjaxMethods.UCSystemDictionaryEdit.Show(id.id,
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
                Ext.MessageBox.confirm('警告','确认要删除所选SystemDictionary ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除SystemDictionary！',RefreshData);            
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

    <ext:Store ID="storeSystemDictionary" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemDictionary_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="SystemDictionaryID">
                <Fields>
										<ext:RecordField Name="SystemDictionaryID" Type="int" />
		<ext:RecordField Name="SystemDictionaryCategoryID" />			
		<ext:RecordField Name="SystemDictionaryKey" />			
		<ext:RecordField Name="SystemDictionaryValue" />			
		<ext:RecordField Name="SystemDictionaryDesciption" />			
				<ext:RecordField Name="SystemDictionaryOrder" Type="int" />
				<ext:RecordField Name="SystemDictionaryIsEnable" Type="Boolean" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemDictionaryAdd ID="UCSystemDictionaryAdd1" runat="server" />
    <uc2:UCSystemDictionaryEdit ID="UCSystemDictionaryEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemDictionary" runat="server" StoreID="storeSystemDictionary" StripeRows="true"
                        Title="SystemDictionary管理" Icon="Table">
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
                                            <Click Handler="#{storeSystemDictionary}.reload();" />
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
												<ext:Column ColumnID="colSystemDictionaryID" DataIndex="SystemDictionaryID" Header="主键" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colSystemDictionaryCategoryID" DataIndex="SystemDictionaryCategoryID" Header="字典类型" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryKey" DataIndex="SystemDictionaryKey" Header="键" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryValue" DataIndex="SystemDictionaryValue" Header="值" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryDesciption" DataIndex="SystemDictionaryDesciption" Header="描述" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colSystemDictionaryOrder" DataIndex="SystemDictionaryOrder" Header="序号" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSystemDictionaryIsEnable" DataIndex="SystemDictionaryIsEnable" Header="是否有效" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
 
                                <ext:CommandColumn ColumnID="colManage" Header="SystemDictionary管理" Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" >
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemDictionary"
                                DisplayInfo="true" DisplayMsg="显示SystemDictionary {0} - {1} 共 {2}" EmptyMsg="没有符合条件的SystemDictionary" />
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

