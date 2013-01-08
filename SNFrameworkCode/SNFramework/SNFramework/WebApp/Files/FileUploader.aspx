<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FileUploader.aspx.cs" Inherits="Legendigital.Common.WebApp.Files.FileUploader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/SwfUpload/swfupload.js"></script>
    <script type="text/javascript">
        var btnUploadButtonID = '<%=btnUploadFile.ClientID%>';

    </script>
    <script type="text/javascript" src="../Scripts/SwfUploadEvent.js"></script>
    <script type="text/javascript" src="../Scripts/SwfUploadInit.js"></script>
    <script type="text/javascript" src="../Scripts/SwfUploadCommon.js"></script>
    <style type="text/css">
        .ContentsStyle
        {
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManager1" runat="server">
        <Listeners>
            <DocumentReady Single="true" Handler="return InitSwf();" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeFiles" runat="server" ShowWarningOnFailure="false">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="MailId" />
                    <ext:RecordField Name="FilePath" />
                    <ext:RecordField Name="FileName" />
                    <ext:RecordField Name="FileSize" Type="Int" />
                    <ext:RecordField Name="FileExtension" />
                    <ext:RecordField Name="FileCreationDate" Type="Date" />
                    <ext:RecordField Name="FileModificationDate" Type="Date" />
                    <ext:RecordField Name="FileCreator" />
                    <ext:RecordField Name="FileId" />
                    <ext:RecordField Name="FileIndex" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Remove Fn="storeFilesRemoveEvent" />
            <Add Fn="storeFilesAddEvent" />
        </Listeners>
    </ext:Store>


    <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout">
        <Items>
            <ext:GridPanel runat="server" ID="gpFiles" StoreID="storeFiles" Title="已上传文件" Frame="true"
                Layout="FitLayout" StripeRows="true" AutoExpandColumn="FileName">
                <ColumnModel>
                    <Columns>
                        <ext:Column ColumnID="FileName" DataIndex="FileName" Header="名称">
                        </ext:Column>
                        <ext:Column ColumnID="FilePath" DataIndex="FilePath" Header="FilePath" Hidden="true">
                        </ext:Column>
                        <ext:Column ColumnID="FileSize" DataIndex="FileSize" Header="大小">
                            <Renderer Fn="renderSize" />
                        </ext:Column>
                        <ext:Column ColumnID="FileExtension" DataIndex="FileExtension" Header="类型">
                        </ext:Column>
                        <ext:Column ColumnID="FileCreationDate" DataIndex="FileCreationDate" Header="FileCreationDate"
                            Hidden="true">
                        </ext:Column>
                        <ext:Column ColumnID="FileModificationDate" DataIndex="FileModificationDate" Header="FileModificationDate"
                            Hidden="true">
                        </ext:Column>
                        <ext:Column ColumnID="FileCreator" DataIndex="FileCreator" Header="FileCreator" Hidden="true">
                        </ext:Column>
                        <ext:CommandColumn Width="24" Resizable="false">
                            <Commands>
                                <ext:GridCommand Icon="Delete" CommandName="delete" ToolTip-Text="删除">
                                </ext:GridCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel />
                </SelectionModel>
                <Listeners>
                    <Command Fn="gpFlilesDelete" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" ID="btnUploadFile" StyleSpec="visibility:hidden;height:21;width:75">
                    </ext:Button>
                    <ext:Button runat="server" ID="btnCancelFileUpload" Text="取消" Hidden="true">
                        <Listeners>
                            <Click Fn="CancelFileUpload" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server">
                        <Content>
                            <ext:ProgressBar ID="pbar" runat="server" Hidden="true">
                            </ext:ProgressBar>
                        </Content>
                    </ext:StatusBar>
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
