<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ResetInterceptToSycn.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ResetInterceptToSycn" %>

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
                <ext:FormPanel ID="formResetIntercept" runat="server" Frame="true" Header="false"
                    MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                    <Body>
                        <ext:FormLayout ID="FormLayoutResetIntercept" runat="server" LabelSeparator=":" LabelWidth="100">
                            <Anchors>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Hidden ID="hidClientChannelID" runat="server">
                                    </ext:Hidden>
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Hidden ID="hidClientID" runat="server">
                                    </ext:Hidden>
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Hidden ID="hidChannelID" runat="server">
                                    </ext:Hidden>
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Hidden ID="hidMaxChangeCount" runat="server" Text="100">
                                    </ext:Hidden>
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Label ID="lblChannleName" runat="server" FieldLabel="通道名" AllowBlank="True" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Label ID="lblClientName" runat="server" FieldLabel="下家名" AllowBlank="True" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Label ID="lblDownCount" runat="server" FieldLabel="点播数" AllowBlank="True" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:Label ID="lblSycnCount" runat="server" FieldLabel="扣量" AllowBlank="True" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:NumberField ID="numMaxCount" runat="server" FieldLabel="最大取消数" MinValue="0"
                                        MaxValue="100" DecimalPrecision="0" Text="20">
                                    </ext:NumberField>
                                </ext:Anchor>
                            </Anchors>
                        </ext:FormLayout>
                    </Body>
                    <Buttons>
                        <ext:Button ID="btnResetIntercept" runat="server" Text="取消扣量同步下家" Icon="Add">
                            <AjaxEvents>
                                <Click Timeout="120000" Before="if(!#{formResetIntercept}.getForm().isValid()) return false;#{winProgress}.show();"
                                    OnEvent="btnResetIntercept_Click" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                </Click>
                            </AjaxEvents>
                        </ext:Button>
                        <ext:Button ID="btnCancelResetIntercept" runat="server" Text="取消" Icon="Cancel">
                            <Listeners>
                                <Click Handler="parent.CloseInterceptReset();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidChannelClientID" runat="server">
    </ext:Hidden>
    <ext:TaskManager ID="TaskManager1" runat="server">
        <Tasks>
            <ext:Task TaskID="longactionprogress" Interval="1000" AutoRun="false" OnStop="
                        #{winProgress}.hide();RefreshPage();">
                <AjaxEvents>
                    <Update Timeout="120000" OnEvent="RefreshProgress" />
                </AjaxEvents>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>
    <ext:Window ID="winProgress" runat="server" Closable="false" Resizable="false" ShowOnLoad="false"
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
