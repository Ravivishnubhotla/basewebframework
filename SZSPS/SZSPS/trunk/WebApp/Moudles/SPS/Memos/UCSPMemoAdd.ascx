<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPMemoAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Memos.UCSPMemoAdd" %>
<ext:Window ID="winSPMemoAdd" runat="server" Icon="ApplicationAdd" Title="添加备注"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPMemoAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtTitle" runat="server" FieldLabel="标题" AllowBlank="False"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtMemoContent" runat="server" FieldLabel="内容" AllowBlank="True"  AnchorHorizontal="95%"/>
                   

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPMemo" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPMemoAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPMemo_Click"
                    Success="Ext.MessageBox.alert('操作成功', '添加备注成功' ,callback);function callback(id) {#{formPanelSPMemoAdd}.getForm().reset();#{storeSPMemo}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPMemo" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPMemoAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>