<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsEdit" %>

<ext:Window ID="winSPChannelParamsEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPChannelParams"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
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
        <ext:Button ID="btnSaveSPChannelParams" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParams_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelParamsEdit}.getForm().reset();#{storeSPChannelParams}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParams" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsEdit}.getForm().reset();#{winSPChannelParamsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

