<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemUserChangePwd.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SystemManage.UserManage.SystemUserChangePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function vaildaPassword() {
        if (Ext.get('<%= txtNewPassword.ClientID %>').dom.value == Ext.get('<%= txtRePassword.ClientID %>').dom.value)
            return true;
        else
            return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ext:ViewPort ID="viewPortMain" runat="server" Layout="fit">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <Items>
                <ext:FormPanel ID="formPanelChangePassword" runat="server" Frame="true" Title="修改用户密码"
                    MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130">
                    <Body>
                        <ext:FormLayout ID="FormLayoutSPUper" runat="server" LabelSeparator=":" LabelWidth="100">
                            <Anchors>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="txtNewPassword" InputType="Password" runat="server" FieldLabel="新密码"
                                        AllowBlank="false" BlankText="新密码不能为空！" AnchorHorizontal="95%" />
                                </ext:Anchor>
                                <ext:Anchor Horizontal="95%">
                                    <ext:TextField ID="txtRePassword" InputType="Password" runat="server" FieldLabel="重复新密码"
                                        AllowBlank="false" BlankText="重复新密码不能为空！" Validator="vaildaPassword" InvalidText="两次输入的密码不一致！"
                                        AnchorHorizontal="95%" />
                                </ext:Anchor>
 
                            </Anchors>
                        </ext:FormLayout>
                    </Body>
                    <Buttons>
                        <ext:Button ID="btnChangePassword" runat="server" Text="更改密码" Icon="KeyStart">
                            <AjaxEvents>
                                <Click Before="if(!#{formPanelChangePassword}.getForm().isValid()) return false;"
                                    OnEvent="btnChangePassword_Click" Success="Ext.MessageBox.alert('操作成功', '修改用户密码成功！',callback);function callback(id) { parent.CloseChangePwd(); };"
                                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                    <EventMask ShowMask="true" Msg="操作中。。。" />
                                </Click>
                            </AjaxEvents>
                        </ext:Button>
                        <ext:Button ID="btnCancelAblum" runat="server" Text="取消" Icon="Cancel">
                            <Listeners>
                                <Click Handler="parent.CloseChangePwd();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:FitLayout>
    </Body>
</ext:ViewPort>
</asp:Content>

