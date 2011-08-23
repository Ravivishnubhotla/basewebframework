<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="WizardPanel" runat="server" Title="快速添加通道" Frame="true" Layout="card"
                ActiveIndex="0">
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
                                    <Select Handler="#{WizardPanel}.layout.setActiveItem(index);"></Select>
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Title="短信通道(SP)" Frame="true"  Layout="Fit" >
                        <Items>
                            <ext:TableLayout ID="TableLayout1" runat="server" Columns="3" ColumnWidth="0.33">
                                <Cells>
                                    <ext:Cell>
                                        <ext:TextField ID="txtLinkParamsName" runat="server" FieldLabel="LinkID字段" AllowBlank="True" AnchorHorizontal="98%"  />
                                    </ext:Cell>
                                    <ext:Cell>
                                        <ext:TextField ID="txtMobileParamsName" runat="server" FieldLabel="Mobile字段" AllowBlank="True"  AnchorHorizontal="98%" />
                                    </ext:Cell>
                                    <ext:Cell>
                                        <ext:TextField ID="txtSPcodeParamsName" runat="server" FieldLabel="SPcode字段" AllowBlank="True"  AnchorHorizontal="98%" />
                                    </ext:Cell>
                                    <ext:Cell>
                                        <ext:TextField ID="txtMoParamsName" runat="server" FieldLabel="Mo字段" AllowBlank="True" />
                                    </ext:Cell>
                                    <ext:Cell>
                                    <ext:TextField ID="txtExtend1" runat="server" FieldLabel="扩展1" AllowBlank="True" />
                                    </ext:Cell>
                                    <ext:Cell>
                                    <ext:TextField ID="txtExtend2" runat="server" FieldLabel="扩展2" AllowBlank="True" />
                                    </ext:Cell>
                                </Cells>
                            </ext:TableLayout>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" Html="<h1>Card 2</h1><p>Step 2 of 3</p>" Title="声讯通道(IVR)"
                        Frame="true" />
                    <ext:Panel ID="Panel3" runat="server" Html="<h1>Congratulations!</h1><p>Step 3 of 3 - Complete</p>"
                        Title="声讯通道(IVR))" Frame="true" />
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
