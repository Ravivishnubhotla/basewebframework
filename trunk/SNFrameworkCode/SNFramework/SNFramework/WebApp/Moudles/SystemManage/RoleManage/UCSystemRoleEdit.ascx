<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.UCSystemRoleEdit" %>
<ext:Window ID="winSystemRoleEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="390" Height="230" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemRoleEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemRoleID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtRoleName" runat="server" FieldLabel="<%$ Resources:msgFiledRoleNameTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtRoleCode" runat="server" FieldLabel="<%$ Resources:msgFiledRoleCodeTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtRoleDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescriptionTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkRoleIsSystemRole" runat="server" FieldLabel="<%$ Resources:msgFiledIsSystemRoleTitle %>"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemRole" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemRoleEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemRole_Click" Success="<%$ Resources:msgUpdateScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRole" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
