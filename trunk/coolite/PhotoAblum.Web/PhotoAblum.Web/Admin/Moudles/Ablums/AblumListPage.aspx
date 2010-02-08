<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Masters/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="AblumListPage.aspx.cs" Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.AblumListPage" %>

<%@ Register Src="UCAblumAddControl.ascx" TagName="UCAblumAddControl" TagPrefix="uc1" %>
<%@ Register Src="UCAblumEditControl.ascx" TagName="UCAblumEditControl" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var isShowDisplay = function(value) {
            if (value)
                return '是';
            else
                return '否';
        }

        var ShowImage = function(value) {
            return '<img src="' + rooturl + value + '" width="30" height="30" style="border-width:0px;" />';
        }

        var RefreshData = function(btn) {
            <%=this.storeAblums.ClientID%>.reload();
        };

        function processcmd(cmd, id) {

            if (cmd == "ImageEdit") {
                Coolite.AjaxMethods.UCAblumEditControl.Show(id.data.Id);
            }

            if (cmd == "ImageDelete") {
                Ext.MessageBox.confirm(
                    '警告',
                    '确认要删除所选记录 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.data.Id,
                                                                {
                                                                    failure:
                                                                    function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>

    <ext:Store ID="storeAblums" runat="server" OnRefreshData="storeAblums_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="Int" />
                    <ext:RecordField Name="Name" Type="String" />
                    <ext:RecordField Name="ShortDescription" Type="String" />
                    <ext:RecordField Name="Description" Type="String" />
                    <ext:RecordField Name="FilePath" Type="String" />
                    <ext:RecordField Name="SmallImageRUrl" Type="String" />
                    <ext:RecordField Name="FullImage" Type="String" />
                    <ext:RecordField Name="MiddleImage" Type="String" />
                    <ext:RecordField Name="ThumbImage" Type="String" />
                    <ext:RecordField Name="DirName" Type="String" />
                    <ext:RecordField Name="OrderIndex" Type="Int" />
                    <ext:RecordField Name="ViewPassword" Type="String" />
                    <ext:RecordField Name="IsShow" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelAblums" runat="server" StoreID="storeAblums" StripeRows="true"
                        Border="false" Header="false">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAddAblums' runat="server" Text="添加" Icon="ImageAdd">
                                        <Listeners>
                                            <Click Handler="#{winAblumAdd}.show();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeAblums}.reload();" />
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
                                <ext:Column DataIndex="Name" Header="相册名" Sortable="true">
                                </ext:Column>
                                <ext:Column DataIndex="SmallImageRUrl" Header="相册封面">
                                    <Renderer Fn="ShowImage" />
                                </ext:Column>
                                <ext:Column DataIndex="DirName" Header="目录名">
                                </ext:Column>
                                <ext:Column DataIndex="OrderIndex" Header="排序号">
                                </ext:Column>
                                <ext:Column DataIndex="IsShow" Header="是否显示">
                                    <Renderer Fn="isShowDisplay" />
                                </ext:Column>
                                <ext:CommandColumn Width="60">
                               
                                    <Commands>
                                        <ext:GridCommand Icon="ImageEdit" CommandName="ImageEdit">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ImageDelete" CommandName="ImageDelete">
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="Compress" CommandName="ImageImport">
                                            <ToolTip Text="导出" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <Plugins>
                            <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                                <Filters>
                                    <ext:StringFilter DataIndex="Name" />
                                </Filters>
                            </ext:GridFilters>
                        </Plugins>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeAblums"
                                DisplayInfo="true" DisplayMsg="显示相册 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的相册" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <uc1:UCAblumAddControl ID="UCAblumAddControl1" runat="server" />
    <uc2:UCAblumEditControl ID="UCAblumEditControl1" runat="server" />
</asp:Content>
