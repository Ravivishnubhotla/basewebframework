﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserEdit.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.UserManage.UCSystemUserEdit" %>
<ext:Window ID="winSystemUserEdit" runat="server" Icon="ApplicationEdit" Title="编辑系统用户"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemUserID" runat="server">
                </ext:Hidden>
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="用户名" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="邮件" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="备注" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了系统用户。',callback);function callback(id) {#{formPanelSystemUserEdit}.getForm().reset();#{storeSystemUser}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
