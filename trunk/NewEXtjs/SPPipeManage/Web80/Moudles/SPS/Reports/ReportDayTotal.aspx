<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDayTotal.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportDayTotal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

        var decimalFormat = function(value) {
            return formatFloat(value, 2).toString() + "%";
        };

        var filterfn = function(rec, id) {
            return (rec.data.TotalCount > 0);
        }

        var prepareCellCommandTotalCount = function(grid, command, record, row, col, value) {
            if ((command.command == 'TotalCountDetail'||command.command == 'InterceptCountDetail'||command.command == 'DownCountDetail'||command.command == 'DownSycnCountDetail') && value > 0) {
                command.hidden = false;
                command.hideMode = 'display';
            }
        };


        var gridCommand = function(command, record, row, col) {
            if (command == 'TotalCountDetail'||command == 'InterceptCountDetail'||command == 'DownCountDetail'||command == 'DownSycnCountDetail')  {
                
                
                var win = <%= this.Window1.ClientID %>;
                
                var datatypeName = "";
                
                if(command == 'TotalCountDetail')
                {
                    datatypeName = '总点播';
                }
                if(command == 'InterceptCountDetail')
                {
                    datatypeName = '扣量';
                }
                if(command == 'DownCountDetail')
                {
                    datatypeName = '转发下家';
                }
                if(command == 'DownSycnCountDetail')
                {
                    datatypeName = '同步下家';
                }                
                
                
                win.setTitle(" 通道 "+record.data.ChannelName+"  " + " 下家 "+record.data.ClientName+"  " + datatypeName + " 明细数据 ");
                
                win.autoLoad.url = 'DetailRecordView.aspx';
                
                win.autoLoad.params.ChannleID = record.data.ChannelID;
                win.autoLoad.params.ClientID = record.data.ClientID;
                win.autoLoad.params.StartDate = record.data.ReportDate;
                win.autoLoad.params.EndDate = record.data.ReportDate;
                win.autoLoad.params.DataType = command;           
                win.show();              
                
                
                //alert(win);
            }

        };

    </script>

    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData">
        <Reader>
            <ext:JsonReader ReaderID="ReportID">
                <Fields>
                    <ext:RecordField Name="ReportID" Type="Int" />
                    <ext:RecordField Name="TotalCount" Type="Int" />
                    <ext:RecordField Name="DownCount" Type="Int" />
                    <ext:RecordField Name="InterceptCount" Type="Int" />
                    <ext:RecordField Name="DownSycnCount" Type="Int" />
                    <ext:RecordField Name="InterceptRate" Type="Float" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelID" Type="Int" />
                    <ext:RecordField Name="ClientID" Type="Int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="if(#{chkFilterNoCount}.getValue()) {#{Store1}.filterBy(filterfn);} else {#{Store1}.clearFilter();}" />
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="Store1"
                        StripeRows="true" Title="日报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="  日期:  ">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="数据汇总统计">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtTotalCount" runat="server" Text="总点播数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtInterceptCount" runat="server" Text="总扣量数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtDownCount" runat="server" Text="总转发下家数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem ID="txtDownSycnCount" runat="server" Text="总同步下家数(条)：0">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem2" runat="server" Text="不显示0流量的通道">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:Checkbox ID="chkFilterNoCount" Checked="false" runat="server">
                                        <Listeners>
                                            <Check Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:Checkbox>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
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
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="TotalCount" Header="总点播数(条)" Sortable="true">
                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="TotalCountDetail" Hidden="true">
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" Args="grid,command,record,row,col,value" />
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptSuccess" DataIndex="InterceptCount" Header="扣量数(条)"
                                    Sortable="true">
                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="InterceptCountDetail" Hidden="true">
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" Args="grid,command,record,row,col,value" />
                                </ext:Column>
                                <ext:Column ColumnID="colDownSuccess" DataIndex="DownCount" Header="转发下家数(条)" Sortable="true">
                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="DownCountDetail" Hidden="true">
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" Args="grid,command,record,row,col,value" />
                                </ext:Column>
                                <ext:Column ColumnID="colDownSuccess" DataIndex="DownSycnCount" Header="同步下家数(条)"
                                    Sortable="true">
                                    <Commands>
                                        <ext:ImageCommand Icon="Table" CommandName="DownSycnCountDetail" Hidden="true">
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" Args="grid,command,record,row,col,value" />
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="扣量率" Sortable="true">
                                    <Renderer Fn="decimalFormat" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <Listeners>
                            <Command Fn="gridCommand" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="Window1" runat="server" Title="Window" Frame="true" Width="640" ConstrainHeader="true"
        Height="480" Maximizable="true" Closable="true" Resizable="true" Modal="true"
        ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
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
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
