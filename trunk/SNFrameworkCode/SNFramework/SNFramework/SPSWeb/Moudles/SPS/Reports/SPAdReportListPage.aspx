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
                                                                    Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: '操作中...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPAdReportEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                }              
                );
            }
			
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPAdReportView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认删除该条记录？ ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', 'Delete a record success!',RefreshData);            
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
                StripeRows="true" Title="结算报表填写" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="批量添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
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

                        <ext:Column ColumnID="colSPAdID" DataIndex="SPAdID" Header="广告" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSPPackID" DataIndex="SPPackID" Header="广告包" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSPClientID" DataIndex="SPClientID" Header="下家" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="结算日期" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colClientCount" DataIndex="ClientCount" Header="下家结算数" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colAdCount" DataIndex="AdCount" Header="上家结算数" Sortable="true">
                        </ext:Column>
 
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="选择操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑"></ext:MenuCommand>

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

