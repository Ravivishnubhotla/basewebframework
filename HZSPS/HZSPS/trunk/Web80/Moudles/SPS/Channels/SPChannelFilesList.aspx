<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelFilesList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelFilesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannelFiles}.reload();"></DocumentReady>
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="storeSPChannelFiles" runat="server" AutoLoad="true" OnRefreshData="storeSPChannelFiles_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Name">
                <Fields>
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="FullName" />
                    <ext:RecordField Name="LastWriteTime" Type="Date" />
                    <ext:RecordField Name="CreationTime" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">
        function processcmd(cmd, id) {

            if (cmd == "cmdEditInfo") {
               
                var win = <%= this.winChannelFileSourceEditor.ClientID %>;
                
 
               win.setTitle('编辑通道文件代码');
                
               win.autoLoad.url = 'SPSourceCodeEditor.aspx';
            
               win.autoLoad.params.FileName = id.data.FullName;

               win.show();  
            }
            


            if (cmd == "cmdCopy") {

                addSource(id.data.FullName);
                
            }
            

       }

        function addSource(copyfilepath) {
            
            var win = <%= this.winChannelFileSourceAdd.ClientID %>;
            
            win.setTitle('新建通道文件代码');
                
            win.autoLoad.url = 'SPSourceCodeAdd.aspx';
            
            win.autoLoad.params.CopyFilePath = copyfilepath;
            
            win.autoLoad.params.SaveFilePath = "<%=FileDir.Replace(@"\",@"\\")%>";

           win.show();
            
        }
        
        function CloseSourceAdd() {
            var win = <%= this.winChannelFileSourceAdd.ClientID %>;
                   win.hide();
        }
        


        

       function CloseSourceEdit() {
           var win = <%= this.winChannelFileSourceEditor.ClientID %>;
           win.hide();
       }
       
       function ReloadData() {
           var storeSPChannelFiles = <%= this.storeSPChannelFiles.ClientID %>;
           storeSPChannelFiles.reload();
       }
 
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeSPChannelFiles" StripeRows="true"
                        Title="通道文件管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加文件" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="addSource('');" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:TextField ID="txtSreachName" runat="server" EmptyText="输入通道名" />
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='ToolbarButton3' runat="server" Text="查找" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPChannelFiles}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPChannelFiles}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <View>
                            <ext:GridView ForceFit="true" ID="GridView1">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colFileName" DataIndex="Name" Header="文件名" Width="130">
                                </ext:Column>
                                <ext:Column ColumnID="colLastWriteTime" DataIndex="LastWriteTime" Header="上次更新时间">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                                <ext:Column ColumnID="colCreationTime" DataIndex="CreationTime" Header="创建日期" Width="120">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                                <ext:CommandColumn Header="文件管理" Width="172">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEditInfo" Text="编辑">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="PageCopy" CommandName="cmdCopy" Text="复制">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPChannelFiles"
                                DisplayInfo="true" DisplayMsg="显示通道文件 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道文件" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>


    <ext:Window ID="winChannelFileSourceEditor" runat="server" Icon="PageCode" Title="编辑通道文件" Frame="true"
        Width="800" ConstrainHeader="true" Height="400" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="FileName" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>

    <ext:Window ID="winChannelFileSourceAdd" runat="server" Icon="PageCode" Title="新建通道文件" Frame="true"
        Width="800" ConstrainHeader="true" Height="400" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="CopyFilePath" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="SaveFilePath" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
