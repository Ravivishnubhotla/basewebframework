<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsEdit" %>
<ext:Window ID="winSystemEmailSettingsEdit" runat="server" Icon="ApplicationEdit"
    Title="<%$ Resources:msgFormTitle %>" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidEmailSettingID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
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
        <ext:Button ID="btnSaveSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailSettingsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailSettings_Click" Success="<%$ Resources:msgUpdateScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailSettingsEdit}.getForm().reset();#{winSystemEmailSettingsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
