<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMoudleAdd.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MoudleManage.UCSystemMoudleAdd" %>
<ext:Window ID="winSystemMoudleAdd" runat="server" Icon="Add" Title="添加系统模块" Width="400"
    Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false"
    ConstrainHeader="true" Resizable="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSystemMoudleAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayout2" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMoudleNameCn" runat="server" FieldLabel="显示名" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMoudleNameEn" runat="server" FieldLabel="编码" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMoudleNameDb" runat="server" FieldLabel="数据库名" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMoudleDescription" runat="server" FieldLabel="描述" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtApplicationID" runat="server" FieldLabel="所属系统应用" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkMoudleIsSystemMoudle" runat="server" FieldLabel="是否为系统模块" Checked="false" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemMoudle" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemMoudleAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMoudle_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统模块。',callback);function callback(id) {#{formPanelSystemMoudleAdd}.getForm().reset();#{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMoudle" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMoudleAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
