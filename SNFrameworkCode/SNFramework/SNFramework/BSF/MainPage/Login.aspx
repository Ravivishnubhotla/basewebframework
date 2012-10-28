<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SNFramework.BSF.MainPage.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    

    <script type="text/javascript">


        /// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base.js" assembly="Ext.Net" />
        /// <reference name="Ext.Net.Build.Ext.Net.extjs.adapter.ext.ext-base-debug.js" assembly="Ext.Net" />
        /// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all-debug.js" assembly="Ext.Net" />
        /// <reference name="Ext.Net.Build.Ext.Net.extjs.ext-all.js" assembly="Ext.Net" />

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

        function show(img) {
            
            //var imgurl = '<%= this.ResolveUrl("~/images/CheckCode.jpg") %>' + '?' + Math.random();
            //alert(imgurl);
            //img.setImageUrl(imgurl);
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
        <Listeners>
            <DocumentReady Handler="show(#{imgCheckCode});"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="500" ButtonAlign="Center" Height="320"
        Title="<%$ Resources:msgPnlLoginTitle %>" Draggable="false" Closable="false"
        Maximizable="false" Modal="true" Icon="UserKey" Resizable="false">
        <Content>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Items>
                    <ext:Panel ID="Panel1" Region="North" runat="server" Header="false" BaseCls="x-plain-body"
                        Height="110px">
                        <Content>
                        </Content>
                    </ext:Panel>
                    <ext:FormPanel ID="pnlLogin" Region="Center" runat="server" Frame="true" BodyStyle="padding:10px;"
                        Layout="Form" LabelWidth="60">
                        <Defaults>
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextField ID="txtUserName" runat="server" FieldLabel="<%$ Resources:msgtxtUserNameFieldLabel %>"
                                AllowBlank="false" Icon="User" BlankText="<%$ Resources:msgtxtUserNameBlankText %>"
                                Text="DeveloperAdministrator" AnchorHorizontal="98%">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="<%$ Resources:msgtxtPassWordFieldLabel %>"
                                Icon="Lock" AllowBlank="false" BlankText="<%$ Resources:msgtxtPassWordBlankText %>"
                                Text="111111" AnchorHorizontal="98%">
                            </ext:TextField>
                            <ext:CompositeField ID="mfCheckCode" runat="server" FieldLabel="验证码" AnchorHorizontal="98%">
                                <Items>
                                    <ext:TextField ID="txtCheckCode" HideLabel="True" runat="server" Flex="1" />
                                    <ext:Image ID="imgCheckCode" runat="server" >

                                    </ext:Image>
                                </Items>
                            </ext:CompositeField>
                            <ext:Label ID="lblMessage" runat="server"  FieldLabel="错误信息" Hidden="True">
 
                            </ext:Label>
                        </Items>
                    </ext:FormPanel>
                </Items>
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
                    <Click Handler="show(#{imgCheckCode});#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <BottomBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:ToolbarFill />
                    <ext:ToolbarTextItem ID="lblSupportMessage" runat="server" Text="推荐使用谷歌浏览器(Google Chrome)浏览本系统">
                    </ext:ToolbarTextItem>
                </Items>
            </ext:Toolbar>
        </BottomBar>
    </ext:Window>
</asp:Content>
