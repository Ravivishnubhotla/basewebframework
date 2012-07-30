<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemOperationEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.PermissionManage.UCSystemOperationEdit" %>
<ext:Window ID="winSystemOperationEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemOperationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidOperationID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="txtResourceName" runat="server" FieldLabel="<%$ Resources:msgFieldResourceName %>" AnchorHorizontal="95%" />
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
        <ext:Button ID="btnSaveSystemOperation" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemOperationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemOperation_Click" Success="<%$ Resources : msgUpdateScript  %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemOperation" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemOperationEdit}.getForm().reset();#{winSystemOperationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
