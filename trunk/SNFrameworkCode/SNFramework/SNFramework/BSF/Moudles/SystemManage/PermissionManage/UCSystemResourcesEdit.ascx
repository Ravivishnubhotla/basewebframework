<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemResourcesEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.PermissionManage.UCSystemResourcesEdit" %>
<ext:Window ID="winSystemResourcesEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemResourcesEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblParentResourcesName" runat="server" FieldLabel="<%$ Resources:msgFieldParentResourcesName %>"
                    AnchorHorizontal="95%">
                </ext:DisplayField>
                <ext:TextField ID="txtResourcesNameCn" runat="server" FieldLabel="<%$ Resources:msgFieldName %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtResourcesNameEn" runat="server" FieldLabel="<%$ Resources:msgFieldCode %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtResourcesDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkResourcesIsRelateUser" runat="server" FieldLabel="<%$ Resources:msgFieldIsRelateUser %>"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemResources" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemResourcesEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemResources_Click" Success="<%$ Resources:msgUpdateScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemResources" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemResourcesEdit}.getForm().reset();#{winSystemResourcesEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
