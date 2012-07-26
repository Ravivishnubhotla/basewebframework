<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsAdd" %>
<ext:Window ID="winSystemEmailSettingsAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="<%$ Resources : msgFiledName  %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="<%$ Resources : msgFiledCode  %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescriprsion" runat="server" FieldLabel="<%$ Resources : msgFiledDescription  %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtHost" runat="server" FieldLabel="<%$ Resources : msgFiledHost  %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtPort" runat="server" FieldLabel="<%$ Resources : msgFiledPort  %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSSL" runat="server" FieldLabel="<%$ Resources : msgFiledSSL  %>" Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtFromEmail" runat="server" FieldLabel="<%$ Resources : msgFiledFromEmail  %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtFromName" runat="server" FieldLabel="<%$ Resources : msgFiledFromName  %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLoginEmail" runat="server" FieldLabel="<%$ Resources : msgFiledLoginEmail  %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLoginPassword" runat="server" FieldLabel="<%$ Resources : msgFiledLoginPassword  %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="<%$ Resources : msgFiledIsEnable  %>" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsDefault" runat="server" FieldLabel="<%$ Resources : msgFiledIsDefault  %>" Checked="false"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailSettingsAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailSettings_Click" Success="<%$ Resources : msgAddScript  %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailSettingsAdd}.getForm().reset();#{winSystemEmailSettingsAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
