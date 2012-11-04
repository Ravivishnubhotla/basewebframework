<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPUpperView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Uppers.UCSPUpperView" %>

<ext:Window ID="winSPUpperView" runat="server" Icon="ApplicationViewDetail" Title="查看SPUpper"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPUpperView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                <ext:Hidden ID="hidSPUpperID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />

                <ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />

                <ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />

                <%--					<ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateAt" runat="server" FieldLabel="CreateAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyBy" runat="server" FieldLabel="LastModifyBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyAt" runat="server" FieldLabel="LastModifyAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyComment" runat="server" FieldLabel="LastModifyComment" AnchorHorizontal="95%" />--%>
            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>




