

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPUpperEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Uppers.UCSPUpperEdit" %>

<ext:Window ID="winSPUpperEdit" runat="server" Icon="ApplicationEdit" Title="编辑上家"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPUpperEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="False"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="False"  AnchorHorizontal="95%"/>
                   
				 
 

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPUpper" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPUpperEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPUpper_Click" Success="Ext.MessageBox.alert('操作成功', '更新记录成功',callback);function callback(id) {#{formPanelSPUpperEdit}.getForm().reset();#{storeSPUpper}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请等待....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPUpper" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPUpperEdit}.getForm().reset();#{winSPUpperEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>







