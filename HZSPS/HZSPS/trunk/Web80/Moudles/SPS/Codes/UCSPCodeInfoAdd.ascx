<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeInfoAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Codes.UCSPCodeInfoAdd" %>
<ext:Window ID="winSPCodeInfoAdd" runat="server" Icon="ApplicationAdd" Title="新建通道信息"
    Width="600" Height="470" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPCodeInfoAdd" runat="server" Frame="true" Header="false" AutoScroll="True"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPCodeInfo" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" FieldLabel="上家"
                                    StoreID="storeSPChannel" TypeAhead="true" Mode="Local"  Editable="True" ForceSelection="True" DisplayField="Name"
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
                                <ext:ComboBox ID="cmbOperatorType" Editable="false" runat="server" FieldLabel="运营商"
                                    AllowBlank="False" TriggerAction="All" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="移动" Text="移动"></ext:ListItem>
                                        <ext:ListItem Value="联通" Text="联通"></ext:ListItem>
                                        <ext:ListItem Value="电信" Text="电信"></ext:ListItem>
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
                            <ext:Anchor Horizontal="95%">
                                <ext:MultiField ID="mfCode" runat="server" FieldLabel="指令">
                                    <Fields>
                                        <ext:Label ID="lblStart" runat="server" Text="指令：" />
                                        <ext:TextField ID="txtMo" runat="server" AllowBlank="False" Width="90" />
                                        <ext:Label ID="Label4" runat="server" Text="类型：" />
                                        <ext:ComboBox ID="cmbCodeType" Editable="false" runat="server" AllowBlank="False" TriggerAction="All"
                                            SelectedIndex="0" Width="70">
                                            <Items>
                                                <ext:ListItem Value="模糊" Text="模糊"></ext:ListItem>
                                                <ext:ListItem Value="精准" Text="精准"></ext:ListItem>
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
                                        <ext:Label ID="Label1" runat="server" Text="端口号：" />
                                        <ext:TextField ID="txtSPCode" runat="server" AllowBlank="False" Width="90" />
                                    </Fields>
                                </ext:MultiField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtProvince" runat="server" FieldLabel="开通省份" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDisableArea" runat="server" FieldLabel="屏蔽地市" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:CheckBox ID="chkIsLimit" runat="server" FieldLabel="限量" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDayMonthLimit" runat="server" FieldLabel="日限月限" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtSendText" runat="server" FieldLabel="下发语" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:CheckBox ID="chkIsEnable" runat="server" FieldLabel="可用"  Checked="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtPrice" runat="server" FieldLabel="价格" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtComent" runat="server" FieldLabel="备注" AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPCodeInfo" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPCodeInfoAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPCodeInfo_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了通道信息。',callback);function callback(id) {#{formPanelSPCodeInfoAdd}.getForm().reset();#{storeSPCodeInfo}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCodeInfo" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPCodeInfoAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
