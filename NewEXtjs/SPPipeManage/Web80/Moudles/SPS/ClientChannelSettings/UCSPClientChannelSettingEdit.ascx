<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingEdit.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingEdit" %>
<ext:Window ID="winSPClientChannelSettingEdit" runat="server" Icon="ApplicationEdit" Title="编辑SPClientChannelSetting"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientChannelSetting" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
							<ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                           			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="通道" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtClinetID" runat="server" FieldLabel="下家" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="扣率" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtUpRate" runat="server" FieldLabel="上行费率" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtDownRate" runat="server" FieldLabel="下行费率" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtCommandType" runat="server" FieldLabel="指令类型" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtCommandCode" runat="server" FieldLabel="指令代码" AllowBlank="True"   />
             </ext:Anchor> 


                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChannelSetting" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelSettingEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientChannelSetting_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SPClientChannelSetting。',callback);function callback(id) { #{storeSPClientChannelSetting}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChannelSetting" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

