<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPAdPackListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.SPAdPackListPage" %>
<%@ Register Src="UCSPAdPackAdd.ascx" TagName="UCSPAdPackAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPAdPackEdit.ascx" TagName="UCSPAdPackEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPAdPackView.ascx" TagName="UCSPAdPackView" TagPrefix="uc3"  %>
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
            <%= this.storeSPAdPack.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPAdPackAdd.Show( 
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: 'Processing...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPAdPackEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing...'
                                                                    }
                                                                }              
                );
            }
			
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPAdPackView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing...'
                                                                    }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshData);            
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

    <ext:Store ID="storeSPAdPack" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPAdPack_Refresh">
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
		<ext:RecordField Name="Name" />			
		<ext:RecordField Name="Code" />			
		<ext:RecordField Name="Description" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPAdPackAdd ID="UCSPAdPackAdd1" runat="server" />
    <uc2:UCSPAdPackEdit ID="UCSPAdPackEdit1" runat="server" /> 
    <uc3:UCSPAdPackView ID="UCSPAdPackView1" runat="server" /> 	
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdPack" runat="server" StoreID="storeSPAdPack"
                StripeRows="true" Title="SPAdPack Management" Icon="Table">
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
                                    <Click Handler="#{storeSPAdPack}.reload();" />
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
		<ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colCode" DataIndex="Code" Header="Code" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescription" DataIndex="Description" Header="Description" Sortable="true">
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
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdPack"
                        DisplayInfo="true" DisplayMsg="Display SPAdPacks {0} - {1} total {2}" EmptyMsg="No matched SPAdPack" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
