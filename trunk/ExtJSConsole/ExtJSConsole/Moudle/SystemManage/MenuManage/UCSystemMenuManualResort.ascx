<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuManualResort.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.UCSystemMenuManualResort" %>
<ext:Store ID="storeSubMenu" runat="server" AutoLoad="true" OnRefreshData="storeSubMenu_Refresh">
    <Proxy>
        <ext:DataSourceProxy />
    </Proxy>
    <Reader>
        <ext:JsonReader ReaderID="MenuID">
            <Fields>
                <ext:RecordField Name="MenuID" />
                <ext:RecordField Name="MenuName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <AutoLoadParams>
        <ext:Parameter Name="appID" Mode="Raw" Value="#{cbApplication}.getValue()">
        </ext:Parameter>
    </AutoLoadParams>
</ext:Store>
<ext:Window ID="winSystemMenuManualResort" runat="server" Icon="SortAscending" Title="系统菜单排序"
    Width="420" Height="460" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSystemMenuManualResort" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:Panel ID="Panel1" runat="server">
                        <Body>
                            <ext:FormLayout ID="FormLayout2" runat="server" HideLabel="true" LabelWidth="100">
                                <Anchors>
                                    <ext:Anchor Horizontal="98%">
                                        <ext:Hidden ID="hidPMenuID" runat="server">
                                        </ext:Hidden>
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="98%">
                                        <ext:MultiSelect ID="multiSelectResort" runat="server" DragGroup="grp1" DropGroup="grp1"
                                            DisplayField="MenuName" ValueField="MenuID" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey"
                                            StoreID="storeSubMenu">
                                        </ext:MultiSelect>
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                    </ext:Panel>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnResortSystemMenu" runat="server" Text="保存" Icon="Add">
            <AjaxEvents>
                <Click OnEvent="btnResortSystemMenu_Click" Success="Ext.MessageBox.alert('操作成功', '成功的对系统菜单进行了排序。',callback);function callback(id) { RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuManualResort}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
