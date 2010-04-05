<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleAssignedApplication.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.RoleManage.UCSystemRoleAssignedApplication" %>
<ext:Window ID="winSystemRoleAssignedApplication" runat="server" Icon="Add" Title="分配应用" Width="500"
    Height="300" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemRoleAssignedApplication" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="form">
            <Items>
 <ext:CheckboxGroup 
                                                ID="chkgApplication" 
                                                runat="server" 
                                                FieldLabel="分配应用" ColumnsNumber="2" >
                                            </ext:CheckboxGroup> 

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemRoleAssignedApplication" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click OnEvent="btnSaveSystemRoleAssignedApplication_Click" Success="Ext.MessageBox.alert('操作成功', '成功的分配了应用。',callback);function callback(id) {#{winSystemRoleAssignedApplication}.getForm().reset();#{storeSystemRole}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRoleAssignedApplication" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleAssignedApplication}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
