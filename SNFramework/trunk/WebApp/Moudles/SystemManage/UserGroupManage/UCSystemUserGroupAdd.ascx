<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserGroupAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserGroupManage.UCSystemUserGroupAdd" %>


<ext:Window ID="winSystemUserGroupAdd" runat="server" Icon="ApplicationAdd" Title="AddUser Group"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserGroupAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtGroupNameCn" runat="server" FieldLabel="Name" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtGroupNameEn" runat="server" FieldLabel="Code" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtGroupDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemUserGroup" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserGroupAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemUserGroup_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Success AddedUser Group。',callback);function callback(id) {#{formPanelSystemUserGroupAdd}.getForm().reset();#{storeSystemUserGroup}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUserGroup" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemUserGroupAdd}.getForm().reset();#{winSystemUserGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
