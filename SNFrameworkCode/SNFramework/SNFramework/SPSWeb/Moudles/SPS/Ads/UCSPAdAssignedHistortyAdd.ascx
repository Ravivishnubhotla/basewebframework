

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdAssignedHistortyAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdAssignedHistortyAdd" %>
<ext:Window ID="winSPAdAssignedHistortyAdd" runat="server" Icon="ApplicationAdd" Title="SPAdAssignedHistorty Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdAssignedHistortyAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
				 
						<ext:NumberField ID="numSPAdID" runat="server" FieldLabel="SPAdID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPAdPackID" runat="server" FieldLabel="SPAdPackID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPClientID" runat="server" FieldLabel="SPClientID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateStartDate" runat="server" FieldLabel="StartDate" AllowBlank="True"   AnchorHorizontal="95%"/>
                
                 
						<ext:DateField  ID="dateEndDate" runat="server" FieldLabel="EndDate" AllowBlank="True"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numCreateBy" runat="server" FieldLabel="CreateBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numLastModifyBy" runat="server" FieldLabel="LastModifyBy"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="True"   AnchorHorizontal="95%"/>
                
			
						<ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="LastModifyComment" AllowBlank="False"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdAssignedHistorty" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdAssignedHistortyAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdAssignedHistorty_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdAssignedHistortyAdd}.getForm().reset();#{storeSPAdAssignedHistorty}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdAssignedHistorty" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdAssignedHistortyAdd}.getForm().reset();#{winSPAdAssignedHistortyAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
 

