<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFileUpload.ascx.cs" Inherits="SNFramework.BSF.Files.UCFileUpload" %>
<ext:Window ID="winFileUpload" runat="server" Icon="PageAdd" Title="上传文件"
    Width="380" Height="120" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelUploadFile" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:FileUploadField
                    ID="fufUploadNewfile"
                    runat="server"
                    AllowBlank="True"
                    EmptyText="选择上传文件"
                    FieldLabel="上传文件"
                    ButtonText="..." AnchorHorizontal="95%" />
                <ext:Hidden ID="hidUploadPath" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelUploadFile" runat="server" Text="<%$ Resources : GlobalResource, msgUpload  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelUploadFile}.getForm().isValid()) return false;"
                    OnEvent="btnSaveUploadFile_Click" Success="Ext.MessageBox.alert('操作成功', '上传文件成功！',callback);function callback(id) {#{formPanelUploadFile}.getForm().reset();LoadFiles(); };"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelUploadFile" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelUploadFile}.getForm().reset();#{winFileUpload}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
