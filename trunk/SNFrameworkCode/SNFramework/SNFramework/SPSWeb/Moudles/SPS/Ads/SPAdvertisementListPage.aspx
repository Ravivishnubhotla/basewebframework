<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPAdvertisementListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.SPAdvertisementListPage" %>

<%@ Register Src="UCSPAdvertisementAdd.ascx" TagName="UCSPAdvertisementAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPAdvertisementEdit.ascx" TagName="UCSPAdvertisementEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPAdvertisementView.ascx" TagName="UCSPAdvertisementView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPAdvertisement.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPAdvertisementAdd.Show( 
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: '操作中...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPAdvertisementEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                }              
                );
            }
			
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPAdvertisementView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认删除该条记录？ ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', 'Delete a record success!',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing ......'
                                                                    }
                                                                }
                                                            );
                    }
                    );
            }
            
            if (cmd == "cmdAdPacksManage") {
                var win = <%= winAdPacksManage.ClientID %>;
                win.autoLoad.params.AdvertisementID = id.id;
                win.setTitle(String.format('广告“{0}”广告包管理',id.data.Name));
                win.show();   
            }
        }

    </script>

    <ext:Store ID="storeDictionaryAdType" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="POST" Url='<%# this.ResolveUrl("~/Moudles/DataService/DictionaryDataService.ashx") %>' AutoDataBind="True" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="dictionarys" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Key" />
                    <ext:RecordField Name="Value" />
                    <ext:RecordField Name="Code" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="GroupCode" Value="AdType" Mode="Value" />
        </BaseParams>
    </ext:Store>

    <ext:Store ID="storeDictionaryAcountType" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="POST" Url='<%# this.ResolveUrl("~/Moudles/DataService/DictionaryDataService.ashx") %>' AutoDataBind="True" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="dictionarys" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Key" />
                    <ext:RecordField Name="Value" />
                    <ext:RecordField Name="Code" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="GroupCode" Value="AcountType" Mode="Value" />
        </BaseParams>
    </ext:Store>
    <ext:Store ID="storeSPAdvertisement" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPAdvertisement_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="ImageUrl" />
                    <ext:RecordField Name="AdPrice" />
                    <ext:RecordField Name="AccountType" />
                    <ext:RecordField Name="ApplyStatus" />
                    <ext:RecordField Name="AdType" />
                    <ext:RecordField Name="AdText" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="IsDisable" Type="Boolean" />
                    <ext:RecordField Name="AssignedClient" Type="int" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                    <ext:RecordField Name="CreateAt" Type="Date" />
                    <ext:RecordField Name="LastModifyBy" Type="int" />
                    <ext:RecordField Name="LastModifyAt" Type="Date" />
                    <ext:RecordField Name="LastModifyComment" />

                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPAdvertisementAdd ID="UCSPAdvertisementAdd1" runat="server" />
    <uc2:UCSPAdvertisementEdit ID="UCSPAdvertisementEdit1" runat="server" />
    <uc3:UCSPAdvertisementView ID="UCSPAdvertisementView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdvertisement" runat="server" StoreID="storeSPAdvertisement"
                StripeRows="true" Title="广告管理" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPAdvertisement}.reload();" />
                                </Listeners>
                            </ext:Button>
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
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="编号" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colAdPrice" DataIndex="AdPrice" Header="价格" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colAccountType" DataIndex="AccountType" Header="结算类型" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colAdType" DataIndex="AdType" Header="类型" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colAdText" DataIndex="AdText" Header="广告文本" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="80">
                            <Commands>
                                <ext:SplitCommand Text="选择操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑"></ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除"></ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="查看"></ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdAdPacksManage" Text="管理广告包"></ext:MenuCommand>
                                        </Items>
                                    </Menu>

                                </ext:SplitCommand>

                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdvertisement"
                        DisplayInfo="true" DisplayMsg="显示广告 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的广告" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>

    <ext:Window ID="winAdPacksManage" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="350" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="SPAdPackListPage.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="AdvertisementID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
