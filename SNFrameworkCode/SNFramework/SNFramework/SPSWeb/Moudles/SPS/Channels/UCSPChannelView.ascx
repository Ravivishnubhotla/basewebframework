<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.UCSPChannelView" %>
<ext:Window ID="winSPChannelView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPChannel"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="60"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidSPChannelID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblName" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblChannelDetailInfo" runat="server" FieldLabel="详细信息" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
