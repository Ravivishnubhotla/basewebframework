<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientCodeRelationListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.SPClientCodeRelationListPage" %>

<%@ Register Src="UCSPClientCodeRelationAdd.ascx" TagName="UCSPClientCodeRelationAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPClientCodeRelationEdit.ascx" TagName="UCSPClientCodeRelationEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSPClientCodeRelationView.ascx" TagName="UCSPClientCodeRelationView"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatStatus = function(value) {
            if (value)
                return '<font color=Green>启用</font>';
            else
                return '<font color=Red>停用</font>';
        };
        
                var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var RefreshData = function(btn) {
            <%= this.storeSPClientCodeRelation.ClientID %>.reload();
        };

        function RefreshSPClientCodeRelationList() {
            <%= this.storeSPClientCodeRelation.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPClientCodeRelationAdd.Show( 
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




            if (cmd == "cmdChannelTest") {
                var win = <%= this.winSendTestRequestForm.ClientID %>;
                

                win.setTitle(' 通道 '+id.data.ChannelName+'  发送模拟数据 ');
                
                win.autoLoad.params.ChannelID = id.data.ChannelID;	
        
            	win.autoLoad.params.CodeID = id.data.CodeID_Id;		                
            			                
                win.show(); 
            }
            

            if (cmd == "cmdClientTest") {
                var win = <%= this.winSendClientTestRequestForm.ClientID %>;
                

                win.setTitle(' 客户 '+id.data.ClientID_Name+'  发送模拟同步数据 ');
                
                win.autoLoad.params.ClientCodeRelationID = id.data.Id;	
            			                
                win.show(); 
            }



            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPClientCodeRelationEdit.Show(id.id,
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
                Ext.net.DirectMethods.UCSPClientCodeRelationView.Show(id.id,
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
                Ext.MessageBox.confirm('警告','确认要删除该条数据？',
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
                                                                                msg: '操作中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }
        var showTip = function() {
            var rowIndex = <%= gridPanelSPClientCodeRelation.ClientID %> .view.findRowIndex(this.triggerElement),
                cellIndex = <%= gridPanelSPClientCodeRelation.ClientID %> .view.findCellIndex(this.triggerElement),
                record = <%= storeSPClientCodeRelation.ClientID %> .getAt(rowIndex),
                fieldName = <%= gridPanelSPClientCodeRelation.ClientID %> .getColumnModel().getDataIndex(cellIndex),
                data = record.get(fieldName);

            if(fieldName=='IsEnable')
                data = record.get('DataRange');
            
            this.body.dom.innerHTML = data;
        };
    </script>
    <ext:Store ID="storeSPClientCodeRelation" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSPClientCodeRelation_Refresh">
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
                    <ext:RecordField Name="CodeID_Id" Type="int" />
                    <ext:RecordField Name="CodeID_MoCode" />
                    <ext:RecordField Name="ChannelName" />
                           <ext:RecordField Name="ClientID_Name" />             
                    
                    <ext:RecordField Name="ChannelID" Type="int" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="InterceptRate" Type="int" />
                    <ext:RecordField Name="UseClientDefaultSycnSetting" Type="Boolean" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="SycnRetryTimes" />
                    <ext:RecordField Name="SyncType" />
                    <ext:RecordField Name="SycnDataUrl" />
                    <ext:RecordField Name="SycnOkMessage" />
                    <ext:RecordField Name="SycnFailedMessage" />
                    <ext:RecordField Name="StartDate" Type="Date" />
                    <ext:RecordField Name="EndDate" Type="Date" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="SycnNotInterceptCount" Type="int" />
                    <ext:RecordField Name="DataRange" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientCodeRelationAdd ID="UCSPClientCodeRelationAdd1" runat="server" />
    <uc2:UCSPClientCodeRelationEdit ID="UCSPClientCodeRelationEdit1" runat="server" />
    <uc3:UCSPClientCodeRelationView ID="UCSPClientCodeRelationView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPClientCodeRelation" runat="server" StoreID="storeSPClientCodeRelation"
                TrackMouseOver="true" StripeRows="true" Title="代码分配管理" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="分配代码" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPClientCodeRelation}.reload();" />
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
                        <ext:Column ColumnID="colID" DataIndex="Id" Header="ID" Width="15" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colChannelName" DataIndex="ChannelName" Header="通道" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMoCode" DataIndex="CodeID_MoCode" Header="代码" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Width="20" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Width="20" Header="扣率"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSyncData" DataIndex="SyncData" Header="同步" Width="20" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="状态" Width="20" Sortable="true">
                            <Renderer Fn="FormatStatus" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="管理" Width="39">
                            <Commands>
                                <ext:SplitCommand Text="操作" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="查看">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdChannelTest" Text="通道测试">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdClientTest" Text="客户同步测试">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPClientCodeRelation"
                        DisplayInfo="true" DisplayMsg="显示代码 {0} - {1} 共 {2}" EmptyMsg="没有分配的代码" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:ToolTip ID="RowTip" runat="server" Target="={#{gridPanelSPClientCodeRelation}.getView().mainBody}"
        Anchor="left" Delegate=".x-grid3-cell" TrackMouse="true">
        <Listeners>
            <Show Fn="showTip" />
        </Listeners>
    </ext:ToolTip>
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true" AutoScroll="true">
        <AutoLoad Url="../Channels/SPChannelSendTestRequestForm.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="CodeID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winSendClientTestRequestForm" runat="server" Title="下家模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true" AutoScroll="true">
        <AutoLoad Url="SPSClientCodeSycnTestForm.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientCodeRelationID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
