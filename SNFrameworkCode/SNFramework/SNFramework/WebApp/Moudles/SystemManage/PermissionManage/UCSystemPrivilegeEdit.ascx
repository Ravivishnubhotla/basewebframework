<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemPrivilegeEdit" %>
<ext:Window ID="winSystemPrivilegeEdit" runat="server" Icon="ApplicationEdit" Title="EditSystem Permission"
    Width="400" Height="310" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPrivilegeEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidPrivilegeID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:ComboBox ID="cmbOperationID" runat="server" StoreID="storeSystemOperation" Editable="true"
                    TypeAhead="true" FieldLabel="Operation" Mode="Local" TriggerAction="All" DisplayField="OperationNameCn"
                    ValueField="OperationID" AllowBlank="False" ForceSelection="false" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblResourcesName" runat="server" AnchorHorizontal="95%"></ext:DisplayField>
                <ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="Name" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="Code" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtPrivilegeOrder" runat="server" FieldLabel="Order" AllowBlank="False"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPrivilege_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success upadted System Permission。',callback);function callback(id) {#{formPanelSystemPrivilegeEdit}.getForm().reset();#{storeSystemPrivilege}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
            <Listeners>
        <BeforeShow Handler="#{storeSystemOperation}.reload();" />
    </Listeners>
</ext:Window>
