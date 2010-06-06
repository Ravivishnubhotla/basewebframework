<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Legendigital.Common.Web.MainPage.Login" %>

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
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="322" ButtonAlign="Right" Height="300"
        Title="SP1.00" Draggable="false" Closable="false" Maximizable="false" Modal="true"
        Icon="UserKey" Resizable="false">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North>
                    <ext:Panel ID="Panel1" runat="server" Header="false" BaseCls="x-plain-body" Height="151px">
                    </ext:Panel>
                </North>
                <Center>
                    <ext:FormPanel ID="pnlLogin" runat="server" Frame="true" BodyStyle="padding:10px;"
                        LabelWidth="60">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server" LabelWidth="60">
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="txtUserName" runat="server" FieldLabel="用户名" AllowBlank="false"
                                        BlankText="请输入管理员帐号!" Cls="LoginID">
                                    </ext:TextField>
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="密&nbsp;&nbsp;&nbsp;码"
                                        AllowBlank="false" Cls="Password" BlankText="请输入正确的管理员口令!">
                                    </ext:TextField>
                                </ext:Anchor>
                            </ext:FormLayout>
                        </Body>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </Body>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="登陆" Type="Submit" Icon="Accept">
                <AjaxEvents>
                    <Click OnEvent="BtnLogin_Click" Before="return #{pnlLogin}.getForm().isValid();"
                        Failure="Ext.Msg.show({ 
                            title:   '登陆错误', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });">
                        <EventMask ShowMask="true" Msg="用户校验中，请稍后......" />
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
