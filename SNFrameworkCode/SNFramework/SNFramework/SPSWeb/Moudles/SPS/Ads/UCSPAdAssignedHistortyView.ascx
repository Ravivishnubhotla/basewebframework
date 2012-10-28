
 
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdAssignedHistortyView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdAssignedHistortyView" %>

<ext:Window ID="winSPAdAssignedHistortyView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPAdAssignedHistorty"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdAssignedHistortyView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPAdAssignedHistortyID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblSPAdID" runat="server" FieldLabel="SPAdID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSPAdPackID" runat="server" FieldLabel="SPAdPackID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSPClientID" runat="server" FieldLabel="SPClientID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblStartDate" runat="server" FieldLabel="StartDate" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblEndDate" runat="server" FieldLabel="EndDate" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateAt" runat="server" FieldLabel="CreateAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyBy" runat="server" FieldLabel="LastModifyBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyAt" runat="server" FieldLabel="LastModifyAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyComment" runat="server" FieldLabel="LastModifyComment" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>




