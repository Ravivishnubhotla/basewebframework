<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigEdit" %>
<ext:Window ID="winSystemConfigEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemConfigID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:ComboBox ID="cmbGroup" runat="server" FieldLabel="选择配置组" StoreID="storeSystemConfigGroup"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="Select a config group...">
                    <Triggers>
                        <ext:FieldTrigger Icon="SimpleCross" HideTrigger="true" />
                        <ext:FieldTrigger Icon="SimpleAdd" Qtip="Add a group" />
                        <ext:FieldTrigger Icon="SimpleEdit" Qtip="Edit this group" HideTrigger="true" />
                        <ext:FieldTrigger Icon="SimpleDelete" Qtip="Delete this group" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();this.triggers[2].show();this.triggers[3].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();this.triggers[2][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();this.triggers[3][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();this.triggers[2].hide();this.triggers[3].hide(); }if (index == 1) {showAddGroupForm();}if (index == 2) {EditGroupByID(#{cmbGroup}.getValue());}if (index == 3) {DeleteGroupByID(#{cmbGroup}.getValue());}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtConfigKey" runat="server" FieldLabel="<%$ Resources:msgFiledKeyTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" ReadOnly="true" />
                <ext:TextArea ID="txtConfigDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescriptionTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbDataType" runat="server" FieldLabel="数据类型" StoreID="storeDictionarySystemDataType"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Value" ValueField="Key"
                    AllowBlank="false">
                </ext:ComboBox>
                <ext:TextField ID="txtConfigValue" runat="server" FieldLabel="<%$ Resources:msgFiledValueTitle %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemConfig_Click" Success="<%$ Resources:msgUpdateScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeSystemConfigGroup}.reload();#{storeDictionarySystemDataType}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>
