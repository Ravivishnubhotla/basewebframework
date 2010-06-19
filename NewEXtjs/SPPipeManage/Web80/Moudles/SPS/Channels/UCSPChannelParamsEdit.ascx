<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.UCSPChannelParamsEdit" %>
<ext:Window ID="winSPChannelParamsEdit" runat="server" Icon="ApplicationEdit" Title="编辑通道参数"
    Width="400" Height="300" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPChannelParamsEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPChannelParams" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat="server" FieldLabel="所属通道" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="编码" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="是否可用" Checked="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIsRequired" runat="server" FieldLabel="是否必须" Checked="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbParamsType" Editable="false" runat="server" FieldLabel="参数类型"
                                    AllowBlank="True" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="普通参数" Text="普通参数"></ext:ListItem>
                                        <ext:ListItem Value="特殊参数" Text="特殊参数"></ext:ListItem>
                                        <ext:ListItem Value="扩展参数" Text="扩展参数"></ext:ListItem>
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbParamsMappingName" Editable="false" runat="server" FieldLabel="映射字段"
                                    AllowBlank="True" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="cpid" Text="cpid"></ext:ListItem>
                                        <ext:ListItem Value="mid" Text="mid"></ext:ListItem>
                                        <ext:ListItem Value="mobile" Text="mobile"></ext:ListItem>
                                        <ext:ListItem Value="port" Text="port"></ext:ListItem>
                                        <ext:ListItem Value="ywid" Text="ywid"></ext:ListItem>
                                        <ext:ListItem Value="msg" Text="msg"></ext:ListItem>
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
                                </ext:ComboBox>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPChannelParams" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPChannelParamsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParams_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了通道参数。',callback);function callback(id) { #{storeSPChannelParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelParamsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
