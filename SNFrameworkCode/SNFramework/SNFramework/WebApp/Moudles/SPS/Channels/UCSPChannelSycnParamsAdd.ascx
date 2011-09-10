<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelSycnParamsAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelSycnParamsAdd" %>
<ext:Window ID="winSPChannelSycnParamsAdd" runat="server" Icon="ApplicationAdd" Title="SPChannelSycnParams Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelSycnParamsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					                                         
                                            <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMappingParams" runat="server" FieldLabel="MappingParams" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtTitle" runat="server" FieldLabel="Title" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsValue" runat="server" FieldLabel="ParamsValue" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsType" runat="server" FieldLabel="ParamsType" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannelSycnParams" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelSycnParamsAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannelSycnParams_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPChannelSycnParamsAdd}.getForm().reset();#{storeSPChannelSycnParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelSycnParams" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelSycnParamsAdd}.getForm().reset();#{winSPChannelSycnParamsAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>