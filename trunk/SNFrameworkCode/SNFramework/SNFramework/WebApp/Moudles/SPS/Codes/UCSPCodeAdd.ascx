<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeAdd" %>
<script type="text/javascript">
    function ChangeCodeType(codeType, chkHasSubCode, txtSubCode) {
        if (codeType == "1") {
            chkHasSubCode.hide();
            txtSubCode.hide();
            chkHasSubCode.setValue(false);
        }
        else {
            chkHasSubCode.show();
            txtSubCode.show();
            chkHasSubCode.setValue(true);
        }
    }
</script>
<ext:Window ID="winSPCodeAdd" runat="server" Icon="ApplicationAdd" Title="快速添加指令"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:ComboBox ID="cmbMOType" Editable="false" runat="server" FieldLabel="指令类型" AllowBlank="false"
                    SelectedIndex="0" AnchorHorizontal="95%">
                    <Items>
                        <ext:ListItem Value="1" Text="精准指令"></ext:ListItem>
                        <ext:ListItem Value="2" Text="模糊指令"></ext:ListItem>
                        <ext:ListItem Value="3" Text="结束指令"></ext:ListItem>
                        <ext:ListItem Value="4" Text="包含指令"></ext:ListItem>
                        <ext:ListItem Value="5" Text="正则指令"></ext:ListItem>
                        <ext:ListItem Value="6" Text="自定义指令"></ext:ListItem>
                        <ext:ListItem Value="7" Text="多条件指令"></ext:ListItem>
                        <ext:ListItem Value="8" Text="表达式指令"></ext:ListItem>
                    </Items>
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
                    Hidden="true"  AnchorHorizontal="95%" />
                <ext:TextArea ID="txtAllowAndDisableArea" runat="server" FieldLabel="开通省份/屏蔽地市" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtGetway" runat="server" FieldLabel="运营商" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtDayLimit" runat="server" FieldLabel="日限制" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtMonthLimit" runat="server" FieldLabel="月限制" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextArea ID="txtCodeSendText" runat="server" FieldLabel="下发语" AllowBlank="True"  AnchorHorizontal="95%" />
                <ext:TextField ID="txtProvince" runat="server" FieldLabel="Province" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtDisableCity" runat="server" FieldLabel="DisableCity" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrice" runat="server" FieldLabel="Price" AllowBlank="True"
                    AnchorHorizontal="95%" />
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
</ext:Window>
