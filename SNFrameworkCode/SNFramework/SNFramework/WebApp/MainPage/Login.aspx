﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Legendigital.Common.WebApp.MainPage.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        if (parent.location.href != self.location.href)
            parent.location.href = '<%= this.ResolveUrl("~/MainPage/Default.aspx") %>';


        function ShowError(etitle, emessage) {
            Ext.Msg.show({
                title: etitle,
                msg: emessage,
                buttons: Ext.Msg.OK,
                icon: Ext.MessageBox.ERROR
            });
        }
    </script>
    <style type="text/css">
        .x-plain-body
        {
            background: #FFFFFF url('<%= this.ResolveUrl("~/images/logo.png") %>') no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="360" ButtonAlign="Right" Height="255"
        Title="<%$ Resources:msgPnlLoginTitle %>" Draggable="false" Closable="false"
        Maximizable="false" Modal="true" Icon="UserKey" Resizable="false">
        <Content>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North>
                    <ext:Panel ID="Panel1" runat="server" Header="false" BaseCls="x-plain-body" Height="110px">
                        <Content>
                        </Content>
                    </ext:Panel>
                </North>
                <Center>
                    <ext:FormPanel ID="pnlLogin" runat="server" Frame="true" BodyStyle="padding:10px;"
                        Layout="Form" LabelWidth="60">
                        <Defaults>
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextField ID="txtUserName" runat="server" FieldLabel="<%$ Resources:msgtxtUserNameFieldLabel %>"
                                AllowBlank="false" Icon="User" BlankText="<%$ Resources:msgtxtUserNameBlankText %>"
                                Text="DeveloperAdministrator" AnchorHorizontal="92%">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="<%$ Resources:msgtxtPassWordFieldLabel %>"
                                Icon="Lock" AllowBlank="false" BlankText="<%$ Resources:msgtxtPassWordBlankText %>"
                                Text="111111" AnchorHorizontal="92%">
                            </ext:TextField>
                        </Items>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </Content>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="<%$ Resources:msgBtnLoginText %>"
                Type="Submit" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="BtnLogin_Click" Before="return #{pnlLogin}.getForm().isValid();"
                        Failure="<%$ Resources:msgLoginError %>">
                        <EventMask ShowMask="true" Msg="<%$ Resources:msgCheckUserInfo %>" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="btnReset" runat="server" Text="<%$ Resources:msgBtnResetText %>"
                Type="Reset" Icon="ArrowRefreshSmall">
                <Listeners>
                    <Click Handler="#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</asp:Content>
