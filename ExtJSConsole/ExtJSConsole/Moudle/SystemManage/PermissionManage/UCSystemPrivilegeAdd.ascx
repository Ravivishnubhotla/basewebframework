<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeAdd.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.PermissionManage.UCSystemPrivilegeAdd" %>
<ext:Window ID="winSystemPrivilegeAdd" runat="server" Icon="Add" Title="添加SystemPrivilege"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPrivilegeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="权限名" AllowBlank="False"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="权限编码" AllowBlank="False"  AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeCategory" runat="server" FieldLabel="权限类别名" AllowBlank="True"  AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemPrivilege" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPrivilege_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了SystemPrivilege。',callback);function callback(id) {#{formPanelSystemPrivilegeAdd}.getForm().reset();#{storeSystemPrivilege}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
