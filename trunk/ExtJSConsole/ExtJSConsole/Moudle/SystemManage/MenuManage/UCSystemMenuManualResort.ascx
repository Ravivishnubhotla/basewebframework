<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuManualResort.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.UCSystemMenuManualResort" %>
<ext:Store ID="storeSubMenus" runat="server" AutoLoad="true" OnRefreshData="storeSubMenus_Refresh">
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
        <ext:Parameter Name="ParentMenuID" Value="-1" Mode="Raw">
        </ext:Parameter>
        <ext:Parameter Name="AppID" Value="-1" Mode="Raw">
        </ext:Parameter>
    </AutoLoadParams>
</ext:Store>
<ext:Window ID="winSystemMenuManualResort" runat="server" Icon="SortAscending" Title="系统菜单排序"
    Width="300" Height="380" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false"
    ConstrainHeader="true">
    <Body>
        <ext:ColumnLayout ID="ColumnLayout1" runat="server" FitHeight="true">
            <ext:LayoutColumn ColumnWidth="1.0">
                <ext:Panel ID="pnlSortItems" Title="子菜单">
                    <Body>
                        <ext:MultiSelect ID="MultiSelect1" runat="server" AutoWidth="true" AutoHeight="true"
                            StoreID="storeSubMenus" DisplayField="MenuName" ValueField="MenuID" DragGroup="grp1"
                            DropGroup="grp1,grp1" KeepSelectionOnClick="WithCtrlKey">
                        </ext:MultiSelect>
                    </Body>
                </ext:Panel>
            </ext:LayoutColumn>
        </ext:ColumnLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnResortSystemMenu" runat="server" Text="保存" Icon="BulletTick">
            <AjaxEvents>
                <Click OnEvent="btnResortSystemMenu_Click" Before="#{MultiSelect1}.get();" Success="Ext.MessageBox.alert('操作成功', '成功的对系统菜单进行了排序。',callback);function callback(id) { RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                    <ExtraParams>
                        <ext:Parameter Name="SubMitValues" Value="1" Mode="Raw">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="取消" Icon="BulletCross">
            <Listeners>
                <Click Handler="#{winSystemMenuManualResort}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
