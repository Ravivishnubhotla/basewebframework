<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigAdd" %>


<ext:Window ID="winSystemConfigAdd" runat="server" Icon="ApplicationAdd" Title="System Config Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtConfigKey" runat="server" FieldLabel="Key" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtConfigValue" runat="server" FieldLabel="Value" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtConfigDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
				 
						<ext:NumberField ID="numSortIndex" runat="server" FieldLabel="Sort Index"  AllowBlank="false"   AnchorHorizontal="95%"/>
                 	

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemConfig" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemConfig_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add System Config Successful ' ,callback);function callback(id) {#{formPanelSystemConfigAdd}.getForm().reset();#{storeSystemConfig}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>