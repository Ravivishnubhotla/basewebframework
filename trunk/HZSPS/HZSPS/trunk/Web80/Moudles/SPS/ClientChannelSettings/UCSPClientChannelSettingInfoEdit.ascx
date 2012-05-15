<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingInfoEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingInfoEdit" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
<script type="text/javascript">
    function CheckDayTotalLimit(checkValue) {
        var txtDayTotalLimit = <%= txtDayTotalLimit.ClientID %>;
        if (!checkValue) {
            txtDayTotalLimit.hide();
        }
        else {
            txtDayTotalLimit.show();
        }
    }
</script>
<ext:Window ID="winSPClientChannelSettingInfoEdit" runat="server" Icon="ApplicationEdit"
    ConstrainHeader="true" Title="设置指令" Width="640" Height="399" AutoShow="false"
    Maximizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingAdd" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayout4" runat="server">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblName" runat="server" FieldLabel="名称" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat="server" FieldLabel="通道">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientName" runat="server" FieldLabel="下家">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientGroupName" runat="server" FieldLabel="下家组">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelClientCode" runat="server" FieldLabel="指令" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkHasDayTotalLimit" runat="server" FieldLabel="日总限量">
                                    <Listeners>
                                        <Check Handler="CheckDayTotalLimit(#{chkHasDayTotalLimit}.getValue());"></Check>
                                    </Listeners>
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtDayTotalLimit" MinValue="0" DecimalPrecision="0" runat="server"
                                    FieldLabel="日总限量" Hidden="True" AllowBlank="True" />
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
                <Click Before="if(!#{formPanelSPClientChannelSettingAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientChannelSetting_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了指令设置。',RefreshSPClientChannelSettingData);
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChannelSetting" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingInfoEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
