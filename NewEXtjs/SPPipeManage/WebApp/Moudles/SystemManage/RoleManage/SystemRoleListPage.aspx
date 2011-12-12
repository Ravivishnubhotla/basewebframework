<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemRoleListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.SystemRoleListPage" %>

<%@ Register Src="UCSystemRoleAdd.ascx" TagName="UCSystemRoleAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemRoleEdit.ascx" TagName="UCSystemRoleEdit" TagPrefix="uc2" %>

<%@ Register Src="UCSystemRoleAssignedApplication.ascx" TagName="UCSystemRoleAssignedApplication" TagPrefix="uc3" %>
<%@ Register Src="UCSystemRoleAssignedMenu.ascx" TagName="UCSystemRoleAssignedMenu" TagPrefix="uc4" %>
<%@ Register Src="UCSystemRoleAssignedPrivilege.ascx" TagName="UCSystemRoleAssignedPrivilege" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server"></ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        };


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
                Ext.net.DirectMethods.UCSystemRoleAssignedApplication.Show(id.id,
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
                    Ext.MessageBox.confirm('warning','Are you sure delete System Role ? ',
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
                                                                            Ext.Msg.alert('Operation Successful', 'Delete successfulSystem Role!',RefreshData);            
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
                   //ctl00_ContentPlaceHolder1_UCSystemRoleAssignedMenu1_storeSystemApplication.reload();
                   Ext.net.DirectMethods.UCSystemRoleAssignedMenu.Show(id.id,
                            {
                                failure: function(msg) 
                                {
                                    Ext.Msg.alert('Operation failed', msg,RefreshData);
                                },
                                eventMask: {
                                            showMask: true,
                                            msg: 'Processing...'
                                           }
                            }              
                );
           }
           
            if (cmd == "cmdAssignedPermission") 
            {
                   //ctl00_ContentPlaceHolder1_UCSystemRoleAssignedMenu1_storeSystemApplication.reload();
                   Ext.net.DirectMethods.UCSystemRoleAssignedPrivilege.Show(id.id,
                            {
                                failure: function(msg) 
                                {
                                    Ext.Msg.alert('Operation failed', msg,RefreshData);
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

    <ext:Store ID="storeSystemRole" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSystemRole_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="RoleID">
                <Fields>
                    <ext:RecordField Name="RoleID" Type="int"  />
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
        <uc3:UCSystemRoleAssignedApplication ID="UCSystemRoleAssignedApplication1" runat="server" /> 
        <uc4:UCSystemRoleAssignedMenu ID="UCSystemRoleAssignedMenu1" runat="server" />
        <uc5:UCSystemRoleAssignedPrivilege ID="UCSystemRoleAssignedPrivilege1" runat="server" />
        
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
                        <ext:Column DataIndex="RoleID" Header="Primary Key" Sortable="true" Width="50">
                        </ext:Column>
                        <ext:Column DataIndex="RoleName" Header="Role Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colRoleDescription" DataIndex="RoleDescription" Header="RoleDescription"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column DataIndex="RoleIsSystemRole" Header="Is System Role" Sortable="true" Width="90">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn Header="System RoleManagement" Width="200">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdAssignedApp" Text="Assigned Apply">
                                    <ToolTip Text="Assigned Apply" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdAssignedMenu" Text="Menu Permission">
                                    <ToolTip Text="Menu Permission" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="GroupKey" CommandName="cmdAssignedPermission" Text="System Permission">
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
</asp:Content>
