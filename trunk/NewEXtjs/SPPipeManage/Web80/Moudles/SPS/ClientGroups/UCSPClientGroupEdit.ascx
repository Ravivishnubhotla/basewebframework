<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientGroupEdit.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.UCSPClientGroupEdit" %>
<ext:Window ID="winSPClientGroupEdit" runat="server" Icon="ApplicationEdit" Title="编辑下家组"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientGroupEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientGroup" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
							<ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                           			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"   />
             </ext:Anchor> 
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientGroup" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientGroupEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientGroup_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SPClientGroup。',callback);function callback(id) { #{storeSPClientGroup}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientGroup" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientGroupEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

