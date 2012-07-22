<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelQuery.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelQuery" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
<ext:Window ID="winSPClientChannelQuery" runat="server" Icon="ApplicationEdit" ConstrainHeader="true"
    Title="通道用户数查询" Width="640" Height="399" AutoShow="false" Maximizable="true" Modal="true"
    ShowOnLoad="false" AutoScroll="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelQuery" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayout4" runat="server">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblName" runat="server" FieldLabel="名称" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat="server" FieldLabel="通道">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientGroupName" runat="server" FieldLabel="下家组">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelClientCode" runat="server" FieldLabel="指令" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:DateField FieldLabel="开始时间" ID="dfStart" runat="server" AllowBlank="False">
                                </ext:DateField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:DateField FieldLabel="结束时间" ID="dfEnd" runat="server" AllowBlank="False">
                                </ext:DateField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIncludeSubCode" runat="server" FieldLabel="包含子指令">
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkAfterIntercept" runat="server" FieldLabel="扣除后数据">
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblResult" runat="server" FieldLabel="查询结果" AllowBlank="False" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSPClientChannelQuery" runat="server" Text="查询" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelQuery}.getForm().isValid()) return false;"
                    OnEvent="btnSPClientChannelQuery_Click"  Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelwinSPClientChannelQuery" runat="server" Text="关闭" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelQuery}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
