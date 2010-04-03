<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationEdit.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.ApplicationManage.UCSystemApplicationEdit" %>
<ext:Window ID="winSystemApplicationEdit" runat="server" Icon="ApplicationEdit" Title="编辑系统应用"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemApplicationID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtSystemApplicationName" runat="server" FieldLabel="名称" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription" runat="server" FieldLabel="描述"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" runat="server" FieldLabel="链接" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" runat="server" Checked="true"
                    FieldLabel="是否为系统应用" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了系统应用。',callback);function callback(id) { #{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
