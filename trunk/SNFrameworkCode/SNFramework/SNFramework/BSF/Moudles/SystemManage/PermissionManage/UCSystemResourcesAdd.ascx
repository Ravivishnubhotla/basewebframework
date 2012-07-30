<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemResourcesAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.PermissionManage.UCSystemResourcesAdd" %>
<ext:Window ID="winSystemResourcesAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemResourcesAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                 <ext:DisplayField ID="lblParentResourcesName" runat="server" FieldLabel="<%$ Resources:msgFieldParentResourcesName %>" AnchorHorizontal="95%">
                </ext:DisplayField>
          
                <ext:Hidden ID="hidParentResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
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
        <ext:Button ID="btnSavelSystemResources" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemResourcesAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemResources_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemResources" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemResourcesAdd}.getForm().reset();#{winSystemResourcesAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
