<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigEdit" %>


<ext:Window ID="winSystemConfigEdit" runat="server" Icon="ApplicationEdit" Title="EditSystemConfig"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidSystemConfigID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtConfigKey" runat="server" FieldLabel="Key" AllowBlank="True"  AnchorHorizontal="95%" ReadOnly=true  />
              
			
						<ext:TextField ID="txtConfigValue" runat="server" FieldLabel="Value" AllowBlank="True"  AnchorHorizontal="95%"/>
              
					
						<ext:TextArea ID="txtConfigDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
				 
						<ext:NumberField ID="numSortIndex" runat="server" FieldLabel="Sort Index"  AllowBlank="false"   AnchorHorizontal="95%"/>
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemConfig" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemConfig_Click" Success="Ext.MessageBox.alert('Operation successful', 'Updated System Config Successful。',callback);function callback(id) {#{formPanelSystemConfigEdit}.getForm().reset();#{storeSystemConfig}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

