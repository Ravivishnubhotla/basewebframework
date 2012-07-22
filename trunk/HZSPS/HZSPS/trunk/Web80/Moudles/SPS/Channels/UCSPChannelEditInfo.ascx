<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelEditInfo.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.UCSPChannelEditInfo" %>
<ext:Window ID="winSPChannelEditInfo" runat="server" Icon="ApplicationEdit" Title="通道上家分配"
    ConstrainHeader="true" Width="500" Height="220" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPChannelEditInfo" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPChannel" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbUpperID" runat="server" AllowBlank="true" FieldLabel="上家" StoreID="storeSPUper"
                                    TypeAhead="true" Mode="Local" Editable="True" ForceSelection="True" DisplayField="Name"
                                    ValueField="Id" EmptyText="全部">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="numRate" FieldLabel="默认扣率" runat="server" AllowDecimals="true"
                                    DecimalPrecision="0">
                                </ext:NumberField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtPrice" runat="server" FieldLabel="单价" DecimalPrecision="2" AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPChannelEditInfo}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannel_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了通道。',callback);function callback(id) { #{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelEditInfo}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
