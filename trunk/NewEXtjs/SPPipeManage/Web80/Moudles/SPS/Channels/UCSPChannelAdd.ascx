<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.UCSPChannelAdd" %>
<ext:Window ID="winSPChannelAdd" runat="server" Icon="ApplicationAdd" Title="新建通道"
    ConstrainHeader="true" Width="500" Height="350" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPChannelAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPChannel" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtArea" runat="server" FieldLabel="支持省份" Hidden="true" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtChannelCode" runat="server" FieldLabel="通道编码" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbChannelCodeParamsName" Editable="false" runat="server" FieldLabel="通道映射字段"
                                    AllowBlank="True" TriggerAction="All" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="cpid" Text="cpid"></ext:ListItem>
                                        <ext:ListItem Value="mid" Text="mid"></ext:ListItem>
                                        <ext:ListItem Value="mobile" Text="mobile"></ext:ListItem>
                                        <ext:ListItem Value="port" Text="port"></ext:ListItem>
                                        <ext:ListItem Value="ywid" Text="ywid"></ext:ListItem>
                                        <ext:ListItem Value="msg" Text="msg"></ext:ListItem>
                                        <ext:ListItem Value="linkid" Text="linkid"></ext:ListItem>
                                        <ext:ListItem Value="dest" Text="dest"></ext:ListItem>
                                        <ext:ListItem Value="price" Text="price"></ext:ListItem>
                                        <ext:ListItem Value="extendfield1" Text="extendfield1"></ext:ListItem>
                                        <ext:ListItem Value="extendfield2" Text="extendfield2"></ext:ListItem>
                                        <ext:ListItem Value="extendfield3" Text="extendfield3"></ext:ListItem>
                                        <ext:ListItem Value="extendfield4" Text="extendfield4"></ext:ListItem>
                                        <ext:ListItem Value="extendfield5" Text="extendfield5"></ext:ListItem>
                                        <ext:ListItem Value="extendfield6" Text="extendfield6"></ext:ListItem>
                                        <ext:ListItem Value="extendfield7" Text="extendfield7"></ext:ListItem>
                                        <ext:ListItem Value="extendfield8" Text="extendfield8"></ext:ListItem>
                                        <ext:ListItem Value="extendfield9" Text="extendfield9"></ext:ListItem>
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
                                <ext:TextField ID="txtFuzzyCommand" runat="server" FieldLabel="提交别名" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtPort" runat="server" FieldLabel="端口"  Hidden="true" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtChannelType" runat="server" FieldLabel="通道类型"  Hidden="true" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtPrice" runat="server" FieldLabel="单价" Text="1"  Hidden="true" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtRate" runat="server" FieldLabel="分成比例"  Text="45"  Hidden="true" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtOkMessage" runat="server" FieldLabel="成功响应消息" Text="ok" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="失败响应消息" Text="failed" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIsAllowNullLinkID" runat="server" FieldLabel="允许空ID" Checked="false" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPChannelAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannel_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了通道。',callback);function callback(id) {#{formPanelSPChannelAdd}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
