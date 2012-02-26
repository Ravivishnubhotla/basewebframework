<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChangeLoginID.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.UCChangeLoginID" %>
<ext:Window ID="winChangeLoginID" runat="server" Icon="ApplicationAdd" Title="修改登录用户ID"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelwinChangeLoginID" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientGroup" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtLoginID" runat="server" FieldLabel="登陆ID" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtNewLoginID" runat="server" FieldLabel="新的登陆ID"
                                    AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveChangeLoginID" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelwinChangeLoginID}.getForm().isValid()) return false;"
                    OnEvent="btnSaveChangeLoginID_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家组。',callback);function callback(id) {#{formPanelwinChangeLoginID}.getForm().reset(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelChangeLoginID" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangeLoginID}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
