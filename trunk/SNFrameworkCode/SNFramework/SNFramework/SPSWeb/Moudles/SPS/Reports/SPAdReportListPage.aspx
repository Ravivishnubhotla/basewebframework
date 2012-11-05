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
                                                                    Ext.Msg.alert('����ʧ��', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: '������...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPAdReportEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('����ʧ��', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '������...'
                                                                    }
                                                                }              
                );
            }
            
            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('����','ȷ��ɾ��������¼�� ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('����ʧ��', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('�����ɹ�', 'Delete a record success!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '������...'
                                                                    }
                                                                }
                                                            );
                    }
                    );
            }
			
 
        }

    </script>

    <ext:Store ID="storeSPAdReport" runat="server" AutoLoad="true"
        OnRefreshData="storeSPAdReport_Refresh" GroupField="SPAd_Name">
        <SortInfo Direction="DESC" Field="SPAd_Name" />
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
                    <ext:RecordField Name="AdClientUseCount" Type="int" />
                    <ext:RecordField Name="AdUseCount" Type="int" />
                    <ext:RecordField Name="AdClientDownCount" Type="int" />
                    <ext:RecordField Name="AdDownCount" Type="int" />
                    <ext:RecordField Name="AdAmount" Type="Float" />

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
                StripeRows="true" Title="�����ܱ���" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:DateField ID="dfStart" FieldLabel="��ʼʱ��" LabelWidth="60" AllowBlank="false"
                                Width="150" runat="server" />
                            <ext:ToolbarSpacer />
                            <ext:DateField ID="dfEnd" FieldLabel="����ʱ��" LabelWidth="60" AllowBlank="false" Width="150"
                                runat="server" />
                            <ext:Button ID='btnRefresh' runat="server" Text="��ѯ" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPAdReport}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnToggleGroups" runat="server" Text="����/չ�� ����" Icon="TableSort"
                                AutoPostBack="false">
                                <Listeners>
                                    <Click Handler="#{gridPanelSPAdReport}.getView().toggleAllGroups();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnAdd' runat="server" Text="�ֶ���ӱ���" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
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
                        <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="����" Sortable="true"
                            Groupable="True">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                        </ext:Column>
                        <ext:Column ColumnID="colAdID" DataIndex="SPAd_Name" Header="���" Sortable="true"
                            Groupable="True">
                        </ext:Column>
                        <ext:Column ColumnID="colAdPackID" DataIndex="SPAdPack_Name" Header="����" Sortable="true"
                            Groupable="True">
                        </ext:Column>
                        <ext:Column ColumnID="colClientID" DataIndex="SPClientID_Name" Header="�ͻ�" Sortable="true"
                            Groupable="True">
                        </ext:Column>
                        <ext:GroupingSummaryColumn ColumnID="colTotalSuccessCount" Header="�ϼҶ�����" DataIndex="AdCount"
                            Sortable="true" SummaryType="Sum" Groupable="False">
                        </ext:GroupingSummaryColumn>

                        <ext:GroupingSummaryColumn ColumnID="colDownTotalCount" Header="�¼Ҷ�����" DataIndex="ClientCount"
                            Sortable="true" Groupable="False" SummaryType="Sum">
                        </ext:GroupingSummaryColumn>
                        <ext:GroupingSummaryColumn ColumnID="colTotalSuccessCount" Header="�ϼҴ���" DataIndex="AdUseCount"
                            Sortable="true" SummaryType="Sum" Groupable="False">
                        </ext:GroupingSummaryColumn>

                        <ext:GroupingSummaryColumn ColumnID="colDownTotalCount" Header="�¼Ҵ���" DataIndex="AdClientUseCount"
                            Sortable="true" Groupable="False" SummaryType="Sum">
                        </ext:GroupingSummaryColumn>

                        <ext:GroupingSummaryColumn ColumnID="colTotalSuccessCount" Header="�ϼҼ�����" DataIndex="AdDownCount"
                            Sortable="true" SummaryType="Sum" Groupable="False">
                        </ext:GroupingSummaryColumn>

                        <ext:GroupingSummaryColumn ColumnID="colDownTotalCount" Header="�¼Ҽ�����" DataIndex="AdClientDownCount"
                            Sortable="true" Groupable="False" SummaryType="Sum">
                        </ext:GroupingSummaryColumn>
                        <ext:CommandColumn ColumnID="colManage" Header="����" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="����" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="�༭">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="ɾ��">
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

                            <ext:DisplayField ID="lblTotalTotalSuccessCount" FieldLabel="���ϼҶ�����" LabelWidth="60" runat="server"
                                Text="-" />

                            <ext:DisplayField ID="lblTotalDownSycnSuccess" FieldLabel="���¼Ҷ�����" LabelWidth="90" runat="server"
                                Text="-" />

                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:GridPanel>

        </Items>
    </ext:Viewport>
</asp:Content>

