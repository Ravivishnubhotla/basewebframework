<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelSendTestRequestForm.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.SPChannelSendTestRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function GetParams(frmValues) {
            return frmValues.replace(/"/g, '').replace(/ctl00_ContentPlaceHolder1_txt/g, '');
        }

        function SubmitUrl(surl, lbl) {
            lbl.setText(surl);

            Ext.Ajax.request({
                url: surl,
                method: "GET",
                success: function (response, opts) {
                    var rtext = response.responseText.toLowerCase();
                    if (rtext == '<%= ChannelID.DataOkMessage %>')
                        Ext.Msg.alert('消息', '请求成功，响应字符串："' + response.responseText + '"');
                    else
                        Ext.Msg.alert('消息', '请求失败，响应字符串："' + response.responseText + '"');
                    //alert(response.responseText);
                },
                failure: function () {
                    alert('请求失败！');
                }
            });

        }


        function RefreshValue(clinkid, cmoblieid) {


            Ext.net.DirectMethods.GetTestSPMessage(
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('刷新失败', msg);
                                                                    },
                                                                    success: function (result) {
                                                                        eval(' var clid = ctl00_ContentPlaceHolder1_' + clinkid);
                                                                        eval(' var cmob = ctl00_ContentPlaceHolder1_' + cmoblieid);
                                                                        clid.setValue(result.LinkID);
                                                                        cmob.setValue(result.Mobile);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '刷新中...'
                                                                    }
                                                                }
                                                            );



        }
    </script>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="发送测试数据" Layout="Form"
                AutoScroll="true">
                <Items>
                    <ext:Label ID="txtChannelName" runat="server" FieldLabel="通道名称" AnchorHorizontal="95%" />
                    <ext:Label ID="txtChannelSubmitUrl" runat="server" FieldLabel="通道提交地址" AnchorHorizontal="95%" />
                    <ext:Label ID="lblSendUrl" runat="server" FieldLabel="通道提交测试Url" AnchorHorizontal="95%" />
                    <ext:Label ID="lblChannelInfo" runat="server" FieldLabel="通道信息" AnchorHorizontal="95%" />
                </Items>
                <Buttons>
                    <ext:Button ID="btnRefreshData" runat="server" Text="刷新测试数据" Icon="Reload">
                        <Listeners>
                            <Click Handler="RefreshValue(#{hidLinkIDeName}.getValue(),#{hidMobileName}.getValue());" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnSPClientSendRequest" runat="server" Text="发送" Icon="TelephoneGo">
                        <Listeners>
                            <Click Handler=" SubmitUrl(#{txtChannelSubmitUrl}.getText()+'?'+GetParams(Ext.encode(#{FormPanel1}.getForm().getValues(true))),#{lblSendUrl});" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
    <ext:Hidden ID="hidChannelID" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidMobileName" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidLinkIDeName" runat="server">
    </ext:Hidden>
</asp:Content>
