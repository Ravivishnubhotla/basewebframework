<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeInfoList.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Codes.SPCodeInfoList" %>

<%@ Register Src="UCSPCodeInfoAdd.ascx" TagName="UCSPCodeInfoAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPCodeInfoEdit.ascx" TagName="UCSPCodeInfoEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannel}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <style type="text/css">
        .x-grid3-td-fullName .x-grid3-cell-inner
        {
            font-family: tahoma, verdana;
            display: block;
            font-weight: normal;
            font-style: normal;
            color: #385F95;
            white-space: normal;
        }
        
        .x-grid3-row-body p
        {
            margin: 5px 5px 10px 5px !important;
            width: 99%;
            color: Gray;
        }
    </style>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '是';
            else
                return '<span style="color:red;">否</span>';
        };
        
                var FormatBool2 = function(value) {
            if (value)
                return '是';
            else
                return '否';
        };

//        var ShowMoCode = function(record) {
//            return record.data.Mo + ' (' + record.data.CodeType + ') ' + record.data.SPCode;
//        };

        function RefreshSPCodeInfoList() {
            <%= this.storeSPCodeInfo.ClientID %>.reload();
        };

        var RefreshSPCodeInfoData = function(btn) {
            <%= this.storeSPCodeInfo.ClientID %>.reload();
        };
        
        function ShowAddSPCodeInfoForm() {
                Coolite.AjaxMethods.UCSPCodeInfoAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPCodeInfoData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {
            
            if (cmd == "cmdEdit") {
                Coolite.AjaxMethods.UCSPCodeInfoEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshSPCodeInfoData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告','确认要删除所选通道信息? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('操作成功', '成功删除通道信息！',RefreshSPCodeInfoData);            
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


                function columnWrap(val){
    return '<div style="white-space:normal !important;">'+ val +'</div>';
}

    </script>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:Store ID="storeSPCodeInfo" runat="server" AutoLoad="true" RemoteSort="true"
        OnRefreshData="storeSPCodeInfo_Refresh">
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
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="MoCode" />
                    <ext:RecordField Name="OperatorType" />
                    <ext:RecordField Name="Mo" />
                    <ext:RecordField Name="CodeType" />
                    <ext:RecordField Name="SPCode" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="Price" />
                    <ext:RecordField Name="DisableArea" />
                    <ext:RecordField Name="DayMonthLimit" />
                    <ext:RecordField Name="SendText" />
                    <ext:RecordField Name="IsLimit" Type="Boolean" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="Comment" />
                    <ext:RecordField Name="CreateUserName" />
                    <ext:RecordField Name="CreateTime" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
        <Listeners>
            <Load Handler="if (#{storeSPCodeInfo}.getCount()>0) #{btnExport}.enable(); else #{btnExport}.disable();">
            </Load>
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPCodeInfoAdd ID="UCSPCodeInfoAdd1" runat="server" />
    <uc2:UCSPCodeInfoEdit ID="UCSPCodeInfoEdit2" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPCodeInfo" runat="server" StoreID="storeSPCodeInfo"
                        Frame="True" StripeRows="true" Title="通道管理" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                        <Listeners>
                                            <Click Handler="ShowAddSPCodeInfoForm();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ComboBox ID="cmbSChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannel"
                                        TypeAhead="true" Mode="Local" Editable="True" ForceSelection="True" DisplayField="Name" ValueField="Id"
                                        EmptyText="选择上家" Width="90">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbSOperatorType" Editable="false" runat="server" EmptyText="选择运营商"
                                        AllowBlank="true" TriggerAction="All" Width="70">
                                        <Items>
                                            <ext:ListItem Value="移动" Text="移动"></ext:ListItem>
                                            <ext:ListItem Value="联通" Text="联通"></ext:ListItem>
                                            <ext:ListItem Value="电信" Text="电信"></ext:ListItem>
                                        </Items>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:TextField ID="txtSMo" Width="70" EmptyText="指令" AllowBlank="true" runat="server">
                                    </ext:TextField>
                                    <ext:TextField ID="txtSPort" Width="70" EmptyText="端口号" AllowBlank="true" runat="server">
                                    </ext:TextField>
                                    <ext:ComboBox ID="cmbSProvince" Width="70" Editable="true" runat="server" EmptyText="开通省份"
                                        AllowBlank="true" TriggerAction="All">
                                        <Items>
                                            <ext:ListItem Value="安徽" Text="安徽"></ext:ListItem>
                                            <ext:ListItem Value="北京" Text="北京"></ext:ListItem>
                                            <ext:ListItem Value="福建" Text="福建"></ext:ListItem>
                                            <ext:ListItem Value="甘肃" Text="甘肃"></ext:ListItem>
                                            <ext:ListItem Value="广东" Text="广东"></ext:ListItem>
                                            <ext:ListItem Value="广西" Text="广西"></ext:ListItem>
                                            <ext:ListItem Value="贵州" Text="贵州"></ext:ListItem>
                                            <ext:ListItem Value="海南" Text="海南"></ext:ListItem>
                                            <ext:ListItem Value="河北" Text="河北"></ext:ListItem>
                                            <ext:ListItem Value="河南" Text="河南"></ext:ListItem>
                                            <ext:ListItem Value="黑龙江" Text="黑龙江"></ext:ListItem>
                                            <ext:ListItem Value="湖北" Text="湖北"></ext:ListItem>
                                            <ext:ListItem Value="湖南" Text="湖南"></ext:ListItem>
                                            <ext:ListItem Value="吉林" Text="吉林"></ext:ListItem>
                                            <ext:ListItem Value="江苏" Text="江苏"></ext:ListItem>
                                            <ext:ListItem Value="江西" Text="江西"></ext:ListItem>
                                            <ext:ListItem Value="辽宁" Text="辽宁"></ext:ListItem>
                                            <ext:ListItem Value="内蒙古" Text="内蒙古"></ext:ListItem>
                                            <ext:ListItem Value="宁夏" Text="宁夏"></ext:ListItem>
                                            <ext:ListItem Value="青海" Text="青海"></ext:ListItem>
                                            <ext:ListItem Value="山东" Text="山东"></ext:ListItem>
                                            <ext:ListItem Value="陕西" Text="陕西"></ext:ListItem>
                                            <ext:ListItem Value="上海" Text="上海"></ext:ListItem>
                                            <ext:ListItem Value="四川" Text="四川"></ext:ListItem>
                                            <ext:ListItem Value="天津" Text="天津"></ext:ListItem>
                                            <ext:ListItem Value="西藏" Text="西藏"></ext:ListItem>
                                            <ext:ListItem Value="新疆" Text="新疆"></ext:ListItem>
                                            <ext:ListItem Value="云南" Text="云南"></ext:ListItem>
                                            <ext:ListItem Value="浙江" Text="浙江"></ext:ListItem>
                                            <ext:ListItem Value="重庆" Text="重庆"></ext:ListItem>
                                        </Items>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbLimit" Width="75" Editable="true" runat="server" EmptyText="限量"
                                        AllowBlank="true" TriggerAction="All">
                                        <Items>
                                            <ext:ListItem Value="1" Text="是"></ext:ListItem>
                                            <ext:ListItem Value="0" Text="否"></ext:ListItem>
                                        </Items>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbSEnbale" Width="75" Editable="true" runat="server" EmptyText="可用"
                                        AllowBlank="true" TriggerAction="All">
                                        <Items>
                                            <ext:ListItem Value="1" Text="是"></ext:ListItem>
                                            <ext:ListItem Value="0" Text="否"></ext:ListItem>
                                        </Items>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='ToolbarButton3' runat="server" Text="查找" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeSPCodeInfo}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnExport' runat="server" Disabled="True" Text="导出" Icon="PageExcel"
                                        AutoPostBack="True" OnClick="ExportToExcel">
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <View>
                            <ext:GridView ID="GridView1" runat="server" ForceFit="True" EnableRowBody="true">
                                <GetRowClass Handler="rowParams.body = '<p>下发语:<br/>' + record.data.SendText + '</p>'; return 'x-grid3-row-expanded';" />
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colChannelName" DataIndex="ChannelName" Header="所属上家" Width="60">
                                </ext:Column>
                                <ext:Column ColumnID="colOperatorType" DataIndex="OperatorType" Header="运营商" Width="35"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colMoCode" DataIndex="MoCode" Header="指令" Sortable="true" Width="100">
                                </ext:Column>
                                <ext:Column ColumnID="colCodeType" DataIndex="CodeType" Header="指令类型" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Sortable="true" Width="30">
                                </ext:Column>
                                <ext:Column ColumnID="colProvince" DataIndex="Province" Header="开通省份" Sortable="true">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colDisableArea" DataIndex="DisableArea" Header="屏蔽地市" Sortable="true">
                                    <Renderer Fn="columnWrap" />
                                </ext:Column>
                                <ext:Column ColumnID="colIsLimit" DataIndex="IsLimit" Header="限量" Width="31" Sortable="true">
                                    <Renderer Fn="FormatBool2"></Renderer>
                                </ext:Column>
                                <ext:Column ColumnID="colDayMonthLimit" DataIndex="DayMonthLimit" Header="日月限" Width="45"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="可用" Width="31" Sortable="true">
                                    <Renderer Fn="FormatBool"></Renderer>
                                </ext:Column>
                                <ext:CommandColumn Header="管理" Width="60">
                                    <Commands>
                                        <ext:GridCommand Icon="Cog" Text="设置" ToolTip-Text="通道信息管理">
                                            <Menu>
                                                <Items>
                                                    <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="编辑" />
                                                    <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="删除" />
                                                </Items>
                                            </Menu>
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSPCodeInfo"
                                DisplayInfo="true" DisplayMsg="显示通道信息 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的通道信息" />
                        </BottomBar>
                        <Listeners>
                            <Command Handler="processcmd(command, record);" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <rsweb:ReportViewer ID="rptvExport" runat="server" Visible="False">
    </rsweb:ReportViewer>
</asp:Content>
