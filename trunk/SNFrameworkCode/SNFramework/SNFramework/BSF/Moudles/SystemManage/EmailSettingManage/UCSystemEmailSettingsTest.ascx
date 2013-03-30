<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsTest.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsTest" %>
<ext:Window ID="winSystemEmailSettingsTest" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsTest" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidEmailSettingID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtMail" runat="server" FieldLabel="<%$ Resources : msgFiledMail  %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtTitle" runat="server" FieldLabel="<%$ Resources : msgFiledTitle  %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtContext" runat="server" FieldLabel="<%$ Resources : msgFiledContext  %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnTestSystemEmailSettings" runat="server" Text="<%$ Resources : msgSend  %>" Icon="Mail">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailSettingsTest}.getForm().isValid()) return false;"
                    OnEvent="btnTestSystemEmailSettings_Click" Success="<%$ Resources : msgSendScript  %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgProcessing  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailSettingsTest}.getForm().reset();#{winSystemEmailSettingsTest}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
