<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsAdd" %>
<ext:Window ID="winSPChannelParamsAdd" runat="server" Icon="ApplicationAdd" Title="SPChannelParams Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					                                         
                                            <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsRequired" runat="server" FieldLabel="IsRequired" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtParamsType" runat="server" FieldLabel="ParamsType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsMappingName" runat="server" FieldLabel="ParamsMappingName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtTitle" runat="server" FieldLabel="Title" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkShowInClientGrid" runat="server" FieldLabel="ShowInClientGrid" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtParamsValue" runat="server" FieldLabel="ParamsValue" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannelParams" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannelParams_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPChannelParamsAdd}.getForm().reset();#{storeSPChannelParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParams" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsAdd}.getForm().reset();#{winSPChannelParamsAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
