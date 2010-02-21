<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs"
    Inherits="ExtJSConsole.Moudle.WebUserControl2" %>
<ext:Window ID="SystemApplicationInfoAddWindows" runat="server" Icon="Group" Title="系统应用信息"
    Width="400" Height="400" AutoShow="false" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout1" runat="server">
            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
                <Tabs>
                    <ext:Tab runat="server" ID="tabBaseSystemApplicationInfo" Title="基本信息" Icon="ChartOrganisation"
                        BodyStyle="padding:5px;">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <ext:Anchor>
                                    <ext:TextField ID="txtSystemApplicationName" runat="server" FieldLabel="名称" Width="250"
                                        AllowBlank="false" />
                                </ext:Anchor>
                                <ext:Anchor>
                                    <ext:TextField ID="txtSystemApplicationDescription" runat="server" FieldLabel="描述"
                                        Width="250" />
                                </ext:Anchor>
                                <ext:Anchor>
                                    <ext:TextField ID="txtSystemApplicationUrl" runat="server" FieldLabel="链接" Width="250" />
                                </ext:Anchor>
                                <ext:Anchor>
                                    <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" runat="server" FieldLabel="是否为系统应用"
                                        Width="250">
                                    </ext:Checkbox>
                                </ext:Anchor>
                            </ext:FormLayout>
                        </Body>
                    </ext:Tab>
                </Tabs>
            </ext:TabPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="SaveButton" runat="server" Text="保存" Icon="Disk">
            <AjaxEvents>
                <Click Before="showProcessMsg();" OnEvent="SaveAction" Success="Ext.MessageBox.hide();Ext.MessageBox.alert('提示', '数据保存成功！');" Failure="Ext.MessageBox.hide();Ext.MessageBox.alert('错误', '数据保存失败！');">
                    <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{SystemApplicationInfoAddWindows}.body}" />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="CancelButton" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{SystemApplicationInfoAddWindows}.hide(null);" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
