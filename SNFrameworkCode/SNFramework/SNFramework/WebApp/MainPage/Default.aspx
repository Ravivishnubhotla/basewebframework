<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Legendigital.Common.WebApp.MainPage.Default" %>

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
                    maskMsg: '<%= GetLocalResourceObject("msgLoadingText").ToString() %>',
                    scripts: true,
                    mode: "iframe",
                    url: taburl
                },
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

        function changeTheme(cbTheme,mainTabs,loadingMessage) {

        Ext.net.DirectMethods.GetThemeUrl(cbTheme.getValue(), {
                                                                        success: function(result) {
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

    </script>
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
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
                                    <ext:ToolbarTextItem ID="lblWelcome" runat="server" Text="<%$ Resources:msglblWelcome %>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblUser" runat="server" Text="<%$ Resources:msglblSuperAdmin %>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblToday" Text="2008-1-1">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarFill>
                                    </ext:ToolbarFill>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="<%$ Resources:msgToolbarTextItemThemsText %>" />
                                    <ext:ComboBox ID="cbTheme" runat="server" EmptyText="<%$ Resources:msgCbThemeEmptyText %>" Width="80"
                                        Editable="false" TypeAhead="true" meta:resourcekey="cbThemeResource1">
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
                                    <ext:Button Icon="UserKey" Text="<%$ Resources:msgButtonChangePasswordText %>" runat="server">
                                        <Listeners>
                                            <Click Handler="#{winChangePassword}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnExit" Icon="UserGo" Text="<%$ Resources:msgBtnExitText %>" runat="server">
                                        <DirectEvents>
                                            <Click OnEvent="btnExit_Click" Failure="<%$ Resources:msgLogoffError %>" Success="window.location.href='Login.aspx'">
                                                <EventMask ShowMask="true" Msg="<%$ Resources:msgEventMaskLogOff %>" />
                                                <Confirmation ConfirmRequest="true" Message="<%$ Resources:msgLogoffWarningMessage %>" Title="<%$ Resources:msgLogoffWarningTitle %>" />
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
                                <asp:Localize ID="locCopyRight" runat="server"></asp:Localize></div>
                        </Content>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="LeftPanel" runat="server" Title="<%$ Resources:msgLeftPanelTitle %>" Width="175" Layout="Accordion">
                        <Items>
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="<%$ Resources:msgPanel2Title %>" Layout="Fit">
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
    <uc1:UCChangePassword ID="UCChangePassword1" runat="server" />
</asp:Content>
