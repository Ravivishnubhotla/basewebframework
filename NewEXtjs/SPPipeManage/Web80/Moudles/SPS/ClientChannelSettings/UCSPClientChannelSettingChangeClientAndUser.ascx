<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingChangeClientAndUser.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingChangeClientAndUser" %>
<ext:Window ID="winSPClientChannelSettingChangeClientAndUser" runat="server" Icon="UserGo"
    Title="更换下家用户" ConstrainHeader="true" Width="600" Height="320" AutoShow="false"
    Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingChangeClientAndUser" runat="server"
                Frame="true" Header="false" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClient" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat="server" FieldLabel="所属通道" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblCode" runat="server" FieldLabel="指令" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblOldClientName" runat="server" FieldLabel="原下家名" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblOldLoginUserID" runat="server" FieldLabel="原登录用户ID" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtLoginUserID" runat="server" FieldLabel="新登陆用户ID" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtLoginPassword" runat="server" FieldLabel="新登陆用户密码" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtClientName" runat="server" FieldLabel="新下家名" AllowBlank="true"
                                    Hidden="true" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtClientAlias" runat="server" FieldLabel="新下家显示名" AllowBlank="False" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClient" runat="server" Text="更换" Icon="UserGo">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelSettingChangeClientAndUser}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClient_Click" Success="Ext.MessageBox.alert('操作成功', '成功的更换了下家用户。',callback);function callback(id) {#{formPanelSPClientChannelSettingChangeClientAndUser}.getForm().reset();#{storeSPClientChannelSetting}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingChangeClientAndUser}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
