<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDepartmentAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage.UCSystemDepartmentAdd" %>
<ext:Window ID="winSystemDepartmentAdd" runat="server" Icon="ApplicationAdd" Title="Add System department"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDepartmentAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="120"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="Parent Department" AnchorHorizontal="95%">
                </ext:Label>
                <ext:Hidden ID="hidParentDepartmentID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtDepartmentNameCn" runat="server" FieldLabel="Name" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtDepartmentNameEn" runat="server" FieldLabel="Code" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDepartmentDecription" runat="server" FieldLabel="Description"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemDepartment" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDepartmentAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDepartment_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add System Deparentment Success',callback);function callback(id) {#{formPanelSystemDepartmentAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDepartment" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemDepartmentAdd}.getForm().reset();#{winSystemDepartmentAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
