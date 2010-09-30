<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCChangePassword.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.UCChangePassword" %>
<ext:Window ID="winChangePassword" runat="server" Icon="ApplicationAdd" Title="修改登录用户ID"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Header="false"
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
                                <ext:TextField ID="txtNewLoginID" runat="server" FieldLabel="新的密码" InputType="Password"
                                    AllowBlank="True" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveChangePassword" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                    OnEvent="btnSaveChangePassword_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家组。',callback);function callback(id) {#{formPanelChangePassword}.getForm().reset();};
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelChangePassword" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winChangePassword}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
