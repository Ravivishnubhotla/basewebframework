<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeView" %>

<ext:Window ID="winSPCodeView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPCode"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPCodeID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblID" runat="server" FieldLabel="ID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblChannelID" runat="server" FieldLabel="ChannelID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblMO" runat="server" FieldLabel="MO" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblMOType" runat="server" FieldLabel="MOType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblOrderIndex" runat="server" FieldLabel="OrderIndex" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSPCode" runat="server" FieldLabel="SPCode" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblProvince" runat="server" FieldLabel="Province" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDisableCity" runat="server" FieldLabel="DisableCity" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsDiable" runat="server" FieldLabel="IsDiable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSPType" runat="server" FieldLabel="SPType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCodeLength" runat="server" FieldLabel="CodeLength" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDayLimit" runat="server" FieldLabel="DayLimit" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblMonthLimit" runat="server" FieldLabel="MonthLimit" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblPrice" runat="server" FieldLabel="Price" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSendText" runat="server" FieldLabel="SendText" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblHasFilters" runat="server" FieldLabel="HasFilters" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
