<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserGroupAdd.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.UserGroupManage.UCSystemUserGroupAdd" %>

<ext:Window ID="winSystemUserGroupAdd" runat="server" Icon="Add" Title="添加系统用户组"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false" ConstrainHeader=true Resizable=true>
    <Body>
        <ext:FitLayout ID="fitLayoutMainSystemUserGroup" runat="server">
            <ext:FormPanel ID="formPanelSystemUserGroupAdd" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="formLayoutSystemUserGroup" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
											 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtGroupNameCn" runat="server" FieldLabel="组名" AllowBlank="False"  />
                     </ext:Anchor>
					 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtGroupNameEn" runat="server" FieldLabel="组编码" AllowBlank="False"  />
                     </ext:Anchor>
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtGroupDescription" runat="server" FieldLabel="描述" AllowBlank="True"  />
                     </ext:Anchor>

                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemUserGroup" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemUserGroupAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemUserGroup_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统用户组。',callback);function callback(id) {#{formPanelSystemUserGroupAdd}.getForm().reset();#{storeSystemUserGroup}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUserGroup" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>







