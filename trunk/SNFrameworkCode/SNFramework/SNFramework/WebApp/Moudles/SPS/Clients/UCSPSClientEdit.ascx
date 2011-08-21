<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPSClientEdit" %>
<ext:Window ID="winSPSClientEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPSClient"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPSClientEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
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
        <ext:Button ID="btnSaveSPSClient" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPSClientEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPSClient_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPSClientEdit}.getForm().reset();#{storeSPSClient}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSClient" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPSClientEdit}.getForm().reset();#{winSPSClientEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
