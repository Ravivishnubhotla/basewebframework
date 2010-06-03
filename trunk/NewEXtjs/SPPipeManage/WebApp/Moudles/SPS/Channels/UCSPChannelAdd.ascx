<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelAdd" %>
<ext:Window ID="winSPChannelAdd" runat="server" Icon="ApplicationAdd" Title="添加SP通道"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False"  AnchorHorizontal="95%" />
              			<ext:TextField ID="txtArea" runat="server" FieldLabel="支持区域" AllowBlank="True"  AnchorHorizontal="95%" />
			            <ext:TextArea ID="txtDecription" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%"  height="130"   />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannel" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannel_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add SPChannel Success ' ,callback);function callback(id) {#{formPanelSPChannelAdd}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
