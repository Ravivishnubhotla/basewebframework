<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Legendigital.Common.WebApp.MainPage.Login" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
      if (parent.location.href != self.location.href)
          parent.location.href = '<%= this.ResolveUrl("~/MainPage/Default.aspx") %>';
</script> 
    <style type="text/css">
        .LoginID
        {
            background-image: url(<%= this.ResolveUrl("~/images/user.png") %>);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .Password
        {
            background-image: url(<%= this.ResolveUrl("~/images/lock.png") %>);
            background-repeat: no-repeat;
            padding-left: 20px;
            background-position: 1px 1px;
        }
        .x-plain-body
        {
            background: #FFFFFF url('<%= this.ResolveUrl("~/images/logo.jpg") %>') no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Window ID="extwinLogin" runat="server" Width="295" ButtonAlign="Right" Height="285"
        Title="IGL Shipment Request" Draggable="false" Closable="false" Maximizable="false" Modal="true" Icon="UserKey"
        Resizable="false">
        <content>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North> 
                    <ext:Panel ID="Panel1" runat="server" Header="false" BaseCls="x-plain-body" Height="140px">
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
                            <ext:TextField ID="txtUserName" runat="server"  FieldLabel="Login ID" AllowBlank="false"
                                Cls="LoginID" BlankText="Please enter login id!"
                                AnchorHorizontal="95%">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWord" InputType="Password" runat="server" FieldLabel="Password"
                                Cls="Password" AllowBlank="false" BlankText="Please enter password!" AnchorHorizontal="95%">
                            </ext:TextField>
                        </Items>
                    </ext:FormPanel>
                </Center>
            </ext:BorderLayout>
        </content>
        <buttons>
            <ext:Button ID="btnLogin" runat="server" Text="Login" Type="Submit" Icon="Accept">
                <DirectEvents>
                    <Click OnEvent="BtnLogin_Click" Before="return #{pnlLogin}.getForm().isValid();"
                        Failure="Ext.Msg.show({ 
                            title:   'Login Error', 
                            msg:     result.errorMessage, 
                            buttons: Ext.Msg.OK, 
                            icon:    Ext.MessageBox.ERROR 
                         });">
                        <EventMask ShowMask="true" Msg="Checking user,Please waiting......" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="btnReset" runat="server" Text="Reset" Type="Reset" Icon="ArrowRefreshSmall">
                <Listeners>
                    <Click Handler="#{pnlLogin}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </buttons>
    </ext:Window>
</asp:Content>
