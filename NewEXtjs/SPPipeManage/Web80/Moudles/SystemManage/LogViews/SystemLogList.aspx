<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemLogList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SystemManage.LogViews.SystemLogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };

        var RefreshData = function(btn) {
            <%= this.storeSystemLog.ClientID %>.reload();
        };

    </script>
    <ext:Store ID="storeSystemLog" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSystemLog_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
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
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server" Layout="fit">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSystemLog" runat="server" StoreID="storeSystemLog" StripeRows="true"
                        AutoExpandColumn="colLogDescrption" Title="系统日志查看" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:DateField ID="dfStart" runat="server" />
                                    <ext:Button runat="server" Text="-" />
                                    <ext:DateField ID="dfEnd" runat="server" />
                                    <ext:Button ID='btnFind' runat="server" Text="搜索"
                                        Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSystemLog}.reload();" />
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
                                <ext:Column ColumnID="colLogLevel" DataIndex="LogLevel" Header="级别"
                                    Width="20" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogDate" DataIndex="LogDate" Header="日期"
                                    Width="39" Sortable="true">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y h:i:s')" />
                                </ext:Column>
                                <ext:Column ColumnID="colLogUser" DataIndex="LogUser" Header="用户"
                                    Width="50" Sortable="true" Hidden="true">
                                </ext:Column>
                                <ext:Column ColumnID="colLogDescrption" DataIndex="LogDescrption" Header="日志内容"
                                    Sortable="true" Width="200">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemLog"
                                DisplayInfo="true" DisplayMsg="显示日志 {0} - {1} 共 {2}"
                                EmptyMsg="没有符合条件的日志" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                        </SelectionModel>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
 
</asp:Content>
