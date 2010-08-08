<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPUperListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Upers.SPUperListPage" %>

<%@ Register Src="UCSPUperAdd.ascx" TagName="UCSPUperAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPUperEdit.ascx" TagName="UCSPUperEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<ext:ScriptManagerProxy ID="ScriptManagerProxy1"   runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }

        function RefreshSPUperList() {
            <%= this.storeSPUper.ClientID %>.reload();
        };

        var RefreshSPUperData = function(btn) {
            <%= this.storeSPUper.ClientID %>.reload();
        };
        
        function ShowAddSPUperForm() {
                Coolite.AjaxMethods.UCSPUperAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPUperData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPUperEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPUperData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选上家 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除上家！',RefreshSPUperData);            
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
	
    <ext:Store ID="storeSPUper" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPUper_Refresh">
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
				<ext:RecordField Name="CreateDate" Type="Date" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPUperAdd ID="UCSPUperAdd1" runat="server" />
    <uc2:UCSPUperEdit ID="UCSPUperEdit1" runat="server" /> 
    
	
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPUper" runat="server" StoreID="storeSPUper" StripeRows="true"
                        Title="上家管理" Icon="Table"  >
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPUperForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPUper}.reload();" />
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
				<ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="创建日期" Sortable="true">
                                </ext:Column>
 
                        <ext:CommandColumn Header="上家管理" Width="160">

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
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPUper"
                                DisplayInfo="true" DisplayMsg="显示上家 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的上家" />
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

