﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemRoleListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.SystemRoleListPage" %>

<%@ Register Src="UCSystemRoleAdd.ascx" TagName="UCSystemRoleAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemRoleEdit.ascx" TagName="UCSystemRoleEdit" TagPrefix="uc2" %>
 
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        }

     function CloseWinAssignedMenu()
     {
        <%= winAssignedMenu.ClientID %>.hide();
     }
     
     function CloseWinAssignedApplication()
     {
        <%= winAssignedApplication.ClientID %>.hide();
     }
     
          function CloseWinAssignedPermission()
     {
        <%= winAssignedPermission.ClientID %>.hide();
     }

        var RefreshData = function(btn) {
            <%= this.storeSystemRole.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemRoleAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemRoleEdit.Show(id.id,
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
            
            
            if (cmd == "cmdAssignedApp") 
            {
                 var win = <%= winAssignedApplication.ClientID %>;
              win.autoLoad.params.RoleID = id.id;
              win.setTitle("Role '" + id.data.RoleName + "' Assign Application ");
              win.show();            
            }

            if (cmd == "cmdDelete") 
            {
                    Ext.MessageBox.confirm('warning','Are you sure delete system role?',
                        function(e) 
                        {
                            if (e == 'yes')
                                Ext.net.DirectMethods.DeleteRecord(
                                                                    id.id,
                                                                    {
                                                                        failure: function(msg) {
                                                                            Ext.Msg.alert('Operation failed', msg);
                                                                        },
                                                                        success: function(result) { 
                                                                            Ext.Msg.alert('Operation Successful', 'Delete system role successful!',RefreshData);            
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
            if (cmd == "cmdAssignedMenu") 
            {
               var win = <%= winAssignedMenu.ClientID %>;
              win.autoLoad.params.RoleID = id.id;
              win.setTitle("Role '" + id.data.RoleName + "' Assign Menu ");
              win.show();
            }
           
            if (cmd == "cmdAssignedPermission") 
            {
               var win = <%= winAssignedPermission.ClientID %>;
              win.autoLoad.params.RoleID = id.id;
              win.setTitle("Role '" + id.data.RoleName + "' Assign Permission");
              win.show();
           }
     }

    </script>

    <ext:Store ID="storeSystemRole" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemRole_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="RoleID">
                <Fields>
                    <ext:RecordField Name="RoleID" Type="int" />
                    <ext:RecordField Name="RoleName" />
                    <ext:RecordField Name="RoleDescription" />
                    <ext:RecordField Name="RoleIsSystemRole" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemRoleAdd ID="UCSystemRoleAdd1" runat="server" />
    <uc2:UCSystemRoleEdit ID="UCSystemRoleEdit1" runat="server" />
 
 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemRole" runat="server" StoreID="storeSystemRole"
                StripeRows="true" Title="System Role Management" Icon="Table" AutoExpandColumn="colRoleDescription">
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
                                    <Click Handler="#{storeSystemRole}.reload();" />
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
                        <ext:Column DataIndex="RoleID" Header="ID" Sortable="true" Width="50">
                        </ext:Column>
                        <ext:Column DataIndex="RoleName" Header="Role Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colRoleDescription" DataIndex="RoleDescription" Header="RoleDescription"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column DataIndex="RoleIsSystemRole" Header="Is System Role" Sortable="true"
                            Width="90">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn Header="System Role Management" Width="200">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdAssignedApp" Text="Assign Application">
                                    <ToolTip Text="Assigned Apply" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdAssignedMenu" Text="Assign Menu">
                                    <ToolTip Text="Menu Permission" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="GroupKey" CommandName="cmdAssignedPermission" Text="Assign Permission">
                                    <ToolTip Text="System Permission" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemRole"
                        DisplayInfo="true" DisplayMsg="Show System Role {0} - {1} total {2}" EmptyMsg="No matched recordSystem Role" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
        <ext:Window ID="winAssignedMenu" runat="server" Title="Window" Frame="true" Width="700"
        ConstrainHeader="true" Height="500" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SystemRoleAssignedMenu.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="RoleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winAssignedApplication" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="500" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SystemRoleAssignedApplication.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="RoleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
        <ext:Window ID="winAssignedPermission" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="500" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SystemRoleAssignedPrivilege.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="RoleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    
</asp:Content>
