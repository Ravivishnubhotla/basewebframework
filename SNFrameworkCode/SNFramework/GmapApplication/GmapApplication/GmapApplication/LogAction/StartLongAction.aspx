<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="StartLongAction.aspx.cs" Inherits="GmapApplication.LogAction.StartLongAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManager1" runat="server" />
    <h1>
        Progress Bar</h1>
    <p>
        The example shows how to update the ProgressBar during long server-side actions.</p>
    <ext:Button ID="ShowProgress1" runat="server" Text="Start long action">
        <DirectEvents>
            <Click OnEvent="OnStartLongAction" Before="#{winProgress}.show();" />
        </DirectEvents>
    </ext:Button>
    <br />
    <ext:TaskManager ID="TaskManager1" runat="server">
        <Tasks>
            <ext:Task TaskID="longactionprogress" Interval="1000" AutoRun="false" OnStart="
                        #{ShowProgress1}.setDisabled(true);" OnStop="
                        #{ShowProgress1}.setDisabled(false);#{winProgress}.hide();">
                <DirectEvents>
                    <Update OnEvent="RefreshProgress" />
                </DirectEvents>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>
    <ext:Window ID="winProgress" runat="server" Closable="false" Resizable="false" Hidden="true"
        Icon="Lock" Title="Login" Draggable="false" Width="550" Modal="true" Padding="5"
        ButtonAlign="Center" Layout="Form">
        <Items>
            <ext:ProgressBar ID="prgProcess" FieldLabel="" runat="server" AnchorHorizontal="99%" />
        </Items>
        <Buttons>
            <ext:Button ID="btnCancel" runat="server" Text="Cancel" Icon="Decline">
                <DirectEvents>
                    <Click OnEvent="OnCancel" />
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</asp:Content>
