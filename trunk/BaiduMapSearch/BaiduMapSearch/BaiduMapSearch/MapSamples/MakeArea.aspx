<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ExtMaster.Master" AutoEventWireup="true"
    CodeBehind="MakeArea.aspx.cs" Inherits="BaiduMapSearch.MapSamples.MakeArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" src='<%= BaiduMapSearch.Global.BaiDuMapAPIUrl %>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:520px;height:340px;border:1px solid gray" id="container"></div>
<p><input id="startBtn" type="button" onclick="startTool();" value="����ȡ�㹤��" /><input type="button" onclick="map.clearOverlays();document.getElementById('info').innerHTML = '';points=[];" value="���" /></p>
<div id="info"></div>
 
<script type="text/javascript">
    var map = new BMap.Map("container");                        // ����Mapʵ��
    map.centerAndZoom("����", 14);     // ��ʼ����ͼ,�������ĵ�����͵�ͼ����
    map.addControl(new BMap.MapTypeControl());          //��ӵ�ͼ���Ϳؼ�
    var opts = { type: BMAP_NAVIGATION_CONTROL_LARGE };
    map.addControl(new BMap.NavigationControl(opts));
    map.enableScrollWheelZoom();
    map.enableKeyboard();

    var key = 1;    //����
    var newpoint;   //һ����γ��
    var points = [];    //���飬�ž�γ����Ϣ
    var polyline = new BMap.Polyline(); //���߸�����

    function startTool() {   //���غ���
        if (key == 1) {
            document.getElementById("startBtn").style.background = "green";
            document.getElementById("startBtn").style.color = "white";
            document.getElementById("startBtn").value = "����״̬";
            key = 0;
        }
        else {
            document.getElementById("startBtn").style.background = "red";
            document.getElementById("startBtn").value = "�ر�״̬";
            key = 1;
        }
    }
    map.addEventListener("click", function (e) {   //������ͼ���γ����߸�����
        newpoint = new BMap.Point(e.point.lng, e.point.lat);
        if (key == 0) {
            //    if(points[points.length].lng==points[points.length-1].lng){alert(111);}
            points.push(newpoint);  //�������ĵ�ŵ�������
            polyline.setPath(points);   //�������ߵĵ�����
            map.addOverlay(polyline);   //��������ӵ���ͼ��
            document.getElementById("info").innerHTML += "new BMap.Point(" + e.point.lng + "," + e.point.lat + "),</br>";    //���������ľ�γ��
        }
    });
    map.addEventListener("dblclick", function (e) {   //˫����ͼ���γɶ���θ�����
        if (key == 0) {
            map.disableDoubleClickZoom();   //�ر�˫���Ŵ�
            var polygon = new BMap.Polygon(points);
            map.addOverlay(polygon);   //��������ӵ���ͼ��
        }
    });
</script>
</asp:Content>
