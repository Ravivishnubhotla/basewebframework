<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigEdit" %>


<ext:Window ID="winSystemConfigEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidSystemConfigID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
		
						<ext:TextField ID="txtConfigKey" runat="server" FieldLabel="<%$ Resources:msgFiledKeyTitle %>" AllowBlank="True"  AnchorHorizontal="95%" ReadOnly=true  />
              
			
						<ext:TextField ID="txtConfigValue" runat="server" FieldLabel="<%$ Resources:msgFiledValueTitle %>" AllowBlank="True"  AnchorHorizontal="95%"/>
              
					
						<ext:TextArea ID="txtConfigDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescriptionTitle %>" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
				 
						<ext:NumberField ID="numSortIndex" runat="server" FieldLabel="<%$ Resources:msgFiledSortIndexTitle %>"  AllowBlank="false"   AnchorHorizontal="95%"/>
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemConfig_Click"  Success="<%$ Resources:msgUpdateScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

