<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsEdit" %>
<ext:Window ID="winSystemEmailSettingsEdit" runat="server" Icon="ApplicationEdit"
    Title="Edit SystemEmailSettings" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidEmailSettingID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextArea ID="txtDescriprsion" runat="server" FieldLabel="Descriprsion" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtHost" runat="server" FieldLabel="Host" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPort" runat="server" FieldLabel="Port" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkSSL" runat="server" FieldLabel="SSL" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtFromEmail" runat="server" FieldLabel="FromEmail" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFromName" runat="server" FieldLabel="FromName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLoginEmail" runat="server" FieldLabel="LoginEmail" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtLoginPassword" runat="server" FieldLabel="LoginPassword" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsDefault" runat="server" FieldLabel="IsDefault" Checked="false"  AnchorHorizontal="95%"/>
                                       
              

            </Items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSaveSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailSettingsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailSettings_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSystemEmailSettingsEdit}.getForm().reset();#{storeSystemEmailSettings}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailSettings" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailSettingsEdit}.getForm().reset();#{winSystemEmailSettingsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
</ext:Window>