<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BaiduMapSearch._Default" %>

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
                    <ext:Panel runat="server" ID="regionHeader"  Height="60" Header="false">
                        <Content>
                            <div id='headerDiv'>
                                <a style='float: left; margin-right: 10px;' href='#' target='_blank'>
                                    <img alt=''  src='images/maplogo.png' /></a> 
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
                    <ext:TreePanel ID="TreePanel1" runat="server" Width="135" Icon="BookOpen"
                        Title="Baidu地图API" AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="Button1" runat="server" Text="展开所有">
                                        <Listeners>
                                            <Click Handler="#{TreePanel1}.expandAll();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button2" runat="server" Text="收起所有">
                                        <Listeners>
                                            <Click Handler="#{TreePanel1}.collapseAll();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Root>
                            <ext:TreeNode Text="地图示例" Expanded="true" IsTarget="false">
                                <Nodes>
                                    <ext:TreeNode Text="普通地图" Icon="MapLink" Href="MapSamples/ShowMap.aspx" />
                                    <ext:TreeNode Text="高级地图" Icon="MapLink" Href="MapSamples/AdvanceShowMap.aspx" />
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
                    <ext:Panel ID="Panel2" runat="server" Title="主工作区" Layout="Fit">
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
