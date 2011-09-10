<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelSycnParamsEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelSycnParamsEdit" %>
<ext:Window ID="winSPChannelSycnParamsEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPChannelSycnParams"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelSycnParamsEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
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
        <ext:Button ID="btnSaveSPChannelSycnParams" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelSycnParamsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelSycnParams_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelSycnParamsEdit}.getForm().reset();#{storeSPChannelSycnParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelSycnParams" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelSycnParamsEdit}.getForm().reset();#{winSPChannelSycnParamsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>




