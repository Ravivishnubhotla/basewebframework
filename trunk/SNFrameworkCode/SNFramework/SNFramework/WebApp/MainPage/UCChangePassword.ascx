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

<ext:Window ID="winChangePassword" runat="server" Icon="UserKey" Title="<%$ Resources:winChangePasswordTitle %>"
    Width="400" Height="200" AutoShow="false" Modal="true"  Layout="fit" Hidden="true">
    <Content>
        <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Title="<%$ Resources:formPanelChangePasswordTitle %>"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130">
            <Items>
                <ext:TextField ID="txtPassword" InputType="Password" runat="server" FieldLabel="<%$ Resources:txtPasswordFieldLabel %>"
                    AllowBlank="false" BlankText="<%$ Resources:txtPasswordBlankText %>"  AnchorHorizontal="95%"/>
                <ext:TextField ID="txtNewPassword" InputType="Password" runat="server" FieldLabel="<%$ Resources:txtNewPasswordFieldLabel %>"
                    AllowBlank="false" BlankText="<%$ Resources:txtNewPasswordBlankText %>"  AnchorHorizontal="95%"/>
 
                <ext:TextField ID="txtRePassword" InputType="Password" runat="server" FieldLabel="<%$ Resources:txtRePasswordFieldLabel %>"
                    AllowBlank="false" BlankText="<%$ Resources:txtRePasswordBlankText %>" Validator="vaildaPassword"
                    InvalidText="The Confirm New Password must match the New Password entry." AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnChangePassword" runat="server" Text="<%$ Resources:btnChangePasswordText %>" Icon="KeyStart">
            <DirectEvents>   
                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                    OnEvent="btnChangePassword_Click" Success="<%$ Resources:SaveOkScript %>" Failure="<%$ Resources:SaveFailedScript %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources:btnChangePasswordMaskMsg %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelAblum" runat="server" Text="<%$ Resources:btnCancelText %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
