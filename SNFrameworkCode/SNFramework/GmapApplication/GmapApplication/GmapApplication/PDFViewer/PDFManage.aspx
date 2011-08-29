﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="PDFManage.aspx.cs" Inherits="GmapApplication.PDFViewer.PDFManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:FormPanel ID="Panel1" runat="server" Title="North" Region="North" Split="true"
                Height="120" Frame="true" Collapsible="true" Layout="Form">
                <Items>
                    <ext:FileUploadField ID="fufPDF" FieldLabel="Upload Pdf File" runat="server" AnchorHorizontal="98%"
                        Icon="Attach" />
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="Upload">
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
                </Buttons>
            </ext:FormPanel>
            <ext:Panel ID="Panel3" runat="server" Height="150" Width="350" Title="IFrame Mode"
                Region="Center">
                <AutoLoad Url="Blank.htm" Mode="IFrame" ShowMask="true" />
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
