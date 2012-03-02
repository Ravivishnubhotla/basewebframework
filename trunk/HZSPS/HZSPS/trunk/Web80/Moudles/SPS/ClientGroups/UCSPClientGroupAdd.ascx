<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientGroupAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.UCSPClientGroupAdd" %>
<ext:Window ID="winSPClientGroupAdd" runat="server" Icon="ApplicationAdd" Title="新建下家组"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientGroupAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientGroup" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtDefaultSycnMoUrl" runat="server" FieldLabel="默认同步地址" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtDefaultInterceptRate" runat="server" FieldLabel="默认扣率" Text="5"
                                    DecimalPrecision="0" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtDefaultNoInterceptCount" runat="server" FieldLabel="默认免扣量"
                                    Text="100" DecimalPrecision="0" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtUserID" runat="server" FieldLabel="登陆用户ID" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtUserPass" runat="server" FieldLabel="登陆用户密码" InputType="Password"
                                    AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientGroup" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientGroupAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientGroup_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家组。',callback);function callback(id) {#{formPanelSPClientGroupAdd}.getForm().reset();#{storeSPClientGroup}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientGroup" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
