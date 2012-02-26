<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChangePassword.ascx.cs"
    Inherits="Legendigital.Common.WebApp.MainPage.UCChangePassword" %>

<script type="text/javascript">
    function vaildaPassword() {
        if (Ext.get('<%= txtNewPassword.ClientID %>').dom.value == Ext.get('<%= txtRePassword.ClientID %>').dom.value)
            return true;
        else
            return false;
    }

</script>

<ext:Window ID="winChangePassword" runat="server" Icon="UserKey" Title="修改密码"
    Width="400" Height="200" AutoShow="false" Modal="true"  Layout="fit" Hidden="true">
    <Content>
        <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Title="修改密码"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130">
            <Items>
                <ext:TextField ID="txtPassword" InputType="Password" runat="server" FieldLabel="旧密码"
                    AllowBlank="false" BlankText="请输入旧密码！"  AnchorHorizontal="95%"/>
                <ext:TextField ID="txtNewPassword" InputType="Password" runat="server" FieldLabel="新密码"
                    AllowBlank="false" BlankText="请输入新密码！"  AnchorHorizontal="95%"/>
 
                <ext:TextField ID="txtRePassword" InputType="Password" runat="server" FieldLabel="确认新密码"
                    AllowBlank="false" BlankText="请输入确认新密码" Validator="vaildaPassword"
                    InvalidText="确认新密码和新密码不一致请输入新密码。" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnChangePassword" runat="server" Text="修改密码" Icon="KeyStart">
            <DirectEvents>
                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                    OnEvent="btnChangePassword_Click" Success="Ext.MessageBox.alert('Operation OK', '密码修改成功！',callback);function callback(id) { #{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="密码修改中......" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelAblum" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
