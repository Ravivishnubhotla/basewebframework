<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingPatchAdd1.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingPatchAdd1" %>
<script type="text/javascript">
    function ChangeCodeType(codeType, chkHasSubCode, numOrderIndex, txtSubCode) {
        if (codeType == "1") {
            chkHasSubCode.hide();
            txtSubCode.hide();
            numOrderIndex.setValue("1");
            chkHasSubCode.setValue(false);
        }
        else {
            chkHasSubCode.show();
            txtSubCode.show();
            numOrderIndex.setValue("1");
            chkHasSubCode.setValue(true);
        }
    }
</script>
<ext:Window ID="winSPChannelClientSetingQuickAdd" runat="server" Icon="ApplicationAdd"
    Title="快速添加指令" ConstrainHeader="true" Width="450" Height="330" AutoShow="false"
    Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formSPChannelClientSetingQuickAdd" runat="server" Frame="true"
                AutoScroll="true" Header="false" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPSendClientParams" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtLoginID" runat="server" FieldLabel="登陆ID" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbCodeType" Editable="false" runat="server" FieldLabel="指令类型"
                                    AllowBlank="false" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="1" Text="精准指令"></ext:ListItem>
                                        <ext:ListItem Value="2" Text="模糊指令"></ext:ListItem>
                                    </Items>
                                    <Listeners>
                                        <Select Handler="ChangeCodeType(#{cmbCodeType}.getValue(),#{chkHasSubCode},#{numOrderIndex},#{txtSubCode});" />
                                    </Listeners>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtCode" runat="server" FieldLabel="指令" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="numOrderIndex" runat="server" FieldLabel="指令序号" AllowBlank="false"
                                    Text="1" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtChannelCode" runat="server" FieldLabel="通道号" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkHasSubCode" runat="server" FieldLabel="是否包含子指令" Checked="false"
                                    Hidden="true">
                                    <Listeners>
                                        <Check Handler="if (#{chkHasSubCode}.getValue()){#{txtSubCode}.setVisible(true);}else{#{txtSubCode}.setVisible(false);}" />
                                    </Listeners>
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtSubCode" runat="server" FieldLabel="子指令" AllowBlank="True" Note="多个指令使用|分隔，例：( 1|2|3 )"
                                    Hidden="true" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtAllowAndDisableArea" runat="server" FieldLabel="开通省份/屏蔽地市" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtGetway" runat="server" FieldLabel="运营商" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtDayLimit" runat="server" FieldLabel="日限制" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMonthLimit" runat="server" FieldLabel="月限制" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtSendText" runat="server" FieldLabel="下发语" AllowBlank="True" />
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
