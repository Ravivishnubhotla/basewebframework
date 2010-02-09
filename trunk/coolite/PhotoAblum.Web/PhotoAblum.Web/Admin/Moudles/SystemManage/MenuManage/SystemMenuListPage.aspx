<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Masters/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="SystemMenuListPage.aspx.cs" Inherits="PhotoAblum.Web.Admin.Moudles.SystemManage.MenuManage.SystemMenuListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="添加节点" Icon="Add">
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
                                <ext:TreePanel ID="TreePanel1" runat="server" Header="false" AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar ID="ToolBar1" runat="server">
                                            <Items>
                                                <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="系统应用： " />
                                                <ext:ComboBox ID="cbTheme" runat="server" EmptyText="选择系统应用" Width="75" Editable="false"
                                                    SelectedIndex="0" TypeAhead="true">
                                                    <Items>
                                                        <ext:ListItem Text="Default" Value="Default" />
                                                        <ext:ListItem Text="Gray" Value="Gray" />
                                                        <ext:ListItem Text="Slate" Value="Slate" />
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                <ext:ToolbarButton ID="ToolbarButton1" runat="server" Icon="ApplicationDouble">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.expandAll();" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip1" IDMode="Ignore" runat="server" Html="Expand All" />
                                                    </ToolTips>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton2" runat="server" Icon="Anchor">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.collapseAll();" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip2" IDMode="Ignore" runat="server" Html="Collapse All" />
                                                    </ToolTips>
                                                </ext:ToolbarButton>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                        <ext:TreeNode Text="系统菜单" Expanded="true">
                                            <Nodes>
                                                <ext:TreeNode Text="相册程序维护管理" Expanded="true">
                                                    <Nodes>
                                                        <ext:TreeNode Text="相册管理">
                                                        </ext:TreeNode>
                                                    </Nodes>
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="系统管理" Expanded="true">
                                                    <Nodes>
                                                        <ext:TreeNode Text="应用管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="菜单管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="角色管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="用户管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="部门管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="用户管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="权限管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="日志管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="字典管理">
                                                        </ext:TreeNode>
                                                        <ext:TreeNode Text="权限管理">
                                                        </ext:TreeNode>
                                                    </Nodes>
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:TreeNode>
                                    </Root>
                                    <BottomBar>
                                        <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                    </BottomBar>
                                    <Listeners>
                                     <ContextMenu  Handler="#{cmenu}.showAt(e.getPoint());" />

                                        <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '</b>', clear: true});" />
                                        <ExpandNode Handler="#{StatusBar1}.setStatus({text: 'Node Expanded: <b>' + node.text + '</b>', clear: true});"
                                            Delay="30" />
                                        <CollapseNode Handler="#{StatusBar1}.setStatus({text: 'Node Collapsed: <b>' + node.text + '</b>', clear: true});" />
                                    </Listeners>
                                </ext:TreePanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:FormPanel ID="FormPanel1" runat="server" Title="菜单设置" Frame="true" ButtonAlign="Right">
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
    </ext:ViewPort>
</asp:Content>
