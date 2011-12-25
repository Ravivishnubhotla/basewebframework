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

 
        }

    </script>
    <ext:Store ID="storeSPDayReport" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPDayReport_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="ChannelID_Name" />
                    <ext:RecordField Name="ClientID_Name" />
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
                        <ext:Column ColumnID="colChannelID" DataIndex="ChannelID_Name" Header="通道"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colClientID" DataIndex="ClientID_Name" Header="客户" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCodeID" DataIndex="CodeID_MoCode" Header="代码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colTotalCount" Header="MR总数" DataIndex="TotalCount" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colTotalSuccessCount" Header="MO总数" DataIndex="TotalSuccessCount"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colInterceptCount" Header="扣量" DataIndex="InterceptCount"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDownTotalCount" Header="同步下家数" DataIndex="DownTotalCount"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnSuccess" Header="同步下家成功数" DataIndex="DownSycnSuccess"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDownSycnFailed" Header="同步下家失败数" DataIndex="DownSycnFailed"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDownNotSycn" Header="未同步下家数" DataIndex="DownNotSycn"
                            Sortable="true">
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
</asp:Content>
