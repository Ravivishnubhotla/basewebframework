<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ClientViewDaySum.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.ClientsView.ClientViewDaySum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
        <ext:Hidden ID="hidChannelID" runat="server">
    </ext:Hidden>
    <ext:Store ID="store1" runat="server" AutoLoad="true" OnRefreshData="store1_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="RID">
                <Fields>
                    <ext:RecordField Name="RID" Type="int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="DownCount" Type="Int" />
                    <ext:RecordField Name="DownSycnCount" Type="Int" />
                    <ext:RecordField Name="Price" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script type="text/javascript">
   var gridCommand = function(command, record, row, col) {
       if (command == 'cmdChartProvince') {
                
               var win = <%= this.winRrovinceReport.ClientID %>;

               var hchannelID = <%= this.hidChannelID.ClientID %>;

                win.setTitle("  日期：【" +  Ext.util.Format.date(record.data.ReportDate,'Y-m-d') + "】省份分布 ");
                
 
                
                win.autoLoad.params.ChannleID = hchannelID.getValue();
                win.autoLoad.params.ClientID = <%= SPClientID %>;
                win.autoLoad.params.StartDate = record.data.ReportDate;
                win.autoLoad.params.EndDate = record.data.ReportDate;
                win.autoLoad.params.DataType = "downcountdetail";
                win.autoLoad.params.IsClientShow = "1";        

        win.show(); 
            }
        };
  </script>
  
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="即时统计" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text=" ">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbProvince" Hidden="true" Editable="true" runat="server" AllowBlank="True"
                                        TriggerAction="All">
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
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
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
                                <ext:Column ColumnID="colReportDate" DataIndex="ReportDate" Header="日期" Sortable="true"
                                    Width="20">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y')" />
                                </ext:Column>
                                <ext:Column ColumnID="colDownCount" DataIndex="DownCount" Header="点播数" Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colDownSycnCount" DataIndex="DownSycnCount" Header="同步下发数"
                                    Sortable="true" Width="20">
                                </ext:Column>
                                <ext:CommandColumn Header="统计" Width="80">
                                    <Commands>
                                        <ext:GridCommand Icon="ChartBar" CommandName="cmdChartProvince" Text="省份分布">
                                            <ToolTip Text="省份分布" />
                                        </ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <Listeners>
                            <Command Fn="gridCommand" />
                        </Listeners>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="15" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
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
