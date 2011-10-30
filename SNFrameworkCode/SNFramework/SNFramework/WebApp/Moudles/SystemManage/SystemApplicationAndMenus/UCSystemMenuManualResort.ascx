<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuManualResort.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemMenuManualResort" %>
<script type="text/javascript">
    function SaveNewOrder(vlues, win, stores) {
        Ext.net.DirectMethods.UCSystemMenuManualResort.SaveNewOrder(vlues,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg, RefreshData);
                                                                    },
                                                                    success: function (result) {
                                                                        win.hide();
                                                                        stores.commitChanges();
                                                                        ReloadMenus();
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                    }
                                                                });
                                                            }



                                                            function ShowOrderList() {
                                                                var storeSubMenus = <%= storeSubMenus.ClientID %>;

                                                                storeSubMenus.reload();
                                                            }

</script>
<ext:Store ID="storeSubMenus" runat="server" AutoLoad="true" OnRefreshData="storeSubMenus_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="MenuID">
            <Fields>
                <ext:RecordField Name="MenuID" />
                <ext:RecordField Name="MenuName" />
                <ext:RecordField Name="LocaLocalizationName" />
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
<ext:Window ID="winSystemMenuManualResort" runat="server" Icon="SortAscending" Title="<%$ Resources:msgFormTitle %>"
    Width="300" Height="380" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Layout="fit">
    <Items>
        <ext:Panel ID="pnlSortItems" Title="<%$ Resources:msgGridmTitle %>" Layout="fit">
            <Content>
                <ext:MultiSelect ID="MultiSelect1" runat="server" StoreID="storeSubMenus" DisplayField="LocaLocalizationName"
                    ValueField="MenuID" DragGroup="grp1" DropGroup="grp1,grp1" KeepSelectionOnClick="WithCtrlKey"
                    AutoScroll="true">
                </ext:MultiSelect>
            </Content>
        </ext:Panel>
    </Items>
    <Buttons>
        <ext:Button ID="btnResortSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="BulletTick">
            <Listeners>
                <Click Handler="SaveNewOrder(Ext.encode(#{MultiSelect1}.getValues()),#{winSystemMenuManualResort},#{storeSubMenus});" />
            </Listeners>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="BulletCross">
            <Listeners>
                <Click Handler="#{winSystemMenuManualResort}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Hidden ID="hidSortPMenuID" runat="server">
</ext:Hidden>
<ext:Hidden ID="hidSortAppID" runat="server">
</ext:Hidden>
