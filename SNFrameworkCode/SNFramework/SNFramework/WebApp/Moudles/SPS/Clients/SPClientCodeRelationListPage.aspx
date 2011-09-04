<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientCodeRelationListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.SPClientCodeRelationListPage" %>

<%@ Register Src="UCSPClientCodeRelationAdd.ascx" TagName="UCSPClientCodeRelationAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPClientCodeRelationEdit.ascx" TagName="UCSPClientCodeRelationEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSPClientCodeRelationView.ascx" TagName="UCSPClientCodeRelationView"
    TagPrefix="uc3" %>
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
            <%= this.storeSPClientCodeRelation.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPClientCodeRelationAdd.Show( 
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
                Ext.net.DirectMethods.UCSPClientCodeRelationEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSPClientCodeRelationView.Show(id.id,
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
                Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshData);            
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
    <ext:Store ID="storeSPClientCodeRelation" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPClientCodeRelation_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="CodeID" Type="int" />
                    <ext:RecordField Name="ClientID" Type="int" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="InterceptRate" Type="int" />
                    <ext:RecordField Name="UseClientDefaultSycnSetting" Type="Boolean" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="SycnResendFailedData" Type="Boolean" />
                    <ext:RecordField Name="SycnRetryTimes" />
                    <ext:RecordField Name="SyncType" />
                    <ext:RecordField Name="SycnDataUrl" />
                    <ext:RecordField Name="SycnOkMessage" />
                    <ext:RecordField Name="SycnFailedMessage" />
                    <ext:RecordField Name="StartDate" Type="Date" />
                    <ext:RecordField Name="EndDate" Type="Date" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="SycnNotInterceptCount" Type="int" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                    <ext:RecordField Name="CreateAt" Type="Date" />
                    <ext:RecordField Name="LastModifyBy" Type="int" />
                    <ext:RecordField Name="LastModifyAt" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientCodeRelationAdd ID="UCSPClientCodeRelationAdd1" runat="server" />
    <uc2:UCSPClientCodeRelationEdit ID="UCSPClientCodeRelationEdit1" runat="server" />
    <uc3:UCSPClientCodeRelationView ID="UCSPClientCodeRelationView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPClientCodeRelation" runat="server" StoreID="storeSPClientCodeRelation"
                StripeRows="true" Title="SPClientCodeRelation Management" Icon="Table">
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
                                    <Click Handler="#{storeSPClientCodeRelation}.reload();" />
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
                        <ext:Column ColumnID="colID" DataIndex="ID" Header="ID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCodeID" DataIndex="CodeID" Header="CodeID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colClientID" DataIndex="ClientID" Header="ClientID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colPrice" DataIndex="Price" Header="Price" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="InterceptRate"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colUseClientDefaultSycnSetting" DataIndex="UseClientDefaultSycnSetting"
                            Header="UseClientDefaultSycnSetting" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSyncData" DataIndex="SyncData" Header="SyncData" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSycnResendFailedData" DataIndex="SycnResendFailedData" Header="SycnResendFailedData"
                            Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSycnRetryTimes" DataIndex="SycnRetryTimes" Header="SycnRetryTimes"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSyncType" DataIndex="SyncType" Header="SyncType" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSycnDataUrl" DataIndex="SycnDataUrl" Header="SycnDataUrl"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSycnOkMessage" DataIndex="SycnOkMessage" Header="SycnOkMessage"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSycnFailedMessage" DataIndex="SycnFailedMessage" Header="SycnFailedMessage"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colStartDate" DataIndex="StartDate" Header="StartDate" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colEndDate" DataIndex="EndDate" Header="EndDate" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="IsEnable" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSycnNotInterceptCount" DataIndex="SycnNotInterceptCount"
                            Header="SycnNotInterceptCount" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCreateBy" DataIndex="CreateBy" Header="CreateBy" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCreateAt" DataIndex="CreateAt" Header="CreateAt" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLastModifyBy" DataIndex="LastModifyBy" Header="LastModifyBy"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLastModifyAt" DataIndex="LastModifyAt" Header="LastModifyAt"
                            Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPClientCodeRelation"
                        DisplayInfo="true" DisplayMsg="Display SPClientCodeRelations {0} - {1} total {2}"
                        EmptyMsg="No matched SPClientCodeRelation" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
