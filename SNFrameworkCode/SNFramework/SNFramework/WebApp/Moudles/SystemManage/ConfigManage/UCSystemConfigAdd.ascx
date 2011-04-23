<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigAdd" %>


<ext:Window ID="winSystemConfigAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtConfigKey" runat="server" FieldLabel="<%$ Resources:msgFiledKeyTitle %>" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtConfigValue" runat="server" FieldLabel="<%$ Resources:msgFiledValueTitle %>" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtConfigDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescriptionTitle %>" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
				 
						<ext:NumberField ID="numSortIndex" runat="server" FieldLabel="<%$ Resources:msgFiledSortIndexTitle %>"  AllowBlank="false"   AnchorHorizontal="95%"/>
                 	

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemConfig_Click"
                    Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>