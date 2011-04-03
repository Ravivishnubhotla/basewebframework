<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemEmailSettingsListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage.SystemEmailSettingsListPage" %>
<%@ Register Src="UCSystemEmailSettingsAdd.ascx" TagName="UCSystemEmailSettingsAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemEmailSettingsEdit.ascx" TagName="UCSystemEmailSettingsEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemEmailSettingsView.ascx" TagName="UCSystemEmailSettingsView" TagPrefix="uc3"  %>
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
            <%= this.storeSystemEmailSettings.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemEmailSettingsAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemEmailSettingsEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSystemEmailSettingsView.Show(id.id,
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

    <ext:Store ID="storeSystemEmailSettings" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSystemEmailSettings_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="EmailSettingID">
                <Fields>
					<ext:RecordField Name="EmailSettingID" Type="int" />
		<ext:RecordField Name="Name" />			
		<ext:RecordField Name="Descriprsion" />			
		<ext:RecordField Name="Host" />			
		<ext:RecordField Name="Port" />			
				<ext:RecordField Name="SSL" Type="Boolean" />
		<ext:RecordField Name="FromEmail" />			
		<ext:RecordField Name="FromName" />			
		<ext:RecordField Name="LoginEmail" />			
		<ext:RecordField Name="LoginPassword" />			
				<ext:RecordField Name="IsEnable" Type="Boolean" />
				<ext:RecordField Name="IsDefault" Type="Boolean" />
				<ext:RecordField Name="CreateDate" Type="Date" />
				<ext:RecordField Name="CreateBy" Type="int" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemEmailSettingsAdd ID="UCSystemEmailSettingsAdd1" runat="server" />
    <uc2:UCSystemEmailSettingsEdit ID="UCSystemEmailSettingsEdit1" runat="server" /> 
    <uc3:UCSystemEmailSettingsView ID="UCSystemEmailSettingsView1" runat="server" /> 	
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemEmailSettings" runat="server" StoreID="storeSystemEmailSettings"
                StripeRows="true" Title="SystemEmailSettings Management" Icon="Table">
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
                                    <Click Handler="#{storeSystemEmailSettings}.reload();" />
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
				<ext:Column ColumnID="colEmailSettingID" DataIndex="EmailSettingID" Header="EmailSettingID" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescriprsion" DataIndex="Descriprsion" Header="Descriprsion" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colHost" DataIndex="Host" Header="Host" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colPort" DataIndex="Port" Header="Port" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colSSL" DataIndex="SSL" Header="SSL" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
		<ext:Column ColumnID="colFromEmail" DataIndex="FromEmail" Header="FromEmail" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colFromName" DataIndex="FromName" Header="FromName" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLoginEmail" DataIndex="LoginEmail" Header="LoginEmail" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLoginPassword" DataIndex="LoginPassword" Header="LoginPassword" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="IsEnable" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colIsDefault" DataIndex="IsDefault" Header="IsDefault" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="CreateDate" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colCreateBy" DataIndex="CreateBy" Header="CreateBy" Sortable="true">
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
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemEmailSettings"
                        DisplayInfo="true" DisplayMsg="Display SystemEmailSettingss {0} - {1} total {2}" EmptyMsg="No matched SystemEmailSettings" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
