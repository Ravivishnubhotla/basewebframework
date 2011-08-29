<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GmapApplication.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <script type="text/javascript">
        var loadPage = function (mtab, node) {
            if (node.attributes.IsTarget == "False")
                return;

            mtab.removeAll();

            createTab(mtab, node);
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
                    maskMsg: 'Loading...',
                    scripts: true,
                    mode: "iframe",
                    url: taburl
                },
                closable: true
            }));
            mtab.setActiveTab(tab);
        }
    </script>
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" AutoHeight="true" Header="false">
                        <Content>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    Google map samples</h1>
                            </div>
                        </Content>
                    </ext:Panel>
                </North>
                <South Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="regionFooter" AutoHeight="true" Border="true" Header="false"
                        BodyBorder="false">
                        <Content>
                            <div class="menu south">
                                <asp:Localize ID="locCopyRight" runat="server"></asp:Localize></div>
                        </Content>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:TreePanel ID="TreePanel1" runat="server" Width="300" Height="450" Icon="BookOpen"
                        Title="Samples" AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="Button1" runat="server" Text="Expand All">
                                        <Listeners>
                                            <Click Handler="#{TreePanel1}.expandAll();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button2" runat="server" Text="Collapse All">
                                        <Listeners>
                                            <Click Handler="#{TreePanel1}.collapseAll();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Root>
                            <ext:TreeNode Text="入门例子" Expanded="true" IsTarget="false">
                                <Nodes>
                                    <ext:TreeNode Text="显示地图" Icon="MapLink" Href="Samples/FirstMap.aspx" />
                                    <ext:TreeNode Text="地址校正" Icon="MapLink" Href="LocationApp/AddAddress.aspx" />
                                    <ext:TreeNode Text="路径计算" Icon="MapLink" Href="Distance/DistanceQuery.aspx" />
                                    <ext:TreeNode Text="进度条操作" Icon="ClockGo" Href="LogAction/StartLongAction.aspx" />
                                    <ext:TreeNode Text="PDF查看" Icon="PagePortrait" Href="PDFViewer/PDFManage.aspx" />
                                </Nodes>
                            </ext:TreeNode>
                        </Root>
                        <BottomBar>
                            <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                        </BottomBar>
                        <Listeners>
                            <Click Handler="e.stopEvent();loadPage(#{MainTabs},node);" />
                        </Listeners>
                    </ext:TreePanel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="Main Area" Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="MainTabs" runat="server" Border="false">
                                <Items>
                                </Items>
                            </ext:TabPanel>
                        </Items>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
