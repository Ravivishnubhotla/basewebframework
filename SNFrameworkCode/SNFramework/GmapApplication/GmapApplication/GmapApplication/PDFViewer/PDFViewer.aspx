<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="PDFViewer.aspx.cs" Inherits="GmapApplication.PDFViewer.PDFViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css" media="screen">
        body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        div
        {
            width: 100%;
            height: 100%;
            position: absolute;
            top: 0;
        }
    </style>
    <script type="text/javascript" src="js/flexpaper_flash.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="viewerPlaceHolder">
    </div>
    <script type="text/javascript">
        var fp = new FlexPaperViewer(
						 'FlexPaperViewer',
						 'viewerPlaceHolder', { config: {
						     SwfFile: escape('Files/<%= this.Request.QueryString["FileName"] %>.swf'),
						     Scale: 0.6,
						     ZoomTransition: 'easeOut',
						     ZoomTime: 0.5,
						     ZoomInterval: 0.2,
						     FitPageOnLoad: false,
						     FitWidthOnLoad: true,
						     PrintEnabled: true,
						     FullScreenAsMaxWindow: false,
						     ProgressiveLoading: false,
						     MinZoomSize: 0.2,
						     MaxZoomSize: 5,
						     SearchMatchAll: false,
						     InitViewMode: 'Portrait',

						     ViewModeToolsVisible: true,
						     ZoomToolsVisible: true,
						     NavToolsVisible: true,
						     CursorToolsVisible: true,
						     SearchToolsVisible: true,

						     localeChain: 'en_US'
						 }
						 });
    </script>
</asp:Content>
