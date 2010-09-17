<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingPatchAdd1.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingPatchAdd1" %>
<ext:Window ID="winSPChannelClientSetingQuickAdd" runat="server" Icon="ApplicationAdd" Title="新建下家参数"  ConstrainHeader=true
    Width="400" Height="330" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formSPChannelClientSetingQuickAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPSendClientParams" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtLoginID" runat="server" FieldLabel="登陆ID" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtCode" runat="server" FieldLabel="指令" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtSubCode" runat="server" FieldLabel="子指令" AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPSendClientParams" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formSPChannelClientSetingQuickAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPSendClientParams_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家参数。',callback);function callback(id) {#{formSPChannelClientSetingQuickAdd}.getForm().reset();#{storeSPClientChannelSetting}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSendClientParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelClientSetingQuickAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
