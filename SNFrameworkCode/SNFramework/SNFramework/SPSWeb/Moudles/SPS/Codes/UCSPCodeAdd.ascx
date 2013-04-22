<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeAdd.ascx.cs"
    Inherits="SPSWeb.Moudles.SPS.Codes.UCSPCodeAdd" %>
<%@ Import Namespace="SPSWeb.AppCode" %>
<script type="text/javascript">
    function CheckLimitProvince() {
        var chkLimitProvince = <%= chkLimitProvince.ClientID %>;
        var mfLimitProvinceArea = <%= mfLimitProvinceArea.ClientID %>;
        if (chkLimitProvince.getValue()) {
            mfLimitProvinceArea.show();
        } else {
            mfLimitProvinceArea.hide();
        }
    }

    function SetSubCode() {
        var txtSubCodes = <%= txtSubCodes.ClientID %>;
        var cmbCodeType = <%= cmbCodeType.ClientID %>;

        if (cmbCodeType.getValue() == '2') {
            txtSubCodes.show();
        } else {
            txtSubCodes.hide();
        }

    }
 
    function CheckAllAddUI() {
        var formPanelSPCodeAdd = <%= formPanelSPCodeAdd.ClientID %>;
        var frmCodeTextInfo = <%= frmCodeTextInfo.ClientID %>;
        formPanelSPCodeAdd.getForm().reset();
        frmCodeTextInfo.getForm().reset(); 
        CheckLimitProvince();
        SetSubCode();
    }
   
</script>
<ext:Window ID="winSPCodeAdd" runat="server" Icon="ApplicationAdd" Title="快速添加指令"
    Width="780" Height="360" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:TabPanel ID="tpMain" runat="server" ActiveTabIndex="0" Plain="true">
            <Items>
                <ext:FormPanel ID="formPanelSPCodeAdd" runat="server" Title="指令设置" Frame="true" PaddingSummary="0"
                    ButtonAlign="Center" Layout="fit" AutoScroll="True">
                    <Items>
                        <ext:TableLayout ID="tblCode" runat="server" Columns="3" ColumnWidth="0.33" padding="15">
                            <Cells>
                                <ext:Cell CellCls="cellClass">
                                    <ext:ComboBox ID="cmbCodeType" Editable="false" runat="server" FieldLabel="指令类型"
                                        AllowBlank="false" SelectedIndex="0" Width="233">
                                        <Items>
                                            <ext:ListItem Value="1" Text="精准指令"></ext:ListItem>
                                            <ext:ListItem Value="2" Text="模糊指令"></ext:ListItem>
                                        </Items>
                                        <Listeners>
                                            <Select Handler="SetSubCode();"></Select>
                                        </Listeners>
                                    </ext:ComboBox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkIsMatchCase" runat="server" FieldLabel="区分大小写">
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkIsDiable" runat="server" FieldLabel="是否禁用">
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:TextField ID="txtMO" runat="server" FieldLabel="指 令"  AllowBlank="false" />
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:TextField ID="txtSPCode" runat="server" FieldLabel="通道号码"  AllowBlank="false" />
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:NumberField ID="nfPrice" runat="server" FieldLabel="默认价格" DecimalPrecision="2"
                                        Text="1.00">
                                    </ext:NumberField>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkLimitProvince" runat="server" FieldLabel="分省指令">
                                        <Listeners>
                                            <Check Handler="CheckLimitProvince();"></Check>
                                        </Listeners>
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass" ColSpan="2">
                                    <ext:MultiCombo ID="mfLimitProvinceArea" runat="server" Width="470" FieldLabel="所属省份">
                                        <Items>
                                            <ext:ListItem Value="安徽" Text="安徽"></ext:ListItem>
                                            <ext:ListItem Value="北京" Text="北京"></ext:ListItem>
                                            <ext:ListItem Value="福建" Text="福建"></ext:ListItem>
                                            <ext:ListItem Value="甘肃" Text="甘肃"></ext:ListItem>
                                            <ext:ListItem Value="广东" Text="广东"></ext:ListItem>
                                            <ext:ListItem Value="广西" Text="广西"></ext:ListItem>
                                            <ext:ListItem Value="贵州" Text="贵州"></ext:ListItem>
                                            <ext:ListItem Value="海南" Text="海南"></ext:ListItem>
                                            <ext:ListItem Value="河北" Text="河北"></ext:ListItem>
                                            <ext:ListItem Value="河南" Text="河南"></ext:ListItem>
                                            <ext:ListItem Value="黑龙江" Text="黑龙江"></ext:ListItem>
                                            <ext:ListItem Value="湖北" Text="湖北"></ext:ListItem>
                                            <ext:ListItem Value="湖南" Text="湖南"></ext:ListItem>
                                            <ext:ListItem Value="吉林" Text="吉林"></ext:ListItem>
                                            <ext:ListItem Value="江苏" Text="江苏"></ext:ListItem>
                                            <ext:ListItem Value="江西" Text="江西"></ext:ListItem>
                                            <ext:ListItem Value="辽宁" Text="辽宁"></ext:ListItem>
                                            <ext:ListItem Value="内蒙古" Text="内蒙古"></ext:ListItem>
                                            <ext:ListItem Value="宁夏" Text="宁夏"></ext:ListItem>
                                            <ext:ListItem Value="青海" Text="青海"></ext:ListItem>
                                            <ext:ListItem Value="山东" Text="山东"></ext:ListItem>
                                            <ext:ListItem Value="山西" Text="山西"></ext:ListItem>
                                            <ext:ListItem Value="陕西" Text="陕西"></ext:ListItem>
                                            <ext:ListItem Value="上海" Text="上海"></ext:ListItem>
                                            <ext:ListItem Value="四川" Text="四川"></ext:ListItem>
                                            <ext:ListItem Value="天津" Text="天津"></ext:ListItem>
                                            <ext:ListItem Value="西藏" Text="西藏"></ext:ListItem>
                                            <ext:ListItem Value="新疆" Text="新疆"></ext:ListItem>
                                            <ext:ListItem Value="云南" Text="云南"></ext:ListItem>
                                            <ext:ListItem Value="浙江" Text="浙江"></ext:ListItem>
                                            <ext:ListItem Value="重庆" Text="重庆"></ext:ListItem>
                                            <ext:ListItem Value="其他" Text="其他"></ext:ListItem>
                                        </Items>
                                    </ext:MultiCombo>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkHasFilters" runat="server" FieldLabel="是否过滤">
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkHasParamsConvert" runat="server" FieldLabel="是否转换">
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass">
                                    <ext:Checkbox ID="chkHasPhoneLimit" runat="server" FieldLabel="是否限量">
                                    </ext:Checkbox>
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass" ColSpan="3">
                                    <ext:TextField ID="txtSubCodes" NoteAlign="Down" Note="多个指令使用|分隔，例：( 1|2|3 )" runat="server" FieldLabel="子指令列表" AllowBlank="True"
                                        Width="600" />
                                </ext:Cell>
                                <ext:Cell CellCls="cellClass" ColSpan="3">
                                    <ext:TextArea ID="txtDescription" runat="server" FieldLabel="备注信息" AllowBlank="True"
                                        Width="600" />
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>
                    </Items>
                </ext:FormPanel>
                <ext:FormPanel ID="frmCodeTextInfo" runat="server" Title="指令信息" Padding="6" AutoScroll="True" Hidden="True">
                    <Items>
                        <ext:TextArea ID="txtProvince" runat="server" FieldLabel="开通省份" AllowBlank="True"
                            AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtDisableCity" runat="server" FieldLabel="屏蔽地市" AllowBlank="True"
                            AnchorHorizontal="95%" />
                        <ext:ComboBox ID="cmbOperateType" Editable="false" runat="server" FieldLabel="运营商" AllowBlank="True"
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
                    </Items>
                </ext:FormPanel>
            </Items>
        </ext:TabPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPCode" runat="server" Text="保存" Icon="Add">

            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPCode_Click"
                    Success="ShowMessage('操作成功','添加指令成功！',1);reloadCodes();"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCode" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPCodeAdd}.hide()"></Click>
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="CheckAllAddUI();"></BeforeShow>
    </Listeners>
</ext:Window>
