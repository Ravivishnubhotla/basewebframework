<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPMemoEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Memos.UCSPMemoEdit" %>
<ext:Window ID="winSPMemoEdit" runat="server" Icon="ApplicationEdit" Title="SPMemo Edit"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPMemoEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtTitle" runat="server" FieldLabel="标题" AllowBlank="False"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtMemoContent" runat="server" FieldLabel="内容" AllowBlank="True"  AnchorHorizontal="95%"/>
                   

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPMemo" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPMemoEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPMemo_Click" Success="Ext.MessageBox.alert('操作成功', ' Update SPMemo Success',callback);function callback(id) {#{formPanelSPMemoEdit}.getForm().reset();#{storeSPMemo}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPMemo" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPMemoEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
