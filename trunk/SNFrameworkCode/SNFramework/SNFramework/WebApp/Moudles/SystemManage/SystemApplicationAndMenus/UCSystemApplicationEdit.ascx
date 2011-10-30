<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemApplicationEdit" %>
<ext:Window ID="winSystemApplicationEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130"
            AutoScroll="true">
            <Items>
                <ext:Hidden ID="hidSystemApplicationID" runat="server" DataIndex="SystemApplicationID"
                    AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtSystemApplicationName" runat="server" DataIndex="SystemApplicationName"
                    FieldLabel="<%$ Resources:msgFieldName %>" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationCode" runat="server" DataIndex="SystemApplicationCode"
                    FieldLabel="<%$ Resources:msgFieldCode %>" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription" runat="server" DataIndex="SystemApplicationDescription"
                    FieldLabel="<%$ Resources:msgFieldDescription %>" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" DataIndex="SystemApplicationUrl" runat="server"
                    FieldLabel="<%$ Resources:msgFieldUrl %>" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" DataIndex="SystemApplicationIsSystemApplication"
                    runat="server" Checked="true" FieldLabel="<%$ Resources:msgFieldIsSystem %>" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="<%$ Resources:msgUpdateScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
