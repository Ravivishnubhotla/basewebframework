<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ExtJsGetJson.aspx.cs" Inherits="GmapApplication.ExtJsAjax.ExtJsGetJson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick() {
            Ext.Ajax.request({
                url: 'http://localhost:6623/ExtJsAjax/GoogleMapService.ashx?ServiceType=geocode&address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=true',
                success: function (response, opts) {
                    var obj = Ext.decode(response.responseText);

                    alert(obj.status);
                },
                failure: function (response, opts) {
                    alert('server-side failure with status code ' + response.status);
                }
            });
        }

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <input id="Button1" type="button" value="button" onclick="return Button1_onclick()" />

</asp:Content>
