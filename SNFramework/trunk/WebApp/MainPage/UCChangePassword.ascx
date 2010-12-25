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

<ext:Window ID="winChangePassword" runat="server" Icon="UserKey" Title="Change Password"
    Width="400" Height="200" AutoShow="false" Modal="true"  Layout="fit" Hidden="true">
    <Content>
        <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Title="Change Password"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130">
            <Items>
                <ext:TextField ID="txtPassword" InputType="Password" runat="server" FieldLabel="Password"
                    AllowBlank="false" BlankText="Please input password!"  AnchorHorizontal="95%"/>
                <ext:TextField ID="txtNewPassword" InputType="Password" runat="server" FieldLabel="New Password"
                    AllowBlank="false" BlankText="Please input new password!"  AnchorHorizontal="95%"/>
 
                <ext:TextField ID="txtRePassword" InputType="Password" runat="server" FieldLabel="Confirm New Password"
                    AllowBlank="false" BlankText="Please input confirm new password!" Validator="vaildaPassword"
                    InvalidText="The Confirm New Password must match the New Password entry." AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnChangePassword" runat="server" Text="Change Password" Icon="KeyStart">
            <DirectEvents>
                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                    OnEvent="btnChangePassword_Click" Success="Ext.MessageBox.alert('Operation OK', 'Suceess To Change Password.',callback);function callback(id) { #{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving Data,Please waiting......" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelAblum" runat="server" Text="Cancle" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangePassword}.hide();#{formPanelChangePassword}.getForm().reset();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
