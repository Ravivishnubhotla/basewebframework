<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemUserGroupListPage.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.UserGroupManage.SystemUserGroupListPage" %>
<%@ Register Src="UCSystemUserGroupAdd.ascx" TagName="UCSystemUserGroupAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemUserGroupEdit.ascx" TagName="UCSystemUserGroupEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemUserGroup.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemUserGroupAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemUserGroupEdit.Show(id.id,
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

            if (cmd == "cmdDelete") 
            {
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
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
            
            if (cmd == "cmdAssignedRole") {
               var win = <%= winAssignedUserRole.ClientID %>;
              win.autoLoad.params.UserGroupID = id.id;
              win.setTitle(String.format("<%= GetLocalResourceObject("msgwinAssignedUserRoleTitle").ToString() %>",id.data.GroupNameCn));
              win.show();
            }
        }
        
        
     function CloseWinAssignedRole()
     {
        <%= winAssignedUserRole.ClientID %>.hide();
     }

    </script>
    <ext:Store ID="storeSystemUserGroup" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemUserGroup_Refresh">
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
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemUserGroup" runat="server" StoreID="storeSystemUserGroup"
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                Icon="Reload">
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
                        <ext:Column ColumnID="colGroupID" DataIndex="GroupID" Header="<%$ Resources:msgcolGroupID %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colGroupNameCn" DataIndex="GroupNameCn" Header="<%$ Resources:msgcolGroupNameCn %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colGroupNameEn" DataIndex="GroupNameEn" Header="<%$ Resources:msgcolGroupNameEn %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colGroupDescription" DataIndex="GroupDescription" Header="<%$ Resources:msgcolGroupDescription %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn Width="80" Header="<%$ Resources : GlobalResource, msgManage  %>">
                            <Commands>
                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" ToolTip-Text="<%$ Resources : GlobalResource, msgDataAction  %>">
                                    <Menu EnableScrolling="true" ShowSeparator="true">
                                        <Items>
                                            <ext:MenuCommand Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit"
                                                CommandName="cmdEdit" />
                                            <ext:MenuCommand Text="<%$ Resources : GlobalResource, msgDelete  %>" Icon="ApplicationDelete"
                                                CommandName="cmdDelete" />
                                            <ext:MenuCommand Text="分配角色" Icon="group" CommandName="cmdAssignedRole" />
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUserGroup"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>"
                        EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winAssignedUserRole" runat="server" Title="Window" Frame="true" Width="700"
        ConstrainHeader="true" Height="350" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="SystemUserGroupAssignedRole.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="UserGroupID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
