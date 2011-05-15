<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDepartmentEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage.UCSystemDepartmentEdit" %>
<ext:Window ID="winSystemDepartmentEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDepartmentEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="120">
            <Items>
                <ext:Hidden ID="hidDepartmentID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblParentMenuName" runat="server" FieldLabel="<%$ Resources:msglblParentMenuName %>" AnchorHorizontal="95%">
                </ext:DisplayField>
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
        <ext:Button ID="btnSaveSystemDepartment" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDepartmentEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDepartment_Click" Success="<%$ Resources:msgEditScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDepartment" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemDepartmentEdit}.getForm().reset();#{winSystemDepartmentEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
