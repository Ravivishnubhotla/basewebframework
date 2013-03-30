<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemEmailSettingsListPage.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.EmailSettingManage.SystemEmailSettingsListPage" %>

<%@ Register Src="UCSystemEmailSettingsAdd.ascx" TagName="UCSystemEmailSettingsAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSystemEmailSettingsEdit.ascx" TagName="UCSystemEmailSettingsEdit"
    TagPrefix="uc2" %>
<%@ Register TagPrefix="uc3" Src="UCSystemEmailSettingsTest.ascx" TagName="UCSystemEmailSettingsTest" %>

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
            <%= this.storeSystemEmailSettings.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSystemEmailSettingsAdd.Show( 
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
                                                                            Ext.net.DirectMethods.UCSystemEmailSettingsEdit.Show(id.id,
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
            


                                                                    if (cmd == "cmdTest") {
                                                                        Ext.net.DirectMethods.UCSystemEmailSettingsTest.Show(id.id,
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
			
                                                            if (cmd == "cmdView") {
                                                                Ext.net.DirectMethods.UCSystemEmailSettingsView.Show(id.id,
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
                                                                        Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %> ',
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
    <ext:Store ID="storeSystemEmailSettings" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemEmailSettings_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="EmailSettingID">
                <Fields>
                    <ext:RecordField Name="EmailSettingID" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="Descriprsion" />
                    <ext:RecordField Name="Host" />
                    <ext:RecordField Name="Port" />
                    <ext:RecordField Name="SSL" Type="Boolean" />
                    <ext:RecordField Name="FromEmail" />
                    <ext:RecordField Name="FromName" />
                    <ext:RecordField Name="LoginEmail" />
                    <ext:RecordField Name="LoginPassword" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="IsDefault" Type="Boolean" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemEmailSettingsAdd ID="UCSystemEmailSettingsAdd1" runat="server" />
    <uc2:UCSystemEmailSettingsEdit ID="UCSystemEmailSettingsEdit1" runat="server" />
    <uc3:UCSystemEmailSettingsTest ID="UCSystemEmailSettingsTest1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemEmailSettings" runat="server" StoreID="storeSystemEmailSettings"
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Table">
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
                                    <Click Handler="#{storeSystemEmailSettings}.reload();" />
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
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="<%$ Resources:msgcolName %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colName" DataIndex="Code" Header="<%$ Resources:msgcolCode %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colHost" DataIndex="Host" Header="<%$ Resources:msgcolHost %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colPort" DataIndex="Port" Header="<%$ Resources:msgcolPort %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSSL" DataIndex="SSL" Header="<%$ Resources:msgcolSSL %>" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colFromEmail" DataIndex="FromEmail" Header="<%$ Resources:msgcolFromEmail %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colFromName" DataIndex="FromName" Header="<%$ Resources:msgcolFromName %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLoginEmail" DataIndex="LoginEmail" Header="<%$ Resources:msgcolLoginEmail %>" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="<%$ Resources:msgcolIsEnable %>" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsDefault" DataIndex="IsDefault" Header="<%$ Resources:msgcolIsDefault %>" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="<%$ Resources : GlobalResource, msgManage  %>"
                            Width="80">
                            <Commands>
                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="Mail" CommandName="cmdTest" Text="<%$ Resources : GlobalResource, msgTest  %>">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemEmailSettings"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>" EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
