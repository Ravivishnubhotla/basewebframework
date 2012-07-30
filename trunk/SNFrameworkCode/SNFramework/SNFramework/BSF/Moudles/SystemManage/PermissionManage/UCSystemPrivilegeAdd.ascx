<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.PermissionManage.UCSystemPrivilegeAdd" %>
<ext:Window ID="winSystemPrivilegeAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="310" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPrivilegeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
                <ext:ComboBox ID="cmbOperationID" runat="server" StoreID="storeSystemOperation" Editable="true"
                    TypeAhead="true" FieldLabel="<%$ Resources:msgFieldOperation %>" Mode="Local" TriggerAction="All" DisplayField="OperationNameCn"
                    ValueField="OperationID" AllowBlank="False" ForceSelection="false" AnchorHorizontal="95%" />
                <ext:Hidden ID="hidResourcesID" runat="server" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblResourcesName" FieldLabel="<%$ Resources:msgFieldResourcesName %>" runat="server" AnchorHorizontal="95%"></ext:DisplayField>
                <ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="<%$ Resources:msgFieldName %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="<%$ Resources:msgFieldCode %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtPrivilegeOrder" runat="server" FieldLabel="<%$ Resources:msgFieldOrder %>" AllowBlank="False"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPrivilege_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
        <Listeners>
        <BeforeShow Handler="#{storeSystemOperation}.reload();" />
    </Listeners>
</ext:Window>
