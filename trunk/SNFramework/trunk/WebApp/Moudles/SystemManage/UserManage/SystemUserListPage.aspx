<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemUserListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.SystemUserListPage" %>

<%@ Register Src="UCSystemUserAdd.ascx" TagName="UCSystemUserAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserEdit.ascx" TagName="UCSystemUserEdit" TagPrefix="uc2" %>
 
<%@ Register Src="UCSystemUserChangePwd.ascx" TagName="UCSystemUserChangePwd" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'Yes';
            else
                return 'No';
        }
        
                  var FormatLocked = function(value) {
            if (value)
                return 'Locked';
            else
                return '';
        }
         var IntailLockedOut=function(grid, toolbar, rowIndex, record)
        {
      
            if(record.data.IsLockedOut)
            {
             toolbar.items.items[0].menu.items.items[5].hide();
             toolbar.items.items[0].menu.items.items[6].show();
            }
            
            else{
             toolbar.items.items[0].menu.items.items[5].show();
             toolbar.items.items[0].menu.items.items[6].hide();
        
            }
               
        }

        var RefreshData = function(btn) {
            <%= this.storeSystemUser.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemUserAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemUserEdit.Show(id.id,
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
                Ext.MessageBox.confirm('warning','Are you sure delete a record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation Successful', 'Delete a record successful!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
            if (cmd == "btnLock"||cmd == "btnUnlock") 
            {
                            Ext.net.DirectMethods.LockUser
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) 
                                                                    { 
                                                                       <%= this.storeSystemUser.ClientID %>.reload();            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }
                            );
            }
            if (cmd == "cmdChangePassword") 
            {
                            Ext.net.DirectMethods.UCSystemUserChangePwd.Show
                            (
                                                                id.id,
                                                                {
                                                                    failure: function(msg) 
                                                                    {
                                                                        Ext.Msg.alert('Operation failed', msg);
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
            if (cmd == "cmdApplyRole") 
            {
               var win = <%= winAssignedUserRole.ClientID %>;
              win.autoLoad.params.UserID = id.id;
              win.setTitle("User '" + id.data.UserLoginID + "' Assign Role ");
              win.show();
            }

            if (cmd == "cmdApplyGroup") 
            {
               var win = <%= winAssignedUserGroup.ClientID %>;
              win.autoLoad.params.UserID = id.id;
              win.setTitle("User '" + id.data.UserLoginID + "' Assign User Group ");
              win.show();
            }
        }
                         function CloseWinAssignedUserRole()
     {
        <%= winAssignedUserRole.ClientID %>.hide();
     } 
        
                  function CloseWinAssignedUserGroup()
     {
        <%= winAssignedUserGroup.ClientID %>.hide();
     }

    </script>

    <ext:Store ID="storeSystemUser" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemUser_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="UserID">
                <Fields>
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="UserEmail" />
                    <ext:RecordField Name="UserPassword" />
                    <ext:RecordField Name="UserStatus" />
                    <ext:RecordField Name="UserCreateDate" Type="Date" />
                    <ext:RecordField Name="UserType" />
                    <ext:RecordField Name="PasswordFormat" Type="int" />
                    <ext:RecordField Name="Comments" />
                    <ext:RecordField Name="IsApproved" Type="Boolean" />
                    <ext:RecordField Name="IsLockedOut" Type="Boolean" />
                    <ext:RecordField Name="LastActivityDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemUserAdd ID="UCSystemUserAdd1" runat="server" />
    <uc2:UCSystemUserEdit ID="UCSystemUserEdit1" runat="server" />
 
    <uc5:UCSystemUserChangePwd ID="UCSystemUserChangePwd1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemUser" runat="server" StoreID="storeSystemUser"
                StripeRows="true" Title="System User Management" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnSearch' runat="server" Text="Search" Icon="Find">
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemUser}.reload();" />
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
                        <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="Login ID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserName" DataIndex="UserName" Header="Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserEmail" DataIndex="UserEmail" Header="Email" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUserStatus" DataIndex="UserStatus" Header="Status" Sortable="true"
                            Width="35">
                        </ext:Column>
                        <ext:Column ColumnID="colUserCreateDate" DataIndex="UserCreateDate" Header="Create Date"
                            Sortable="true" Width="60">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                        </ext:Column>
                        <ext:Column ColumnID="colComments" DataIndex="Comments" Header="Comments" Sortable="true"
                            Width="60">
                        </ext:Column>
                        <ext:Column ColumnID="colIsLockedOut" DataIndex="IsLockedOut" Header="Locked" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatLocked" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="System User Management" Width="60"
                            DataIndex="IsLockedOut">
                            <Commands>
                                <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Key" CommandName="cmdChangePassword" Text="Change Password">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Application" CommandName="cmdApplyRole" Text="Assign Role">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Application" CommandName="cmdApplyGroup" Text="Assign Group">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Lock" CommandName="btnLock" Text="Lock">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="LockOpen" CommandName="btnUnlock" Text="unLock">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                            <PrepareToolbar Fn="IntailLockedOut" />
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUser"
                        DisplayInfo="true" DisplayMsg="Show system user {0} - {1} total{2}" EmptyMsg="No matched record system user" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winAssignedUserGroup" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="500" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SystemUserAssignedGroup.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="UserID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winAssignedUserRole" runat="server" Title="Window" Frame="true" Width="700"
        ConstrainHeader="true" Height="500" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SystemUserAssignedRole.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="UserID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
