<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserSelector.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.DataSelector.UserSelector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:Store ID="storeSystemUser" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSystemUser_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Reader>
            <ext:JsonReader IDProperty="UserID">
                <Fields>
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="UserEmail" />
                    <ext:RecordField Name="UserPassword" />
                    <ext:RecordField Name="UserStatus" />
                    <ext:RecordField Name="UserCreateDate" Type="Date" />
                    <ext:RecordField Name="UserType" />
                    <ext:RecordField Name="PasswordFormat" Type="int" />
                    <ext:RecordField Name="Comments" />
                    <ext:RecordField Name="IsApproved" Type="Boolean" />
                    <ext:RecordField Name="IsLockedOut" Type="Boolean" />
                    <ext:RecordField Name="LastActivityDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="storeSelectedUsers" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="UserID">
                <Fields>
                    <ext:RecordField Name="UserID" Type="int" />
                    <ext:RecordField Name="UserLoginID" />
                    <ext:RecordField Name="UserName" />
                    <ext:RecordField Name="UserEmail" />
                    <ext:RecordField Name="UserPassword" />
                    <ext:RecordField Name="UserStatus" />
                    <ext:RecordField Name="UserCreateDate" Type="Date" />
                    <ext:RecordField Name="UserType" />
                    <ext:RecordField Name="PasswordFormat" Type="int" />
                    <ext:RecordField Name="Comments" />
                    <ext:RecordField Name="IsApproved" Type="Boolean" />
                    <ext:RecordField Name="IsLockedOut" Type="Boolean" />
                    <ext:RecordField Name="LastActivityDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">
        function SelectUsers() {

            var gridPanelSystemUser = <%= gridPanelSystemUser.ClientID %>;
            var gridPanelSelectedUser = <%= gridPanelSelectedUser.ClientID %>;
            if (gridPanelSystemUser.hasSelection()) {
                var records = gridPanelSystemUser.selModel.getSelections();
                gridPanelSystemUser.selModel.clearSelections();
                Ext.each(records, function (record) {
                    if(!gridPanelSelectedUser.store.getById(record.data.UserID))
                        gridPanelSelectedUser.store.addSorted(record);
                });
            }
        }


        function ClearSelectUsers() {
            var gridPanelSelectedUser = <%= gridPanelSelectedUser.ClientID %>;
            if (gridPanelSelectedUser.hasSelection()) {
                gridPanelSelectedUser.deleteSelected();
            }
        }
    </script>
    <%--         
            //---Commnon function for drop zones
            var onContainerOver = function (dz, grid, dd, e, data) {
                return dd.grid !== grid ? dz.dropAllowed : dz.dropNotAllowed;
            };

            var onContainerDrop = function (grid, dd, e, data) {
                if (dd.grid !== grid) {
                    Ext.each(data.selections, function (r) {
                        dd.grid.store.remove(r);
                    });
                    grid.store.add(data.selections);
                    return true;
                } else {
                    return false;
                }
            };

            //---grid drag and rop custom text ------------------
            var getDragDropText = function () {
                var buf = [];

                buf.push("<ul>");

                Ext.each(this.getSelectionModel().getSelections(), function (record) {
                    buf.push("<li>" + record.data.Name + "</li>");
                });

                buf.push("</ul>");

                return buf.join("");
            };

            var getRepairXY = function (e, dd) {
                if (this.dragData.selections.length > 0) {
                    var foundItem = dd.grid.store.find('Name', this.dragData.selections[0].data.Name);
                    var myRow = dd.grid.getView().getRow(foundItem);
                    this.invalidRow = myRow;
                    var xy = Ext.fly(myRow).getXY();
                    return xy;
                }
                return false;
            };

            var setDD = function () {
                this.getView().dragZone.getRepairXY = getRepairXY;
            };
    --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="ViewPort1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West MinWidth="175" MaxWidth="400" Split="true" Collapsible="true">
                    <ext:Panel
                        ID="WestPanel"
                        runat="server"
                        Title="查询条件"
                        Width="175"
                        Icon="Find"
                        Layout="Accordion">
                        <Items>
                            <ext:Panel
                                ID="Navigation"
                                runat="server"
                                Title="按照组织查找"
                                Icon="UserHome"
                                Border="false"
                                Padding="6"
                                Html="West" />
                            <ext:Panel
                                ID="Settings"
                                runat="server"
                                Title="按照角色查找"
                                Icon="UserKey"
                                Border="false"
                                Padding="6"
                                Collapsed="True"
                                Html="Some settings in here." />
                            <ext:Panel
                                ID="Panel2"
                                runat="server"
                                Title="按照岗位查找"
                                Icon="UserGrayCool"
                                Border="false"
                                Padding="6"
                                Collapsed="True"
                                Html="Some settings in here." />
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:GridPanel ID="gridPanelSystemUser" runat="server"
                        StoreID="storeSystemUser"
                        StripeRows="true" Title="全部用户" Icon="Group">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:TextField ID="txtSearchName" FieldLabel="User Name" LabelWidth="70" runat="server" EmptyText="[Enter user Name]" />
                                    <ext:Button ID='btnFind' runat="server" Text="<%$ Resources : GlobalResource, msgSearch  %>"
                                        Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSystemUser}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID='btnSelect' runat="server" Text="<%$ Resources : GlobalResource, msgSelect  %>"
                                        Icon="UserGo">
                                        <Listeners>
                                            <Click Handler="SelectUsers();" />
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

                                <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="用户登陆ID"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserName" DataIndex="UserName" Header="用户名"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUserEmail" DataIndex="UserEmail" Header="邮件"
                                    Sortable="true">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemUser"
                                DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>"
                                EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                        </BottomBar>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Center>
                <East Collapsible="False" Split="true" MinWidth="150">
                    <ext:GridPanel ID="gridPanelSelectedUser" runat="server"
                        StoreID="storeSelectedUsers"
                        StripeRows="true" Width="150" Title="所选用户" Icon="Group">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID='btnClearSelect' runat="server" Text="清除所选"
                                       Icon="UserDelete">
                                        <Listeners>
                                            <Click Handler="ClearSelectUsers();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <View>
                            <ext:GridView ForceFit="true" ID="GridView2">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colUserLoginID" DataIndex="UserLoginID" Header="用户登陆ID"
                                    Sortable="true">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server" />
                        </SelectionModel>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </East>
            </ext:BorderLayout>

        </Items>
    </ext:Viewport>

    <%--    <ext:DropZone ID="DropZone1" runat="server" Target="={gridPanelSystemUser.view.scroller.dom}" Group="GridDDGroup" ContainerScroll="true">
        <OnContainerDrop Handler="return onContainerDrop(gridPanelSystemUser, source, e, data);" />
        <OnContainerOver Handler="return onContainerOver(this, gridPanelSystemUser, source, e, data);" />
    </ext:DropZone>

    <ext:DropZone ID="DropZone2" runat="server" Target="={gridPanelSelectedUser.view.scroller.dom}" Group="GridDDGroup" ContainerScroll="true">
        <OnContainerDrop Handler="return onContainerDrop(gridPanelSelectedUser, source, e, data);" />
        <OnContainerOver Handler="return onContainerOver(this, gridPanelSelectedUser, source, e, data);" />
    </ext:DropZone>--%>
</asp:Content>
