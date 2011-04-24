<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemApplicationAdd" %>
<ext:Window ID="winSystemApplicationAdd" runat="server" Icon="ApplicationAdd" Title="添加应用"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtSystemApplicationName" runat="server" DataIndex="SystemApplicationName" FieldLabel="名称" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationCode" runat="server"  DataIndex="SystemApplicationCode" FieldLabel="编码" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription"  DataIndex="SystemApplicationDescription" runat="server" FieldLabel="描述"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" runat="server"  DataIndex="SystemApplicationUrl" FieldLabel="链接" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication"  DataIndex="SystemApplicationIsSystemApplication" runat="server" Checked="true"
                    FieldLabel="系统应用" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('操作成功', '添加应用成功！',callback);function callback(id) {#{formPanelSystemApplicationAdd}.getForm().reset();#{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                    <ExtraParams>
                        <ext:Parameter Name="frmValues" Value="Ext.encode(#{formPanelSystemApplicationAdd}.getForm().getFieldValues(false, 'dataIndex'))"
                            Mode="Raw">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
