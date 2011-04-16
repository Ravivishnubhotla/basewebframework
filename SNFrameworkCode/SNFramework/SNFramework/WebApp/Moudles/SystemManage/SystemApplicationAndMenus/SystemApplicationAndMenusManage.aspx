<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationAndMenusManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.SystemApplicationAndMenusManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" RemotePaging="true"
        RemoteSort="true" OnRefreshData="storeSystemApplication_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationCode" />
                    <ext:RecordField Name="LocaLocalizationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{GridPanel1}.getSelectionModel().selectFirstRow();" />
        </Listeners>
    </ext:Store>
    <script type="text/javascript">
        var FormatBool = function (value) {
            if (value)
                return '是';
            else
                return '否';
        }
    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Frame="true" Title="应用菜单管理">
                <Items>
                    <ext:BorderLayout ID="BorderLayout1" runat="server">
                        <West Split="true" Collapsible="true">
                            <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true"
                                Title="系统应用管理" Width="390" Frame="true" AutoScroll="true" AutoExpandColumn="colLocaLocalizationName">
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ColumnID="colLocaLocalizationName" Header="名称" Width="80" Sortable="true"
                                            DataIndex="LocaLocalizationName" />
                                        <ext:Column ColumnID="colSystemApplicationCode" Header="编码" Width="120" Sortable="true"
                                            DataIndex="SystemApplicationCode" />
                                        <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="系统应用" Width="65">
                                            <Renderer Fn="FormatBool" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        <DirectEvents>
                                            <RowSelect OnEvent="RowSelect" Buffer="100">
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{TreePanel1}" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="RecordID" Value="this.getSelected().id" Mode="Raw" />
                                                </ExtraParams>
                                            </RowSelect>
                                        </DirectEvents>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10" StoreID="storeSystemApplication" />
                                </BottomBar>
                            </ext:GridPanel>
                        </West>
                        <Center>
                            <ext:TreePanel ID="TreePanel1" runat="server" Title="菜单管理" AutoScroll="true" Frame="true" RootVisible=false>
                                <Root>
                                    <ext:TreeNode Text="Root" Expanded="true">
                                        <Nodes>
                                            <ext:TreeNode Text="Folder 1" Qtip="Rows dropped here will be appended to the folder">
                                                <Nodes>
                                                    <ext:TreeNode Text="Subleaf 1" Qtip="Subleaf 1 Quick Tip" Leaf="true" />
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Folder 2" Qtip="Rows dropped here will be appended to the folder">
                                                <Nodes>
                                                    <ext:TreeNode Text="Subleaf 2" Qtip="Subleaf 2 Quick Tip" Leaf="true" />
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Leaf 1" Qtip="Leaf 1 Quick Tip" Leaf="true" />
                                        </Nodes>
                                    </ext:TreeNode>
                                </Root>
                            </ext:TreePanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
