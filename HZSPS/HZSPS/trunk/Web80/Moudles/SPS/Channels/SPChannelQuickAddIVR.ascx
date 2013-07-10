<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SPChannelQuickAddIVR.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelQuickAddIVR" %>
<ext:Window ID="winSPChannelQuickAdd" runat="server" Icon="ApplicationAdd" Title="快速添加IVR通道"
    ConstrainHeader="true" Width="700" Height="399" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPChannelQuickAdd" runat="server" Frame="true" Header="false"
                MonitorPoll="500" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:Panel ID="Panel3" runat="server">
                        <Body>
                            <ext:ColumnLayout ID="ColumnLayout1" runat="server">
                                <ext:LayoutColumn ColumnWidth=".5">
                                    <ext:Panel ID="Panel1" runat="server" Border="false" Header="false">
                                        <Body>
                                            <ext:FormLayout ID="FormLayout1" runat="server" LabelWidth="100">
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtFuzzyCommand" runat="server" FieldLabel="提交别名" AllowBlank="True" />
                                                </ext:Anchor>
                                            </ext:FormLayout>
                                        </Body>
                                    </ext:Panel>
                                </ext:LayoutColumn>
                                <ext:LayoutColumn ColumnWidth=".5">
                                    <ext:Panel ID="Panel2" runat="server" Border="false">
                                        <Body>
                                            <ext:FormLayout ID="FormLayout2" runat="server" LabelWidth="100">
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtChannelCode" runat="server" FieldLabel="通道编码" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Checkbox ID="chkIsAllowNullLinkID" runat="server" FieldLabel="允许空ID" Checked="false" />
                                                </ext:Anchor>
                                            </ext:FormLayout>
                                        </Body>
                                    </ext:Panel>
                                </ext:LayoutColumn>
                            </ext:ColumnLayout>
                        </Body>
                    </ext:Panel>
                    <ext:Panel ID="Panel4" runat="server">
                        <Body>
                            <ext:ColumnLayout ID="ColumnLayout2" runat="server">
                                <ext:LayoutColumn ColumnWidth=".5">
                                    <ext:Panel ID="Panel5" runat="server" Border="false" Header="false">
                                        <Body>
                                            <ext:FormLayout ID="FormLayout3" runat="server" LabelWidth="100">
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtLinkParamsName" runat="server" FieldLabel="LinkID字段" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtMobileParamsName" runat="server" FieldLabel="Mobile字段" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtFeeTimeParamsName" runat="server" FieldLabel="FeeTime字段" AllowBlank="True" />
                                                </ext:Anchor>
                                            </ext:FormLayout>
                                        </Body>
                                    </ext:Panel>
                                </ext:LayoutColumn>
                                <ext:LayoutColumn ColumnWidth=".5">
                                    <ext:Panel ID="Panel6" runat="server" Border="false">
                                        <Body>
                                            <ext:FormLayout ID="FormLayout4" runat="server" LabelWidth="100">
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtSPcodeParamsName" runat="server" FieldLabel="SPcode字段" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtStartTimeParamsName" runat="server" FieldLabel="StartTime字段" AllowBlank="True" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtEndTimeParamsName" runat="server" FieldLabel="EndTime字段" AllowBlank="True" />
                                                </ext:Anchor>
                                            </ext:FormLayout>
                                        </Body>
                                    </ext:Panel>
                                </ext:LayoutColumn>
                            </ext:ColumnLayout>
                        </Body>
                    </ext:Panel>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPChannelQuickAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannel_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了IVR通道。',callback);function callback(id) {#{formPanelSPChannelQuickAdd}.getForm().reset();#{storeSPChannel}.reload();#{winSPChannelQuickAdd}.hide(); };
"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelQuickAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
