<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPhotoEdit.ascx.cs"
    Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.UCPhotoEdit" %>
<ext:Window ID="winEditPhoto" runat="server" Icon="PhotoEdit" Title="编辑照片" Width="400"
    Height="320" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout1" runat="server">
            <ext:FormPanel ID="FormPanel9" runat="server" Frame="true" Header="false" MonitorValid="true"
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
                                <ext:NumberField runat="server" ID="NumberField1" FieldLabel="排序号" Width="250" AllowBlank="false"
                                    AllowNegative="false">
                                </ext:NumberField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden runat="server" ID="hidID">
                                </ext:Hidden>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
                <Buttons>
                    <ext:Button ID="btnEditPhoto" runat="server" Text="编辑" Icon="PhotoEdit">
                        <AjaxEvents>
                            <Click OnEvent="btnEditPhoto_Click" Before="if(!#{FormPanel9}.getForm().isValid()) return false;"
                                Success="Ext.MessageBox.alert('操作成功', '成功的编辑了照片。',callback);function callback(id) { #{storePhotos}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                            </Click>
                        </AjaxEvents>
                    </ext:Button>
                    <ext:Button ID="btnEditPhotoCancel" runat="server" Text="取消" Icon="Cancel">
                        <Listeners>
                            <Click Handler="#{winEditPhoto}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
</ext:Window>
