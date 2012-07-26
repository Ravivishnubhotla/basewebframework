<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailTemplateEdit.ascx.cs"
    Inherits="SNFramework.BSF.Moudles.SystemManage.EmailTemplates.UCSystemEmailTemplateEdit" %>
<ext:Window ID="winSystemEmailTemplateEdit" runat="server" Icon="ApplicationEdit"
    Title="<%$ Resources : msgFormTitle  %>" Width="680" Height="300" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailTemplateEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidEmailTemplateID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="<%$ Resources : msgFiledName  %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="<%$ Resources : msgFiledCode  %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="<%$ Resources : msgFiledDescription  %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbTemplateType" Editable="false" runat="server" FieldLabel="<%$ Resources : msgFiledTemplateType  %>"
                    AllowBlank="True" SelectedIndex="0" AnchorHorizontal="95%">
                    <Items>
                        <ext:ListItem Value="1" Text="String Template"></ext:ListItem>
                        <ext:ListItem Value="2" Text="NVelocity Template"></ext:ListItem>
                    </Items>
                </ext:ComboBox>
                <ext:TextArea ID="txtTitleTemplate" runat="server" FieldLabel="<%$ Resources : msgFiledTitleTemplate  %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:HtmlEditor ID="txtBodyTemplate" runat="server" FieldLabel="<%$ Resources : msgFiledBodyTemplate  %>"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsHtmlEmail" runat="server" FieldLabel="<%$ Resources : msgFiledIsHtmlEmail  %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="<%$ Resources : msgFiledIsEnable  %>"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemEmailTemplate" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailTemplateEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailTemplate_Click" Success="<%$ Resources : msgUpdateScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailTemplate" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailTemplateEdit}.getForm().reset();#{winSystemEmailTemplateEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
