<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemLogViewList.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.LogManage.SystemLogViewList" %>
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
                AutoExpandColumn="colLogDescrption" Title="<%$ Resources:msgGridTitle %>" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:DateField ID="dfStart" runat="server" />
                            <ext:Button ID="Button1" runat="server" Text="-" />
                            <ext:DateField ID="dfEnd" runat="server" />
                            <ext:Button ID='btnFind' runat="server" Text="<%$ Resources : GlobalResource, msgSearch  %>"
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
                        <ext:Column ColumnID="colLogLevel" DataIndex="LogLevel" Header="<%$ Resources:msgcolLogLevel %>"
                            Width="16" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogDate" DataIndex="LogDate" Header="<%$ Resources:msgcolLogDate %>"
                            Width="39" Sortable="true">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y h:i:s')" />
                        </ext:Column>
                        <ext:Column ColumnID="colLogUser" DataIndex="LogUser" Header="<%$ Resources:msgcolLogUser %>"
                            Width="50" Sortable="true" Hidden="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLogDescrption" DataIndex="LogDescrption" Header="<%$ Resources:msgcolLogDescrption %>"
                            Sortable="true">
                        </ext:Column>
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
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:ToolTip ID="RowTip" runat="server" Target="={#{gridPanelSystemLog}.getView().mainBody}"
        Delegate=".x-grid3-row" TrackMouse="true">
        <Listeners>
            <Show Handler="var rowIndex = #{gridPanelSystemLog}.view.findRowIndex(this.triggerElement);this.body.dom.innerHTML = '  ' + #{storeSystemLog}.getAt(rowIndex).get('LogDescrption');" />
        </Listeners>
    </ext:ToolTip>
</asp:Content>
