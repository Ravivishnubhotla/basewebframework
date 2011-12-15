<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPostAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage.UCSystemPostAdd" %>
<ext:Window ID="winSystemPostAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPostAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidOrgID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="txtOrganizationID" runat="server" FieldLabel="<%$ Resources:msgFiledOrganizationID %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtName" runat="server" FieldLabel="<%$ Resources:msgFiledName %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="<%$ Resources:msgFiledCode %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemPost" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPostAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPost_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPost" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemPostAdd}.getForm().reset();#{winSystemPostAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
