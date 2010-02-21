<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationEdit.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.ApplicationManage.UCSystemApplicationEdit" %>
<ext:Window ID="winSystemApplicationEdit" runat="server" Icon="ApplicationEdit" Title="编辑系统应用"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSystemApplicationEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayout2" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidSystemApplicationID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtSystemApplicationName" runat="server" FieldLabel="名称" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtSystemApplicationDescription" runat="server" FieldLabel="描述" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtSystemApplicationUrl" runat="server" FieldLabel="链接" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" runat="server" Checked="true"
                                    FieldLabel="是否为系统应用">
                                </ext:Checkbox>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemApplicationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了系统应用。',callback);function callback(id) { #{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
