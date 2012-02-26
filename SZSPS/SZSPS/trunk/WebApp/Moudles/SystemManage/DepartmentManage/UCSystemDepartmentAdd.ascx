<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDepartmentAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage.UCSystemDepartmentAdd" %>
<ext:Window ID="winSystemDepartmentAdd" runat="server" Icon="ApplicationAdd" Title="新建系统部门"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDepartmentAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
            
            
                                    <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="父部门" AnchorHorizontal="95%">
                        </ext:Label>
                        
                       <ext:Hidden ID="hidParentDepartmentID" runat="server"  AnchorHorizontal="95%"></ext:Hidden>

              
			
						<ext:TextField ID="txtDepartmentNameCn" runat="server" FieldLabel="部门名" AllowBlank="False"  AnchorHorizontal="95%" />
              

						<ext:TextField ID="txtDepartmentNameEn" runat="server" FieldLabel="部门编码" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextArea ID="txtDepartmentDecription" runat="server" FieldLabel="部门描述" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemDepartment" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDepartmentAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemDepartment_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统部门。',callback);function callback(id) {#{formPanelSystemDepartmentAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDepartment" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDepartmentAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>