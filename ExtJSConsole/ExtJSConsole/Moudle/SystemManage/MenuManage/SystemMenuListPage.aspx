<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemMenuListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.SystemMenuListPage" %>

<%@ Register Src="UCSystemMenuAdd.ascx" TagName="UCSystemMenuAdd" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" OnRefreshData="storeSystemApplication_Refresh">
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="SystemApplicationID">
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
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>

    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="添加子节点" Icon="Add">
                <Listeners>
                    <Click Handler="#{winSystemMenuAdd}.show();"   />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="修改节点" Icon="Anchor">
            </ext:MenuItem>
            <ext:MenuItem ID="moveItems" runat="server" Text="删除节点" Icon="Delete">
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West MinWidth="300" MaxWidth="500" Split="true" Collapsible="true">
                    <ext:Panel ID="WestPanel" runat="server" Title="系统菜单管理" Width="300">
                        <Body>
                            <ext:FitLayout ID="FitLayout1" runat="server">
                                <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                    AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar ID="ToolBar1" runat="server">
                                            <Items>
                                                <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="所属系统应用： " />
                                                <ext:ComboBox ID="cbApplication" runat="server" EmptyText="选择系统应用" AutoWidth="true"
                                                    Editable="false" TypeAhead="true" StoreID="storeSystemApplication" DisplayField="SystemApplicationName"
                                                    ValueField="SystemApplicationID" ForceSelection="true" SelectOnFocus="true">
                                                    <Listeners>
                                                        <Select Handler="Coolite.AjaxMethods.GetTreeNodes(
                                                                                                            #{cbApplication}.getValue(), 
                                                                                                            { 
                                                                                                                success: function(result) { 
                                                                                                                            var nodes = eval(result);
                                                                                                                            #{TreePanel1}.root.ui.remove();
                                                                                                                            #{TreePanel1}.initChildren(nodes);
                                                                                                                            #{TreePanel1}.root.render();
                                                                                                                            },
                                                                                                                eventMask: {
                                                                                                                            showMask: true,
                                                                                                                            msg: '正在加载菜单......'
                                                                                                                           }
                                                                                                             }
                                                                                                          );" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                <ext:ToolbarButton ID="ToolbarButton1" runat="server" Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="Coolite.AjaxMethods.UCSystemMenuAdd.Show(#{cbApplication}.getValue(),'',
                                                                                                                { 
                                                                                                                eventMask: {
                                                                                                                            showMask: true,
                                                                                                                            msg: '加载中......'
                                                                                                                           }
                                                                                                                 }
                                                                                                                                               
                                                                                                                 );" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                        <ext:TreeNode Text="系统菜单" Expanded="true" Icon="Folder">
                                        </ext:TreeNode>
                                    </Root>
                                    <BottomBar>
                                        <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                    </BottomBar>
                                    <Listeners>
                                        <ContextMenu Handler="#{cmenu}.showAt(e.getPoint());" />
                                        <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '</b>', clear: true});#{FormPanel1}.show();" />
                                    </Listeners>
                                </ext:TreePanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:FormPanel ID="FormPanel1" runat="server" Title="菜单设置" Frame="true" ButtonAlign="Right"
                        Hidden="true">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="TextField1" DataIndex="pctChange" runat="server" FieldLabel="父菜单" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="CompanyField" DataIndex="company" runat="server" FieldLabel="菜单名" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="PriceField" DataIndex="price" runat="server" FieldLabel="菜单描述" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="ChangeField" DataIndex="change" runat="server" FieldLabel="菜单链接" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="PctChangeField" DataIndex="pctChange" runat="server" FieldLabel="菜单图标" />
                                </ext:Anchor>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="Button3" runat="server" Text="修改">
                            </ext:Button>
                            <ext:Button ID="Button6" runat="server" Text="删除">
                            </ext:Button>
                            <ext:Button ID="Button2" runat="server" Text="添加子菜单">
                            </ext:Button>
                            <ext:Button ID="Button1" runat="server" Text="子类手动排序">
                            </ext:Button>
                            <ext:Button ID="Button4" runat="server" Text="子类自动排序">
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>    <uc1:UCSystemMenuAdd ID="UCSystemMenuAdd1" runat="server" />
</asp:Content>
