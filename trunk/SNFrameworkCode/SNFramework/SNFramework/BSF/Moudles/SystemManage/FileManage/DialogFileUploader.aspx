<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DialogFileUploader.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.FileManage.DialogFileUploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../../Scripts/swfupload/swfupload.js"></script>
        <script type="text/javascript" src="swfuploadevent.js"></script>
    <script type="text/javascript" src="InitSwfUpload.js"></script>
    <script type="text/javascript" src="fileUpload.js"></script>
    <style type="text/css">
        .ContentsStyle
        {
            font-size: 14px;
        }
    </style>
    <ext:Store ID="storeFiles" runat="server" ShowWarningOnFailure="false" >
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
            <%--移除记录时引发storeFilesRemoveEvent事件--%>
            <Remove Fn="storeFilesRemoveEvent" />
            <%--添加记录时引发storeFilesAddEvent事件--%>
            <Add Fn="storeFilesAddEvent" />
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <%--每行后面添加一个删除按钮，用来删除已上传的文件--%>
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
                    <%--点击每行后面的删除按钮时引发gpFlilesDelete--%>
                    <Command Fn="gpFlilesDelete" />
                </Listeners>
                <Buttons>
                    <%--swfupload库通过这个按钮ID来找到并替换此区域,此ID比较关键，后面的样式是为了做一些美观处理，可去掉看看效果--%>
                    <ext:Button runat="server" ID="btnUploadFile" StyleSpec="visibility:hidden;height:21;width:75">
                    </ext:Button>
                    <ext:Button runat="server" ID="btnCancelFileUpload" Text="取消" Hidden="true" >
                        <Listeners>
                            <Click Fn="CancelFileUpload" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server">
                        <Content>
                            <%--进度条--%>
                            <ext:ProgressBar ID="pbar" runat="server" Hidden="true">
                            </ext:ProgressBar>
                        </Content>
                    </ext:StatusBar>
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
