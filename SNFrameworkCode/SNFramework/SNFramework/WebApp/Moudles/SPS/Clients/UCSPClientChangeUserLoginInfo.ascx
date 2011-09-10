<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChangeUserLoginInfo.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPClientChangeUserLoginInfo" %>
<script type="text/javascript">
    function ShowChangePass(chkChangePass, txtpassword) {
        //alert(chkSyncData);
        //alert(chkSyncData.getValue());
        if (chkChangePass.getValue()) {
            txtpassword.show();

        }
        else {
            txtpassword.hide();

        }
    }
</script>
<ext:Window ID="winSPClientChangeUserLoginInfo" runat="server" Icon="ApplicationEdit"
    Title="更改用户登录信息" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPClientChangeUserLoginInfo" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="txtName" runat="server" FieldLabel="下家名" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserID" runat="server" FieldLabel="登陆用户ID" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkChangePassword" runat="server" FieldLabel="更改密码" Checked="false"
                    AnchorHorizontal="95%">
                    <Listeners>
                        <Check Handler="ShowChangePass(#{chkChangePassword},#{txtUserPasword});">
                        </Check>
                    </Listeners>
                </ext:Checkbox>
                <ext:TextField ID="txtUserPasword" runat="server" FieldLabel="登陆用户密码" Hidden="true"
                      AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChangeUserLoginInfo" runat="server" Text="更新" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPClientChangeUserLoginInfo}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPSClient_Click" Success="Ext.MessageBox.alert('操作成功', '更改用户登录信息成功',callback);function callback(id) {#{formPanelSPClientChangeUserLoginInfo}.getForm().reset();#{storeSPSClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据更新中....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChangeUserLoginInfo" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPClientChangeUserLoginInfo}.getForm().reset();#{winSPClientChangeUserLoginInfo}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
