<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Masters/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoAblum.Web.Admin.MainPage.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var loadPage = function(mtab, node) {
            var tab = mtab.getComponent(node.id);

            if (tab) {
                mtab.setActiveTab(tab);
            } else {
                createTab(mtab, node);
            }
        }
        function createTab(mtab, node) {

            var tabid = node.id;
            var taburl = node.attributes.href;
            var tabname = node.text;

            var tab = mtab.add(new Ext.Panel({
                id: tabid,
                title: tabname,
                autoLoad: {
                showMask: true,
                    maskMsg: '加载中...',
                    scripts: true,
                    mode: "iframe",
                    url: taburl
                },
                closable: true
            }));
            mtab.setActiveTab(tab);
        }
    </script>

    <ext:ViewPort ID="ViewPort1" runat="server">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" AutoHeight="true" Header="false">
                        <Body>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    管理后台</h1>
                            </div>
                        </Body>
                        <BottomBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="欢迎">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblUser" Text="<b>超级管理员</b>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblToday" Text="今天是2008年1月1日">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarFill>
                                    </ext:ToolbarFill>
                                    <ext:Button Icon="UserEdit" Text="个人设置">
                                    </ext:Button>
                                    <ext:Button Icon="UserKey" Text="修改密码">
                                    </ext:Button>
                                    <ext:Button ID="btnExit" OnClick="btnExit_Click" AutoPostBack="true" Icon="UserGo"
                                        Text="注销">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </North>
                <South Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="regionFooter" AutoHeight="true" Border="true" Header="false"
                        BodyBorder="false">
                        <Body>
                            <div class="menu south">
                                @ X工作室 2009</div>
                        </Body>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="Panel1" runat="server" Title="菜单导航" Width="175">
                        <Body>
                            <ext:Accordion ID="leftAccordion" runat="server" Animate="true">
                            </ext:Accordion>
                        </Body>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="主工作区">
                        <Body>
                            <ext:FitLayout ID="FitLayout1" runat="server">
                                <ext:TabPanel ID="MainTabs" runat="server" ActiveTabIndex="0" Border="false">
                                    <Tabs>
                                        <ext:Tab runat="server" ID="HomeTab" Closable="false" Title="系统首页">
                                            <Body>
                                            </Body>
                                        </ext:Tab>
                                    </Tabs>
                                </ext:TabPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
