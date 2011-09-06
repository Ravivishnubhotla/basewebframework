<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeAdd" %>
<script type="text/javascript">
    function ChangeCodeType(codeType, chkHasSubCode, txtSubCode) {
        if (codeType == "2") {
            chkHasSubCode.show();
            txtSubCode.show();
            chkHasSubCode.setValue(true);
        }
        else {
            chkHasSubCode.hide();
            txtSubCode.hide();
            chkHasSubCode.setValue(false);
        }
    }
</script>
    <ext:Store ID="storeMOType" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="POST" Url="../../SystemManage/DataService/DictionaryDataService.ashx" />
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
            <ext:Parameter Name="GroupCode" Value="CodeType" Mode="Value" />
        </BaseParams>
    </ext:Store>
<ext:Window ID="winSPCodeAdd" runat="server" Icon="ApplicationAdd" Title="快速添加指令"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:ComboBox ID="cmbMOType" Editable="false" runat="server" FieldLabel="指令类型" AllowBlank="false"
                    SelectedIndex="0" AnchorHorizontal="95%" StoreID="storeMOType" DisplayField="Value"
                    ValueField="Key">
                    <Listeners>
                        <Select Handler="ChangeCodeType(#{cmbMOType}.getValue(),#{chkHasSubCode},#{txtSubCode});" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtMO" runat="server" FieldLabel="指令" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSPCode" runat="server" FieldLabel="通道号" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkHasSubCode" runat="server" FieldLabel="是否包含子指令" Checked="false"
                    Hidden="true">
                    <Listeners>
                        <Check Handler="if (#{chkHasSubCode}.getValue()){#{txtSubCode}.setVisible(true);}else{#{txtSubCode}.setVisible(false);}" />
                    </Listeners>
                </ext:Checkbox>
                <ext:TextArea ID="txtSubCode" runat="server" FieldLabel="子指令" AllowBlank="True" Note="多个指令使用|分隔，例：( 1|2|3 )"
                    Hidden="true" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtProvince" runat="server" FieldLabel="开通省份" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDisableCity" runat="server" FieldLabel="屏蔽地市" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtGetway" runat="server" FieldLabel="运营商" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtDayLimit" runat="server" FieldLabel="日限制" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtMonthLimit" runat="server" FieldLabel="月限制" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtCodeSendText" runat="server" FieldLabel="下发语" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrice" runat="server" FieldLabel="价格" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPCode" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPCode_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPCodeAdd}.getForm().reset();#{storeSPCode}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCode" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPCodeAdd}.getForm().reset();#{winSPCodeAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
    <BeforeShow Handler="#{storeMOType}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>
