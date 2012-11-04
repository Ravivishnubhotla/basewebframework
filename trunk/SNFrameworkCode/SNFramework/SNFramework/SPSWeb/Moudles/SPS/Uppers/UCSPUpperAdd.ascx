

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPUpperAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Uppers.UCSPUpperAdd" %>
<ext:Window ID="winSPUpperAdd" runat="server" Icon="ApplicationAdd" Title="上家添加"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPUpperAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="False"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="False"  AnchorHorizontal="95%"/>
                   
				 
<%--						<ext:NumberField ID="numCreateBy" runat="server" FieldLabel="CreateBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numLastModifyBy" runat="server" FieldLabel="LastModifyBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
			
						<ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="LastModifyComment" AllowBlank="False"  AnchorHorizontal="95%" />
              --%>

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPUpper" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPUpperAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPUpper_Click"
                    Success="Ext.MessageBox.alert('操作成功', '添加记录成功' ,callback);function callback(id) {#{formPanelSPUpperAdd}.getForm().reset();#{storeSPUpper}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请等待....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPUpper" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPUpperAdd}.getForm().reset();#{winSPUpperAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
 

