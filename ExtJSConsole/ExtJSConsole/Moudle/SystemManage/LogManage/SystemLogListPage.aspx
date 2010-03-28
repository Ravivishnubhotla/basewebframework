<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemLogListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.LogManage.SystemLogListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemLog.ClientID %>.reload();
        };
        




    </script>

    <ext:Store ID="storeSystemLog" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSystemLog_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="LogID">
                <Fields>
                    <ext:RecordField Name="LogID" Type="int" />
                    <ext:RecordField Name="LogLevel" />
                    <ext:RecordField Name="LogType" />
                    <ext:RecordField Name="LogDate" Type="Date" />
                    <ext:RecordField Name="LogSource" />
                    <ext:RecordField Name="LogUser" />
                    <ext:RecordField Name="LogDescrption" />
                    <ext:RecordField Name="LogRequestInfo" />
                    <ext:RecordField Name="LogRelateMoudleID" Type="int" />
                    <ext:RecordField Name="LogRelateMoudleDataID" Type="int" />
                    <ext:RecordField Name="LogRelateUserID" Type="int" />
                    <ext:RecordField Name="LogRelateDateTime" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemLog" runat="server" StoreID="storeSystemLog" StripeRows="true"
                        Title="SystemLog管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="showAddForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSystemLog}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
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
                                <ext:Column ColumnID="colLogID" DataIndex="LogID" Header="主键" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogLevel" DataIndex="LogLevel" Header="日志级别" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogType" DataIndex="LogType" Header="日志类型" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogDate" DataIndex="LogDate" Header="日志时间" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogSource" DataIndex="LogSource" Header="日志来源" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogUser" DataIndex="LogUser" Header="日志用户" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogDescrption" DataIndex="LogDescrption" Header="日志内容" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogRequestInfo" DataIndex="LogRequestInfo" Header="日志请求信息"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogRelateMoudleID" DataIndex="LogRelateMoudleID" Header="日志相关模块"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogRelateMoudleDataID" DataIndex="LogRelateMoudleDataID"
                                    Header="日志相关模块记录" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogRelateUserID" DataIndex="LogRelateUserID" Header="日志相关用户"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogRelateDateTime" DataIndex="LogRelateDateTime" Header="日志相关日期"
                                    Sortable="true">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemLog"
                                DisplayInfo="true" DisplayMsg="显示SystemLog {0} - {1} 共 {2}" EmptyMsg="没有符合条件的SystemLog" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
