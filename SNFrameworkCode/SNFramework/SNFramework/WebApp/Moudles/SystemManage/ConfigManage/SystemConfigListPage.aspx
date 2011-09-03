<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemConfigListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.SystemConfigListPage" %>

<%@ Register Src="UCSystemConfigAdd.ascx" TagName="UCSystemConfigAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemConfigEdit.ascx" TagName="UCSystemConfigEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSystemConfigGroup}.reload();#{storeDictionarySystemDataType}.reload();">
            </DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemConfig.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemConfigAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemConfigEdit.Show(id.id,
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

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>
    <ext:Store ID="storeSystemConfig" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemConfig_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemConfigID">
                <Fields>
                    <ext:RecordField Name="SystemConfigID" Type="int" />
                    <ext:RecordField Name="GroupName" />
                    <ext:RecordField Name="ConfigKey" />
                    <ext:RecordField Name="ConfigValue" />
                    <ext:RecordField Name="ConfigDataTypeName" />
                    <ext:RecordField Name="ConfigDescription" />
                    <ext:RecordField Name="SortIndex" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="storeSystemConfigGroup" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemConfigGroup_Refresh">
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
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="IsSystem" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemConfigAdd ID="UCSystemConfigAdd1" runat="server" />
    <uc2:UCSystemConfigEdit ID="UCSystemConfigEdit1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemConfig" runat="server" StoreID="storeSystemConfig"
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Cog">
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
                                    <Click Handler="#{storeSystemConfig}.reload();" />
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
                        <ext:Column ColumnID="colConfigDictionaryGroupName" DataIndex="GroupName" Header="配置组"
                            Sortable="false">
                        </ext:Column>
                        <ext:Column ColumnID="colConfigKey" DataIndex="ConfigKey" Header="<%$ Resources:msgcolKey %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colConfigValue" DataIndex="ConfigValue" Header="<%$ Resources:msgcolValue %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colConfigDescription" DataIndex="ConfigDescription" Header="<%$ Resources:msgcolDescription %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colConfig_DataType" DataIndex="ConfigDataTypeName" Header="数据类型"
                            Sortable="false">
                        </ext:Column>
                        <ext:CommandColumn Header="<%$ Resources : GlobalResource, msgManage  %>" Width="160">
                            <Commands>
                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                    <ToolTip Text="<%$ Resources : GlobalResource, msgEdit  %>" />
                                </ext:GridCommand>
                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                    <ToolTip Text="<%$ Resources : GlobalResource, msgDelete  %>" />
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemConfig"
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
