﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ExtJSConsole.MainPage.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

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

    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" AutoHeight="true" Header="false">
                        <Content>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    管理后台</h1>
                            </div>
                        </Content>
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
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="主题：" />
                                    <ext:ComboBox ID="cbTheme" runat="server" EmptyText="选择主题" Width="80" Editable="false"
                                        TypeAhead="true">
                                        <Items>
                                            <ext:ListItem Text="默认" Value="Default" />
                                            <ext:ListItem Text="灰色" Value="Gray" />
                                            <ext:ListItem Text="暗蓝" Value="Slate" />
                                            <ext:ListItem Text="Access" Value="Access" />                                     
                                        </Items>
                                        <Listeners>
                                            <Select Handler="Ext.net.DirectMethods.GetThemeUrl(
                                                                                                #{cbTheme}.getValue(), {
                                                                        success: function(result) {
                                                                            Ext.net.ResourceMgr.setTheme(result);
                                                                            #{MainTabs}.items.each(function(el) {
                                                                                if (!Ext.isEmpty(el.iframe)) {
                                                                                    el.iframe.dom.contentWindow.Ext.net.ResourceMgr.setTheme(result);
                                                                                }
                                                                            });
                                                                        },
                    eventMask: {
                        showMask: true,
                        msg: '主题更换中...'
                    }
            });" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:Button Icon="UserEdit" Text="个人设置">
                                    </ext:Button>
                                    <ext:Button Icon="UserKey" Text="修改密码">
                                    </ext:Button>
                                    <ext:Button ID="btnExit" Icon="UserGo" Text="注销">
                                        <DirectEvents>
                                            <Click OnEvent="btnExit_Click" Failure="Ext.Msg.show({ 
                            title:   '系统错误', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });" Success="window.location.href='Login.aspx'">
                                                <EventMask ShowMask="true" Msg="注销中..." />
                                                <Confirmation ConfirmRequest="true" Message="确认退出系统？" Title="警告" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </North>
                <South Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="regionFooter" AutoHeight="true" Border="true" Header="false"
                        BodyBorder="false">
                        <Content>
                            <div class="menu south">
                                @ X工作室 2009</div>
                        </Content>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="LeftPanel" runat="server" Title="菜单导航" Width="175" Layout="Accordion">
                        <Items>
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="主工作区" Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="MainTabs" runat="server" ActiveTabIndex="0" Border="false">
                                <Items>
                                    <ext:Panel runat="server" ID="HomeTab" Closable="false" Title="系统首页">
                                        <Content>
                                        </Content>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </Items>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
