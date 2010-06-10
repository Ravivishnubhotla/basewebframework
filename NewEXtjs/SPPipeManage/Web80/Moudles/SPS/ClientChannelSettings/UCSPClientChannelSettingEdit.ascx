<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingEdit" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
<ext:Window ID="winSPClientChannelSettingEdit" runat="server" Icon="ApplicationEdit"
    Title="编辑通道下家设置" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingEdit" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientChannelSetting" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat=server  FieldLabel="通道"></ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientName" runat=server  FieldLabel="下家"></ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtInterceptRate" runat="server" FieldLabel="扣率(%)" AllowBlank="False"
                                    Text="50" DecimalPrecision="0" MinValue="1" MaxValue="99" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbCommandType" runat="server" FieldLabel="指令匹配规则" AllowBlank="False"
                                    Editable="false" TypeAhead="true" ForceSelection="true" Mode="Local" TriggerAction="All"
                                    EmptyText="请选择指令匹配规则">
                                    <Items>
                                        <ext:ListItem Text="完全匹配" Value="1" />
                                        <ext:ListItem Text="包含" Value="2" />
                                        <ext:ListItem Text="以开头" Value="3" />
                                        <ext:ListItem Text="以结尾" Value="4" />
                                        <ext:ListItem Text="正则表达式" Value="5" />
                                        <ext:ListItem Text="自定义解析" Value="6" />
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtCommandCode" runat="server" FieldLabel="指令代码" AllowBlank="True" />
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
