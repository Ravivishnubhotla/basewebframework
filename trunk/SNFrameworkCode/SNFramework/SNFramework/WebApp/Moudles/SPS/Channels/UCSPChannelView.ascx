<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelView" %>
<ext:Window ID="winSPChannelView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPChannel"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPChannelID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblOtherRecieved" runat="server" FieldLabel="OtherRecieved" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblOtherRecievedUrl" runat="server" FieldLabel="OtherRecievedUrl" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblRecievedName" runat="server" FieldLabel="RecievedName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsAllowNullLinkID" runat="server" FieldLabel="IsAllowNullLinkID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsMonitorRequest" runat="server" FieldLabel="IsMonitorRequest" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsDisable" runat="server" FieldLabel="IsDisable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDataOkMessage" runat="server" FieldLabel="DataOkMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDataFailedMessage" runat="server" FieldLabel="DataFailedMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblReportOkMessage" runat="server" FieldLabel="ReportOkMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblReportFailedMessage" runat="server" FieldLabel="ReportFailedMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblStatSendOnce" runat="server" FieldLabel="StatSendOnce" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblTypeRequest" runat="server" FieldLabel="TypeRequest" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDataParamName" runat="server" FieldLabel="DataParamName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDataParamValue" runat="server" FieldLabel="DataParamValue" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblReportParamName" runat="server" FieldLabel="ReportParamName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblReportParamValue" runat="server" FieldLabel="ReportParamValue" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblHasFilters" runat="server" FieldLabel="HasFilters" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblStatusParamName" runat="server" FieldLabel="StatusParamName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblStatusParamValue" runat="server" FieldLabel="StatusParamValue" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblPrice" runat="server" FieldLabel="Price" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDefaultRate" runat="server" FieldLabel="DefaultRate" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblHasStatReport" runat="server" FieldLabel="HasStatReport" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblChannelDetailInfo" runat="server" FieldLabel="ChannelDetailInfo" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblUpperID" runat="server" FieldLabel="UpperID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsIVR" runat="server" FieldLabel="IsIVR" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsLogRequest" runat="server" FieldLabel="IsLogRequest" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>

