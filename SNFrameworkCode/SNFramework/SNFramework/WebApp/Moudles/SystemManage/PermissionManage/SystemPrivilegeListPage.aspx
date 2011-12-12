<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemPrivilegeListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.SystemPrivilegeListPage" %>


<%@ Register Src="UCSystemPrivilegeAdd.ascx" TagName="UCSystemPrivilegeAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemPrivilegeEdit.ascx" TagName="UCSystemPrivilegeEdit" TagPrefix="uc2" %>
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
        };


        var RefreshData = function(btn) {
            <%= this.storeSystemPrivilege.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemPrivilegeAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemPrivilegeEdit.Show(id.id,
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

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','Are you sure delete the record ?System Permission ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete successfulSystem Permission!',RefreshData);            
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
        }

    </script>

    <ext:Store ID="storeSystemPrivilege" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSystemPrivilege_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="PrivilegeID">
                <Fields>
					<ext:RecordField Name="PrivilegeID" Type="int" />
				<ext:RecordField Name="OperationID" Type="int" />
				<ext:RecordField Name="ResourcesID" Type="int" />
		<ext:RecordField Name="PrivilegeCnName" />			
		<ext:RecordField Name="PrivilegeEnName" />			
		<ext:RecordField Name="DefaultValue" />			
		<ext:RecordField Name="Description" />			
				<ext:RecordField Name="PrivilegeOrder" Type="int" />
		<ext:RecordField Name="PrivilegeCategory" />			
		<ext:RecordField Name="PrivilegeType" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemPrivilegeAdd ID="UCSystemPrivilegeAdd1" runat="server" />
    <uc2:UCSystemPrivilegeEdit ID="UCSystemPrivilegeEdit1" runat="server" /> 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemPrivilege" runat="server" StoreID="storeSystemPrivilege"
                StripeRows="true" Title="System PermissionManagement" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemPrivilege}.reload();" />
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
				<ext:Column ColumnID="colPrivilegeID" DataIndex="PrivilegeID" Header="Primary Key" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colOperationID" DataIndex="OperationID" Header="Operation ID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colResourcesID" DataIndex="ResourcesID" Header="Resources ID" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colPrivilegeCnName" DataIndex="PrivilegeCnName" Header="Permission Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colPrivilegeEnName" DataIndex="PrivilegeEnName" Header="Permission Code" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDefaultValue" DataIndex="DefaultValue" Header="Default Value" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescription" DataIndex="Description" Header="Permission Description" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colPrivilegeOrder" DataIndex="PrivilegeOrder" Header="Permission Order" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colPrivilegeCategory" DataIndex="PrivilegeCategory" Header="permission Category" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colPrivilegeType" DataIndex="PrivilegeType" Header="PrivilegeType" Sortable="true">
                                </ext:Column>			
 
                        <ext:CommandColumn Header="System PermissionManagement" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                    <ToolTip Text="<%$ Resources : GlobalResource, msgEdit  %>" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                    <ToolTip Text="<%$ Resources : GlobalResource, msgDelete  %>" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemPrivilege"
                        DisplayInfo="true" DisplayMsg="ShowSystem Permission {0} - {1} total {2}" EmptyMsg="No matched recordSystem Permission" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

