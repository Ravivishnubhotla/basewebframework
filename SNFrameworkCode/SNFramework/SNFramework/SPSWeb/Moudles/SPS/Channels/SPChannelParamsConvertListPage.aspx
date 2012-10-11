<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelParamsConvertListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.SPChannelParamsConvertListPage" %>
<%@ Register Src="UCSPChannelParamsConvertAdd.ascx" TagName="UCSPChannelParamsConvertAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPChannelParamsConvertEdit.ascx" TagName="UCSPChannelParamsConvertEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSPChannelParamsConvertView.ascx" TagName="UCSPChannelParamsConvertView"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPChannelParamsConvert.ClientID %>.reload();
        };
        
        function showAddForm() {
            Ext.net.DirectMethods.UCSPChannelParamsConvertAdd.Show( 
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: 'Processing...'
                                                                }
                                                            });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPChannelParamsConvertEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing...'
                                                                    }
                                                                }              
                );
            }
			
            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPChannelParamsConvertView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: 'Processing...'
                                                                    }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshData);            
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
    <ext:Store ID="storeSPChannelParamsConvert" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPChannelParamsConvert_Refresh">
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
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="ParamsValue" />
                    <ext:RecordField Name="ParamsConvertTo" />
                    <ext:RecordField Name="ParamsConvertType" />
                    <ext:RecordField Name="ParamsConvertCondition" />
                    <ext:RecordField Name="ChannelID" Type="int" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                    <ext:RecordField Name="CreateAt" Type="Date" />
                    <ext:RecordField Name="LastModifyBy" Type="int" />
                    <ext:RecordField Name="LastModifyAt" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPChannelParamsConvertAdd ID="UCSPChannelParamsConvertAdd1" runat="server" />
    <uc2:UCSPChannelParamsConvertEdit ID="UCSPChannelParamsConvertEdit1" runat="server" />
    <uc3:UCSPChannelParamsConvertView ID="UCSPChannelParamsConvertView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPChannelParamsConvert" runat="server" StoreID="storeSPChannelParamsConvert"
                StripeRows="true" Title="SPChannelParamsConvert Management" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPChannelParamsConvert}.reload();" />
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
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colParamsValue" DataIndex="ParamsValue" Header="ParamsValue"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colParamsConvertTo" DataIndex="ParamsConvertTo" Header="ParamsConvertTo"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colParamsConvertType" DataIndex="ParamsConvertType" Header="ParamsConvertType"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colParamsConvertCondition" DataIndex="ParamsConvertCondition"
                            Header="ParamsConvertCondition" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colChannelID" DataIndex="ChannelID" Header="ChannelID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCreateBy" DataIndex="CreateBy" Header="CreateBy" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCreateAt" DataIndex="CreateAt" Header="CreateAt" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLastModifyBy" DataIndex="LastModifyBy" Header="LastModifyBy"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLastModifyAt" DataIndex="LastModifyAt" Header="LastModifyAt"
                            Sortable="true">
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPChannelParamsConvert"
                        DisplayInfo="true" DisplayMsg="Display SPChannelParamsConverts {0} - {1} total {2}"
                        EmptyMsg="No matched SPChannelParamsConvert" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

