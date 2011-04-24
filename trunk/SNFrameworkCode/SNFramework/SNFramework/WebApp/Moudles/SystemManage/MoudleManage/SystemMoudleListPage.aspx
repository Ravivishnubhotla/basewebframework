<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemMoudleListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.MoudleManage.SystemMoudleListPage" %>

<%@ Register Src="UCSystemMoudleAdd.ascx" TagName="UCSystemMoudleAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemMoudleEdit.ascx" TagName="UCSystemMoudleEdit" TagPrefix="uc2" %>
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
            <%= this.storeSystemMoudle.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemMoudleAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemMoudleEdit.Show(id.id,
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
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','Are you sure delete the record ?System Moudle ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete successfulSystem Moudle!',RefreshData);            
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

    <ext:Store ID="storeSystemMoudle" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSystemMoudle_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="MoudleID">
                <Fields>
					<ext:RecordField Name="MoudleID" Type="int" />
		<ext:RecordField Name="MoudleNameCn" />			
		<ext:RecordField Name="MoudleNameEn" />			
		<ext:RecordField Name="MoudleNameDb" />			
		<ext:RecordField Name="MoudleDescription" />			
				<ext:RecordField Name="ApplicationID" Type="int" />
				<ext:RecordField Name="MoudleIsSystemMoudle" Type="Boolean" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemMoudleAdd ID="UCSystemMoudleAdd1" runat="server" />
    <uc2:UCSystemMoudleEdit ID="UCSystemMoudleEdit1" runat="server" /> 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemMoudle" runat="server" StoreID="storeSystemMoudle"
                StripeRows="true" Title="System MoudleManagement" Icon="Table">
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
                                    <Click Handler="#{storeSystemMoudle}.reload();" />
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
				<ext:Column ColumnID="colMoudleID" DataIndex="MoudleID" Header="Primary Key" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colMoudleNameCn" DataIndex="MoudleNameCn" Header="Moudle Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colMoudleNameEn" DataIndex="MoudleNameEn" Header="Moudle Code" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colMoudleNameDb" DataIndex="MoudleNameDb" Header="moudle of Table" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colMoudleDescription" DataIndex="MoudleDescription" Header="Moudle Description" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colApplicationID" DataIndex="ApplicationID" Header="Application ID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colMoudleIsSystemMoudle" DataIndex="MoudleIsSystemMoudle" Header="Is System Moudle" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
 
                        <ext:CommandColumn Header="System MoudleManagement" Width="160">
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
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemMoudle"
                        DisplayInfo="true" DisplayMsg="ShowSystem Moudle {0} - {1} total {2}" EmptyMsg="No matched recordSystem Moudle" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

