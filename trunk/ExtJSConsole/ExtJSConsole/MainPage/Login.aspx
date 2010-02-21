<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExtJSConsole.MainPage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ScriptManager ID="ScriptManager1" runat="server" />
    <ext:Window ID="extwinLogin" runat="server" Width="350" ButtonAlign="Right" BodyStyle="padding:20px;"
        Height="200" Title="登录后台管理" Draggable="false" Closable="false" Maximizable="false"
        Modal="true" Icon="UserGo" Resizable="false">
        <Body>
            <ext:FormPanel ID="pnlLogin" runat="server" Frame="true" BodyStyle="padding:10px;">
                <Body>
                    <ext:FormLayout ID="FormLayout1" runat="server" LabelWidth="60">
                        <ext:Anchor Horizontal="100%">
                            <ext:TextField ID="txtUserName" runat="server" FieldLabel="用户名" AllowBlank="false"
                                BlankText="请输入管理员帐号!" Text="DeveloperAdministrator">
                            </ext:TextField>
                        </ext:Anchor>
                        <ext:Anchor Horizontal="100%">
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="密&nbsp;&nbsp;&nbsp;码"
                                AllowBlank="false" BlankText="请输入正确的管理员口令!">
                            </ext:TextField>
                        </ext:Anchor>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </Body>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="登录" Type="Submit" Icon="ServerGo">
                <AjaxEvents>
                    <Click OnEvent="BtnLogin_Click" Before="#{pnlLogin}.getForm().isValid();" Success="#{extwinLogin}.hide();">
                        <EventMask ShowMask="true" Msg="正在验证登录,请稍候..." />
                    </Click>
                </AjaxEvents>
            </ext:Button>
            <ext:Button ID="btnReset" runat="server" Text="重置" Type="Reset" Icon="ArrowRefreshSmall">
                <Listeners>
                    <Click Handler="#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
