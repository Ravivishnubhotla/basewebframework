<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingFiltersEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingFiltersEdit" %>
<ext:Window ID="winSPClientChannelSettingFiltersEdit" runat="server" Icon="ApplicationEdit"
    Title="编辑SPClientChannelSettingFilters" Width="390" Height="120" AutoShow="false"
    Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingFiltersEdit" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientChannelSettingFilters" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbFilterProvince" Editable="true" runat="server" FieldLabel="过滤省份"
                                    AllowBlank="false" TriggerAction="All">
                                    <Items>
                                        <ext:ListItem Value="自定义区域1" Text="自定义区域1"></ext:ListItem>
                                        <ext:ListItem Value="其他" Text="其他"></ext:ListItem>
                                    </Items>
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
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChannelSettingFilters" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelSettingFiltersEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientChannelSettingFilters_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SPClientChannelSettingFilters。',callback);function callback(id) { #{storeSPClientChannelSettingFilters}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChannelSettingFilters" runat="server" Text="取消"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingFiltersEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
