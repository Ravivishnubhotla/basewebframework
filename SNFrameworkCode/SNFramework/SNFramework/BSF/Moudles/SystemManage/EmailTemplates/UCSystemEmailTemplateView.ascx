<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailTemplateView.ascx.cs"
    Inherits="SNFramework.BSF.Moudles.SystemManage.EmailTemplates.UCSystemEmailTemplateView" %>
<ext:Window ID="winSystemEmailTemplateView" runat="server" Icon="ApplicationViewDetail"
    Title="ShowSystemEmailTemplate" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailTemplateView" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidSystemEmailTemplateID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblTemplateType" runat="server" FieldLabel="TemplateType" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblTitleTemplate" runat="server" FieldLabel="TitleTemplate"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblBodyTemplate" runat="server" FieldLabel="BodyTemplate" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblIsHtmlEmail" runat="server" FieldLabel="IsHtmlEmail" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblIsEnable" runat="server" FieldLabel="IsEnable" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateDate" runat="server" FieldLabel="CreateDate" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
