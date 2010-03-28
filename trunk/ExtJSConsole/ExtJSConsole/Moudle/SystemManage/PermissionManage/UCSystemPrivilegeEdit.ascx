<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeEdit.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.PermissionManage.UCSystemPrivilegeEdit" %>
<ext:Window ID="winSystemPrivilegeEdit" runat="server" Icon="ApplicationEdit" Title="编辑SystemPrivilege"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false" ConstrainHeader=true Resizable=true>
    <Body>
        <ext:FitLayout ID="fitLayoutMainSystemPrivilege" runat="server">
            <ext:FormPanel ID="formPanelSystemPrivilegeEdit" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="formLayoutSystemPrivilege" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
						                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidSystemPrivilegeID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
						
											 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="权限名" AllowBlank="False"  />
                     </ext:Anchor>
					 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="权限编码" AllowBlank="False"  />
                     </ext:Anchor>
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"  />
                     </ext:Anchor>
					 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtPrivilegeCategory" runat="server" FieldLabel="权限类别名" AllowBlank="True"  />
                     </ext:Anchor>

                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemPrivilege" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeEdit}.getForm().isValid()) return false;" OnEvent="btnSaveSystemPrivilege_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SystemPrivilege。',callback);function callback(id) {#{formPanelSystemPrivilegeEdit}.getForm().reset();#{storeSystemPrivilege}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

