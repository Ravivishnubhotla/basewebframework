<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailTemplateAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailTemplates.UCSystemEmailTemplateAdd" %>
<ext:Window ID="winSystemEmailTemplateAdd" runat="server" Icon="ApplicationAdd" Title="SystemEmailTemplate Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailTemplateAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
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
        <ext:Button ID="btnSavelSystemEmailTemplate" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemEmailTemplateAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemEmailTemplate_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSystemEmailTemplateAdd}.getForm().reset();#{storeSystemEmailTemplate}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemEmailTemplate" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemEmailTemplateAdd}.getForm().reset();#{winSystemEmailTemplateAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
