<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailTemplateEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailTemplates.UCSystemEmailTemplateEdit" %>
<ext:Window ID="winSystemEmailTemplateEdit" runat="server" Icon="ApplicationEdit"
    Title="Edit SystemEmailTemplate" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailTemplateEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidEmailTemplateID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbTemplateType" Editable="false" runat="server" FieldLabel="Template Type"
                    AllowBlank="True" SelectedIndex="0" AnchorHorizontal="95%">
                    <Items>
                        <ext:ListItem Value="1" Text="String Template"></ext:ListItem>
                        <ext:ListItem Value="2" Text="NVelocity Template"></ext:ListItem>
                    </Items>
                </ext:ComboBox>
                <ext:TextArea ID="txtTitleTemplate" runat="server" FieldLabel="TitleTemplate" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtBodyTemplate" runat="server" FieldLabel="BodyTemplate" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsHtmlEmail" runat="server" FieldLabel="IsHtmlEmail" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"
                    AnchorHorizontal="95%" />
  
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemEmailTemplate" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailTemplateEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailTemplate_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSystemEmailTemplateEdit}.getForm().reset();#{storeSystemEmailTemplate}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailTemplate" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailTemplateEdit}.getForm().reset();#{winSystemEmailTemplateEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
