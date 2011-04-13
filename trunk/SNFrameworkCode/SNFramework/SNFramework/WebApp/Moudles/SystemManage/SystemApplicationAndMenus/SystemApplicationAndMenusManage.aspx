<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationAndMenusManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.SystemApplicationAndMenusManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel2" runat="server" Title="系统应用管理" Region="West" Layout="border"
                Width="300" Split="true">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Title="Settings" Border="false" Region="Center"
                        Padding="6" Icon="FolderWrench" Layout="fit">
                        <Items>
                            <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true"
                                Title="System Application" Icon="Table" AutoExpandColumn="colSystemApplicationDescription">
                                <TopBar>
                                    <ext:Toolbar ID="tbTop" runat="server">
                                        <Items>
                                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="ApplicationAdd">
                                                <Listeners>
                                                    <Click Handler="showAddForm();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                                <Listeners>
                                                    <Click Handler="#{storeSystemApplication}.reload();" />
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
                                        <ext:Column DataIndex="SystemApplicationName" Header="Name" Sortable="true">
                                        </ext:Column>
                                        <ext:Column ColumnID="colSystemApplicationDescription" DataIndex="SystemApplicationDescription"
                                            Header="Description">
                                        </ext:Column>
                                        <ext:Column DataIndex="SystemApplicationUrl" Header="Url">
                                        </ext:Column>
                                        <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="System Application"
                                            Width="80">
                                            <Renderer Fn="FormatBool" />
                                        </ext:Column>
                                        <ext:CommandColumn Width="60">
                                            <Commands>
                                                <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit">
                                                    <ToolTip Text="Edit" />
                                                </ext:GridCommand>
                                                <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete">
                                                    <ToolTip Text="Delete" />
                                                </ext:GridCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemApplication"
                                        DisplayInfo="true" DisplayMsg="Displaying records {0} - {1} total: {2}" EmptyMsg="No matched record" />
                                </BottomBar>
                                <Listeners>
                                    <Command Handler="processcmd(command, record);" />
                                </Listeners>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel4" runat="server" Title="Settings" Border="false" Region="South"
                        Padding="6" Icon="FolderWrench" Html="Some settings in here" />
                </Items>
            </ext:Panel>
            <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Title="菜单管理" Border="false" Padding="6" Html="<h1>Viewport with BorderLayout</h1>" />
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
