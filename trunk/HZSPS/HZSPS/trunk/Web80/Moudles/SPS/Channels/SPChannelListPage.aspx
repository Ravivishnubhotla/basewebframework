<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="SPChannelListPage.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelListPage" %>

<%@ Register Src="UCSPChannelAdd.ascx" TagName="UCSPChannelAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPChannelEdit.ascx" TagName="UCSPChannelEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPChannelEditInfo.ascx" TagName="UCSPChannelEditInfo" TagPrefix="uc5" %>
<%@ Register Src="UCChannelParamsManage.ascx" TagName="UCChannelParamsManage" TagPrefix="uc3" %>
<%@ Register Src="SPChannelQuickAdd.ascx" TagName="SPChannelQuickAdd" TagPrefix="uc4" %>
<%@ Register Src="SPChannelQuickAddIVR.ascx" TagName="SPChannelQuickAddIVR" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPUper}.reload();"></DocumentReady>
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };


        function ReloadAllChannelInfo()
        {
                               Coolite.AjaxMethods.RefreshAllChannelInfo( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功刷新通道信息！',RefreshSPChannelData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }
                                                            );     
        }

        function RefreshSPChannelList() {
            <%= this.storeSPChannel.ClientID %>.reload();
        };

        var RefreshSPChannelData = function(btn) {
            <%= this.storeSPChannel.ClientID %>.reload();
        };
        
        function ShowAddSPChannelForm() {
                Coolite.AjaxMethods.UCSPChannelAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }


        function ShowSPChannelQuickAdd() {
                Coolite.AjaxMethods.SPChannelQuickAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }
        

        function ShowSPChannelQuickAddIVR() {
            Coolite.AjaxMethods.SPChannelQuickAddIVR.Show( 
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('操作失败', msg,RefreshSPChannelData);
                                                                },
                                                                eventMask: {
                                                                    showMask: true,
                                                                    msg: '加载中...'
                                                                }
                                                            });    
        
        }
        
        


        

        function processcmd(cmd, id) {


        
            if (cmd == "cmdEditInfo") {
                Coolite.AjaxMethods.UCSPChannelEditInfo.Show(id.id,
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


            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPChannelEdit.Show(id.id,
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

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选通道 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除通道！',RefreshSPChannelData);            
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
            
            if (cmd == "cmdParams") {
                Coolite.AjaxMethods.UCChannelParamsManage.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPChannelParamsData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }   
            
            if (cmd == "cmdSendTestRequest") {

                var win = <%= this.winSendTestRequestForm.ClientID %>;
                

                win.setTitle(" 通道 "+id.data.Name+"  " + " 发送模拟数据 ");
                
                win.autoLoad.url = 'SPChannelSendTestRequestForm.aspx';
                
                win.autoLoad.params.ChannleID = id.data.Id;
        
                win.show();    
            }  
            
            
            if (cmd == "cmdClientSetting") {

                var win = <%= this.winChannelClientSettings.ClientID %>;
                

                win.setTitle(" 通道 "+id.data.Name+"  " + " 指令分配 ");
                
                win.autoLoad.url = '../ClientChannelSettings/SPClientChannelSettingListPage.aspx';
                
                win.autoLoad.params.ChannleID = id.data.Id;
        
                win.show();    
            }
            
            if (cmd == "cmdnChannelDefaultSendParams") {

                var win = <%= this.winChannelDefaultSendParams.ClientID %>;
                

                win.setTitle(" 通道 "+id.data.Name+"  " + " 默认下发参数 ");
                
                win.autoLoad.url = 'SPChannelDefaultSycnParamsListPage.aspx';
                
                win.autoLoad.params.ChannleID = id.data.Id;
        
                win.show();    
            }
            
 
            
                   
        }

        function manageChannelSource(channleFileType) {

                var win = <%= this.winChannelFileList.ClientID %>;
                
 
                win.setTitle('管理通道代码');
                
                win.autoLoad.url = 'SPChannelFilesList.aspx';
            
                win.autoLoad.params.ChannleFileType = channleFileType;

                win.show();  
        }

    </script>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeSPChannel_Refresh">
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
                    <ext:RecordField Name="Area" />
                    <ext:RecordField Name="Operator" />
                    <ext:RecordField Name="ChannelCode" />
                    <ext:RecordField Name="FuzzyCommand" />
                    <ext:RecordField Name="AccurateCommand" />
                    <ext:RecordField Name="Port" />
                    <ext:RecordField Name="ChannelType" />
                    <ext:RecordField Name="Price" Type="Float" />
                    <ext:RecordField Name="Rate" Type="Int" />
                    <ext:RecordField Name="Status" Type="int" />
                    <ext:RecordField Name="CStatusString" />
                    <ext:RecordField Name="CreateTime" Type="Date" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                    <ext:RecordField Name="InterfaceUrl" />
                    <ext:RecordField Name="UperName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:Store ID="storeSPUper" runat="server" AutoLoad="true" OnRefreshData="storeSPUper_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPChannelAdd ID="UCSPChannelAdd1" runat="server" />
    <uc2:UCSPChannelEdit ID="UCSPChannelEdit1" runat="server" />
    <uc3:UCChannelParamsManage ID="UCChannelParamsManage1" runat="server" />
    <uc4:SPChannelQuickAdd ID="SPChannelQuickAdd1" runat="server" />
    <uc5:UCSPChannelEditInfo ID="UCSPChannelEditInfo1" runat="server" />
    <uc6:SPChannelQuickAddIVR ID="SPChannelQuickAddIVR1" runat="server" />   
    
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPChannel" runat="server" StoreID="storeSPChannel" StripeRows="true"
                        Title="通道管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>

                                    <ext:ToolbarButton ID='ToolbarButton1' runat="server" Text="快速添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowSPChannelQuickAdd();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                   <ext:ToolbarButton ID='ToolbarButton8' runat="server" Text="快速添加IVR" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowSPChannelQuickAddIVR();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                     <ext:ToolbarButton ID='btnAdd' runat="server" Text="管理通道代码" Icon="PageCode">
                                        <Listeners>
                                            <Click Handler="manageChannelSource('1');" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='ToolbarButton2' runat="server" Text="管理通道规则" Icon="Cog">
                                         <Listeners>
                                            <Click Handler="manageChannelSource('2');" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:TextField ID="txtSreachName" runat="server" EmptyText="输入通道名" />
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='ToolbarButton3' runat="server" Text="查找" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPChannel}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSPChannel}.reload();" />
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
                                <ext:Column ColumnID="colUperName" DataIndex="UperName" Header="所属上家" Width="90"
                                    Sortable="False">
                                </ext:Column>
                                <ext:Column ColumnID="colName" DataIndex="Name" Header="名称" Width="80" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelCode" DataIndex="ChannelCode" Header="通道编码" Sortable="true"
                                    Hidden="true">
                                </ext:Column>
                                <ext:Column ColumnID="colFuzzyCommand" DataIndex="FuzzyCommand" Header="提交别名" Width="80"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colPort" DataIndex="Port" Header="端口" Hidden="true" Sortable="true"
                                    Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colRate" DataIndex="Rate" Header="默认扣率" Sortable="true" Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="通道价格" Sortable="true" Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colStatus" DataIndex="CStatusString" Header="状态" Sortable="true"
                                    Width="30">
                                </ext:Column>
                                <ext:CommandColumn Header="通道管理" Width="80">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationForm" Text="选择操作" ToolTip-Text="选择操作">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEditInfo" Text="分配上家" />
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑" Hidden='<%# IsSPCommUser %>'
                                                        AutoDataBind="True" />
                                                    <ext:MenuCommand Icon="TelephoneGo" CommandName="cmdSendTestRequest" Text="测试" />
                                                    <ext:MenuCommand Icon="ApplicationFormEdit" CommandName="cmdClientSetting" Text="指令分配" />
                                                    <ext:MenuCommand Icon="ServerEdit" CommandName="cmdParams" Text="参数管理" Hidden='<%# IsSPCommUser %>'
                                                        AutoDataBind="True" />
                                                    <ext:MenuCommand Icon="ApplicationFormEdit" CommandName="cmdnChannelDefaultSendParams"
                                                        Text="默认下发参数" Hidden='<%# IsSPCommUser %>' AutoDataBind="True" />
                                                </Items>
                                            </Menu>
                                            <ToolTip Text="Menu" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                                <ext:CommandColumn Header="通道管理" Width="172" Hidden="True">
                                    <Commands>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEditInfo" Text="分配上家">
                                            <ToolTip Text="测试" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="TelephoneGo" CommandName="cmdSendTestRequest" Text="测试">
                                            <ToolTip Text="测试" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdClientSetting" Text="指令分配">
                                            <ToolTip Text="指令分配" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑" Hidden='<%# IsSPCommUser %>'
                                            runat="server" AutoDataBind="True">
                                            <ToolTip Text="编辑" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" Hidden="true">
                                            <ToolTip Text="删除" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ServerEdit" CommandName="cmdParams" Text="参数管理" Hidden='<%# IsSPCommUser %>'
                                            runat="server" AutoDataBind="True">
                                            <ToolTip Text="参数管理" />
                                        </ext:GridCommand>
                                        <ext:GridCommand Icon="ApplicationFormEdit" CommandName="cmdnChannelDefaultSendParams"
                                            Text="默认下发参数" Hidden='<%# IsSPCommUser %>' runat="server" AutoDataBind="True">
                                            <ToolTip Text="默认下发参数" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPChannel"
                                DisplayInfo="true" DisplayMsg="显示通道 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <p><b>描述：</b> {Description}</p>
                        <p><b>接口链接：</b> {InterfaceUrl}</p>                        
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelClientSettings" runat="server" Title="Window" Frame="true"
        Width="980" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelDefaultSendParams" runat="server" Title="Window" Frame="true"
        Width="850" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winChannelFileList" runat="server" Title="管理通道文件" Frame="true"
        Width="850" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
                        <Params>
                <ext:Parameter Name="ChannleFileType" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
