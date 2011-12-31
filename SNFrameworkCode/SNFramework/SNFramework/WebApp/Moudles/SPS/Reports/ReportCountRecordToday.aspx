<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportCountRecordToday.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportCountRecordToday" %>

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

             if (cmd == "cmdViewTotalRecord") {
              var win = <%= winShowRecordList.ClientID %>;
              win.autoLoad.params.ChannelID = id.data.ChannelID_Id;
              win.autoLoad.params.CodeID = id.data.CodeID_Id;
              win.autoLoad.params.ClientID = id.data.ClientID_Id;
              win.autoLoad.params.DataType = 'AllUp';
              win.autoLoad.params.StartDate = '<%= System.DateTime.Now.ToShortDateString() %>';
              win.autoLoad.params.EndDate = '<%= System.DateTime.Now.ToShortDateString() %>';
                 
                 
              win.setTitle(String.format('通道【{0}】客户【{1}】指令【{2}】详细数据',id.data.ChannelID_Name,id.data.ClientID_Name,id.data.CodeID_MoCode));
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
                    <ext:RecordField Name="TotalCount" Type="int" />
                    <ext:RecordField Name="TotalSuccessCount" Type="int" />
                    <ext:RecordField Name="InterceptCount" Type="int" />
                    <ext:RecordField Name="DownTotalCount" Type="int" />
                    <ext:RecordField Name="DownSycnSuccess" Type="int" />
                    <ext:RecordField Name="DownSycnFailed" Type="int" />
                    <ext:RecordField Name="DownNotSycn" Type="int" />
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
                        <ext:Column ColumnID="colChannelID" DataIndex="ChannelID_Name" Header="通道" Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewChannelDetail" Icon="ApplicationViewDetail">
                                    <ToolTip Text="通道详细信息" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colClientID" DataIndex="ClientID_Name" Header="客户" Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewClientDetail" Icon="ApplicationViewDetail">
                                    <ToolTip Text="客户详细信息" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colCodeID" DataIndex="CodeID_MoCode" Header="代码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colTotalCount" Header="MR总数" DataIndex="TotalCount" Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewTotalRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colTotalSuccessCount" Header="MO总数" DataIndex="TotalSuccessCount"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewTotalSuccessRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colInterceptCount" Header="扣量" DataIndex="InterceptCount" Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewInterceptCountRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownTotalCount" Header="同步下家数" DataIndex="DownTotalCount"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownTotalCountRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnSuccess" Header="同步下家成功数" DataIndex="DownSycnSuccess"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownSycnSuccessRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnFailed" Header="同步下家失败数" DataIndex="DownSycnFailed"
                            Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownSycnFailedRecord" Icon="DatabaseTable">
                                    <ToolTip Text="查看记录" />
                                </ext:ImageCommand>
                            </Commands>
                        </ext:Column>
                        <ext:Column ColumnID="colDownNotSycn" Header="未同步下家数" DataIndex="DownNotSycn" Sortable="true">
                            <Commands>
                                <ext:ImageCommand CommandName="cmdViewDownNotSycnRecord" Icon="DatabaseTable">
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
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winShowRecordList" runat="server" Title="Window" Frame="true" Width="800"
        ConstrainHeader="true" Height="600" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" Hidden="true">
        <AutoLoad Url="ReportDetailPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
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
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
