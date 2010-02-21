<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl5.ascx.cs"
    Inherits="ExtJSConsole.Moudle.WebUserControl5" %>
<ext:Window ID="SystemApplicationInfoDetailsWindow" runat="server" Icon="Group" Title="系统应用信息"
    Width="400" Height="400" AutoShow="false" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout1" runat="server">
            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                <Tabs>
                    <ext:Tab runat="server" ID="tabBaseSystemApplicationInfo" Title="基本信息" Icon="ChartOrganisation"
                        BodyStyle="padding:5px;">
                        <Body>
                            <ext:FormPanel ID="FormPanel1" runat="server" BodyStyle="padding:5px;" ButtonAlign="Right"
                                Frame="true" Title="邮件发送表单" Width="450">
                                <Body>
                                    <ext:FormLayout ID="FormLayout2" runat="server" LabelWidth="60" >
                                        <ext:Anchor Horizontal="100%">
                                            <ext:TextField ID="tfTitle" runat="server" FieldLabel="邮件主题" AllowBlank="false" BlankText="邮件主题不能为空" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:TextArea ID="tfContent" runat="server" FieldLabel="邮件内容" Height="150" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:FileUploadField ID="upAttachment" runat="server" FieldLabel="邮件附件" ButtonText="选择附件" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:DateField ID="tfTime" runat="server" FieldLabel="发送时间" />
                                        </ext:Anchor>
                                    </ext:FormLayout>
                                </Body>
                                <Buttons>
                                    <ext:Button ID="btnSend" CausesValidation=true runat="server" Icon="WorldGo" Text="发送">
                                        <AjaxEvents>
                                            <Click OnEvent="SendClick" />
                                        </AjaxEvents>
                                    </ext:Button>
                                </Buttons>
                            </ext:FormPanel>
                        </Body>
                    </ext:Tab>
                </Tabs>
            </ext:TabPanel>
        </ext:FitLayout>
    </Body>
</ext:Window>
