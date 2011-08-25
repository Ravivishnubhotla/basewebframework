<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="formChannelParamsSeting" runat="server" Title="通道参数设置" Frame="true"
                Layout="card" ActiveIndex="0">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:ToolbarTextItem runat="server" Text="选择通道类型" />
                            <ext:ToolbarSpacer runat="server" />
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
                            <ext:TableLayout ID="TableLayout1" runat="server" Columns="4" ColumnWidth="0.25">
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
                                        <ext:TextField ID="txtState" runat="server" FieldLabel="状态字段" LabelWidth="80" LabelAlign="Right"
                                            LabelPad="10" AllowBlank="True" AnchorHorizontal="85%" />
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
                    <ext:Panel ID="pnlParamsIVR" runat="server" 
                        Title="声讯通道(IVR)" Frame="true" Layout="Fit">
                        <Items>
                            <ext:TableLayout ID="TableLayout2" runat="server" Columns="4" ColumnWidth="0.25">
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
                                        <ext:TextField ID="txtIVRStartTime" runat="server" FieldLabel="开始时间" LabelWidth="80" LabelAlign="Right"
                                            LabelPad="10" AllowBlank="True" AnchorHorizontal="85%" />
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
                                </Cells>
                            </ext:TableLayout>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="pnlParamsCustom" runat="server" Html="待定" Title="自定义通道" Frame="true" />
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
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
