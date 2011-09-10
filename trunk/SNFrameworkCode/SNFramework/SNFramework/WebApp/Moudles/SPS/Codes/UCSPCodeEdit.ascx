<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeEdit" %>
<ext:window id="winSPCodeEdit" runat="server" icon="ApplicationEdit" title="Edit SPCode"
    width="400" height="270" autoshow="false" maximizable="true" modal="true" hidden="true"
    autoscroll="true" constrainheader="true" resizable="true" layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" AnchorHorizontal="95%" />
                                <ext:Checkbox ID="chkIsDiable" runat="server" FieldLabel="是否禁用" Checked="false"  AnchorHorizontal="95%"/>
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
        <ext:Button ID="btnSaveSPCode" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPCode_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPCodeEdit}.getForm().reset();#{storeSPCode}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCode" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPCodeEdit}.getForm().reset();#{winSPCodeEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:window>
