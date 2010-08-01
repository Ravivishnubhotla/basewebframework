<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPMemoEdit.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Memos.UCSPMemoEdit" %>
<ext:Window ID="winSPMemoEdit" runat="server" Icon="ApplicationEdit" Title="编辑SPMemo"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPMemoEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPMemo" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
							<ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                           			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtTitle" runat="server" FieldLabel="标题" AllowBlank="False"   />
             </ext:Anchor> 
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtMemoContent" runat="server" FieldLabel="内容" AllowBlank="True"   />
                    </ext:Anchor>
                 <ext:Anchor Horizontal="95%"> 
						<ext:DateField  ID="txtCreateDate" runat="server" FieldLabel="发布日期" AllowBlank="True"    />
                </ext:Anchor> 


                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPMemo" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPMemoEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPMemo_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SPMemo。',callback);function callback(id) { #{storeSPMemo}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPMemo" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPMemoEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>