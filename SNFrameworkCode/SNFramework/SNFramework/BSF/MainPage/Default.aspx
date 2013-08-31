<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SNFramework.BSF.MainPage.Default" %>

<%@ Register Src="UCChangePassword.ascx" TagName="UCChangePassword" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var loadPage = function (mtab, node) {
            if (node.attributes.isCategory != "False" && node.attributes.isCategory != null)
                return;
            
            var navPath = node.attributes.navPath;

            var tab = mtab.getComponent(node.id);

            if (tab) {
                mtab.setActiveTab(tab);
            } else {
                createTab(mtab, node);
            }
            
            var currentLocation = <%= currentLocation.ClientID %>;

            currentLocation.setText(navPath);
        };
        function createTab(mtab, node) {

            var tabid = node.id;
            var taburl = node.attributes.href;
            var tabname = node.text;

            var tab = mtab.add(new Ext.Panel({
                id: tabid,
                title: tabname,
                iconCls: node.attributes.iconCls,
                autoLoad: {
                    showMask: true,
                    maskMsg: '<%= GetLocalResourceObject("msgLoadingText").ToString() %>',
                    scripts: true,
                    mode: "iframe",
                    url: taburl
                },
                tabTip:node.attributes.navPath,
                closable: true
            }));
            
 
            mtab.setActiveTab(tab);
        }

        function ShowError(etitle, emessage) {
            Ext.Msg.show({
                title: etitle,
                msg: emessage,
                buttons: Ext.Msg.OK,
                icon: Ext.MessageBox.ERROR
            });
        }

        function changeTheme(cbTheme, mainTabs, loadingMessage) {

            Ext.net.DirectMethods.GetThemeUrl(cbTheme.getValue(), {
                success: function (result) {
                    Ext.net.ResourceMgr.setTheme(result);
                    mainTabs.items.each(function (el) {
                        if (!Ext.isEmpty(el.iframe)) {
                            el.iframe.dom.contentWindow.Ext.net.ResourceMgr.setTheme(result);
                        }
                    });
                },
                eventMask: {
                    showMask: true,
                    msg: loadingMessage
                }
            });

        }

        function MainTabs_Changed(tab) {
            
            var currentLocation = <%= currentLocation.ClientID %>;

            if (currentLocation != null) {

                // alert(Ext.get(tab.tabEl).child('span.x-tab-strip-text', true));

                currentLocation.setText(Ext.get(tab.tabEl).child('span.x-tab-strip-text', true).qtip);

            }
            


        }

        function FullScreen() {


            var leftPanel = Ext.getCmp('<%= LeftPanel.ClientID %>');

            var iscollapsed = leftPanel.collapsed;

            iscollapsed ? leftPanel.expand() : leftPanel.collapse();


            var regionHeader = Ext.getCmp('<%= regionHeader.ClientID %>');

            //alert(w);
            // expand or collapse that Panel based on its collapsed property state
            iscollapsed ? regionHeader.expand() : regionHeader.collapse();


            var regionFooter = Ext.getCmp('<%= regionFooter.ClientID %>');

            //alert(w);
            // expand or collapse that Panel based on its collapsed property state
            iscollapsed ? regionFooter.expand() : regionFooter.collapse();


        }

    </script>
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" CollapseMode="Mini" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" AutoHeight="true" Header="false">
                        <Content>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    <asp:Localize ID="locSystemName" runat="server"></asp:Localize></h1>
                            </div>
                        </Content>
                        <BottomBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button Icon="Date" runat="server">
                                    </ext:Button>
                                    <ext:ToolbarTextItem ID="lblToday" Text="2008-1-1">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:Button Icon="DriveNetwork" runat="server">
                                    </ext:Button>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem2" Text="当前位置">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="currentLocation" Text=">> 系统首页" runat="server">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarFill>
                                    </ext:ToolbarFill>
                                    <ext:ToolbarTextItem ID="lblWelcome" runat="server" Text="<%$ Resources:msglblWelcome %>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblUser" runat="server" Text="<%$ Resources:msglblSuperAdmin %>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="<%$ Resources:msgToolbarTextItemThemsText %>" />
                                    <ext:ComboBox ID="cbTheme" runat="server" EmptyText="<%$ Resources:msgCbThemeEmptyText %>"
                                        Width="100" Editable="false" TypeAhead="true">
                                        <Items>
                                            <ext:ListItem Text="Default" Value="Default" />
                                            <ext:ListItem Text="Gray" Value="Gray" />
                                            <ext:ListItem Text="Slate" Value="Slate" />
                                            <ext:ListItem Text="Access" Value="Access" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="<%$ Resources:msgChangeThemes %>" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:Button ID="Button1" Icon="UserKey" Text="<%$ Resources:msgButtonChangePasswordText %>" runat="server">
                                        <Listeners>
                                            <Click Handler="#{winChangePassword}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnExit" Icon="UserGo" Text="<%$ Resources:msgBtnExitText %>" runat="server">
                                        <DirectEvents>
                                            <Click OnEvent="btnExit_Click" Failure="<%$ Resources:msgLogoffError %>" Success="window.location.href='Login.aspx'">
                                                <EventMask ShowMask="true" Msg="<%$ Resources:msgEventMaskLogOff %>" />
                                                <Confirmation ConfirmRequest="true" Message="<%$ Resources:msgLogoffWarningMessage %>"
                                                    Title="<%$ Resources:msgLogoffWarningTitle %>" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </North>
                <South Collapsible="true" Split="true" CollapseMode="Mini">
                    <ext:Panel runat="server" ID="regionFooter" AutoHeight="true" Border="true" Header="false"
                        BodyBorder="false">
                        <Content>
                            <div class="menu south">
                                <asp:Localize ID="locCopyRight" runat="server"></asp:Localize>
                            </div>
                        </Content>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="LeftPanel" runat="server" Title="<%$ Resources:msgLeftPanelTitle %>"
                        Width="175" Layout="Accordion">
                        <Items>
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="<%$ Resources:msgPanel2Title %>" Layout="Fit">
                        <Tools>
                            <ext:Tool Type="Toggle" Qtip="首页"></ext:Tool>
                            <ext:Tool Type="Maximize" Handler="FullScreen();" Qtip="全屏">
                            </ext:Tool>
                            <ext:Tool Type="Refresh" Qtip="刷新当前模块">
                            </ext:Tool>
                            <ext:Tool Type="Help" Qtip="帮助">
                            </ext:Tool>
                        </Tools>
                        <Items>
                            <ext:TabPanel ID="MainTabs" runat="server" Border="false" EnableTabScroll="true">
                                <Items>
                                    <ext:Panel ID="pnlWorkSpace" runat="server" Title="工作面板" TabTip="工作面板" Layout="Fit" Frame="True"
                                        Closable="False">
                                        <Items>
                                            <ext:Panel ID="Panel1" runat="server" Header="False" Layout="Fit" Frame="True">
                                                <TopBar>
                                                    <ext:Toolbar ID="Toolbar2" runat="server">
                                                        <Items>
                                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                            <ext:Button ID="Button4" runat="server" Text="添加模块" Icon="BulletPlus" Hidden="True" />
                                                            <ext:Button ID="Button2" runat="server" Text="保存" Icon="Disk" Hidden="True" />
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <Items>
                                                    <ext:Portal ID="Portal1" runat="server" Border="false" Layout="Column" Closable="True">
                                                        <Items>
                                                            <ext:PortalColumn ID="PortalColumn3" runat="server" Cls="x-column-padding1" ColumnWidth=".66"
                                                                Layout="Anchor">
                                                                <Items>
                                                                    <ext:Portlet ID="Portlet5" runat="server" Title="最新公告">
                                                                        <Tools>
                                                                            <ext:Tool Type="Close" />
                                                                            <ext:Tool Type="Refresh" />
                                                                        </Tools>
                                                                    </ext:Portlet>
                                                                    <ext:Portlet ID="Portlet4" runat="server" Title="代办事宜" Hidden="True">
                                                                        <Tools>
                                                                            <ext:Tool Type="Close" />
                                                                            <ext:Tool Type="Refresh" />
                                                                        </Tools>
                                                                    </ext:Portlet>

                                                                    <ext:Portlet ID="Portlet1" runat="server" Title="我的任务" Hidden="True">
                                                                        <Tools>
                                                                            <ext:Tool Type="Close" />
                                                                            <ext:Tool Type="Refresh" />
                                                                        </Tools>
                                                                    </ext:Portlet>
                                                                </Items>
                                                            </ext:PortalColumn>
                                                            <ext:PortalColumn ID="PortalColumn1" runat="server" Cls="x-column-padding" ColumnWidth=".33"
                                                                Layout="Anchor">
                                                                <Items>
                                                                    <ext:Portlet ID="plServerInfo" runat="server" Title="我的消息" Icon="Server" Closable="True" Hidden="True">
                                                                        <Tools>
                                                                            <ext:Tool Type="Close" />
                                                                            <ext:Tool Type="Refresh" />
                                                                        </Tools>
                                                                    </ext:Portlet>
                                                                    <ext:Portlet ID="Portlet2" runat="server" Title="我的日程" Icon="Server" Closable="True" Hidden="True">
                                                                        <Tools>
                                                                            <ext:Tool Type="Close" />
                                                                            <ext:Tool Type="Refresh" />
                                                                        </Tools>
                                                                    </ext:Portlet>
                                                                </Items>
                                                            </ext:PortalColumn>
                                                        </Items>
                                                    </ext:Portal>
                                                </Items>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                                <Plugins>
                                    <ext:TabScrollerMenu ID="TabScrollerMenu1" runat="server" PageSize="5" />
                                </Plugins>
                                <Listeners>
                                    <TabChange Handler="MainTabs_Changed(tab);"></TabChange>
                                </Listeners>
                            </ext:TabPanel>
                        </Items>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <uc1:UCChangePassword ID="UCChangePassword1" runat="server" />
</asp:Content>
