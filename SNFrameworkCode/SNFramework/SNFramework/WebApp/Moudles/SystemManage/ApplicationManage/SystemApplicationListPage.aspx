<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ApplicationManage.SystemApplicationListPage" %>

<%@ Register Src="UCSystemApplicationAdd.ascx" TagName="UCSystemApplicationAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemApplicationEdit.ascx" TagName="UCSystemApplicationEdit"
    TagPrefix="uc2" %>
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

        var RefreshData = function(btn) {
            <%= this.storeSystemApplication.ClientID %>.reload();
        };
        
        function showAddForm() {
               Ext.net.DirectMethods.UCSystemApplicationAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation successful', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemApplicationEdit.Show(id.id,
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
                Ext.MessageBox.confirm('Warning','Are you sure you want to delete this record?',
                    function(e) {
                        if (e == 'yes')
                           Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete the record successful!',RefreshData);            
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

    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" RemotePaging="true"
        RemoteSort="true" OnRefreshData="storeSystemApplication_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                                        <ext:RecordField Name="LocaLocalizationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemApplicationAdd ID="UCSystemApplicationAdd1" runat="server" />
    <uc2:UCSystemApplicationEdit ID="UCSystemApplicationEdit2" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
    
        <Items>
            <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true"
                Title="System Application" Icon="Table" AutoExpandColumn="colSystemApplicationDescription">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="ApplicationAdd">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemApplication}.reload();" />
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
                        <ext:Column DataIndex="LocaLocalizationName" Header="Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSystemApplicationDescription" DataIndex="SystemApplicationDescription"
                            Header="Description">
                        </ext:Column>
                        <ext:Column DataIndex="SystemApplicationUrl" Header="Url">
                        </ext:Column>
                        <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="System Application"
                            Width="80">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn Width="60">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemApplication"
                        DisplayInfo="true" DisplayMsg="Displaying records {0} - {1} total: {2}" EmptyMsg="No matched record" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
