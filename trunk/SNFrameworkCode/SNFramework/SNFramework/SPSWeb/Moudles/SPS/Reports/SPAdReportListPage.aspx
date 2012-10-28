
<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPAdReportListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Reports.SPAdReportListPage" %>


<%@ Register Src="UCSPAdReportAdd.ascx" TagName="UCSPAdReportAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPAdReportEdit.ascx" TagName="UCSPAdReportEdit" TagPrefix="uc2" %>
 
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
        };


        var RefreshData = function(btn) {
            <%= this.storeSPAdReport.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPAdReportAdd.Show( 
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
                Ext.net.DirectMethods.UCSPAdReportEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSPAdReportView.Show(id.id,
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

    <ext:Store ID="storeSPAdReport" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPAdReport_Refresh">
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
				<ext:RecordField Name="SPAdID" Type="int" />
				<ext:RecordField Name="SPPackID" Type="int" />
				<ext:RecordField Name="SPClientID" Type="int" />
				<ext:RecordField Name="ReportDate" Type="Date" />
				<ext:RecordField Name="ClientCount" Type="int" />
				<ext:RecordField Name="AdCount" Type="int" />
				<ext:RecordField Name="AdAmount" Type="int" />
				<ext:RecordField Name="CreateBy" Type="int" />
				<ext:RecordField Name="CreateAt" Type="Date" />
				<ext:RecordField Name="LastModifyBy" Type="int" />
				<ext:RecordField Name="LastModifyAt" Type="Date" />
		<ext:RecordField Name="LastModifyComment" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPAdReportAdd ID="UCSPAdReportAdd1" runat="server" />
    <uc2:UCSPAdReportEdit ID="UCSPAdReportEdit1" runat="server" /> 
 
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdReport" runat="server" StoreID="storeSPAdReport"
                StripeRows="true" Title="SPAdReport Management" Icon="Table">
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
                                    <Click Handler="#{storeSPAdReport}.reload();" />
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
				<ext:Column ColumnID="colSPAdID" DataIndex="SPAdID" Header="SPAdID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSPPackID" DataIndex="SPPackID" Header="SPPackID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colSPClientID" DataIndex="SPClientID" Header="SPClientID" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="ReportDate" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colClientCount" DataIndex="ClientCount" Header="ClientCount" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colAdCount" DataIndex="AdCount" Header="AdCount" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colAdAmount" DataIndex="AdAmount" Header="AdAmount" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colCreateBy" DataIndex="CreateBy" Header="CreateBy" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colCreateAt" DataIndex="CreateAt" Header="CreateAt" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLastModifyBy" DataIndex="LastModifyBy" Header="LastModifyBy" Sortable="true">
                                </ext:Column>
				<ext:Column ColumnID="colLastModifyAt" DataIndex="LastModifyAt" Header="LastModifyAt" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colLastModifyComment" DataIndex="LastModifyComment" Header="LastModifyComment" Sortable="true">
                                </ext:Column>			
 
                                <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                                    <Commands>
                                    <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                                 <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View"></ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                   
                                    </ext:SplitCommand>

                                    </Commands>
                                </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdReport"
                        DisplayInfo="true" DisplayMsg="Display SPAdReports {0} - {1} total {2}" EmptyMsg="No matched SPAdReport" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

