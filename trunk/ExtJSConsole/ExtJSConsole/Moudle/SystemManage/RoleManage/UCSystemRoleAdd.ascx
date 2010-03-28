﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleAdd.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.RoleManage.UCSystemRoleAdd" %>
<ext:Window ID="winSystemRoleAdd" runat="server" Icon="Add" Title="添加系统角色"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false" ConstrainHeader=true Resizable=true>
    <Body>
        <ext:FitLayout ID="fitLayoutMainSystemRole" runat="server">
            <ext:FormPanel ID="formPanelSystemRoleAdd" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="formLayoutSystemRole" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
											 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtRoleName" runat="server" FieldLabel="角色名" AllowBlank="True"  />
                     </ext:Anchor>
					 <ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtRoleDescription" runat="server" FieldLabel="描述" AllowBlank="True"  />
                     </ext:Anchor>
					                                        <ext:Anchor Horizontal="95%">
                                            <ext:Checkbox ID="chkRoleIsSystemRole" runat="server" FieldLabel="是否为系统角色" Checked="false" />
                                        </ext:Anchor>

                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemRole" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemRoleAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemRole_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统角色。',callback);function callback(id) {#{formPanelSystemRoleAdd}.getForm().reset();#{storeSystemRole}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRole" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

