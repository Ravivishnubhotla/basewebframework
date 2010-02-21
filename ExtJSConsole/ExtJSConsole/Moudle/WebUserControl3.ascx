<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl3.ascx.cs"
    Inherits="ExtJSConsole.Moudle.WebUserControl3" %>
<ext:Window ID="SeachWindow" runat="server" Icon="Group" Title="系统应用查询" Width="400"
    AutoHeight="true" AutoShow="false" Modal="true" ShowOnLoad="false" Hidden="true">
    <Body>
        <ext:ContainerLayout ID="ContainerLayout1" runat="server">
            <ext:FieldSet ID="FieldSet2" runat="server" CheckboxToggle="false" Title="检索条件" AutoHeight="true">
                <Body>
                    <ext:FormLayout ID="FormLayout2" runat="server" LabelWidth="75">
                        <ext:Anchor Horizontal="100%">
                            <ext:TextField ID="txtName" runat="server" FieldLabel="名称" Text=""
                                AllowBlank="false" />
                        </ext:Anchor>
                    </ext:FormLayout>
                </Body>
            </ext:FieldSet>
        </ext:ContainerLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveButton" runat="server" Text="查询" Icon="Find">
            <AjaxEvents>
                <Click Before="showProcessMsg();" OnEvent="SaveAction" Success="Ext.MessageBox.hide();"
                    Failure="Ext.MessageBox.hide();Ext.MessageBox.alert('错误', '查询数据失败！');">
                    <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{SeachWindow}.body}" />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelButton" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{SeachWindow}.hide(null);" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
