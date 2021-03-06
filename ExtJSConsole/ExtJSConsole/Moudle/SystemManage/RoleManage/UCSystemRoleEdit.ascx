﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleEdit.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.RoleManage.UCSystemRoleEdit" %>
<ext:Window ID="winSystemRoleEdit" runat="server" Icon="ApplicationEdit" Title="编辑系统角色"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemRoleEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemRoleID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtRoleName" runat="server" FieldLabel="角色名" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtRoleDescription" runat="server" FieldLabel="描述" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkRoleIsSystemRole" runat="server" FieldLabel="是否为系统角色" Checked="false"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemRole" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemRoleEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemRole_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了系统角色。',callback);function callback(id) {#{formPanelSystemRoleEdit}.getForm().reset();#{storeSystemRole}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRole" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
