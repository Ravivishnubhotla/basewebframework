<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemOrganizationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage.UCSystemOrganizationAdd" %>
<ext:Window ID="winSystemOrganizationAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemOrganizationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
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
                <ext:TextField ID="txtMasterName" runat="server" FieldLabel="<%$ Resources:msgFiledMasterName %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsMainOrganization" runat="server" FieldLabel="<%$ Resources:msgFiledIsMainOrganization %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtTelPhone" runat="server" FieldLabel="<%$ Resources:msgFiledTelPhone %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtFaxNumber" runat="server" FieldLabel="<%$ Resources:msgFiledFaxNumber %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtWebSite" runat="server" FieldLabel="<%$ Resources:msgFiledWebSite %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtEmail" runat="server" FieldLabel="<%$ Resources:msgFiledEmail %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemOrganization" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemOrganizationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemOrganization_Click" Success="<%$ Resources:msgAddScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemOrganization" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemOrganizationAdd}.getForm().reset();#{winSystemOrganizationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
