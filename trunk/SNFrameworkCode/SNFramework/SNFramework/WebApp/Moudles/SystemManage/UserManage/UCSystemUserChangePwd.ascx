<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserChangePwd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.UCSystemUserChangePwd" %>
<script type="text/javascript">
    function vaildaPassword() {
        if (Ext.get('<%= txtNewPassword.ClientID %>').dom.value == Ext.get('<%= txtRePassword.ClientID %>').dom.value)
            return true;
        else
            return false;
    }
</script>
<ext:Window ID="winChangePassword" runat="server" Icon="UserKey" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="170" AutoShow="false" Modal="true" Layout="fit" Hidden="true">
    <Content>
        <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Title="<%$ Resources:msgFormTitle %>"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130">
            <Items>
                <ext:TextField ID="txtNewPassword" InputType="Password" runat="server" FieldLabel="<%$ Resources:msgFieldNewPassword %>"
                    AllowBlank="false" BlankText="<%$ Resources:msgFieldNewPasswordBlankText %>" AnchorHorizontal="95%" />
                <ext:TextField ID="txtRePassword" InputType="Password" runat="server" FieldLabel="<%$ Resources:msgFieldRePassword %>"
                    AllowBlank="false" BlankText="<%$ Resources:msgFieldRePasswordBlankText %>" Validator="vaildaPassword"
                    InvalidText="<%$ Resources:msgFieldRePasswordInvalidText %>" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnChangePassword" runat="server" Text="<%$ Resources :  msgbtnChangePassword  %>" Icon="KeyStart">
            <DirectEvents>
                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                    OnEvent="btnChangePassword_Click" Success="<%$ Resources:msgChangePasswordScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelAblum" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Hidden ID="HiddenUserID" runat="server">
</ext:Hidden>
