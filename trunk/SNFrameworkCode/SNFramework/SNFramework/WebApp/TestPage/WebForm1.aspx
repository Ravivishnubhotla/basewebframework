<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.WebForm1" %>

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

    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:FormPanel ID="panlQuickAddChannel" runat="server" Title="快速添加通道" Frame="true"
                AutoScroll="true">
                <Items>
                    <ext:FieldSet ID="FieldSet3" runat="server" Title="通道基本信息" AutoHeight="true" LabelWidth="75"
                        Layout="Form">
                        <Items>
                            <ext:Container ID="Container1" runat="server" Layout="Column" Height="30" AnchorHorizontal="98%">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="TextField11" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container5" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="TextField12" runat="server" FieldLabel="编码" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container6" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="TextField15" runat="server" FieldLabel="成功响应信息" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:TextField ID="TextField14" runat="server" FieldLabel="失败响应信息" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container4" runat="server" Layout="Form" AnchorHorizontal="98%">
                                <Items>
                                    <ext:TextArea ID="HtmlEditor1" runat="server" Height="50" FieldLabel="描述" AnchorHorizontal="98%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsAdapter" runat="server" CheckboxToggle="false" Title="数据接收适配器"
                        Layout="Form" LabelWidth="130">
                        <Items>
                            <ext:RadioGroup ID="rdgSelectDataAdapter" runat="server" ColumnsWidths="150,150,150"
                                AnchorHorizontal="98%" FieldLabel="选择数据接收适配器">
                                <Items>
                                    <ext:Radio ID="Radio4" runat="server" BoxLabel="HttpGetPost适配器" InputValue="0" Checked="true" />
                                    <ext:Radio ID="Radio5" runat="server" BoxLabel="XMLPost适配器" InputValue="1" />
                                    <ext:Radio ID="Radio6" runat="server" BoxLabel="自定义适配器" InputValue="2" />
                                </Items>
                                <Listeners>
                                    <Change Handler="ChangeAdapter(#{rdgSelectDataAdapter},#{txtAdapterHandleName});">
                                    </Change>
                                </Listeners>
                            </ext:RadioGroup>
                            <ext:TextField ID="txtAdapterHandleName" runat="server" Hidden="true" Disabled="true"
                                Text="HttpGetPostAdapter.ashx" FieldLabel="适配器地址" AnchorHorizontal="98%" />
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsParams" runat="server" Height="225" CheckboxToggle="false" Title="通道参数设置"
                        Layout="Fit" Frame="true">
                        <Items>
                            <ext:Panel ID="formChannelParamsSeting" runat="server" Title="设置" Frame="true" Layout="card"
                                ActiveIndex="0">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="选择通道类型" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" />
                                            <ext:ComboBox ID="cmbChannelType" runat="server" Editable="false" SelectedIndex="0">
                                                <Items>
                                                    <ext:ListItem Text="短信通道(SP)" Value="0" />
                                                    <ext:ListItem Text="声讯通道(IVR)" Value="1" />
                                                    <ext:ListItem Text="自定义通道" Value="2" />
                                                </Items>
                                                <Listeners>
                                                    <Select Handler="#{formChannelParamsSeting}.layout.setActiveItem(index);"></Select>
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Items>
                                    <ext:Panel ID="pnlParamsSP" runat="server" Title="短信通道(SP)" Frame="true" Layout="Fit">
                                        <Items>
                                            <ext:TableLayout ID="TableLayout1" runat="server" Columns="5" ColumnWidth="0.2">
                                                <Cells>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtLinkParamsName" runat="server" FieldLabel="LinkID字段" LabelWidth="80"
                                                            LabelAlign="Right" LabelPad="10" AllowBlank="True" AnchorHorizontal="85%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtMobileParamsName" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="Mobile字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtSPcodeParamsName" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="SPcode字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtMoParamsName" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="Mo字段" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtCreateDate" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="日期字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtProvince" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="省份字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtCity" runat="server" LabelWidth="80" LabelAlign="Right" LabelPad="10"
                                                            FieldLabel="地市字段" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend1" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展1" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend2" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展2" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend3" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展3" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend4" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展4" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend5" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展5" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend6" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展6" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend7" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展7" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend8" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展8" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend9" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展9" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtExtend10" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展10" AllowBlank="True" />
                                                    </ext:Cell>
                                                </Cells>
                                            </ext:TableLayout>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="pnlParamsIVR" runat="server" Title="声讯通道(IVR)" Frame="true" Layout="Fit">
                                        <Items>
                                            <ext:TableLayout ID="TableLayout2" runat="server" Columns="5" ColumnWidth="0.2">
                                                <Cells>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRLinkID" runat="server" FieldLabel="LinkID字段" LabelWidth="80"
                                                            LabelAlign="Right" LabelPad="10" AllowBlank="True" AnchorHorizontal="85%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRMobile" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="Mobile字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRSPCode" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="SPcode字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRFeetime" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="时长字段" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRStartTime" runat="server" FieldLabel="开始时间" LabelWidth="80"
                                                            LabelAlign="Right" LabelPad="10" AllowBlank="True" AnchorHorizontal="85%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVREndTime" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="结束时间" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="TextField7" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="省份字段" AllowBlank="True" AnchorHorizontal="98%" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="TextField8" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="地市字段" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend1" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展1" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend2" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展2" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend3" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展3" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend4" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展4" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend5" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展5" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend6" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展6" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend7" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展7" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend8" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展8" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend9" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展9" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="txtIVRExtend10" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="扩展10" AllowBlank="True" />
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:ComboBox ID="cmbIVRType" FieldLabel="时长策略" LabelWidth="86" Width="220" LabelAlign="Right"
                                                            runat="server" Editable="false" SelectedIndex="0">
                                                            <Items>
                                                                <ext:ListItem Text="不计算时长" Value="0" />
                                                                <ext:ListItem Text="时间差计算时长" Value="1" />
                                                            </Items>
                                                            <Listeners>
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </ext:Cell>
                                                    <ext:Cell>
                                                        <ext:TextField ID="TextField5" runat="server" LabelWidth="80" LabelAlign="Right"
                                                            LabelPad="10" FieldLabel="日期格式" AllowBlank="True" />
                                                    </ext:Cell>
                                                </Cells>
                                            </ext:TableLayout>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="pnlParamsCustom" runat="server" Html="待定" Title="自定义通道" Frame="true" />
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="true" Title="数据状态报告设置"
                        AutoHeight="true" Collapsed="false" LabelWidth="130" Layout="Form">
                        <Items>
                            <ext:RadioGroup ID="RadioGroup1" runat="server" AnchorHorizontal="98%" ColumnsWidths="100,150,200"
                                FieldLabel="状态报告类型">
                                <Items>
                                    <ext:Radio ID="Radio1" runat="server" BoxLabel="单次状态报告" InputValue="0" Checked="true" />
                                    <ext:Radio ID="Radio2" runat="server" BoxLabel="双次状态报告（普通）" InputValue="1" />
                                    <ext:Radio ID="Radio3" runat="server" BoxLabel="双次状态报告（分类型请求）" InputValue="2" />
                                </Items>
                                <Listeners>
                                </Listeners>
                            </ext:RadioGroup>
                            <ext:TextField ID="TextField1" runat="server" FieldLabel="状态报告参数" AnchorHorizontal="95%" />
                            <ext:TextField ID="TextField13" runat="server" FieldLabel="状态报告成功标示" AnchorHorizontal="95%" />
                            <ext:CompositeField ID="CompositeField1" runat="server" FieldLabel="分类型请求参数" AnchorHorizontal="95%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField1" runat="server" Text="请求类型参数：" />
                                    <ext:TextField ID="TextField2" runat="server" Width="80" AllowBlank="false" />
                                    <ext:DisplayField ID="DisplayField2" runat="server" Text="状态报告值：" />
                                    <ext:TextField ID="TextField3" runat="server" Width="80" AllowBlank="false" />
                                    <ext:DisplayField ID="DisplayField3" runat="server" Text="数据请求值：" />
                                    <ext:TextField ID="TextField4" runat="server" Width="80" AllowBlank="false" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet2" runat="server" CheckboxToggle="true" Title="其他设置" AutoHeight="true"
                        Collapsed="false" LabelWidth="75" Layout="Form">
                        <Items>
                            <ext:Container ID="Container7" runat="server" Layout="Column" Height="60" AnchorHorizontal="98%">
                                <Items>
                                    <ext:Container ID="Container8" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="Checkbox1" FieldLabel="自动生成LinkID" AnchorHorizontal="95%" runat="server" />
                                            <ext:Checkbox ID="Checkbox5" FieldLabel="请求参数转换" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container9" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:ComboBox ID="ComboBox1" FieldLabel="LinkID策略" AnchorHorizontal="95%"
                                                runat="server" Editable="false" SelectedIndex="0">
                                                <Items>
                                                    <ext:ListItem Text="随机生成" Value="0" />
                                                    <ext:ListItem Text="手机号时间" Value="1" />
                                                    <ext:ListItem Text="时间" Value="2" />
                                                </Items>
                                                <Listeners>
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:Checkbox ID="Checkbox2" FieldLabel="监控请求" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container10" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="Checkbox3" FieldLabel="记录请求日志" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container11" runat="server" Layout="Form" ColumnWidth=".25">
                                        <Items>
                                            <ext:Checkbox ID="Checkbox4" FieldLabel="过滤请求" AnchorHorizontal="95%" runat="server" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnPrev" runat="server" Text="添加" Icon="Accept">
                        <DirectEvents>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnNext" runat="server" Text="取消" Icon="Decline">
                        <DirectEvents>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
