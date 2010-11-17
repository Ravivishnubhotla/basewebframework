<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientGroupViewRecord.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientGroupViewRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        function ShowProviceChart(channleValue, tbProviceChart) {
            if (channleValue != null && channleValue != '') {
                tbProviceChart.show();
            }
            else {
                tbProviceChart.hide();           
            }
        }

        function showProvince(clientID,storeClient) { 
                var win = <%= this.winRrovinceReport.ClientID %>;
                var dtpStart = <%= this.dfReportStartDate.ClientID %>;
                var dtpEnd = <%= this.dfReportEndDate.ClientID %>;
                win.autoLoad.params.ChannleID = storeClient.getById(clientID).data.DefaultChannelID;
                win.autoLoad.params.ClientID = clientID;
                win.autoLoad.params.StartDate = dtpStart.component.getValue();
                win.autoLoad.params.EndDate = dtpEnd.component.getValue();
                win.autoLoad.params.DataType = "downcountdetail";
                win.autoLoad.params.IsClientShow = "1"; 
                win.show(); 
        }
    </script>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="false" OnRefreshData="storeSPClient_OnRefresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="DisplayName" Mapping="DisplayName" />
                    <ext:RecordField Name="DefaultChannelID" Mapping="DefaultChannelID" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="DataType" Mode="Value" Value="GetAllClientByClientGroup">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Store ID="store1" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="store1_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="MobileNumber" />
                    <ext:RecordField Name="RequestContent" />
                    <ext:RecordField Name="Values" />
                    <ext:RecordField Name="Linkid" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="Ywid" />
                    <ext:RecordField Name="Cpid" />
                    <ext:RecordField Name="SSycnDataUrl" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="即时统计" Icon="Table" AutoExpandColumn="colRequestContent">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbClientID" runat="server" AllowBlank="true" StoreID="storeSPClient"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="DisplayName"
                                        ValueField="Id" EmptyText="全部">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();ShowProviceChart(this.getValue(),#{tbProviceChart});" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();ShowProviceChart(this.getValue(),#{tbProviceChart}); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="省份:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbProvince" Editable="true" runat="server" AllowBlank="True" TriggerAction="All">
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
                                            <ext:ListItem Value="NULL" Text="未知地区"></ext:ListItem>
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
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarButton ID='tbProviceChart' runat="server" Text="省份分布" Icon="ChartBar"
                                        Hidden="true">
                                        <Listeners>
                                            <Click Handler="showProvince(#{cmbClientID}.getValue(),#{storeSPClient});" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
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
                                <ext:Column ColumnID="colReportDate" DataIndex="MobileNumber" Header="手机号" Sortable="true" Width="60"
                                    >
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Linkid" Header="LinkID" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Province" Header="省份" Sortable="false" Width="30">
                                </ext:Column>
                                <ext:Column ColumnID="colYwid" DataIndex="Ywid" Header="上行内容" Sortable="false" Width="60">
                                </ext:Column>
                                <ext:Column ColumnID="colCpid" DataIndex="Cpid" Header="长号码" Sortable="false" Width="60">
                                </ext:Column>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="日期" Sortable="true"  Width="80"
                                     >
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <b>所有参数：</b> {Values}  <br />

                        <b>同步链接：</b> {SSycnDataUrl}

                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="winRrovinceReport" runat="server" Title="数据省份分布报表" Frame="true" Width="640"
        ConstrainHeader="true" Height="480" Maximizable="true" Closable="true" Resizable="true"
        Modal="true" ShowOnLoad="false">
        <AutoLoad Url="../Reports/DataProviceReport.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="ClientID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="StartDate" Mode="Raw" Value="2009-1-1">
                </ext:Parameter>
                <ext:Parameter Name="EndDate" Mode="Raw" Value="2009-1-1">
                </ext:Parameter>
                <ext:Parameter Name="DataType" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="IsClientShow" Mode="Raw" Value="1">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
