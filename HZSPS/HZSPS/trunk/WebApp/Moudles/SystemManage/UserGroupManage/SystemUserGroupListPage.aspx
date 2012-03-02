<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemUserGroupListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserGroupManage.SystemUserGroupListPage" %>
<%@ Register Src="UCSystemUserGroupAdd.ascx" TagName="UCSystemUserGroupAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserGroupEdit.ascx" TagName="UCSystemUserGroupEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemUserGroupAssignedRole.ascx" TagName="UCSystemUserGroupAssignedRole" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server"></ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemUserGroup.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemUserGroupAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemUserGroupEdit.Show(id.id,
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

            if (cmd == "cmdDelete") 
            {
                Ext.MessageBox.confirm('warning','Are you sure delete the record ?User Group ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete successfulUser Group！',RefreshData);            
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
            
            if (cmd == "cmdAssignedRole") {
                Ext.net.DirectMethods.UCSystemUserGroupAssignedRole.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                     success: function(result) 
                                                                    { 
                                                                       //Ext.Msg.alert('Operation Successful', 'Delete successfulSystem User!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
            }
        }

    </script>

    <ext:Store ID="storeSystemUserGroup" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSystemUserGroup_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="GroupID">
                <Fields>
					<ext:RecordField Name="GroupID" Type="int" />
		<ext:RecordField Name="GroupNameCn" />			
		<ext:RecordField Name="GroupNameEn" />			
		<ext:RecordField Name="GroupDescription" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemUserGroupAdd ID="UCSystemUserGroupAdd1" runat="server" />
    <uc2:UCSystemUserGroupEdit ID="UCSystemUserGroupEdit1" runat="server" /> 
    <uc3:UCSystemUserGroupAssignedRole ID="UCSystemUserGroupAssignedRole1" runat="server" /> 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemUserGroup" runat="server" StoreID="storeSystemUserGroup"
                StripeRows="true" Title="User GroupManagement" Icon="Table">
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
                                    <Click Handler="#{storeSystemUserGroup}.reload();" />
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
				<ext:Column ColumnID="colGroupID" DataIndex="GroupID" Header="Primary Key" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colGroupNameCn" DataIndex="GroupNameCn" Header="User Group Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colGroupNameEn" DataIndex="GroupNameEn" Header="User Group Code" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colGroupDescription" DataIndex="GroupDescription" Header="User Group Description" Sortable="true">
                                </ext:Column>			
 
                        <ext:CommandColumn Header="User GroupManagement" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationAdd" CommandName="cmdAssignedRole" Text="AssignedRole">
                                    <ToolTip Text="AssignedRole" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUserGroup"
                        DisplayInfo="true" DisplayMsg="ShowUser Group {0} - {1} total {2}" EmptyMsg="No matched recordUser Group" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>