<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReSendData.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReSendData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManager1" runat="server">
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        function RefreshPage() {
            Coolite.AjaxMethods.RefreshPage({
                failure: function (msg) {
                    Ext.Msg.alert('操作失败', msg);
                },
                eventMask: {
                    showMask: true,
                    msg: '加载中...'
                }
            }
                );
        }
    </script>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formResetSycTimes" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayoutResetSycTimes" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidClientChannelID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannleName" runat="server" FieldLabel="通道名" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientName" runat="server" FieldLabel="下家名" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidMaxChangeCount" runat="server" Text="1000">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="numMaxCount" runat="server" FieldLabel="最大重发数" MinValue="0"
                                    MaxValue="1000" DecimalPrecision="0" Text="20">
                                </ext:NumberField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:MultiField ID="mfDownCount" runat="server" FieldLabel="转发下家数">
                                    <Fields>
                                        <ext:Label ID="lblDownCount" runat="server" Width="100" />
                                        <ext:Button ID="btnReSendDown" runat="server" Text="重新发送" Icon="LightningGo">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="提示" Html="把要同步成给下家的所有数据重新同步，包括成功同步的和同步失败的。">
                                                </ext:ToolTip>
                                            </ToolTips>
                                            <AjaxEvents>
                                                <Click Timeout="120000" Before="#{prgProcess}.updateText('');#{prgProcess}.updateProgress(0,'',false);#{winProgress2}.show();" OnEvent="btnReSendDown_Click"
                                                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Fields>
                                </ext:MultiField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="100%">
                                <ext:MultiField ID="mfDownNotSycnCount" runat="server" FieldLabel="未能转发下家数">
                                    <Fields>
                                        <ext:Label ID="lblDownNotSycnCount" runat="server" Width="100" />
                                        <ext:Button ID="btnReSendDownNotSycn" runat="server" Text="重新发送" Icon="LightningGo">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip2" runat="server" Title="提示" Html="把未能设置为同步状态的所有数据重新同步，主要是由于忘记设置同步URL所产生的数据。">
                                                </ext:ToolTip>
                                            </ToolTips>
                                            <AjaxEvents>
                                                <Click Timeout="120000" Before="#{prgProcess}.updateText('');#{prgProcess}.updateProgress(0,'',false);#{winProgress2}.show();" OnEvent="btnReSendDownNotSycn_Click"
                                                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Fields>
                                </ext:MultiField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:MultiField ID="mfSycnCount" runat="server" FieldLabel="同步下家数">
                                    <Fields>
                                        <ext:Label ID="lblSycnCount" runat="server" Width="100" />
                                        <ext:Button ID="btnReSendSycn" runat="server" Text="重新发送" Icon="LightningGo">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip3" runat="server" Title="提示" Html="把同步给下家返回成功状态的所有数据重新同步。">
                                                </ext:ToolTip>
                                            </ToolTips>
                                            <AjaxEvents>
                                                <Click Timeout="120000" Before="#{prgProcess}.updateText('');#{prgProcess}.updateProgress(0,'',false);#{winProgress2}.show();" OnEvent="btnReSendSycn_Click"
                                                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Fields>
                                </ext:MultiField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:MultiField ID="mfSycnFailedCount" runat="server" FieldLabel="同步下家失败数">
                                    <Fields>
                                        <ext:Label ID="lblSycnFailedCount" runat="server" Width="100" />
                                        <ext:Button ID="btnReSendSycnFailed" runat="server" Text="重新发送" Icon="LightningGo">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip4" runat="server" Title="提示" Html="把同步给下家返回失败状态的所有数据重新同步。">
                                                </ext:ToolTip>
                                            </ToolTips>
                                            <AjaxEvents>
                                                <Click Timeout="120000" Before="#{prgProcess}.updateText('');#{prgProcess}.updateProgress(0,'',false);#{winProgress2}.show();" OnEvent="btnReSendSycnFailed_Click"
                                                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Fields>
                                </ext:MultiField>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:TaskManager ID="TaskManager2" runat="server">
        <Tasks>
            <ext:Task TaskID="longactionprogress" Interval="1000" AutoRun="false" OnStop="#{winProgress2}.hide();RefreshPage();">
                <AjaxEvents>
                    <Update OnEvent="RefreshProgress" />
                </AjaxEvents>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>
    <ext:Window ID="winProgress2" runat="server" Closable="false" Resizable="false" ShowOnLoad="false"
        Icon="Lock" Title="Login" Draggable="false" Width="550" Modal="true" Padding="5"
        ButtonAlign="Center" Layout="Form">
        <Body>
            <ext:FormLayout ID="FormLayout1" runat="server" LabelSeparator="" LabelWidth="0">
                <Anchors>
                    <ext:Anchor Horizontal="99%">
                        <ext:ProgressBar ID="prgProcess" FieldLabel="" runat="server" />
                    </ext:Anchor>
                </Anchors>
            </ext:FormLayout>
        </Body>
        <Buttons>
            <ext:Button ID="btnCancel" runat="server" Text="Cancel" Icon="Decline">
                <AjaxEvents>
                    <Click OnEvent="OnCancel" />
                </AjaxEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</asp:Content>
