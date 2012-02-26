<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemDictionaryListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.SystemDictionaryListPage" %>

<%@ Register Src="UCSystemDictionaryAdd.ascx" TagName="UCSystemDictionaryAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemDictionaryEdit.ascx" TagName="UCSystemDictionaryEdit" TagPrefix="uc2" %>
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
            <%= this.storeSystemDictionary.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemDictionaryAdd.Show( 
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
                Ext.net.DirectMethods.UCSystemDictionaryEdit.Show(id.id,
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
                Ext.MessageBox.confirm('warning','Are you sure delete the record ?System Dictionary ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete successfulSystem Dictionary！',RefreshData);            
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

    <ext:Store ID="storeSystemDictionary" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSystemDictionary_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
		 <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemDictionaryID">
                <Fields>
					<ext:RecordField Name="SystemDictionaryID" Type="int" />
		<ext:RecordField Name="SystemDictionaryCategoryID" />			
		<ext:RecordField Name="SystemDictionaryKey" />			
		<ext:RecordField Name="SystemDictionaryValue" />			
		<ext:RecordField Name="SystemDictionaryDesciption" />			
				<ext:RecordField Name="SystemDictionaryOrder" Type="int" />
				<ext:RecordField Name="SystemDictionaryIsEnable" Type="Boolean" />
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemDictionaryAdd ID="UCSystemDictionaryAdd1" runat="server" />
    <uc2:UCSystemDictionaryEdit ID="UCSystemDictionaryEdit1" runat="server" /> 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemDictionary" runat="server" StoreID="storeSystemDictionary"
                StripeRows="true" Title="System DictionaryManagement" Icon="Table">
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
                                    <Click Handler="#{storeSystemDictionary}.reload();" />
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
				<ext:Column ColumnID="colSystemDictionaryID" DataIndex="SystemDictionaryID" Header="Primary Key" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colSystemDictionaryCategoryID" DataIndex="SystemDictionaryCategoryID" Header="Category Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryKey" DataIndex="SystemDictionaryKey" Header="Key" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryValue" DataIndex="SystemDictionaryValue" Header="Value" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colSystemDictionaryDesciption" DataIndex="SystemDictionaryDesciption" Header="Description" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colSystemDictionaryOrder" DataIndex="SystemDictionaryOrder" Header="Order Index" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSystemDictionaryIsEnable" DataIndex="SystemDictionaryIsEnable" Header="Is Enable" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
 
                        <ext:CommandColumn Header="System DictionaryManagement" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemDictionary"
                        DisplayInfo="true" DisplayMsg="ShowSystem Dictionary {0} - {1} total {2}" EmptyMsg="No matched recordSystem Dictionary" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>