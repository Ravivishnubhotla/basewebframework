<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.UCSystemUserEdit" %>
<ext:Window ID="winSystemUserEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="430" Height="200" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemUserID" runat="server">
                </ext:Hidden>
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="<%$ Resources:msgFieldUserName %>"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="<%$ Resources:msgFieldUserEmail %>"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="<%$ Resources:msgFieldComments %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="<%$ Resources:msgUpdateScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Hidden ID="hiddenDepartment1" runat="server">
</ext:Hidden>
