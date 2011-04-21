<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
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
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
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
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemRoleEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }              
                );
            }
            
            
            if (cmd == "cmdAssignedApp") 
            {
                 var win = <%= winAssignedApplication.ClientID %>;
              win.autoLoad.params.RoleID = id.id;
              win.setTitle(String.format('<%= GetLocalResourceObject("msgAssignApplicationTitle").ToString() %>',id.data.RoleName));
              win.show();            
            }

            if (cmd == "cmdDelete") 
            {
                    Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                        function(e) 
                        {
                            if (e == 'yes')
                                Ext.net.DirectMethods.DeleteRecord(
                                                                    id.id,
                                                                    {
                                                                        failure: function(msg) {
                                                                            Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                        },
                                                                        success: function(result) { 
                                                                            Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>',RefreshData);            
                                                                        },
                                                                        eventMask: {
                                                                                    showMask: true,
                                                                                    msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
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
              win.setTitle(String.format('<%= GetLocalResourceObject("msgAssignMenuTitle").ToString() %>',id.data.RoleName));
              win.show();
            }
           
            if (cmd == "cmdAssignedPermission") 
            {
               var win = <%= winAssignedPermission.ClientID %>;
              win.autoLoad.params.RoleID = id.id;
              win.setTitle(String.format('<%= GetLocalResourceObject("msgAssignPermissionTitle").ToString() %>',id.data.RoleName));
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
                                        <ext:RecordField Name="RoleCode" />
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
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Table" AutoExpandColumn="colRoleDescription">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnSearch' runat="server" Text="<%$ Resources : GlobalResource, msgSearch  %>" Icon="Find">
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                Icon="Reload">
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
                        <ext:Column DataIndex="RoleName" Header="<%$ Resources:msgcolRoleName %>" Sortable="true">
                        </ext:Column>
                                                <ext:Column DataIndex="RoleCode" Header="<%$ Resources:msgcolRoleCode %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colRoleDescription" DataIndex="RoleDescription" Header="<%$ Resources:msgcolRoleDescription %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column DataIndex="RoleIsSystemRole" Header="<%$ Resources:msgcolIsSystemRole %>" Sortable="true"
                            Width="90">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn Width="80" Header="<%$ Resources : GlobalResource, msgManage  %>">
                            <Commands>
                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" ToolTip-Text="<%$ Resources : GlobalResource, msgDataAction  %>">
                                    <Menu EnableScrolling="true" ShowSeparator="true">
                                        <Items>
                                            <ext:MenuCommand Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit" CommandName="cmdEdit" />
                                            <ext:MenuCommand Text="<%$ Resources : GlobalResource, msgDelete  %>" Icon="ApplicationDelete" CommandName="cmdDelete" />
                                            <ext:MenuCommand Text="<%$ Resources:msgAssignApplicationBtnText %>" Icon="ApplicationEdit" CommandName="cmdAssignedApp" />
                                            <ext:MenuCommand Text="<%$ Resources:msgAssignMenuBtnText %>" Icon="ApplicationFormEdit" CommandName="cmdAssignedMenu" />
                                            <ext:MenuCommand Text="<%$ Resources:msgAssignPermissionBtnText %>" Icon="GroupKey" CommandName="cmdAssignedPermission" />
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemRole"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>" EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
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
        Width="700" ConstrainHeader="true" Height="350" Maximizable="true" Closable="true"
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
