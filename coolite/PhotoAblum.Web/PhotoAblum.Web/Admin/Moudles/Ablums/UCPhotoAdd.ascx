<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPhotoAdd.ascx.cs"
    Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.UCPhotoAdd" %>

<script type="text/javascript">
    var showPhotoFile = function(fb, v) {
        if (!v) return;

        var patn = /\.jpg$|\.jpeg$|\.gif$|\.png&/i; //判断文件后缀名

        if (!patn.test(v)) {

            Ext.MessageBox.alert('警告', '您选择的不是图像文件!');

            return;
        }
    }            
</script>

<ext:Window ID="winNewPhoto" runat="server" Icon="PhotoAdd" Title="添加照片" Width="400"
    Height="250" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout1" runat="server">
            <ext:FormPanel ID="FormPanel8" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;" ButtonAlign="Left">
                <Body>
                    <ext:FormLayout ID="FormLayout2" runat="server">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtPhotoName" runat="server" FieldLabel="照片名" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txPhototDescription" runat="server" FieldLabel="照片描述" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkPhotoIsShow" runat="server" Checked="true" FieldLabel="是否显示">
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:FileUploadField ID="fufPhotoFullImage" runat="server" FieldLabel="上传照片" AllowBlank=false>
                                    <Listeners>
                                        <FileSelected Fn="showPhotoFile" />
                                    </Listeners>
                                </ext:FileUploadField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden runat="server" ID="hidAblumID">
                                </ext:Hidden>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
                <Buttons>
                    <ext:Button ID="btnAddPhoto" runat="server" Text="添加" Icon="PhotoAdd">
                        <AjaxEvents>
                            <Click OnEvent="btnAddPhoto_Click" Before="if(!#{FormPanel8}.getForm().isValid()) return false;"
                                Success="Ext.MessageBox.alert('操作成功', '成功的上传了照片。',callback);function callback(id) { #{storePhotos}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                <EventMask ShowMask="true" Msg="文件上传中，请稍候....." />
                            </Click>
                        </AjaxEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
</ext:Window>
