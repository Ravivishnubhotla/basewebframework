<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsConvertView.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsConvertView" %>
<ext:Window ID="winSPChannelParamsConvertView" runat="server" Icon="ApplicationViewDetail"
    Title="ShowSPChannelParamsConvert" Width="400" Height="270" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsConvertView" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidSPChannelParamsConvertID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblParamsValue" runat="server" FieldLabel="ParamsValue" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblParamsConvertTo" runat="server" FieldLabel="ParamsConvertTo"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblParamsConvertType" runat="server" FieldLabel="ParamsConvertType"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblParamsConvertCondition" runat="server" FieldLabel="ParamsConvertCondition"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblChannelID" runat="server" FieldLabel="ChannelID" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateAt" runat="server" FieldLabel="CreateAt" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblLastModifyBy" runat="server" FieldLabel="LastModifyBy" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblLastModifyAt" runat="server" FieldLabel="LastModifyAt" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
