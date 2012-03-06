<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportClientCountRecordToday.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.ClientView.ReportClientCountRecordToday" %>

<%@ Import Namespace="SPS.Bussiness.Wrappers" %>
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
            <%= this.storeSPDayReport.ClientID %>.reload();
        };
        
 
        function processcmd(cmd, id) {

 
            
           if (cmd == "cmdViewDownTotalCountRecord") {
              var win = <%= winShowRecordList.ClientID %>;
              win.autoLoad.params.ChannelID = id.data.ChannelID_Id;
              win.autoLoad.params.CodeID = id.data.CodeID_Id;
              win.autoLoad.params.ClientID = id.data.ClientID_Id;
              win.autoLoad.params.DataType = '<%= SPRecordWrapper.DayReportType_Down %>';
              win.autoLoad.params.StartDate = '<%= System.DateTime.Now.ToShortDateString() %>';
              win.autoLoad.params.EndDate = '<%= System.DateTime.Now.ToShortDateString() %>';
                 
                 
              win.setTitle(String.format('指令【{0}】下家详细数据',id.data.CodeID_MoCode));
              win.show();   
            }
            
            
           if (cmd == "cmdViewDownSycnSuccessRecord") {
              var win = <%= winShowRecordList.ClientID %>;
              win.autoLoad.params.ChannelID = id.data.ChannelID_Id;
              win.autoLoad.params.CodeID = id.data.CodeID_Id;
              win.autoLoad.params.ClientID = id.data.ClientID_Id;
              win.autoLoad.params.DataType = '<%= SPRecordWrapper.DayReportType_DownSycnSuccess %>';
              win.autoLoad.params.StartDate = '<%= System.DateTime.Now.ToShortDateString() %>';
              win.autoLoad.params.EndDate = '<%= System.DateTime.Now.ToShortDateString() %>';
                 
                 
              win.setTitle(String.format('指令【{0}】同步下家成功详细数据',id.data.CodeID_MoCode));
              win.show();   
            }
           if (cmd == "cmdViewDownSycnFailedRecord") {
              var win = <%= winShowRecordList.ClientID %>;
              win.autoLoad.params.ChannelID = id.data.ChannelID_Id;
              win.autoLoad.params.CodeID = id.data.CodeID_Id;
              win.autoLoad.params.ClientID = id.data.ClientID_Id;
              win.autoLoad.params.DataType = '<%= SPRecordWrapper.DayReportType_DownSycnFailed %>';
              win.autoLoad.params.StartDate = '<%= System.DateTime.Now.ToShortDateString() %>';
              win.autoLoad.params.EndDate = '<%= System.DateTime.Now.ToShortDateString() %>';
                 
                 
              win.setTitle(String.format('指令【{0}】同步下家失败详细数据',id.data.CodeID_MoCode));
              win.show();   
            }
 
        }

    </script>
    <ext:Store ID="storeSPDayReport" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPDayReport_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="ChannelID_Id" />
                    <ext:RecordField Name="ChannelID_Name" />
                    <ext:RecordField Name="ClientID_Name" />
                    <ext:RecordField Name="ClientID_Id" />
                    <ext:RecordField Name="CodeID_Id" />
                    <ext:RecordField Name="CodeID_MoCode" />
                    <ext:RecordField Name="DownTotalCount" Type="int" />
                    <ext:RecordField Name="DownSycnSuccess" Type="int" />
                    <ext:RecordField Name="DownSycnFailed" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig Timeout="120000">
            <EventMask ShowMask="true"></EventMask>
        </DirectEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPDayReport" runat="server" StoreID="storeSPDayReport"
                StripeRows="true" Title="即时报表" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPDayReport}.reload();" />
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
                        <ext:Column ColumnID="colCodeID" DataIndex="CodeID_MoCode" Header="代码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDownTotalCount" Header="同步数" DataIndex="DownTotalCount"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdRemovewInterceptRecord" Icon="DatabaseLightning">
                                    <ToolTip Text="重新同步" />
                                </ext:ImageCommand>
                                <ext:ImageCommand CommandName="cmdViewDownTotalCountRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnSuccess" Header="同步成功数" DataIndex="DownSycnSuccess"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownSycnSuccessRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnFailed" Header="同步失败数" DataIndex="DownSycnFailed"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownSycnFailedRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
                <BottomBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:DisplayField ID="lblTotalDownTotalCount" FieldLabel="总下家数" LabelWidth="60" runat="server"
                                Text="-" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server" />
                            <ext:DisplayField ID="lblTotalDownSycnSuccess" FieldLabel="总同步成功数" LabelWidth="90"
                                runat="server" Text="-" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server" />
                            <ext:DisplayField ID="lblTotalDownSycnFailed" FieldLabel="总同步失败数" LabelWidth="90"
                                runat="server" Text="-" />
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winShowRecordList" runat="server" Title="Window" Frame="true" Width="900"
        ConstrainHeader="true" Height="600" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="../Reports/ReportDetailPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="CodeID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ClientID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="DataType" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="StartDate" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="EndDate" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ShowMode" Mode="Value" Value="Client">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
