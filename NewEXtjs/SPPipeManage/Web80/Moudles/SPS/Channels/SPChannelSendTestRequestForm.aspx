<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelSendTestRequestForm.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelSendTestRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function GetParams(frmValues) {
            return frmValues.replace('"', '').replace(/ctl00_ContentPlaceHolder1_txt/g, '');
        }

        function SubmitUrl(surl) {
            //Ext.Msg.alert('操作', surl);
            Ext.Ajax.request({
                url: surl,
                method: "GET",
                success: function (response, opts) {
                    var rtext = response.responseText.toLowerCase();
                    if (rtext == "ok")
                        Ext.Msg.alert('消息','请求成功，响应字符串："' + response.responseText + '"');
                    else
                        Ext.Msg.alert('消息', '请求失败，响应字符串："' + response.responseText + '"');
                    //alert(response.responseText);
                },
                failure: function () {
                    alert('请求失败！');
                }
            });

        }
    </script>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="发送测试数据">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="txtChannelName" runat="server" FieldLabel="通道名称" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="txtChannelSubmitUrl" runat="server" FieldLabel="通道提交地址" />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnSPClientSendRequest" runat="server" Text="发送" Icon="TelephoneGo">
                                <Listeners>
                                    <Click Handler=" SubmitUrl(#{txtChannelSubmitUrl}.getText()+'?'+GetParams(Ext.encode(#{FormPanel1}.getForm().getValues(true))));" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidChannelID" runat="server">
    </ext:Hidden>
</asp:Content>
