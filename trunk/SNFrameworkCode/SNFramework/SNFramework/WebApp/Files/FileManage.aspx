<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="FileManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Files.FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:Store ID="storeFiles" runat="server" OnRefreshData="storeFiles_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Name">
                <Fields>
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="FileType" />
                    <ext:RecordField Name="FileSize" Type="Int" />
                    <ext:RecordField Name="LastModifyTime" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="True"></EventMask>
        </DirectEventConfig>
    </ext:Store>
    <script type="text/javascript">
        function LoadSubDir(subdir) {
            
            var hidcPath = <%=cPath.ClientID  %>;
 
            hidcPath.setValue(subdir);

            LoadFiles();
        }
        
        var showFileExtImage = function (value) {
            var imgsrc = String.format("<img src='/images/FileExts/{0}.gif'>", value);
            //alert(imgsrc);
            return imgsrc;
        };

        function LoadFiles() {
             var storeFiles = <%=storeFiles.ClientID  %>;
            storeFiles.reload();
        }

        function LoadDirectorys(rootPath) {
            var tree = <%=trpDirs.ClientID  %>;
            Ext.net.DirectMethods.GetTreeNodes(
                rootPath,
                {
                    failure: function (msg) {
                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                    },
                    success: function (result) {
                        var nodes = eval(result);
                        if (nodes.length > 0) {
                            tree.initChildren(nodes);
                        }
                        else {
                            tree.getRootNode().removeChildren();
                        }

                    },
                    eventMask: {
                        showMask: true,
                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>',
                        target: 'customtarget',
                        customTarget: '<%= trpDirs.ClientID %>.el'
                    }
                }
            );    
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="LoadDirectorys('/');LoadFiles();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel2" runat="server" Title="目录" Region="West" Width="225" MinWidth="225"
                Layout="Fit" MaxWidth="400" Split="true" Collapsible="true">
                <Items>
                    <ext:TreePanel ID="trpDirs" runat="server" Icon="Folder" Header="False" RootVisible="false"
                        AutoScroll="True">
                        <Root>
                            <ext:TreeNode Text="根节点" Expanded="true">
                            </ext:TreeNode>
                        </Root>
                        <Listeners>
                            <Click Handler="#{ssMessage}.setText('当前目录： <b>' + node.text + '<b/>');LoadSubDir(node.attributes.Path);" />
                            <ExpandNode Handler="#{ssMessage}.setText('当前目录：<b>' + node.text + '<b/>');LoadSubDir(node.attributes.Path);"
                                Delay="30" />
                            <CollapseNode Handler="#{ssMessage}.setText('当前目录：<b>' + node.text + '<b/>');LoadSubDir(node.attributes.Path);" />
                        </Listeners>
                        <BottomBar>
                            <ext:Toolbar ID="Toolbar3" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem ID="ssMessage" runat="server" Text="当前目录：">
                                    </ext:ToolbarTextItem>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:TreePanel>
                </Items>
            </ext:Panel>
            <ext:Panel ID="TabPanel1" runat="server" Title="文件管理" Region="Center" Layout="Fit">
                <TopBar>
                    <ext:Toolbar ID="Toolbar2" runat="server" Flat="true">
                        <Items>
                            <ext:ToolbarTextItem Text="当前路径：">
                            </ext:ToolbarTextItem>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Frame="True" Header="False"
                        StoreID="storeFiles" AutoExpandColumn="colName">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server" Flat="true">
                                <Items>
                                    <ext:Button ID="btnUp" runat="server" Icon="FolderUp" Text="向上">
                                    </ext:Button>
                                    <ext:Button ID="btnHome" runat="server" Icon="FolderHome" Text="首页">
                                    </ext:Button>
                                    <ext:Button ID="btnReload" runat="server" Icon="Reload" Text="刷新">
                                    </ext:Button>
                                    <ext:Button ID="btnFolderAdd" runat="server" Icon="FolderAdd" Text="新文件夹">
                                    </ext:Button>
                                    <ext:Button ID="btnPageAdd" runat="server" Icon="PageAdd" Text="新文件">
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button ID="btnDelete" runat="server" Icon="Delete" Text="删除">
                                    </ext:Button>
                                    <ext:Button ID="Button1" runat="server" Icon="Cut" Text="剪切">
                                    </ext:Button>
                                    <ext:Button ID="Button2" runat="server" Icon="PageCopy" Text="复制">
                                    </ext:Button>
                                    <ext:Button ID="Button3" runat="server" Icon="PastePlain" Text="粘贴">
                                    </ext:Button>
                                    <ext:Button ID="Button4" runat="server" Icon="Package" Text="压缩">
                                    </ext:Button>
                                    <ext:Button ID="Button5" runat="server" Icon="PackageGo" Text="解压">
                                    </ext:Button>
                                    <ext:Button ID="Button6" runat="server" Icon="DiskUpload" Text="上传">
                                    </ext:Button>
                                    <ext:Button ID="Button7" runat="server" Icon="DiskDownload" Text="下载">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colFileType" Header="" Width="30" DataIndex="FileType">
                                    <Renderer Fn="showFileExtImage"></Renderer>
                                </ext:Column>
                                <ext:Column ColumnID="colName" Header="名称" Width="160" DataIndex="Name" />
                                <ext:Column ColumnID="colFileSize" Header="大小" Width="80" DataIndex="FileSize">
                                    <Renderer Format="FileSize"></Renderer>
                                </ext:Column>
                                <ext:Column ColumnID="colLastModifyTime" Header="日期" Width="135" DataIndex="LastModifyTime">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y h:i:s')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                        <Items>
                                            <ext:ListItem Text="1" />
                                            <ext:ListItem Text="2" />
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="20" />
                                        </Items>
                                        <SelectedItem Value="10" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
            <ext:Panel ID="pnlFileInfo" runat="server" Title="属性" Region="East" Collapsible="true"
                Collapsed="True" Split="true" MinWidth="225" Width="225" Layout="Fit">
                <Items>
                    <ext:TabPanel ID="tabFileInfo" runat="server" Border="false">
                        <Items>
                            <ext:Panel ID="pnlBaseInfo" runat="server" Title="常规" Border="false" Padding="6">
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Hidden ID="cPath" runat="server" />
</asp:Content>
