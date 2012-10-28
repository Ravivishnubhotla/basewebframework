<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdvertisementAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdvertisementAdd" %>
<ext:Window ID="winSPAdvertisementAdd" runat="server" Icon="ApplicationAdd" Title="SPAdvertisement Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdvertisementAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtImageUrl" runat="server" FieldLabel="ImageUrl" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtAdPrice" runat="server" FieldLabel="AdPrice" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtAccountType" runat="server" FieldLabel="AccountType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtApplyStatus" runat="server" FieldLabel="ApplyStatus" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtAdType" runat="server" FieldLabel="AdType" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtAdText" runat="server" FieldLabel="AdText" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					                                         
                                            <ext:Checkbox ID="chkIsDisable" runat="server" FieldLabel="IsDisable" Checked="false"  AnchorHorizontal="95%"/>
                                       
				 
						<ext:NumberField ID="numAssignedClient" runat="server" FieldLabel="AssignedClient"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numCreateBy" runat="server" FieldLabel="CreateBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="txtCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="radnumLastModifyBy" runat="server" FieldLabel="LastModifyBy"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="txtLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="True"   AnchorHorizontal="95%"/>
                
			
						<ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="LastModifyComment" AllowBlank="False"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdvertisement" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdvertisementAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdvertisement_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdvertisementAdd}.getForm().reset();#{storeSPAdvertisement}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdvertisement" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdvertisementAdd}.getForm().reset();#{winSPAdvertisementAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
