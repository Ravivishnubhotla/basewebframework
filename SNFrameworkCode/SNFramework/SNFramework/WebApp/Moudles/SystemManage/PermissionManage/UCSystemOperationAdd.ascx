<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemOperationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemOperationAdd" %>
<ext:Window ID="winSystemOperationAdd" runat="server" Icon="ApplicationAdd" Title="Operation Add "
    Width="450" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemOperationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="150"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblResourceName" runat="server" FieldLabel="Resource" AnchorHorizontal="95%" />
                <ext:TextField ID="txtOperationNameCn" runat="server" FieldLabel="Name" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtOperationNameEn" runat="server" FieldLabel="Code" 
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtOperationDescription" runat="server" FieldLabel="Description"
                    AllowBlank="False" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsSystemOperation" runat="server" FieldLabel="System Operation"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCanSingleOperation" runat="server" FieldLabel="Single Operation"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCanMutilOperation" runat="server" FieldLabel="Mutil Operation"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="Enable" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsInListPage" runat="server" FieldLabel="In List" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsInSinglePage" runat="server" FieldLabel="In Single" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtOperationOrder" runat="server" FieldLabel="Order" Text="1"
                    DecimalPrecision="0" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsCommonOperation" runat="server" FieldLabel="Common Operation"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemOperation" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemOperationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemOperation_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSystemOperationAdd}.getForm().reset();RefreshOperationDataList(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemOperation" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemOperationAdd}.getForm().reset();#{winSystemOperationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
