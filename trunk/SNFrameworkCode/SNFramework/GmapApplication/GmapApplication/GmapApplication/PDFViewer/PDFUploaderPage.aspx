<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="PDFUploaderPage.aspx.cs" Inherits="GmapApplication.PDFViewer.PDFUploaderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:FileUploadField ID="fufPDF" runat="server" Width="400" Icon="Attach" />
    <ext:Button ID="Button1" runat="server" Text="Get File Path">
        <DirectEvents>
            <Click OnEvent="UploadClick" Before="Ext.Msg.wait('Uploading your pdf...', 'Uploading');"
                Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error during uploading', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
            </Click>
        </DirectEvents>
    </ext:Button>
</asp:Content>
