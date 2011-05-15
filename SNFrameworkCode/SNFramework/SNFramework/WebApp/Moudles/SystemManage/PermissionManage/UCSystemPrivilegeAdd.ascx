<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemPrivilegeAdd" %>
<ext:Window ID="winSystemPrivilegeAdd" runat="server" Icon="ApplicationAdd" Title="AddSystem Permission"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPrivilegeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
                <ext:NumberField ID="radnumOperationID" runat="server" FieldLabel="Operation ID"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:NumberField ID="radnumResourcesID" runat="server" FieldLabel="Resources ID"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="Name"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="Code"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:NumberField ID="txtPrivilegeOrder" runat="server" FieldLabel="Order"
                    AllowBlank="False" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPrivilege_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success AddedSystem Permission',callback);function callback(id) {#{formPanelSystemPrivilegeAdd}.getForm().reset();#{storeSystemPrivilege}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
