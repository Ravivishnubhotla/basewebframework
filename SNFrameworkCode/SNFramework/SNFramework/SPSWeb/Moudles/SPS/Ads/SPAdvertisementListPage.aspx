<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPAdvertisementListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.SPAdvertisementListPage" %>
<%@ Register Src="UCSPAdvertisementAdd.ascx" TagName="UCSPAdvertisementAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPAdvertisementEdit.ascx" TagName="UCSPAdvertisementEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPAdvertisementView.ascx" TagName="UCSPAdvertisementView" TagPrefix="uc3"  %>
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
        }


        var RefreshData = function(btn) {
            <%= this.storeSPAdvertisement.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPAdvertisementAdd.Show( 
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
                Ext.net.DirectMethods.UCSPAdvertisementEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSPAdvertisementView.Show(id.id,
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

    <ext:Store ID="storeSPAdvertisement" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPAdvertisement_Refresh">
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
		<ext:RecordField Name="Name" />			
		<ext:RecordField Name="Code" />			
		<ext:RecordField Name="ImageUrl" />			
		<ext:RecordField Name="AdPrice" />			
		<ext:RecordField Name="AccountType" />			
		<ext:RecordField Name="ApplyStatus" />			
		<ext:RecordField Name="AdType" />			
		<ext:RecordField Name="AdText" />			
		<ext:RecordField Name="Description" />			
				<ext:RecordField Name="IsDisable" Type="Boolean" />
				<ext:RecordField Name="AssignedClient" Type="int" />
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
    <uc1:UCSPAdvertisementAdd ID="UCSPAdvertisementAdd1" runat="server" />
    <uc2:UCSPAdvertisementEdit ID="UCSPAdvertisementEdit1" runat="server" /> 
    <uc3:UCSPAdvertisementView ID="UCSPAdvertisementView1" runat="server" /> 	
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdvertisement" runat="server" StoreID="storeSPAdvertisement"
                StripeRows="true" Title="SPAdvertisement Management" Icon="Table">
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
                                    <Click Handler="#{storeSPAdvertisement}.reload();" />
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
		<ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colCode" DataIndex="Code" Header="Code" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colImageUrl" DataIndex="ImageUrl" Header="ImageUrl" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colAdPrice" DataIndex="AdPrice" Header="AdPrice" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colAccountType" DataIndex="AccountType" Header="AccountType" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colApplyStatus" DataIndex="ApplyStatus" Header="ApplyStatus" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colAdType" DataIndex="AdType" Header="AdType" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colAdText" DataIndex="AdText" Header="AdText" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescription" DataIndex="Description" Header="Description" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colIsDisable" DataIndex="IsDisable" Header="IsDisable" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colAssignedClient" DataIndex="AssignedClient" Header="AssignedClient" Sortable="true">
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
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdvertisement"
                        DisplayInfo="true" DisplayMsg="Display SPAdvertisements {0} - {1} total {2}" EmptyMsg="No matched SPAdvertisement" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
