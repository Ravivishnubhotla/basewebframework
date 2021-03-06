
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPAdAssignedHistortyListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.SPAdAssignedHistortyListPage" %>


<%@ Register Src="UCSPAdAssignedHistortyAdd.ascx" TagName="UCSPAdAssignedHistortyAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPAdAssignedHistortyEdit.ascx" TagName="UCSPAdAssignedHistortyEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPAdAssignedHistortyView.ascx" TagName="UCSPAdAssignedHistortyView" TagPrefix="uc3"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPAdAssignedHistorty.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPAdAssignedHistortyAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '操作中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPAdAssignedHistortyEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '操作中...'
                                                                               }
                                                                }              
                );
            }
			
			            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPAdAssignedHistortyView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '操作中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认删除该条记录？ ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', 'Delete a record success!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing ......'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>

    <ext:Store ID="storeSPAdAssignedHistorty" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPAdAssignedHistorty_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
					<ext:RecordField Name="ID" Type="int" />
				<ext:RecordField Name="SPAdID" Type="int" />
				<ext:RecordField Name="SPAdPackID" Type="int" />
				<ext:RecordField Name="SPClientID" Type="int" />
				<ext:RecordField Name="StartDate" Type="Date" />
				<ext:RecordField Name="EndDate" Type="Date" />
				<ext:RecordField Name="CreateBy" Type="int" />
				<ext:RecordField Name="CreateAt" Type="Date" />
				<ext:RecordField Name="LastModifyBy" Type="int" />
				<ext:RecordField Name="LastModifyAt" Type="Date" />
		<ext:RecordField Name="LastModifyComment" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPAdAssignedHistortyAdd ID="UCSPAdAssignedHistortyAdd1" runat="server" />
    <uc2:UCSPAdAssignedHistortyEdit ID="UCSPAdAssignedHistortyEdit1" runat="server" /> 
    <uc3:UCSPAdAssignedHistortyView ID="UCSPAdAssignedHistortyView1" runat="server" /> 	
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdAssignedHistorty" runat="server" StoreID="storeSPAdAssignedHistorty"
                StripeRows="true" Title="SPAdAssignedHistorty Management" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPAdAssignedHistorty}.reload();" />
                                </Listeners>
                            </ext:Button>
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
				<ext:Column ColumnID="colID" DataIndex="ID" Header="ID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSPAdID" DataIndex="SPAdID" Header="SPAdID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSPAdPackID" DataIndex="SPAdPackID" Header="SPAdPackID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSPClientID" DataIndex="SPClientID" Header="SPClientID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colStartDate" DataIndex="StartDate" Header="StartDate" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colEndDate" DataIndex="EndDate" Header="EndDate" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colCreateBy" DataIndex="CreateBy" Header="CreateBy" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colCreateAt" DataIndex="CreateAt" Header="CreateAt" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLastModifyBy" DataIndex="LastModifyBy" Header="LastModifyBy" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLastModifyAt" DataIndex="LastModifyAt" Header="LastModifyAt" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colLastModifyComment" DataIndex="LastModifyComment" Header="LastModifyComment" Sortable="true">
                                </ext:Column>			
 
                                <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                                    <Commands>
                                    <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                                 <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View"></ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                   
                                    </ext:SplitCommand>

                                    </Commands>
                                </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdAssignedHistorty"
                        DisplayInfo="true" DisplayMsg="Display SPAdAssignedHistortys {0} - {1} total {2}" EmptyMsg="No matched SPAdAssignedHistorty" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

