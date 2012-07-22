<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientChannelSettingListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.SPClientChannelSettingListPage" %>

<%@ Register Src="UCSPClientChannelSettingAdd.ascx" TagName="UCSPClientChannelSettingAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSPClientChannelSettingEdit.ascx" TagName="UCSPClientChannelSettingEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSPClientChannelSettingPatchAdd1.ascx" TagName="UCSPClientChannelSettingPatchAdd1"
    TagPrefix="uc3" %>
<%@ Register Src="UCSPClientChannelSettingChangeClientAndUser.ascx" TagName="UCSPClientChannelSettingChangeClientAndUser"
    TagPrefix="uc4" %>
<%@ Register Src="UCSPClientChannelSettingBaseEdit.ascx" TagName="UCSPClientChannelSettingBaseEdit"
    TagPrefix="uc5" %>
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

        function GetChannleID()
        {
            return <%= this.ChannleID %>;
        }

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

            if ((record.data.CommandType == "1" || record.data.CommandType == "3") && record.data.AllowFilter != null && record.data.AllowFilter) {
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


          if (cmd == "cmdTest") {

                var win = <%= this.winSendTestRequestForm.ClientID %>;
                

                win.setTitle("  "+id.data.Name + "  " + " 发送模拟数据 ");
                
                win.autoLoad.url = 'SPChannelClientSendTestRequestForm.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
        
                win.show();    
            } 
            
            
           if (cmd == "cmdTestClient") {

                var win = <%= this.WindwinSendClientTestRequestFormow1.ClientID %>;
                

                win.setTitle("  "+id.data.Name + "  " + " 下家发送模拟数据 ");
                
                win.autoLoad.url = 'SPChannelClientSendClientTestRequestForm.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
        
                win.show();    
            }  

                      if (cmd == "cmdProvinceFilter") {

                var win = <%= this.winFilterManage.ClientID %>;
                

                win.setTitle("  "+id.data.Name + "  " + " 省份过滤设置 ");
                
                win.autoLoad.url = 'SPClientChannelSettingFiltersListPage.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
        
                win.show();    
            }  

            if (cmd == "cmdParamsEdit") {
                
                var win = <%= this.winParamsEdit.ClientID %>;
                 
                win.setTitle("  "+id.data.Name + " 参数设置 ");
                
                win.autoLoad.url = 'SPClientChannelParamsManage.aspx';
                
                win.autoLoad.params.ChannleClientID = id.data.Id;
          
                win.show();  
            }


        }

    </script>
    <ext:Store ID="storeSPClientChannelSetting" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPClientChannelSetting_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
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
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="OrderIndex" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="AllowFilter" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPClientChannelSettingAdd ID="UCSPClientChannelSettingAdd1" runat="server" />
    <uc2:UCSPClientChannelSettingEdit ID="UCSPClientChannelSettingEdit1" runat="server" />
    <uc3:UCSPClientChannelSettingPatchAdd1 ID="UCSPClientChannelSettingPatchAdd11" runat="server" />
    <uc4:UCSPClientChannelSettingChangeClientAndUser ID="UCSPClientChannelSettingChangeClientAndUser1"
        runat="server" />
    <uc5:UCSPClientChannelSettingBaseEdit ID="UCSPClientChannelSettingBaseEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="storeSPClientChannelSetting"
                        StripeRows="true" Title="通道下家设置管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd" Hidden="true">
                                        <Listeners>
                                            <Click Handler="ShowAddSPClientChannelSettingForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='ToolbarButton1' runat="server" Text="快速添加指令" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowSPClientChannelSettingPatchAddForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPClientChannelSetting}.reload();" />
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
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Sortable="true" Hidden="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Sortable="true"
                                    Hidden="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣率" Width="30">
                                </ext:Column>
                                <ext:Column ColumnID="colOrderIndex" DataIndex="OrderIndex" Header="序号" Width="30">
                                </ext:Column>
                                <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="启用" Sortable="true"
                                    Width="30">
                                    <Renderer Fn="change" />
                                </ext:Column>
                                <ext:Column ColumnID="colCommandType" DataIndex="ChannelClientRuleMatch" Header="指令匹配规则"
                                    Sortable="true" Width="120">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelClientCode" DataIndex="ChannelClientCode" Header="指令"
                                    Sortable="true" Width="120">
                                </ext:Column>
                                <ext:CommandColumn Header="设置管理" Width="50">
                                    <Commands>
                                        <ext:GridCommand Icon="Cog" Text="设置" ToolTip-Text="通道下家设置">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑" />
                                                    <ext:MenuCommand Icon="ServerConnect" CommandName="cmdParamsEdit" Text="设置同步参数" />
                                                    <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdTest" Text="通道测试" />
                                                    <ext:MenuCommand Icon="ScriptAdd" CommandName="cmdAddSubCode" Text="添加子指令" />
                                                    <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" Hidden="true" />
                                                    <ext:MenuCommand Icon="UserGo" CommandName="cmdChangeClientUser" Text="更换下家用户" />
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdSetCode" Text="设置" />
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdProvinceFilter" Text="省份过滤" />
                                                    <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdTestClient" Text="下家测试" />
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Menu" />
                                        </ext:GridCommand>
                                    </Commands>
                                    <PrepareToolbar Fn="showCommands" />
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPClientChannelSetting"
                                DisplayInfo="true" DisplayMsg="显示通道下家设置 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道下家设置" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winParamsEdit" runat="server" Title="Window" Frame="true" Width="640"
        ConstrainHeader="true" Height="450" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winFilterManage" runat="server" Title="Window" Frame="true" Width="640"
        ConstrainHeader="true" Height="450" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="380" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
        <ext:Window ID="WindwinSendClientTestRequestFormow1" runat="server" Title="下家模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="380" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleClientID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
