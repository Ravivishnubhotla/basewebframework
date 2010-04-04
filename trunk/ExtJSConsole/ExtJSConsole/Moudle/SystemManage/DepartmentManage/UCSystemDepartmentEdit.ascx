<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDepartmentEdit.ascx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.DepartmentManage.UCSystemDepartmentEdit" %>
<ext:Window ID="winSystemDepartmentEdit" runat="server" Icon="ApplicationEdit" Title="编辑SystemDepartment"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDepartmentEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidDepartmentID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
                                    <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="父部门" AnchorHorizontal="95%">
                        </ext:Label>
                        
              
			
						<ext:TextField ID="txtDepartmentNameCn" runat="server" FieldLabel="部门名" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDepartmentNameEn" runat="server" FieldLabel="部门编码" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDepartmentDecription" runat="server" FieldLabel="部门描述" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemDepartment" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDepartmentEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDepartment_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了SystemDepartment。',callback);function callback(id) {#{formPanelSystemDepartmentEdit}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDepartment" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDepartmentEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

