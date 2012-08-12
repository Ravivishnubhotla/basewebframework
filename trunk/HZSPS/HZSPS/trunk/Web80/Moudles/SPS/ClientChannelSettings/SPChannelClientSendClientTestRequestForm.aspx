<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelClientSendClientTestRequestForm.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.SPChannelClientSendClientTestRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function GetParams(frmValues) {
            return frmValues.replace(/"/g, '').replace(/ctl00_ContentPlaceHolder1_txt/g, '');
        }

        function SubmitUrl(surl,params, lbl) {
	    if(surl.indexOf('?')>-1)
		surl = surl + "&" + params;    
   	    else
		surl = surl + "?" + params;   
            
         lbl.setText(surl);
         

            Coolite.AjaxMethods.SubmitUrl(surl,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('请求失败', msg);
                                                                    },
                                                                    success: function (result) {
                                                                    var lblOkMessage = <%= lblOkMessage.ClientID %>;
                    
                    var rtext = result.toLowerCase();
                    if (Ext.util.Format.trim(rtext.toLowerCase()) == Ext.util.Format.trim(lblOkMessage.getText().toLowerCase())) {
                        Ext.Msg.alert('消息', '请求成功，响应字符串："' + result + '"');
                        var btnRefreshData = <%= btnRefreshData.ClientID %>;
                        btnRefreshData.fireEvent("click");
                    }
                                                                        
                    else
                        Ext.Msg.alert('消息', '请求失败，响应字符串："' + result + '"');                            
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '发送请求中...'
                                                                    }
                                                                }
                                                            );            
            
            
            
            
 

        }





        function RefreshValue(clinkid, cmoblieid) {
            //alert(clinkid);
            //alert(cmoblieid);

            Coolite.AjaxMethods.GetTestSPMessage(
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
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="发送测试数据"  AutoScroll="true">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server" >
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblChannelName" runat="server" FieldLabel="通道名称" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblClientName" runat="server" FieldLabel="下家名" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblClientGroupName" runat="server" FieldLabel="下家组名" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblCode" runat="server" FieldLabel="指令" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblOkMessage" runat="server" FieldLabel="成功标示" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="txtClientSycnUrl" runat="server" FieldLabel="下家同步地址" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblClientSendUrl" runat="server" FieldLabel="下家提交测试Url" />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnRefreshData" runat="server" Text="刷新测试数据" Icon="Reload">
                                <Listeners>
                                    <Click Handler="RefreshValue(#{hidLinkIDeName}.getValue(),#{hidMobileName}.getValue());" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnSPClientSendRequest" runat="server" Text="发送" Icon="TelephoneGo">
                                <Listeners>
                                    <Click Handler=" SubmitUrl(#{txtClientSycnUrl}.getText(),GetParams(Ext.encode(#{FormPanel1}.getForm().getValues(true))),#{lblClientSendUrl});" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidChannelClientID" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidMobileName" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidLinkIDeName" runat="server">
    </ext:Hidden>
</asp:Content>
