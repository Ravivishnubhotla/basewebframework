<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClientAdPackList.aspx.cs" Inherits="SPSWeb.Moudles.SPS.ClientView.ClientAdPackList" %>

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
            <%= this.storeSPAdPack.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPAdPackAdd.Show( 
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
                Ext.net.DirectMethods.UCSPAdPackEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSPAdPackView.Show(id.id,
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
        }

    </script>

    <ext:Store ID="storeSPAdPack" runat="server" AutoLoad="true"
        OnRefreshData="storeSPAdPack_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="SPAdID_Name" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="Description" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPAdPack" runat="server" StoreID="storeSPAdPack"
                StripeRows="true" Title="分配广告包" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>

                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPAdPack}.reload();" />
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
                        <ext:Column ColumnID="colSPAdID" DataIndex="SPAdID_Name" Header="广告名" Sortable="false">
                        </ext:Column>
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="广告包名" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPAdPack"
                        DisplayInfo="true" DisplayMsg="显示分配的广告包 {0} - {1} 共 {2}" EmptyMsg="没有分配的广告包" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>


