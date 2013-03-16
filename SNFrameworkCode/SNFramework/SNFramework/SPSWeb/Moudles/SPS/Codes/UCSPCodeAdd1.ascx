<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeAdd1.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Codes.UCSPCodeAdd1" %>
<%@ Import Namespace="SPSWeb.AppCode" %>
<ext:Store ID="storeMOType" runat="server" AutoLoad="True">
    <Proxy>
        <ext:HttpProxy Method="POST" Url='<%# BasePage.BSFWebRoot + "Moudles/SystemManage/DataService/DictionaryDataService.ashx" %>' AutoDataBind="True" />
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
                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" Hidden="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True" Hidden="True"
                    AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbMOType" Editable="false" runat="server" FieldLabel="指令类型" AllowBlank="false"
                    SelectedIndex="1" AnchorHorizontal="95%" StoreID="storeMOType" DisplayField="Value"
                    ValueField="Key">
                    <Listeners>
                        <Select Handler="ChangeCodeType(#{cmbMOType}.getValue(),#{chkHasSubCode},#{txtSubCode});" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtMO" runat="server" FieldLabel="指令" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSPCode" runat="server" FieldLabel="通道号" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:NumberField ID="numOrderIndex" runat="server" FieldLabel="价格" Text="1" DecimalPrecision="0"
                    AllowBlank="false" AnchorHorizontal="95%" />
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
                <ext:ComboBox ID="cmbOperateType" Editable="false" runat="server" FieldLabel="运营商"
                    LabelWidth="40" Width="120" TriggerAction="All">
                    <Items>
                        <ext:ListItem Value="移动" Text="移动"></ext:ListItem>
                        <ext:ListItem Value="联通" Text="联通"></ext:ListItem>
                        <ext:ListItem Value="电信" Text="电信"></ext:ListItem>
                    </Items>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtDayLimit" runat="server" FieldLabel="日限制" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtMonthLimit" runat="server" FieldLabel="月限制" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtCodeSendText" runat="server" FieldLabel="下发语" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtPrice" runat="server" FieldLabel="价格" Text="1" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkHasFilters" runat="server" FieldLabel="是否过滤" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkHasParamsConvert" runat="server" FieldLabel="是否转换" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="备注信息" AllowBlank="True"
                    AnchorHorizontal="95%" />
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