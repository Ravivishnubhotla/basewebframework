<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.UserManage.UCSystemUserAdd" %>

<ext:Window ID="winSystemUserAdd" runat="server" Icon="Add" Title="<%$ Resources:msgFormTitle %>" Width="400"
    Height="220" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" LabelWidth="100">
            <Items>
                <ext:TextField ID="txtUserLoginID" runat="server" FieldLabel="<%$ Resources:msgFieldUserLoginID %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="<%$ Resources:msgFieldUserName %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="<%$ Resources:msgFieldUserEmail %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserPassword" runat="server" FieldLabel="<%$ Resources:msgFieldUserPassword %>" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="<%$ Resources:msgFieldComments %>" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
 