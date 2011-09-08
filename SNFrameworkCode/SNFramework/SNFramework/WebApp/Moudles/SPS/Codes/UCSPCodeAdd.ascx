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
<ext:store id="storeMOType" runat="server" autoload="false">
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
    </ext:store>
<ext:window id="winSPCodeAdd" runat="server" icon="ApplicationAdd" title="快速添加指令"
    width="400" height="270" autoshow="false" maximizable="true" modal="true" hidden="true"
    autoscroll="true" constrainheader="true" resizable="true" layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbMOType" Editable="false" runat="server" FieldLabel="指令类型" AllowBlank="false"
                    SelectedIndex="1" AnchorHorizontal="95%" StoreID="storeMOType" DisplayField="Value"
                    ValueField="Key">
                    <Listeners>
                        <Select Handler="ChangeCodeType(#{cmbMOType}.getValue(),#{chkHasSubCode},#{txtSubCode});" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtMO" runat="server" FieldLabel="指令" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSPCode" runat="server" FieldLabel="通道号" AllowBlank="True" AnchorHorizontal="95%" />
                                <ext:NumberField ID="numOrderIndex" runat="server" FieldLabel="价格" Text="1" DecimalPrecision="0" AllowBlank="false" AnchorHorizontal="95%" />
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
                <ext:NumberField ID="txtPrice" runat="server" FieldLabel="价格" Text="1" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkHasFilters" runat="server" FieldLabel="是否过滤" Checked="false"  AnchorHorizontal="95%"/>
                <ext:Checkbox ID="chkHasParamsConvert" runat="server" FieldLabel="是否转换" Checked="false"  AnchorHorizontal="95%"/>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPCode" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPCode_Click"
                    Success="Ext.MessageBox.alert('操作成功', '添加指令成功' ,callback);function callback(id) {#{formPanelSPCodeAdd}.getForm().reset();#{storeSPCode}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
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
</ext:window>
