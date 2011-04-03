<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.UCSystemUserAdd" %>



<ext:Window ID="winSystemUserAdd" runat="server" Icon="Add" Title="Add System User" Width="400"
    Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" LabelWidth="100">
            <Items>
                <ext:TextField ID="txtUserLoginID" runat="server" FieldLabel="Login ID" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="Name" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="Email" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserPassword" runat="server" FieldLabel="Password" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="Comments" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success AddedSystem User',callback);function callback(id) {#{formPanelSystemUserAdd}.getForm().reset();#{storeSystemUser}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
 