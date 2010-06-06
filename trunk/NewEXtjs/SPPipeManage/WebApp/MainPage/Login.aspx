<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Legendigital.Common.WebApp.MainPage.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .LoginID
        {
            background-image: url(/images/user.png);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .Password
        {
            background-image: url(/images/lock.png);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .x-plain-body
        {
            background: #f0edce url('/images/logo.png') no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="322" ButtonAlign="Right" Height="290"
        Title="" Draggable="false" Closable="false" Maximizable="false" Modal="true" Icon="UserKey"
        Resizable="false">
        <content>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North>
                    <ext:Panel ID="Panel1" runat="server" Header="false" BaseCls="x-plain-body" Height="151px">
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
                            <ext:TextField ID="txtUserName" runat="server"  FieldLabel="登陆ID" AllowBlank="false"
                                Text="DeveloperAdministrator" Cls="LoginID" BlankText="请输入登陆ID！"
                                AnchorHorizontal="95%">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="密码"
                                Cls="Password" AllowBlank="false" BlankText="请输入密码！" AnchorHorizontal="95%">
                            </ext:TextField>
                        </Items>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </content>
        <buttons>
            <ext:Button ID="btnLogin" runat="server" Text="登陆" Type="Submit" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="BtnLogin_Click" Before="return #{pnlLogin}.getForm().isValid();"
                        Failure="Ext.Msg.show({ 
                            title:   '登陆错误', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });">
                        <EventMask ShowMask="true" Msg="用户校验中，请稍后......" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="btnReset" runat="server" Text="重置" Type="Reset" Icon="ArrowRefreshSmall">
                <Listeners>
                    <Click Handler="#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </buttons>
    </ext:Window>
</asp:Content>
