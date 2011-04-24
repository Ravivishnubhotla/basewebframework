<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsAdd" %>
<ext:Window ID="winSystemEmailSettingsAdd" runat="server" Icon="ApplicationAdd" Title="SystemEmailSettings Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescriprsion" runat="server" FieldLabel="Descriprsion" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtHost" runat="server" FieldLabel="Host" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtPort" runat="server" FieldLabel="Port" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSSL" runat="server" FieldLabel="SSL" Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtFromEmail" runat="server" FieldLabel="FromEmail" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtFromName" runat="server" FieldLabel="FromName" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLoginEmail" runat="server" FieldLabel="LoginEmail" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLoginPassword" runat="server" FieldLabel="LoginPassword" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsDefault" runat="server" FieldLabel="IsDefault" Checked="false"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailSettingsAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailSettings_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSystemEmailSettingsAdd}.getForm().reset();#{storeSystemEmailSettings}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
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
