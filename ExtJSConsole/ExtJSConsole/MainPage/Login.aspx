<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExtJSConsole.MainPage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Window ID="extwinLogin" runat="server" Width="350" ButtonAlign="Right" Height="200"
        Title="Ext.Net Console
" Draggable="false" Closable="false" Maximizable="false" Modal="true" Icon="UserKey"
        Resizable="false">
        <Content>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North>
                    <ext:Panel ID="Panel1" runat="server" Header="false" BaseCls="x-plain-body" Height="55px">
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
                            <ext:TextField ID="txtUserName" runat="server" FieldLabel="Login ID" AllowBlank="false"
                                Text="DeveloperAdministrator" Cls="LoginID" BlankText="Please enter login id!"
                                AnchorHorizontal="95%">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="Password"
                                Cls="Password" AllowBlank="false" BlankText="Please enter password!" AnchorHorizontal="95%">
                            </ext:TextField>
                        </Items>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </Content>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="Login" Type="Submit" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="BtnLogin_Click" Before="return #{pnlLogin}.getForm().isValid();"
                        Failure="Ext.Msg.show({ 
                            title:   'Login Error', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });" Success="#{extwinLogin}.hide();">
                        <EventMask ShowMask="true" Msg="Checking user,Please waiting......" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="btnReset" runat="server" Text="Reset" Type="Reset" Icon="ArrowRefreshSmall">
                <Listeners>
                    <Click Handler="#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
