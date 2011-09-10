<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigAdd" %>
<%@ Register Src="UCSystemConfigGroupAdd.ascx" TagName="UCSystemConfigGroupAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemConfigGroupEdit.ascx" TagName="UCSystemConfigGroupEdit"
    TagPrefix="uc2" %>
<uc1:UCSystemConfigGroupAdd ID="UCSystemConfigGroupAdd1" runat="server" />
<uc2:UCSystemConfigGroupEdit ID="UCSystemConfigGroupEdit1" runat="server" />
<script type="text/javascript">


        var RefreshGroupData = function(btn) {
            <%= this.storeSystemConfigGroup.ClientID %>.reload();
        };


        function DeleteGroupByID(id) {
                            Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteGroupRecord(
                                                                id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshGroupData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing ......'
                                                                               }
                                                                }
                                                            );
                    }
                    );
        }
        
        
                function EditGroupByID(id) {
                Ext.net.DirectMethods.UCSystemConfigGroupEdit.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshGroupData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
        }

    function showAddGroupForm() {
        Ext.net.DirectMethods.UCSystemConfigGroupAdd.Show(
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshGroupData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing...'
                                                                    }
                                                                });

    }
 

</script>
<ext:Store ID="storeSystemConfigGroup" runat="server" OnRefreshData="storeSystemConfigGroup_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
                <ext:RecordField Name="Code" />
                <ext:RecordField Name="Description" />
                <ext:RecordField Name="IsEnable" Type="Boolean" />
                <ext:RecordField Name="IsSystem" Type="Boolean" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Store ID="storeDictionarySystemDataType" runat="server" AutoLoad="false">
    <Proxy>
        <ext:HttpProxy Method="POST" Url="../DataService/DictionaryDataService.ashx" />
    </Proxy>
    <Reader>
        <ext:JsonReader Root="dictionarys" TotalProperty="total">
            <Fields>
                <ext:RecordField Name="Key" />
                <ext:RecordField Name="Value" />
                <ext:RecordField Name="Code" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <BaseParams>
        <ext:Parameter Name="GroupCode" Value="System_DataType" Mode="Value" />
    </BaseParams>
</ext:Store>
<ext:Window ID="winSystemConfigAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
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
                    AllowBlank="True" AnchorHorizontal="95%" />
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
        <ext:Button ID="btnSavelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemConfig_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeSystemConfigGroup}.reload();#{storeDictionarySystemDataType}.reload();">
        </BeforeShow>
    </Listeners>
</ext:Window>
