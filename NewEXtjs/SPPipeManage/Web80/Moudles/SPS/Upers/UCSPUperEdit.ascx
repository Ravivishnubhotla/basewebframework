<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPUperEdit.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Upers.UCSPUperEdit" %>
<ext:Window ID="winSPUperEdit" runat="server" Icon="ApplicationEdit" Title="编辑上家"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPUperEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPUper" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
							<ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                           			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtID" runat="server" FieldLabel="ID" AllowBlank="False"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"   />
             </ext:Anchor> 
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"   />
                    </ext:Anchor>
 

 
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPUper" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPUperEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPUper_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了上家。',callback);function callback(id) { #{storeSPUper}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPUper" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPUperEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

