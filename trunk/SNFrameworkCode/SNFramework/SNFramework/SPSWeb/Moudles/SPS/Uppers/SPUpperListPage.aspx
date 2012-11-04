<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPUpperListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Uppers.SPUpperListPage" %>


<%@ Register Src="UCSPUpperAdd.ascx" TagName="UCSPUpperAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPUpperEdit.ascx" TagName="UCSPUpperEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPUpperView.ascx" TagName="UCSPUpperView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>

    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPUpper.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPUpperAdd.Show( 
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: '处理中...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPUpperEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中...'
                                                                    }
                                                                }              
                );
            }
			
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPUpperView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中...'
                                                                    }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认删除该条数据？ ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '删除记录成功！',RefreshData);            
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中......'
                                                                    }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>

    <ext:Store ID="storeSPUpper" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPUpper_Refresh">
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
                    <ext:RecordField Name="Description" />
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
    <uc1:UCSPUpperAdd ID="UCSPUpperAdd1" runat="server" />
    <uc2:UCSPUpperEdit ID="UCSPUpperEdit1" runat="server" />
    <uc3:UCSPUpperView ID="UCSPUpperView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPUpper" runat="server" StoreID="storeSPUpper"
                StripeRows="true" Title="上家管理" Icon="Table">
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
                                    <Click Handler="#{storeSPUpper}.reload();" />
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
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="编码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="描述" Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="选择操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑"></ext:MenuCommand>
<%--                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除"></ext:MenuCommand>--%>
<%--                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="查看"></ext:MenuCommand>--%>
                                        </Items>
                                    </Menu>

                                </ext:SplitCommand>

                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPUpper"
                        DisplayInfo="true" DisplayMsg="显示上家 {0} - {1} 共 {2}" EmptyMsg="没有匹配的上家" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

