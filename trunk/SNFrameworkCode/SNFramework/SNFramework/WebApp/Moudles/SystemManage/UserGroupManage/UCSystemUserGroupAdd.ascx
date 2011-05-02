<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserGroupAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserGroupManage.UCSystemUserGroupAdd" %>
<ext:Window ID="winSystemUserGroupAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="230" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserGroupAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
                <ext:TextField ID="txtGroupNameCn" runat="server" FieldLabel="<%$ Resources:msgcolGroupNameCn %>"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtGroupNameEn" runat="server" FieldLabel="<%$ Resources:msgcolGroupNameEn %>"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtGroupDescription" runat="server" FieldLabel="<%$ Resources:msgcolGroupDescription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemUserGroup" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserGroupAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUserGroup_Click" Success="<%$ Resources:msgAddScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUserGroup" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemUserGroupAdd}.getForm().reset();#{winSystemUserGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
