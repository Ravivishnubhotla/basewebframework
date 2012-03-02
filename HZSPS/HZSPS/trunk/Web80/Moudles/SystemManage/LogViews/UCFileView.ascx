<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFileView.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SystemManage.LogViews.UCFileView" %>

<ext:Window ID="winFileView" runat="server" Icon="ApplicationEdit" Title="查看日志"
    ConstrainHeader="true" Width="800" Height="600" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelFileView" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutFileView" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidFilePath" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblFileName" runat="server" FieldLabel="日志名" AllowBlank="True"  />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%" Vertical="-30">
                                <ext:TextArea ID="lblFileContent" runat="server" FieldLabel="日志内容" AllowBlank="True"   />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnClose" runat="server" Text="关闭" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winFileView}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
