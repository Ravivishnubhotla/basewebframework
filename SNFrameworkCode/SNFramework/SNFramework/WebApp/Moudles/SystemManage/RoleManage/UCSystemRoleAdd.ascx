<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.UCSystemRoleAdd" %>
<ext:Window ID="winSystemRoleAdd" runat="server" Icon="Add" Title="SystemRoleAdd" Width="400"
    Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemRoleAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="form">
            <Items>
                <ext:TextField ID="txtRoleName" runat="server" FieldLabel="RoleName" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtRoleDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkRoleIsSystemRole" runat="server" FieldLabel="IsSystemRole" Checked="false"  AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemRole" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemRoleAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemRole_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success Added System Role',callback);function callback(id) {#{formPanelSystemRoleAdd}.getForm().reset();#{storeSystemRole}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRole" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
