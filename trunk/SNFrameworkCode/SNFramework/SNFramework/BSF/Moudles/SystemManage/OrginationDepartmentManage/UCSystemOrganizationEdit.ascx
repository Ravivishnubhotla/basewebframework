<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemOrganizationEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.OrginationDepartmentManage.UCSystemOrganizationEdit" %>
<ext:Window ID="winSystemOrganizationEdit" runat="server" Icon="ApplicationEdit"
    Title="<%$ Resources:msgFormTitle %>" Width="400" Height="270" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemOrganizationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:DisplayField ID="lblParentOrgName" runat="server" FieldLabel="<%$ Resources:msgFiledParentID %>"
                    AnchorHorizontal="95%" />
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="<%$ Resources:msgFiledName %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtShortName" runat="server" FieldLabel="<%$ Resources:msgFiledShortName %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="<%$ Resources:msgFiledCode %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtLogoUrl" runat="server" FieldLabel="<%$ Resources:msgFiledLogoUrl %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtType" runat="server" FieldLabel="<%$ Resources:msgFiledType %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtMasterName" runat="server" FieldLabel="<%$ Resources:msgFiledMasterName %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsMainOrganization" runat="server" FieldLabel="<%$ Resources:msgFiledIsMainOrganization %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtParentID" runat="server" FieldLabel="<%$ Resources:msgFiledParentID %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtAddressID" runat="server" FieldLabel="<%$ Resources:msgFiledAddressID %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtTelPhone" runat="server" FieldLabel="<%$ Resources:msgFiledTelPhone %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtFaxNumber" runat="server" FieldLabel="<%$ Resources:msgFiledFaxNumber %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtWebSite" runat="server" FieldLabel="<%$ Resources:msgFiledWebSite %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtEmail" runat="server" FieldLabel="<%$ Resources:msgFiledEmail %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCreateBy" runat="server" FieldLabel="<%$ Resources:msgFiledCreateBy %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCreateAt" runat="server" FieldLabel="<%$ Resources:msgFiledCreateAt %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtLastModifyBy" runat="server" FieldLabel="<%$ Resources:msgFiledLastModifyBy %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtLastModifyAt" runat="server" FieldLabel="<%$ Resources:msgFiledLastModifyAt %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="<%$ Resources:msgFiledLastModifyComment %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemOrganization" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemOrganizationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemOrganization_Click" Success="<%$ Resources :  msgUpdateScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemOrganization" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemOrganizationEdit}.getForm().reset();#{winSystemOrganizationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
