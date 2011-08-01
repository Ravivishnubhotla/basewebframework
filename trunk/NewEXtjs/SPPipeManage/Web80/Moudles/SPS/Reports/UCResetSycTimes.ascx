<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResetSycTimes.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.UCResetSycTimes" %>
<ext:Window ID="winResetSycTimes" runat="server" Icon="ApplicationAdd" Title="重新发送数据"
    ConstrainHeader="true" Width="500" Height="320" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
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
                                <ext:MultiField ID="mfDownCount" runat="server" FieldLabel="转发下家数">
                                    <Fields>
                                        <ext:Label ID="lblDownCount" runat="server" Width="100" />
                                        <ext:Button ID="btnReSendDown" runat="server" Text="重新发送" Icon="LightningGo">
                                            <ToolTips>
                                                <ext:ToolTip runat="server" Title="提示" Html="把要同步成给下家的所有数据重新同步，包括成功同步的和同步失败的。">
                                                </ext:ToolTip>
                                            </ToolTips>
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
                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="提示" Html="把未能设置为同步状态的所有数据重新同步，主要是由于忘记设置同步URL所产生的数据。">
                                                </ext:ToolTip>
                                            </ToolTips>
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
                                                <ext:ToolTip ID="ToolTip2" runat="server" Title="提示" Html="把同步给下家返回成功状态的所有数据重新同步。">
                                                </ext:ToolTip>
                                            </ToolTips>
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
                                                <ext:ToolTip ID="ToolTip3" runat="server" Title="提示" Html="把同步给下家返回失败状态的所有数据重新同步。">
                                                </ext:ToolTip>
                                            </ToolTips>
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
    <Buttons>
        <ext:Button ID="btnCancelResetSycTimes" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winResetSycTimes}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<%--<ext:TaskManager ID="TaskManager2" runat="server">
    <Tasks>
        <ext:Task TaskID="longactionprogress" Interval="1000" AutoRun="false" OnStart="
                        #{btnResetIntercept}.setDisabled(true);" OnStop="
                        #{btnResetIntercept}.setDisabled(false);#{winProgress2}.hide();">
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
</ext:Window>--%>
