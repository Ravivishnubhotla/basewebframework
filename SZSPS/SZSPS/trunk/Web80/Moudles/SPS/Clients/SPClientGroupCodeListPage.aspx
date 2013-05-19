<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientGroupCodeListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.SPClientGroupCodeListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <script type="text/javascript">

       var template = '<span style="color:{0};">{1}</span>';

       var change = function(value) {
           return String.format(template, (value) ? 'green' : 'red', FormatBool(value));
       };

        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };

 

        function AllValidate(frm1,frm2,frm3)
        {
            return frm1.getForm().isValid()&&frm2.getForm().isValid()&&frm3.getForm().isValid();
        }
        
 
        

        function RefreshSPClientChannelSettingList() {
            <%= this.storeSPClientChannelSetting.ClientID %>.reload();
        };

        var RefreshSPClientChannelSettingData = function(btn) {
            <%= this.storeSPClientChannelSetting.ClientID %>.reload();
        };
        
        function ShowAddSPClientChannelSettingForm() {
                Coolite.AjaxMethods.UCSPClientChannelSettingAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }


      function ShowSPClientChannelSettingPatchAddForm() {
                Coolite.AjaxMethods.UCSPClientChannelSettingPatchAdd1.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function prepareToolbar(grid, toolbar, rowIndex, record){
            if(record.get("SyncData")!=null && record.get("SyncData")){
                toolbar.items.itemAt(0).items.itemAt(1).show();
            }
            else{
                toolbar.items.itemAt(0).items.itemAt(1).hide();
            }
        }


        var showCommands = function(grid, toolbar, rowIndex, record) {

            if (record.data.SyncData != null && record.data.SyncData) {
                toolbar.items.items[0].menu.items.items[1].show();
                //toolbar.items.items[0].menu.items.items[2].show();
                toolbar.items.items[0].menu.items.items[8].show();
            } else {
                toolbar.items.items[0].menu.items.items[1].hide();
                //toolbar.items.items[0].menu.items.items[2].hide();
                toolbar.items.items[0].menu.items.items[8].hide();

            }

            if ((record.data.CommandType == "1"||record.data.CommandType == "3") && record.data.AllowFilter != null && record.data.AllowFilter) {
                toolbar.items.items[0].menu.items.items[7].show();
            } else {
                toolbar.items.items[0].menu.items.items[7].hide();
            }

            if (record.data.CommandType == "3") {
                toolbar.items.items[0].menu.items.items[3].show();
            } else {
                toolbar.items.items[0].menu.items.items[3].hide();
            }

        };

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPClientChannelSettingEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdSetCode") {
                Coolite.AjaxMethods.UCSPClientChannelSettingBaseEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            

            

           if (cmd == "cmdAddSubCode") {
                Ext.MessageBox.prompt('添加子指令','子指令:',function(button,text){ 
                    Coolite.AjaxMethods.UCSPClientChannelSettingPatchAdd1.ShowAddSub(id.id,text,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
                } );
                
            }

            if (cmd == "cmdChangeClientUser") {
                Coolite.AjaxMethods.UCSPClientChannelSettingChangeClientAndUser.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPClientChannelSettingData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选SPClientChannelSetting ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除通道下家设置！',RefreshSPClientChannelSettingData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }

 

 


        }

    </script>
    <ext:Store ID="storeSPClientChannelSetting" runat="server" AutoLoad="False" WarningOnDirty="False"  
        OnRefreshData="storeSPClientChannelSetting_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="InterceptRate" Type="int" />
                    <ext:RecordField Name="UpRate" Type="int" />
                    <ext:RecordField Name="DownRate" Type="int" />
                    <ext:RecordField Name="CommandType" />
                    <ext:RecordField Name="CommandCode" />
                    <ext:RecordField Name="CommandTypeName" />
                    <ext:RecordField Name="ChannelClientRuleMatch" />
                    <ext:RecordField Name="ChannelClientCode" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="ChannelID_ID" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="OrderIndex" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="AllowFilter" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
            <Listeners> 
        <Save Handler="#{storeSPClientChannelSetting}.commitChanges();"></Save>
    </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeSPClientChannelSetting"
                        StripeRows="true" Title="下家组分配指令管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnReload' runat="server" Text="刷新" Icon="Reload">
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnSaveAll' runat="server" Text="批量修改" Icon="DiskEdit">
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
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Width="39" Header="通道"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣率" Width="25">
                                    <Editor>
                                        <ext:NumberField ID="TextField2" runat="server" DecimalPrecision="0" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column ColumnID="colChannelClientCode" DataIndex="ChannelClientCode" Header="同步地址"
                                    Sortable="false" Width="120">
                                    <Editor>
                                        <ext:TextField ID="TextField1" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column ColumnID="colChannelClientCode" DataIndex="ChannelClientCode" Header="指令"
                                    Sortable="false" Width="120">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientChannelSetting"
                                DisplayInfo="true" DisplayMsg="显示通道指令 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道指令" />
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
