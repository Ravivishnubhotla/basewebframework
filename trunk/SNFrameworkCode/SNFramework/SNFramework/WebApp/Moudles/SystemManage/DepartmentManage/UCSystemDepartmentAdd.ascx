<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDepartmentAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage.UCSystemDepartmentAdd" %>
<ext:Window ID="winSystemDepartmentAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDepartmentAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="120"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:DisplayField ID="lblParentMenuName" runat="server" FieldLabel="<%$ Resources:msglblParentMenuName %>" AnchorHorizontal="95%">
                </ext:DisplayField>
                <ext:Hidden ID="hidParentDepartmentID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtDepartmentNameCn" runat="server" FieldLabel="<%$ Resources:msgtxtDepartmentNameCn %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtDepartmentNameEn" runat="server" FieldLabel="<%$ Resources:msgtxtDepartmentNameEn %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDepartmentDecription" runat="server" FieldLabel="<%$ Resources:msgtxtDepartmentDecription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemDepartment" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDepartmentAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDepartment_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDepartment" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemDepartmentAdd}.getForm().reset();#{winSystemDepartmentAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
