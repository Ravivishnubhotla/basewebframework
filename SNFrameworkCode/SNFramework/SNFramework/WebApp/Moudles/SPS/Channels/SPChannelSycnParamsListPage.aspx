<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelSycnParamsListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.SPChannelSycnParamsListPage" %>
<%@ Register Src="UCSPChannelSycnParamsAdd.ascx" TagName="UCSPChannelSycnParamsAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPChannelSycnParamsEdit.ascx" TagName="UCSPChannelSycnParamsEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPChannelSycnParamsView.ascx" TagName="UCSPChannelSycnParamsView" TagPrefix="uc3"  %>
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
        }


        var RefreshData = function(btn) {
            <%= this.storeSPChannelSycnParams.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPChannelSycnParamsAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPChannelSycnParamsEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
            }
			
			            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPChannelSycnParamsView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
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
                                                                        Ext.Msg.alert('Operation failed', msg);
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

    <ext:Store ID="storeSPChannelSycnParams" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPChannelSycnParams_Refresh">
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
		<ext:RecordField Name="Description" />			
				<ext:RecordField Name="IsEnable" Type="Boolean" />
				<ext:RecordField Name="ChannelID" Type="int" />
		<ext:RecordField Name="MappingParams" />			
		<ext:RecordField Name="Title" />			
		<ext:RecordField Name="ParamsValue" />			
		<ext:RecordField Name="ParamsType" />			
 
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPChannelSycnParamsAdd ID="UCSPChannelSycnParamsAdd1" runat="server" />
    <uc2:UCSPChannelSycnParamsEdit ID="UCSPChannelSycnParamsEdit1" runat="server" /> 
    <uc3:UCSPChannelSycnParamsView ID="UCSPChannelSycnParamsView1" runat="server" /> 	
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPChannelSycnParams" runat="server" StoreID="storeSPChannelSycnParams"
                StripeRows="true" Title="SPChannelSycnParams Management" Icon="Table">
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
                                    <Click Handler="#{storeSPChannelSycnParams}.reload();" />
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
				<ext:Column ColumnID="colID" DataIndex="ID" Header="ID" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colDescription" DataIndex="Description" Header="Description" Sortable="true">
                                </ext:Column>			
				<ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="IsEnable" Sortable="true">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
				<ext:Column ColumnID="colChannelID" DataIndex="ChannelID" Header="ChannelID" Sortable="true">
                                </ext:Column>
		<ext:Column ColumnID="colMappingParams" DataIndex="MappingParams" Header="MappingParams" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colTitle" DataIndex="Title" Header="Title" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colParamsValue" DataIndex="ParamsValue" Header="ParamsValue" Sortable="true">
                                </ext:Column>			
		<ext:Column ColumnID="colParamsType" DataIndex="ParamsType" Header="ParamsType" Sortable="true">
                                </ext:Column>			
 
                                <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                                    <Commands>
                                    <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                                 <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete"></ext:MenuCommand>
                                                 <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View"></ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                   
                                    </ext:SplitCommand>

                                    </Commands>
                                </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPChannelSycnParams"
                        DisplayInfo="true" DisplayMsg="Display SPChannelSycnParamss {0} - {1} total {2}" EmptyMsg="No matched SPChannelSycnParams" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
