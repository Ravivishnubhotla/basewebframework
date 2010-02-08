<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAblumAddControl.ascx.cs"
    Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.UCAblumAddControl" %>
<ext:Window ID="winAblumAdd" runat="server" Icon="ImageAdd" Title="新建相册" Width="400"
    Height="270" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayout2" runat="server" LabelSeparator=":" LabelWidth="80">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="相册名" AllowBlank="false" BlankText="请输入【相册名】！" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="相册描述" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtDirName" runat="server" FieldLabel="目录名" AllowBlank="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIsShow" runat="server" Checked="true" FieldLabel="是否显示">
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField runat="server" ID="txtViewPassword" FieldLabel="设置查看密码" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveAblum" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{FormPanel1}.getForm().isValid()) return false;" OnEvent="btnSaveAblum_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了相册。',callback);function callback(id) { #{storeAblums}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelAblum" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winAblumAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
