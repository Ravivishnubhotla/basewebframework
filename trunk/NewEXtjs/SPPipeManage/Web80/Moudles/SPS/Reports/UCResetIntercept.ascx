<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResetIntercept.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.UCResetIntercept" %>
<ext:Window ID="winResetIntercept" runat="server" Icon="ApplicationAdd" Title="取消扣量同步下家"
    ConstrainHeader="true" Width="500" Height="220" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formResetIntercept" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayoutResetIntercept" runat="server" LabelSeparator=":" LabelWidth="100">
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
                                <ext:Label ID="lblDownCount" runat="server" FieldLabel="点播数" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblSycnCount" runat="server" FieldLabel="扣量" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="numMaxCount" runat="server" FieldLabel="最大取消数" MinValue="1"
                                    MaxValue="100" DecimalPrecision="0" Text="5">
                                </ext:NumberField>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnResetIntercept" runat="server" Text="取消扣量同步下家" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formResetIntercept}.getForm().isValid()) return false;" OnEvent="btnResetIntercept_Click"
                    Success="Ext.MessageBox.alert('操作成功', '取消扣量同步下家，稍后立即发送。',callback);function callback(id) {#{formResetIntercept}.getForm().reset(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="重置保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelResetIntercept" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winResetIntercept}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
