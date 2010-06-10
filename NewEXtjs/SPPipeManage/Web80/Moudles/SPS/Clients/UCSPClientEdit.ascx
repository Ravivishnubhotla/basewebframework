<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientEdit.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPClientEdit" %>
<ext:Window ID="winSPClientEdit" runat="server" Icon="ApplicationEdit" Title="编辑下家"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClient" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
							<ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                           			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="接收数据接口" AllowBlank="True"   />
             </ext:Anchor> 
 


                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClient" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClient_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了下家。',callback);function callback(id) { #{storeSPClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>


