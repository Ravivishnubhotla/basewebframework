<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemLogListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.LogManage.SystemLogListPage" %>

<%@ Register Src="UCSystemLogView.ascx" TagName="UCSystemLogView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var RefreshData = function(btn) {
            <%= this.storeSystemLog.ClientID %>.reload();
        };
        
 

        function processcmd(cmd, id) {

 
            
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSystemLogView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }              
                );
            }

         
        }

    </script>
    <ext:Store ID="storeSystemLog" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSystemLog_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="LogID">
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
    <uc3:UCSystemLogView ID="UCSystemLogView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemLog" runat="server" StoreID="storeSystemLog" StripeRows="true"
                Title="SystemLogManagement" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                Icon="Reload">
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
                        <ext:RowNumbererColumn>
                        </ext:RowNumbererColumn>
                        <ext:Column ColumnID="colLogID" DataIndex="LogID" Header="LogID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogLevel" DataIndex="LogLevel" Header="LogLevel" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogType" DataIndex="LogType" Header="LogType" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogDate" DataIndex="LogDate" Header="LogDate" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogSource" DataIndex="LogSource" Header="LogSource" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogUser" DataIndex="LogUser" Header="LogUser" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogDescrption" DataIndex="LogDescrption" Header="LogDescrption"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogRequestInfo" DataIndex="LogRequestInfo" Header="LogRequestInfo"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogRelateMoudleID" DataIndex="LogRelateMoudleID" Header="LogRelateMoudleID"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogRelateMoudleDataID" DataIndex="LogRelateMoudleDataID"
                            Header="LogRelateMoudleDataID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogRelateUserID" DataIndex="LogRelateUserID" Header="LogRelateUserID"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogRelateDateTime" DataIndex="LogRelateDateTime" Header="LogRelateDateTime"
                            Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn Header="SystemLogManagement" Width="160">
                            <Commands>
 
                                <ext:GridCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="ViewDetail">
                                    <ToolTip Text="ViewDetail" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemLog"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>"
                        EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
