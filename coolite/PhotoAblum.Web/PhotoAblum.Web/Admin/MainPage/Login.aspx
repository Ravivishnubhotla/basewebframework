<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Masters/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhotoAblum.Web.Admin.MainPage.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="350" ButtonAlign="Right" BodyStyle="padding:20px;"
        Height="200" Title="登录后台管理" Draggable="false" Closable="false" Maximizable="false"
        Modal="true" Icon="UserGo" Resizable="false">
        <Body>
            <ext:FormPanel ID="pnlLogin" runat="server" Frame="true" BodyStyle="padding:10px;">
                <Body>
                    <ext:FormLayout ID="FormLayout1" runat="server" LabelWidth="60">
                        <ext:Anchor Horizontal="100%">
                            <ext:TextField ID="txtUserName" runat="server" FieldLabel="用户名" AllowBlank="false"
                                BlankText="请输入管理员帐号!">
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
                    <Click OnEvent="BtnLogin_Click" Before="#{pnlLogin}.getForm().isValid();">
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
</asp:Content>
