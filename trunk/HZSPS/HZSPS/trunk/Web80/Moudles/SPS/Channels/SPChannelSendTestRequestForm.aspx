<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelSendTestRequestForm.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelSendTestRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function GetParams(frmValues) {
            return frmValues.replace(/"/g, '').replace(/ctl00_ContentPlaceHolder1_txt/g, '');
        }
        
        function BuildDataUrl() {
            var dataUrl = <%= txtChannelSubmitUrl.ClientID %>.getText();
            return dataUrl+'?'+GetParams(Ext.encode(<%= FormPanel1.ClientID %>.getForm().getValues(true)));
        }
        

       function GetParamFromField(fieldName) {
            if(fieldName.indexOf('ctl00_ContentPlaceHolder1_')==-1) {
                fieldName = 'ctl00_ContentPlaceHolder1_' + fieldName;
            }

            var findFields = <%= FormPanel1.ClientID %>.find('id', fieldName);
            
            if(findFields.length>0)
                return findFields[0].getValue();
            
            return 'NA';
        }


        function BuildReportDataUrl() {
            

            
            var dataUrl = <%= txtChannelSubmitUrl.ClientID %>.getText();

            var dataParams = <%= this.hidDataParam.ClientID %>.getValue().toString().split(',');
            
            var len=dataParams.length;
            
            for(var i=0; i<len; i++) {
	            
                var pvalue = dataParams[i];

                var paramName = pvalue;
                
                if(paramName.indexOf('ctl00_ContentPlaceHolder1_')==-1) {
                    paramName = 'ctl00_ContentPlaceHolder1_' + paramName;
                }
                
                
	            
                if(i==0) {
                    dataUrl = dataUrl + '?' + paramName.replace('ctl00_ContentPlaceHolder1_txt','') + '=' + decodeURI(GetParamFromField(pvalue));
                } else {
                    dataUrl = dataUrl + '&' + paramName.replace('ctl00_ContentPlaceHolder1_txt','') + '=' + decodeURI(GetParamFromField(pvalue));
                }

            }
            
            var isTypeRequest = <%= this.ChannelID.IsTypeReuquestReportChannel.ToString().ToLower() %>;

            if (isTypeRequest) {
               dataUrl = dataUrl + '&' + '<%= this.ChannelID.RequestTypeParamName %>' + '=' + decodeURI('<%= this.ChannelID.RequestDataTypeValue %>'); 
            } 

            return dataUrl;
        }
                
        function BuildReportStatusUrl() {
            
            var dataUrl = <%= txtChannelSubmitUrl.ClientID %>.getText();

            var dataParams = <%= this.hidDataStatusParam.ClientID %>.getValue().toString().split(',');
            
            var len=dataParams.length;
            

            
            for(var i=0; i<len; i++) {
	            
                var pvalue = dataParams[i];

//                alert(pvalue);

                var paramName = pvalue;
                
                if(paramName.indexOf('ctl00_ContentPlaceHolder1_')==-1) {
                    paramName = 'ctl00_ContentPlaceHolder1_' + paramName;
                }
                
	            
                if(i==0) {
                    dataUrl = dataUrl + '?' + paramName.replace('ctl00_ContentPlaceHolder1_txt','') + '=' + decodeURI(GetParamFromField(pvalue));
                } else {
                    dataUrl = dataUrl + '&' + paramName.replace('ctl00_ContentPlaceHolder1_txt','') + '=' + decodeURI(GetParamFromField(pvalue));
                }

            }
            
            var isTypeRequest = <%= this.ChannelID.IsTypeReuquestReportChannel.ToString().ToLower() %>;

            if (isTypeRequest) {
               dataUrl = dataUrl + '&' + '<%= this.ChannelID.RequestTypeParamName %>' + '=' + decodeURI('<%= this.ChannelID.RequestReportTypeValue %>'); 
            }

            return dataUrl;
        }
        
             function TestUrl() {
                 var dataSendOnce = <%= this.ChannelID.DataSendOnce.ToString().ToLower() %>;

                 <%= lblDataTestResult.ClientID %>.setText('');

                 <%= lblDataStatusTestResult.ClientID %>.setText('');

//                 alert(dataSendOnce);

                 if (dataSendOnce) {

                     var dataUrl = BuildDataUrl();

                     <%= lblSendUrl.ClientID %>.setText(dataUrl);


                     Ext.Ajax.request({
                         url: dataUrl,
                         method: "GET",
                         success: function(response, opts) {
                             var rtext = response.responseText.toLowerCase();

                             <%= lblDataTestResult.ClientID %>.setText(rtext);

                             if (rtext == '<%= ChannelID.OkMessage %>')
                                 Ext.Msg.alert('消息', '请求成功，响应字符串："' + response.responseText + '"');
                             else
                                 Ext.Msg.alert('消息', '请求失败，响应字符串："' + response.responseText + '"');

                             RefreshValue();
                         },
                         failure: function() {
                             alert('请求失败！');
                         }
                     });
                 } else {

                     

                     
                                var dataUrl = BuildReportDataUrl();

                                <%= lblSendUrl.ClientID %>.setText(dataUrl);
                 
                                var statusUrl = BuildReportStatusUrl();

                                <%= lblStatusSendUrl.ClientID %>.setText(statusUrl);
                 

                                Ext.Ajax.request({
                                    url: dataUrl,
                                    method: "GET",
                                    success: function (response, opts) {
                                        var rtext = response.responseText.toLowerCase();

                                        var showtext = '';

                                        if (rtext == '<%= ChannelID.OkMessage %>')
                                            showtext = '数据请求成功，响应字符串："' + response.responseText + '"';
                                        else
                                            showtext = '数据请求失败，响应字符串："' + response.responseText + '"';
                        
                                        <%= lblDataTestResult.ClientID %>.setText(showtext);
 
                                 Ext.Ajax.request({
                                    url: statusUrl,
                                    method: "GET",
                                    success: function (response, opts) {
                                        var rtext = response.responseText.toLowerCase();
                        
                                        var showtext2 = '';

                                        if (rtext == '<%= ChannelID.OkMessage %>')
                                            showtext2 = '状态请求成功，响应字符串："' + response.responseText + '"';
                                        else
                                            showtext2 = '状态请求失败，响应字符串："' + response.responseText + '"';
                        

                                         <%= lblDataStatusTestResult.ClientID %>.setText(showtext2);

                                        RefreshValue();

                                    },
                                    failure: function () {
                                        alert('请求失败！');
                                    }
                                });


                                    },
                                    failure: function () {
                                        alert('请求失败！');
                                    }
                                });
                 }

             }


             function RefreshValue() {
            
            var clinkid = <%= hidLinkIDeName.ClientID %>.getValue();
                
            var cmoblieid = <%= hidMobileName.ClientID %>.getValue();

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
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="发送测试数据" AutoScroll="true">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="txtChannelName" runat="server" FieldLabel="通道名称" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="txtChannelSubmitUrl" runat="server" FieldLabel="通道提交地址" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblSendUrl" runat="server" FieldLabel="通道提交测试Url" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblStatusSendUrl" runat="server" FieldLabel="状态报告测试Url" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblDataTestResult" runat="server" FieldLabel="数据测试结果" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblDataStatusTestResult" runat="server" FieldLabel="状态测试结果" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblChannelInfo" runat="server" FieldLabel="通道信息" />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnRefreshData" runat="server" Text="刷新测试数据" Icon="Reload">
                                <Listeners>
                                    <Click Handler="RefreshValue();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnSPClientSendRequest" runat="server" Text="发送" Icon="TelephoneGo">
                                <Listeners>
                                    <Click Handler="TestUrl();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidMobileName" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidLinkIDeName" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidStatusName" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidDataParam" runat="server">
    </ext:Hidden>
    <ext:Hidden ID="hidDataStatusParam" runat="server">
    </ext:Hidden>
</asp:Content>