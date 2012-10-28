<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdPackAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdPackAdd" %>
<ext:Window ID="winSPAdPackAdd" runat="server" Icon="ApplicationAdd" Title="SPAdPack Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdPackAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
				 
						<ext:NumberField ID="radnumID" runat="server" FieldLabel="ID"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="radnumSPAdID" runat="server" FieldLabel="SPAdID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdPack" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdPackAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdPack_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdPackAdd}.getForm().reset();#{storeSPAdPack}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdPack" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdPackAdd}.getForm().reset();#{winSPAdPackAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

