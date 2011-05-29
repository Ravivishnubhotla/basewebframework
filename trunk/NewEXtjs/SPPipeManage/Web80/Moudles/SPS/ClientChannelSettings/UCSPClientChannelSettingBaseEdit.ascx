<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingBaseEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingBaseEdit" %>
<ext:Window ID="winSPClientChannelSettingEdit" runat="server" Icon="ApplicationEdit"
    Title="设置指令信息" Width="640" Height="460" AutoShow="false" Maximizable="true" ConstrainHeader="true"
    Modal="true" ShowOnLoad="false" AutoScroll="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingAdd" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:ContainerLayout ID="ContainerLayout1" runat="server">
                        <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="false" Title="基本信息" Collapsed="false">
                            <Body>
                                <ext:FormPanel ID="pnlSPClientChannelSettingAdd1" runat="server">
                                    <Body>
                                        <ext:FormLayout ID="FormLayout4" runat="server">
                                            <Anchors>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Hidden ID="hidId" runat="server">
                                                    </ext:Hidden>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Label ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Label ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="False" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Label ID="txtShowCode" runat="server" FieldLabel="指令" AllowBlank="False" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Label ID="lblChanneCode" runat="server" FieldLabel="通道号" AllowBlank="true">
                                                    </ext:Label>
                                                </ext:Anchor>
                                            </Anchors>
                                        </ext:FormLayout>
                                    </Body>
                                </ext:FormPanel>
                                <ext:Panel ID="Panel1" runat="server">
                                    <Body>
                                        <ext:ColumnLayout ID="ColumnLayout1" runat="server">
                                            <ext:LayoutColumn ColumnWidth=".5">
                                                <ext:FormPanel ID="pnlSPClientChannelSettingAdd2" runat="server" Border="false" Header="false">
                                                    <Body>
                                                        <ext:FormLayout ID="FormLayout2" runat="server">
                                                            <Anchors>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:Label ID="lblChannelName" runat="server" FieldLabel="通道">
                                                                    </ext:Label>
                                                                </ext:Anchor>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:Checkbox ID="chkDisable" runat="server" FieldLabel="禁用">
                                                                    </ext:Checkbox>
                                                                </ext:Anchor>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:NumberField ID="txtInterceptRate" runat="server" FieldLabel="扣率(%)" AllowBlank="False"
                                                                        Text="50" DecimalPrecision="0" MinValue="0" MaxValue="100" />
                                                                </ext:Anchor>
                                                            </Anchors>
                                                        </ext:FormLayout>
                                                    </Body>
                                                </ext:FormPanel>
                                            </ext:LayoutColumn>
                                            <ext:LayoutColumn ColumnWidth=".5">
                                                <ext:FormPanel ID="pnlSPClientChannelSettingAdd3" runat="server">
                                                    <Body>
                                                        <ext:FormLayout ID="FormLayout3" runat="server">
                                                            <Anchors>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:Label ID="lblClientName" runat="server" FieldLabel="下家">
                                                                    </ext:Label>
                                                                </ext:Anchor>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:Checkbox ID="chkAllowFilter" runat="server" FieldLabel="允许省份过滤">
                                                                    </ext:Checkbox>
                                                                </ext:Anchor>
                                                                <ext:Anchor Horizontal="95%">
                                                                    <ext:Hidden ID="txtChannleCode" runat="server" FieldLabel="通道号" AllowBlank="true">
                                                                    </ext:Hidden>
                                                                </ext:Anchor>
                                                            </Anchors>
                                                        </ext:FormLayout>
                                                    </Body>
                                                </ext:FormPanel>
                                            </ext:LayoutColumn>
                                        </ext:ColumnLayout>
                                    </Body>
                                </ext:Panel>
                            </Body>
                        </ext:FieldSet>
                        <ext:FieldSet ID="fsAllowSycnData" runat="server" CheckboxToggle="true" Title="允许同步数据"
                            Collapsed="true">
                            <Body>
                                <ext:FormLayout ID="FormLayout1" runat="server" LabelSeparator=":" LabelWidth="100">
                                    <ext:Anchor Horizontal="95%">
                                        <ext:TextField ID="txtSyncDataUrl" runat="server" FieldLabel="数据同步URL" AllowBlank="true">
                                        </ext:TextField>
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:TextField ID="txtOkMessage" runat="server" FieldLabel="同步数据成功信息" AllowBlank="True" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="同步数据失败信息" AllowBlank="True" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbSycnType" Editable="false" runat="server" FieldLabel="同步数据类型"
                                            AllowBlank="True" SelectedIndex="0">
                                            <Items>
                                                <ext:ListItem Value="1" Text="即时同步"></ext:ListItem>
                                                <ext:ListItem Value="2" Text="异步同步"></ext:ListItem>
                                            </Items>
                                        </ext:ComboBox>
                                    </ext:Anchor>
                                </ext:FormLayout>
                            </Body>
                            <Listeners>
                                <Collapse Handler="#{txtSyncDataUrl}.setValue('');#{txtOkMessage}.setValue('');#{txtFailedMessage}.setValue('');#{cmbSycnType}.setValue('');" />
                            </Listeners>
                        </ext:FieldSet>
                    </ext:ContainerLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChannelSetting" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if (!AllValidate(#{pnlSPClientChannelSettingAdd1},#{pnlSPClientChannelSettingAdd2},#{pnlSPClientChannelSettingAdd3})) return false;"
                    OnEvent="btnSaveSPClientChannelSetting_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了通道下家设置。',RefreshSPClientChannelSettingData);
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
