<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResetSycTimes.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.UCResetSycTimes" %>
<ext:Window ID="winResetSycTimes" runat="server" Icon="ApplicationAdd" Title="重新发送数据"
    ConstrainHeader="true" Width="500" Height="220" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formResetSycTimes" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayoutResetSycTimes" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidClientChannelID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannleName" runat="server" FieldLabel="通道名" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientName" runat="server" FieldLabel="下家名" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblDownCount" runat="server" FieldLabel="转发下家数" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblSycnCount" runat="server" FieldLabel="同步下家数" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblSycnFailedCount" runat="server" FieldLabel="同步下家失败数" AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnResetSycTimes" runat="server" Text="重新发送" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formResetSycTimes}.getForm().isValid()) return false;" OnEvent="btnResetSycTimes_Click"
                    Success="Ext.MessageBox.alert('操作成功', '所有发送失败数据重置，稍后立即发送。',callback);function callback(id) {#{formResetSycTimes}.getForm().reset(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="重置保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelResetSycTimes" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winResetSycTimes}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
