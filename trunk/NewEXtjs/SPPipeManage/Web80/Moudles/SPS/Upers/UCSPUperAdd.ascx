<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPUperAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Upers.UCSPUperAdd" %>
<ext:Window ID="winSPUperAdd" runat="server" Icon="ApplicationAdd" Title="新建上家"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPUperAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPUper" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPUper" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPUperAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPUper_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了上家。',callback);function callback(id) {#{formPanelSPUperAdd}.getForm().reset();#{storeSPUper}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPUper" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPUperAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
