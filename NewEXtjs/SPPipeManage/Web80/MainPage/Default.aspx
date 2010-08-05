<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Legendigital.Common.Web.MainPage.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>

    <script type="text/javascript">
        var loadPage = function(mtab, node) {
            if (node.attributes.isCategory != "False" && node.attributes.isCategory != null)
                return;
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
                <North Split="true" Collapsible="true">
                    <ext:Panel ID="regionHeader" AutoHeight="true" Header="false">
                        <Body>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    <asp:Localize ID="locSystemName" runat="server"></asp:Localize></h1>
                            </div>
                        </Body>
                        <BottomBar>
                            <ext:Toolbar>
                                <Items>
                                    <ext:ToolbarTextItem Text="欢迎">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblUser" Text="<b>Super Admin</b>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblToday" Text="2008-1-1">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarFill>
                                    </ext:ToolbarFill>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="主题：" />
                                    <ext:ComboBox ID="cbTheme" runat="server" EmptyText="选择主题" Width="80" Editable="false"
                                        TypeAhead="true" SelectedIndex="0">
                                        <Items>
                                            <ext:ListItem Text="Default" Value="Default" />
                                            <ext:ListItem Text="Gray" Value="Gray" />
                                            <ext:ListItem Text="Slate" Value="Slate" />
                                            <ext:ListItem Text="Access" Value="Access" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="Coolite.AjaxMethods.GetThemeUrl(
                                                                                                #{cbTheme}.getValue(), {
                                                                        success: function(result) {
                                                                            Coolite.Ext.setTheme(result);
                                                                            #{MainTabs}.items.each(function(el) {
                                                                                if (!Ext.isEmpty(el.iframe)) {
                                                                            if(!Ext.isEmpty(el.iframe.dom.contentWindow.Coolite)) 
                                                                            { 
                                                                                el.iframe.dom.contentWindow.Coolite.Ext.setTheme(result); 
                                                                            } 
                                                                                }
                                                                            });
                                                                        },
                    eventMask: {
                        showMask: true,
                        msg: '主题更换中 ...'
                    }
            });" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarButton Icon="UserKey" Text="更改密码">
                                        <Listeners>
                                            <Click Handler="#{winChangePassword}.show();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID="btnExit" Icon="UserGo" Text="注销">
                                        <AjaxEvents>
                                            <Click OnEvent="btnExit_Click" Failure="Ext.Msg.show({ 
                            title:   '系统错误', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });" Success="window.location.href='Login.aspx'">
                                                <EventMask ShowMask="true" Msg="注销中..." />
                                                <Confirmation ConfirmRequest="true" Message="确认注销用户？" Title="警告" />
                                            </Click>
                                        </AjaxEvents>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </North>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="Panel1" runat="server" Title="菜单导航" Width="175">
                        <Body>
                            <ext:Accordion ID="LeftPanel" runat="server" Animate="true">
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
                                                <ext:FitLayout ID="FitLayout2" runat="server">
<%--                                                    <ext:Portal ID="Portal1" runat="server" Border="false">
                                                        <Listeners>
                                                            <Drop Handler="e.panel.el.frame();" />
                                                        </Listeners>
                                                        <Body>
                                                            <ext:ColumnLayout ID="ColumnLayout1" runat="server">
                                                                <ext:LayoutColumn ColumnWidth=".33">
                                                                    <ext:PortalColumn ID="PortalColumn1" runat="server" StyleSpec="padding:10px 0 10px 10px">
                                                                        <Body>
                                                                            <ext:AnchorLayout ID="AnchorLayout1" runat="server">
                                                                                <ext:Anchor>
                                                                                    <ext:Portlet ID="Portlet1" runat="server" Title="今日数据统计">
                                                                                        <Tools>
                                                                                            <ext:Tool Type="Gear" Qtip="设置" />
                                                                                            <ext:Tool Type="Close" Qtip="关闭" Handler="this.close();" />
                                                                                        </Tools>
                                                                                    </ext:Portlet>
                                                                                </ext:Anchor>
                                                                                <ext:Anchor>
                                                                                    <ext:Portlet ID="Portlet5" runat="server" Title="系统公告">
                                                                                        <Tools>
                                                                                            <ext:Tool Type="Gear" Qtip="设置" />
                                                                                            <ext:Tool Type="Close" Qtip="关闭" Handler="this.close();" />
                                                                                        </Tools>
                                                                                    </ext:Portlet>
                                                                                </ext:Anchor>
                                                                            </ext:AnchorLayout>
                                                                        </Body>
                                                                    </ext:PortalColumn>
                                                                </ext:LayoutColumn>
                                                                <ext:LayoutColumn ColumnWidth=".33">
                                                                    <ext:PortalColumn ID="PortalColumn2" runat="server" StyleSpec="padding:10px 0 10px 10px">
                                                                        <Body>
                                                                            <ext:AnchorLayout ID="AnchorLayout2" runat="server">
                                                                                <ext:Anchor>
                                                                                    <ext:Portlet ID="Portlet2" runat="server" Title="失败请求监控">
                                                                                        <Tools>
                                                                                            <ext:Tool Type="Gear" Qtip="设置" />
                                                                                            <ext:Tool Type="Close" Qtip="关闭" Handler="this.close();" />
                                                                                        </Tools>
                                                                                    </ext:Portlet>
                                                                                </ext:Anchor>
                                                                                <ext:Anchor>
                                                                                    <ext:Portlet ID="Portlet3" runat="server" Title="系统错误监控">
                                                                                        <Tools>
                                                                                            <ext:Tool Type="Gear" Qtip="设置" />
                                                                                            <ext:Tool Type="Close" Qtip="关闭" Handler="this.close();" />
                                                                                        </Tools>
                                                                                    </ext:Portlet>
                                                                                </ext:Anchor>
                                                                            </ext:AnchorLayout>
                                                                        </Body>
                                                                    </ext:PortalColumn>
                                                                </ext:LayoutColumn>
                                                                <ext:LayoutColumn ColumnWidth=".33">
                                                                    <ext:PortalColumn ID="PortalColumn3" runat="server" StyleSpec="padding:10px">
                                                                        <Body>
                                                                            <ext:AnchorLayout ID="AnchorLayout3" runat="server">
                                                                                <ext:Anchor>
                                                                                    <ext:Portlet ID="Portlet4" runat="server" Title="系统运行状态">
                                                                                        <Tools>
                                                                                            <ext:Tool Type="Gear" Qtip="设置" />
                                                                                            <ext:Tool Type="Close" Qtip="关闭" Handler="this.close();" />
                                                                                        </Tools>
                                                                                    </ext:Portlet>
                                                                                </ext:Anchor>
                                                                            </ext:AnchorLayout>
                                                                        </Body>
                                                                    </ext:PortalColumn>
                                                                </ext:LayoutColumn>
                                                            </ext:ColumnLayout>
                                                        </Body>
                                                    </ext:Portal>--%>
                                                </ext:FitLayout>
                                            </Body>
                                        </ext:Tab>
                                    </Tabs>
                                </ext:TabPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </Center>
                <South Split="true" Collapsible="true">
                    <ext:Panel ID="regionFooter" AutoHeight="true" Border="true" Header="false" BodyBorder="false">
                        <Body>
                            <div class="menu south">
                                <asp:Localize ID="locCopyRight" runat="server"></asp:Localize></div>
                        </Body>
                    </ext:Panel>
                </South>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
