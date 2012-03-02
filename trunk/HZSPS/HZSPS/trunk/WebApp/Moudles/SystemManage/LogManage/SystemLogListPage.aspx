<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemLogListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.LogManage.SystemLogListPage" %>
<%@ Register Src="UCSystemLogAdd.ascx" TagName="UCSystemLogAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemLogEdit.ascx" TagName="UCSystemLogEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemLogView.ascx" TagName="UCSystemLogView" TagPrefix="uc3" %>
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
            <%= this.storeSystemLog.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemLogAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemLogEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSystemLogView.Show(id.id,
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
                Ext.MessageBox.confirm('warning','Are you sure delete the record ?SystemConfig ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete successfulSystemLog!',RefreshData);            
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
        }

    </script>

    <ext:Store ID="storeSystemLog" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemLog_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="LogID">
                <Fields>
					<ext:RecordField Name="LogID" Type="int" />
		<ext:RecordField Name="LogLevel" />			
		<ext:RecordField Name="LogType" />			
				<ext:RecordField Name="LogDate" Type="Date" />
		<ext:RecordField Name="LogSource" />			
		<ext:RecordField Name="LogUser" />			
		<ext:RecordField Name="LogDescrption" />			
		<ext:RecordField Name="LogRequestInfo" />			
				<ext:RecordField Name="LogRelateMoudleID" Type="int" />
				<ext:RecordField Name="LogRelateMoudleDataID" Type="int" />
				<ext:RecordField Name="LogRelateUserID" Type="int" />
				<ext:RecordField Name="LogRelateDateTime" Type="Date" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemLogAdd ID="UCSystemLogAdd1" runat="server" />
    <uc2:UCSystemLogEdit ID="UCSystemLogEdit1" runat="server" /> 
    <uc3:UCSystemLogView ID="UCSystemLogView1" runat="server" />    
    
    
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemLog" runat="server" StoreID="storeSystemLog"
                StripeRows="true" Title="SystemLogManagement" Icon="Table">
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
                                    <Click Handler="#{storeSystemLog}.reload();" />
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
				<ext:Column ColumnID="colLogID" DataIndex="LogID" Header="LogID" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colLogLevel" DataIndex="LogLevel" Header="LogLevel" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLogType" DataIndex="LogType" Header="LogType" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colLogDate" DataIndex="LogDate" Header="LogDate" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colLogSource" DataIndex="LogSource" Header="LogSource" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLogUser" DataIndex="LogUser" Header="LogUser" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLogDescrption" DataIndex="LogDescrption" Header="LogDescrption" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colLogRequestInfo" DataIndex="LogRequestInfo" Header="LogRequestInfo" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colLogRelateMoudleID" DataIndex="LogRelateMoudleID" Header="LogRelateMoudleID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLogRelateMoudleDataID" DataIndex="LogRelateMoudleDataID" Header="LogRelateMoudleDataID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLogRelateUserID" DataIndex="LogRelateUserID" Header="LogRelateUserID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLogRelateDateTime" DataIndex="LogRelateDateTime" Header="LogRelateDateTime" Sortable="true">
                                </ext:Column>
 
                        <ext:CommandColumn Header="SystemLogManagement" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                                                                <ext:GridCommand Icon=ApplicationViewDetail CommandName="cmdView" Text="ViewDetail">
                                    <ToolTip Text="ViewDetail" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemLog"
                        DisplayInfo="true" DisplayMsg="Show SystemLog {0} - {1} 共 {2}" EmptyMsg="No matched SystemLog" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

