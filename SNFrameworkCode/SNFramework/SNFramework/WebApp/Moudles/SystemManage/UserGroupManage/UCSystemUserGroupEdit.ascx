<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserGroupEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserGroupManage.UCSystemUserGroupEdit" %>

<ext:Window ID="winSystemUserGroupEdit" runat="server" Icon="ApplicationEdit" Title="EditUser Group"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserGroupEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidGroupID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtGroupNameCn" runat="server" FieldLabel="Name" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtGroupNameEn" runat="server" FieldLabel="Code" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtGroupDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUserGroup" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserGroupEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUserGroup_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success upadted User Group。',callback);function callback(id) {#{formPanelSystemUserGroupEdit}.getForm().reset();#{storeSystemUserGroup}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUserGroup" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemUserGroupEdit}.getForm().reset();#{winSystemUserGroupEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

