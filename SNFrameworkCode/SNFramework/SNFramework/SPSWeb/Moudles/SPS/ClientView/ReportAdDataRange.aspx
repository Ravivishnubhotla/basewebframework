<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReportAdDataRange.aspx.cs" Inherits="SPSWeb.Moudles.SPS.ClientView.ReportAdDataRange" %>
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
                                                                        msg: '操作中...'
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
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="SPAd_Name" />
                    <ext:RecordField Name="SPAdPack_Name" />
                    <ext:RecordField Name="SPClientID_Name" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="ClientCount" Type="int" />
                    <ext:RecordField Name="AdCount" Type="int" />
                    <ext:RecordField Name="AdAmount" Type="int" />

                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdReport" runat="server" StoreID="storeSPAdReport"
                StripeRows="true" Title="广告汇总报表" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:DateField ID="dfStart" FieldLabel="开始时间" LabelWidth="60" AllowBlank="false"
                                Width="150" runat="server" />
                            <ext:ToolbarSpacer />
                            <ext:DateField ID="dfEnd" FieldLabel="结束时间" LabelWidth="60" AllowBlank="false" Width="150"
                                runat="server" />
                            <ext:Button ID='btnRefresh' runat="server" Text="查询" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPAdReport}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnToggleGroups" runat="server" Text="收起/展开 分组" Icon="TableSort"
                                AutoPostBack="false">
                                <Listeners>
                                    <Click Handler="#{gridPanelSPAdReport}.getView().toggleAllGroups();" />
                                </Listeners>
                            </ext:Button>
 
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <View>
                    <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                        ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                </View>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true"
                            Groupable="True">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                        </ext:Column>
                        <ext:Column ColumnID="colAdID" DataIndex="SPAd_Name" Header="广告" Sortable="true"
                            Groupable="True">
                        </ext:Column>
                        <ext:Column ColumnID="colAdPackID" DataIndex="SPAdPack_Name" Header="广告包" Sortable="true"
                            Groupable="True">
                        </ext:Column>
 

                        <ext:GroupingSummaryColumn ColumnID="colDownTotalCount" Header="点播数" DataIndex="ClientCount"
                            Sortable="true" Groupable="False" SummaryType="Sum">
                        </ext:GroupingSummaryColumn>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
                <Plugins>
                    <ext:GroupingSummary ID="GroupingSummary1" runat="server">
                    </ext:GroupingSummary>
                </Plugins>
                <BottomBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
 

                            <ext:DisplayField ID="lblTotalDownSycnSuccess" FieldLabel="总点播数" LabelWidth="90" runat="server"
                                Text="-" />

                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:GridPanel>

        </Items>
    </ext:Viewport>
</asp:Content>