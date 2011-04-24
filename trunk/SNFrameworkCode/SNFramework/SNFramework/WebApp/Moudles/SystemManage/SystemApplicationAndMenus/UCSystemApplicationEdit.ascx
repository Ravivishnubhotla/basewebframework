<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemApplicationEdit" %>
<ext:Window ID="winSystemApplicationEdit" runat="server" Icon="ApplicationEdit" Title="System Application Eidt"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130"
            AutoScroll="true">
            <Items>
                <ext:Hidden ID="hidSystemApplicationID" runat="server" DataIndex="SystemApplicationID"
                    AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtSystemApplicationName" runat="server" DataIndex="SystemApplicationName"
                    FieldLabel="名称" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationCode" runat="server" DataIndex="SystemApplicationCode"
                    FieldLabel="编码" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription" runat="server" DataIndex="SystemApplicationDescription"
                    FieldLabel="描述" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" DataIndex="SystemApplicationUrl" runat="server"
                    FieldLabel="链接" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" DataIndex="SystemApplicationIsSystemApplication"
                    runat="server" Checked="true" FieldLabel="系统应用" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="修改" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('操作成功','修改系统成功',callback);function callback(id) { #{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
