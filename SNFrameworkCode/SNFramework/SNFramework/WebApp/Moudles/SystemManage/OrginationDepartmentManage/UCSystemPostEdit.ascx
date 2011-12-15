<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPostEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage.UCSystemPostEdit" %>
<ext:Window ID="winSystemPostEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPostEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
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
        <ext:Button ID="btnSaveSystemPost" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPostEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPost_Click" Success="<%$ Resources :  msgUpdateScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPost" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemPostEdit}.getForm().reset();#{winSystemPostEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
