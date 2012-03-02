<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelEdit" %>
<ext:Window ID="winSPChannelEdit" runat="server" Icon="ApplicationEdit" Title="编辑SP通道"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
			
              
			
						<ext:TextField ID="txtArea" runat="server" FieldLabel="支持区域" AllowBlank="True"  AnchorHorizontal="95%" />
						
						
									<ext:TextArea ID="txtDecription" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%"  height="130"  />
             
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannel_Click" Success="Ext.MessageBox.alert('操作成功', ' 更新通道成功！',callback);function callback(id) {#{formPanelSPChannelEdit}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中g....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
