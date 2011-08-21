<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPSClientAdd" %>
<ext:Window ID="winSPSClientAdd" runat="server" Icon="ApplicationAdd" Title="SPSClient Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPSClientAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
			
						<ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="RecieveDataUrl" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtUserID" runat="server" FieldLabel="UserID" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="SyncData" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtOkMessage" runat="server" FieldLabel="OkMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="FailedMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSyncType" runat="server" FieldLabel="SyncType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtAlias" runat="server" FieldLabel="Alias" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="InterceptRate" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDefaultPrice" runat="server" FieldLabel="DefaultPrice" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPSClient" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPSClientAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPSClient_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPSClientAdd}.getForm().reset();#{storeSPSClient}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSClient" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPSClientAdd}.getForm().reset();#{winSPSClientAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>