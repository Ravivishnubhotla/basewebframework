<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TextLogList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SystemManage.LogViews.TextLogList" %>
<%@ Register Src="UCFileView.ascx" TagName="UCFileView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }


           var RefreshSPChannelData = function(btn) {
            <%= this.storeFiles.ClientID %>.reload();
        };
        
    
        

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCFileView.Show(id.data.FilePath,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

 
    
            
            
                   
        }

    </script>
    <ext:Store ID="storeFiles" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeFiles_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="FileID">
                <Fields>
                    <ext:RecordField Name="FileID" Type="int" />
                     <ext:RecordField Name="NID" Type="int" />
                    <ext:RecordField Name="FilePath" />
                    <ext:RecordField Name="FileName" />
                    <ext:RecordField Name="FileExt" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000"></AjaxEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCFileView ID="UCFileView1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeFiles" StripeRows="true"
                        Title="WEB日志查看" Icon="Table" AutoExpandColumn="colFileName">
                           <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeFiles}.reload();" />
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
                                <ext:Column ColumnID="colID" DataIndex="NID" Header="序号" Sortable="true" Width=30>
                                </ext:Column>
                                <ext:Column ColumnID="colFileName" DataIndex="FileName" Header="日志名" Sortable="true">
                                </ext:Column>
                                <ext:CommandColumn Header="日志管理" Width="172">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="查看日志">
                                            <ToolTip Text="查看日志" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeFiles"
                                DisplayInfo="true" DisplayMsg="显示日志 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的日志" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>

