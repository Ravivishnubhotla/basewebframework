<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="SystemSettingEditor.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SettingManage.SystemSettingEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Icon="ServerWrench" Title="<%$ Resources:Panel1Title %>"
                Frame="true" Layout="Center">
                <Items>
                    <ext:Panel ID="Panel2" runat="server" Icon="ServerWrench" Title="<%$ Resources:Panel2Title %>" Width="500"
                        Frame="true" AutoHeight="true">
                        <Content>
                            <ext:FormPanel ID="formPanelSystemSettingEdit"  runat="server" Frame="true" Header="false"
                                MonitorValid="true" Layout="form" LabelSeparator=":" LabelWidth="100">
                                <Items>
                                    <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                                    </ext:Hidden>
                                    <ext:TextField ID="txtSystemName" runat="server" FieldLabel="<%$ Resources:txtSystemNameFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%" />
                                    <ext:TextArea ID="txtSystemDescription" runat="server" FieldLabel="<%$ Resources:txtSystemDescriptionFieldLabel %>"
                                        AllowBlank="True" AnchorHorizontal="95%" />
                                    <ext:TextField ID="txtSystemUrl" runat="server" FieldLabel="<%$ Resources:txtSystemUrlFieldLabel %>"
                                        AllowBlank="True" AnchorHorizontal="95%" />
                                    <ext:TextField ID="txtSystemVersion" runat="server" FieldLabel="<%$ Resources:txtSystemVersionFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%" />
                                    <ext:TextArea ID="txtSystemLisence" runat="server" FieldLabel="<%$ Resources:txtSystemLisenceFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%" />
                                </Items>
                            </ext:FormPanel>
                        </Content>
                        <Buttons>
                            <ext:Button ID="btnSaveSystemSetting" runat="server" Text="<%$ Resources:btnSaveSystemSettingText %>"
                                Icon="ApplicationEdit">
                                <DirectEvents>
                                    <Click Before="if(!#{formPanelSystemSettingEdit}.getForm().isValid()) return false;"
                                        OnEvent="btnSaveSystemSetting_Click" Success="<%$ Resources:SaveOkScript %>"
                                        Failure="<%$ Resources:SaveFailedScript %>">
                                        <EventMask ShowMask="true" Msg="<%$ Resources:btnSaveSystemSettingEventMaskMsg %>" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
