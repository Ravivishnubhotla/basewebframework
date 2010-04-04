<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuManualResort.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.UCSystemMenuManualResort" %>

<script type="text/javascript">
    function SaveNewOrder(vlues, win, stores) {
        Ext.net.DirectMethods.UCSystemMenuManualResort.SaveNewOrder(vlues,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshData);
                                                                    },
                                                                    success: function(result) {
                                                                        win.hide();
                                                                        stores.commitChanges();
                                                                        RefreshTreeList1();
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '数据保存中...'
                                                                    }
                                                                });
    }

</script>

<ext:Store ID="storeSubMenus" runat="server" AutoLoad="true" OnRefreshData="storeSubMenus_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="MenuID">
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
    Width="300" Height="380" AutoShow="false" Maximizable="true" Modal="true"  Hidden=true
    ConstrainHeader="true">
    <Items>
        <ext:Panel ID="pnlSortItems" Title="子菜单">
            <Content>
                <ext:MultiSelect ID="MultiSelect1" runat="server" AutoWidth="true" AutoHeight="true"
                    StoreID="storeSubMenus" DisplayField="MenuName" ValueField="MenuID" DragGroup="grp1"
                    DropGroup="grp1,grp1" KeepSelectionOnClick="WithCtrlKey">
                </ext:MultiSelect>
                <ext:Hidden ID="hidSortPMenuID" runat=server></ext:Hidden>
                <ext:Hidden ID="hidSortAppID" runat=server></ext:Hidden>
            </Content>
        </ext:Panel>
    </Items>
    <Buttons>
        <ext:Button ID="btnResortSystemMenu" runat="server" Text="保存" Icon="BulletTick">
            <Listeners>
                <Click Handler="SaveNewOrder(Ext.encode(#{MultiSelect1}.getValues()),#{winSystemMenuManualResort},#{storeSubMenus});" />
            </Listeners>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="取消" Icon="BulletCross">
            <Listeners>
                <Click Handler="#{winSystemMenuManualResort}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
