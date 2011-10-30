<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemOperationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemOperationAdd" %>
<ext:Window ID="winSystemOperationAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="450" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemOperationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="150"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblResourceName" runat="server" FieldLabel="<%$ Resources:msgFieldResourceName %>" AnchorHorizontal="95%" />
                <ext:TextField ID="txtOperationNameCn" runat="server" FieldLabel="<%$ Resources:msgFieldName %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtOperationNameEn" runat="server" FieldLabel="<%$ Resources:msgFieldCode %>" 
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtOperationDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsSystemOperation" runat="server" FieldLabel="<%$ Resources:msgFieldIsSystem %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCanSingleOperation" runat="server" FieldLabel="<%$ Resources:msgFieldIsCanSingleOperation %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCanMutilOperation" runat="server" FieldLabel="<%$ Resources:msgFieldIsCanMutilOperation %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="<%$ Resources:msgFieldIsEnable %>" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsInListPage" runat="server" FieldLabel="<%$ Resources:msgFieldIsInListPage %>" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsInSinglePage" runat="server" FieldLabel="<%$ Resources:msgFieldInSinglePage %>" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtOperationOrder" runat="server" FieldLabel="<%$ Resources:msgFieldOperationOrder %>" Text="1"
                    DecimalPrecision="0" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCommonOperation" runat="server" FieldLabel="<%$ Resources:msgFieldIsCommonOperation %>"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemOperation" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemOperationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemOperation_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemOperation" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemOperationAdd}.getForm().reset();#{winSystemOperationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
