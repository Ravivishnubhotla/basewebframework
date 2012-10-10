<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelEdit.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.SPChannelEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ChangeAdapter(rdgDataAdapter, txtAdapter) {

            var selectItemValue = rdgDataAdapter.getValue().getGroupValue();

            if (selectItemValue == 0) {
                txtAdapter.setValue("HttpGetPostAdapter.ashx");
                txtAdapter.setDisabled(true);
                txtAdapter.hide();
            }
            else if (selectItemValue == 1) {
                txtAdapter.setValue("XMLAdapter.ashx");
                txtAdapter.setDisabled(true);
                txtAdapter.hide();
            }
            else {
                txtAdapter.setValue("");
                txtAdapter.setDisabled(false);
                txtAdapter.show();
            }

        }

        function changeStateReportType(stateReportType, typeReportSetting) {

            var selectItemValue = stateReportType.getValue().getGroupValue();

            if (selectItemValue == 0) {
                typeReportSetting.hide();
            }
            else if (selectItemValue == 1) {
                typeReportSetting.hide();
            }
            else {

                typeReportSetting.show();
            }

        }


        function changeAutoLinkID(autoLinkID, autoLinkField) {

            //alert(autoLinkID.getValue());

            if (autoLinkID.getValue()) {
                autoLinkField.show();
            }
            else {
                autoLinkField.hide();
            }

        }


    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:FormPanel ID="panlQuickAddChannel" runat="server" Title="编辑通道" Frame="true"
                AutoScroll="true">
                <Items>
                    <ext:FieldSet ID="FieldSet3" runat="server" Title="通道基本信息" AutoHeight="true" LabelWidth="75"
                        Layout="Form">
                        <Items>
                            <ext:Container ID="Container1" runat="server" Layout="Column" Height="30" AnchorHorizontal="98%">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AnchorHorizontal="95%"
                                                AllowBlank="false" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container5" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="txtCode" runat="server" FieldLabel="编码" AnchorHorizontal="95%"
                                                AllowBlank="false" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container6" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="txtDataOkMessage" runat="server" FieldLabel="成功响应信息" Text="ok"
                                                AnchorHorizontal="95%" AllowBlank="false" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="txtDataFailedMessage" runat="server" FieldLabel="失败响应信息" Text="failed"
                                                AnchorHorizontal="95%" AllowBlank="false" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container4" runat="server" Layout="Form" AnchorHorizontal="98%">
                                <Items>
                                    <ext:TextArea ID="txtDescription" runat="server" Height="50" FieldLabel="描述" AnchorHorizontal="98%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsAdapter" runat="server" CheckboxToggle="false" Title="数据接收适配器"
                        Layout="Form" LabelWidth="130">
                        <Items>
                            <ext:DisplayField ID="lblDataAdapterType" FieldLabel="数据接收适配器" AnchorHorizontal="98%"
                                runat="server">
                            </ext:DisplayField>
                            <ext:TextField ID="txtAdapterHandleName" runat="server" Hidden="true" Disabled="true"
                                Text="HttpGetPostAdapter.ashx" FieldLabel="适配器地址" AnchorHorizontal="98%" AllowBlank="false" />
                            <ext:DisplayField ID="lblChannelType" FieldLabel="通道类型" AnchorHorizontal="98%" runat="server">
                            </ext:DisplayField>
                            <ext:ComboBox ID="cmbIVRType" FieldLabel="时长策略" Hidden="true" AnchorHorizontal="98%  " runat="server"
                                Editable="false" SelectedIndex="0">
                                <Items>
                                    <ext:ListItem Text="不计算时长" Value="0" />
                                    <ext:ListItem Text="时间差计算时长" Value="1" />
                                </Items>
                                <Listeners>
                                </Listeners>
                            </ext:ComboBox>
                            <ext:TextField ID="txtIVRTimeFormat" runat="server"  Hidden="true" AnchorHorizontal="98%" FieldLabel="日期格式"
                                AllowBlank="True" />
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsIsStateReport" runat="server" CheckboxToggle="true" Title="数据状态报告设置"
                        AutoHeight="true" Collapsed="true" LabelWidth="130" Layout="Form">
                        <Items>
                            <ext:RadioGroup ID="rdgStateReportType" runat="server" AnchorHorizontal="98%" ColumnsWidths="100,150,200"
                                FieldLabel="状态报告类型">
                                <Items>
                                    <ext:Radio ID="Radio1" runat="server" BoxLabel="单次状态报告" InputValue="0" Checked="true" />
                                    <ext:Radio ID="Radio2" runat="server" BoxLabel="双次状态报告（普通）" InputValue="1" />
                                    <ext:Radio ID="Radio3" runat="server" BoxLabel="双次状态报告（分类型请求）" InputValue="2" />
                                </Items>
                                <Listeners>
                                    <Change Handler="changeStateReportType(#{rdgStateReportType},#{cpTypeReportSetting});">
                                    </Change>
                                </Listeners>
                            </ext:RadioGroup>
                            <ext:TextField ID="txtStateReportParamName" runat="server" FieldLabel="状态报告参数" AnchorHorizontal="95%" />
                            <ext:TextField ID="txtStateReportParamValue" runat="server" FieldLabel="状态报告成功标示"
                                AnchorHorizontal="95%" />
                            <ext:CompositeField ID="CompositeField1" runat="server" FieldLabel="状态报告响应信息" AnchorHorizontal="95%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField4" runat="server" Text="成功信息：" />
                                    <ext:TextField ID="txtReportOkMessage" runat="server" Width="80" AllowBlank="true" />
                                    <ext:DisplayField ID="DisplayField5" runat="server" Text="失败信息：" />
                                    <ext:TextField ID="txtReportFailedMessage" runat="server" Width="80" AllowBlank="true" />
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField ID="cpTypeReportSetting" runat="server" FieldLabel="分类型请求参数"
                                Hidden="true" AnchorHorizontal="95%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField1" runat="server" Text="请求类型参数：" />
                                    <ext:TextField ID="txtRequestTypeParamName" runat="server" Width="80" AllowBlank="true" />
                                    <ext:DisplayField ID="DisplayField2" runat="server" Text="状态报告值：" />
                                    <ext:TextField ID="txtRequestTypeParamStateReportValue" runat="server" Width="80"
                                        AllowBlank="true" />
                                    <ext:DisplayField ID="DisplayField3" runat="server" Text="数据请求值：" />
                                    <ext:TextField ID="txtRequestTypeParamDataReportValue" runat="server" Width="80"
                                        AllowBlank="true" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet2" runat="server" CheckboxToggle="false" Title="其他设置" AutoHeight="true"
                        Collapsed="false" LabelWidth="75" Layout="Form">
                        <Items>
                            <ext:Container ID="Container7" runat="server" Layout="Column" Height="46" AnchorHorizontal="98%">
                                <Items>
                                    <ext:Container ID="Container8" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="chkIsParamsConvert" FieldLabel="请求参数转换" AnchorHorizontal="95%"
                                                runat="server" />
                                            <ext:Checkbox ID="chkIsAutoLinkID" FieldLabel="自动生成LinkID" AnchorHorizontal="95%"
                                                runat="server">
                                                <Listeners>
                                                    <Check Handler="changeAutoLinkID(#{chkIsAutoLinkID},#{txtAutoLinkIDFields});"></Check>
                                                </Listeners>
                                            </ext:Checkbox>
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container9" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="chkIsMonitorRequest" FieldLabel="监控请求" AnchorHorizontal="95%" runat="server" />
                                            <ext:TextField ID="txtAutoLinkIDFields" FieldLabel="LinkID生成字段" Hidden="true" AnchorHorizontal="95%"
                                                runat="server">
                                            </ext:TextField>
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container10" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="chkIsLogRequest" FieldLabel="记录请求日志" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container11" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="chkHasFilters" FieldLabel="过滤请求" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnEdit" runat="server" Text="编辑" Icon="Accept">
                        <DirectEvents>
                            <Click Before="if(!#{panlQuickAddChannel}.getForm().isValid()) return false;" OnEvent="btnEdit_Click"
                                Success="Ext.MessageBox.alert('操作成功', '编辑通道成功！' ,callback);function callback(id) {#{panlQuickAddChannel}.getForm().reset();parent.RefreshSPChannelData();parent.CloseEdit(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                <EventMask ShowMask="true" Msg="数据保存中,请稍等....." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnClose" runat="server" Text="取消" Icon="Decline">
                        <Listeners>
                            <Click Handler="parent.CloseEdit();"></Click>
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

