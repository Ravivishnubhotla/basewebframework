<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportToday.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportToday" %>

<%@ Register Src="../ClientChannelSettings/UCSPClientChannelSettingEdit.ascx" TagName="UCSPClientChannelSettingEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        function formatFloat(src, pos) {
            return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
        }

        var decimalFormat = function(value) {
            return formatFloat(value, 2).toString() + "%";
        };
        

        var decimalFormat1 = function(value) {
            return formatFloat(value, 2).toString(); 
        };

        var showPerent = function(value) {
            return value.toString() + "%";
        };


        var filterfn = function(rec, id) {
            return (rec.data.TotalCount > 0);
        };


        function AllValidate(frm1,frm2,frm3)
        {
            return frm1.getForm().isValid()&&frm2.getForm().isValid()&&frm3.getForm().isValid();
        }


        var RefreshSPClientChannelSettingData = function(btn) {
            <%= this.Store1.ClientID %>.reload();
        };

         var RefreshReportData = function(btn) {
            <%= this.Store1.ClientID %>.reload();
        };
         
         
                 function CloseInterceptReset()
        {
                var win = <%= this.winResetIntercept.ClientID %>;
                
 
                                         
                win.hide();   
        }


        var prepareCellCommandTotalCount = function(grid, command, record, row, col, value) {
            if ((command.command == 'TotalCountDetail'||command.command == 'InterceptCountDetail'||command.command == 'DownCountDetail'||command.command == 'DownSycnCountDetail') && value > 0) {
                command.hidden = false;
                command.hideMode = 'display';
            }
            if(command.command == 'ReSend')
            {
                if(record.data.IsSycnData)
                {
                    command.hidden = false;
                    command.hideMode = 'display';  
                }
                else{
                    command.hidden = true;
                    command.hideMode = 'display';  
                }
            }

            
//            if(command.command == 'InterceptCountChange')
//            {
//                if(!record.data.IsSycnData)
//                {
//                    command.hidden = false;
//                    command.hideMode = 'display';  
//                }
//                else{
//                    command.hidden = true;
//                    command.hideMode = 'display';  
//                }
//            }

            if(command.command == 'InterceptReset')
            {
                if(record.data.IsSycnData&&(record.data.InterceptCount > 0))
                {
                    command.hidden = false;
                    command.hideMode = 'display';  
                }
                else{
                    command.hidden = true;
                    command.hideMode = 'display';  
                }
            }

        };


        var gridCommand = function(command, record, row, col) {
    
             if (command == "cmdEditChannelClient") {
                Coolite.AjaxMethods.UCSPClientChannelSettingEdit.Show(record.data.ChannelClientID,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }              
                );
            }


            if (command == "ReSend") {
                             
                             
                var win = <%= this.winReSendData.ClientID %>;
                
                win.setTitle("补发数据");
                
                win.autoLoad.url = 'ReSendData.aspx';
                
                win.autoLoad.params.ClientChannelID = record.data.ChannelClientID;
                                         
                win.show(); 
            }


           if (command == "InterceptReset") {
                                         
                var win = <%= this.winResetIntercept.ClientID %>;
                
                win.setTitle("取消扣除的数据");
                
                win.autoLoad.url = 'ResetInterceptToSycn.aspx';
                
                win.autoLoad.params.ClientChannelID = record.data.ChannelClientID;
                                         
                win.show();                      
                                         
            }


             if (command == 'InterceptCountChange')  {
                var title = "修改通道‘"+record.data.ChannelName+"’-下家‘"+record.data.ClientName+"' "+record.data.ReportDate.dateFormat('Y/m/d')+" 扣量,原扣量："+record.data.InterceptCount.toString();
                Ext.MessageBox.prompt(
                                        title,
                                        '新的扣量:',
                                        function(button,text){ 
                                                                if(button=="ok")
                                                                {
                                                                        Coolite.AjaxMethods.ChangeInterceptCount(
                                                                                    record.data.ReportDate.dateFormat('Y/m/d'),record.data.ClientID,text,
                                                                                    {
                                                                                        failure: function(msg) {
                                                                                            Ext.Msg.alert('操作失败', msg,RefreshReportData);
                                                                                        },
                                                                                        success: function(result) { 
                                                                                            Ext.Msg.alert('操作成功', '成功修改扣量！',RefreshReportData);            
                                                                                        },
                                                                                        eventMask: {
                                                                                            showMask: true,
                                                                                            msg: '加载中...'
                                                                                        }
                                                                                    });                                      
                                                                }
                                                             } 
                                      );
             }


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
                    <ext:RecordField Name="SetInterceptRate" Type="Float" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelID" Type="Int" />
                    <ext:RecordField Name="ClientID" Type="Int" />
                    <ext:RecordField Name="ChannelClientID" Type="Int" />
                    <ext:RecordField Name="ReportDate" Type="Date" />
                    <ext:RecordField Name="ClientGroupName" />
                    <ext:RecordField Name="ChannelClientCode" />
                    <ext:RecordField Name="AssignedUser" />
                    <ext:RecordField Name="Price" Type="Float" />
                    <ext:RecordField Name="IsSycnData" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCSPClientChannelSettingEdit ID="UCSPClientChannelSettingEdit1" runat="server" />
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="Store1"
                        StripeRows="true" Title="今日即时报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarButton ID='btnExport' runat="server" Text="导出" Icon="PageExcel" Hidden="true">
                                        <Listeners>
                                            <Click Handler="exportData(#{gridPanelSPClientChannelSetting});" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="隐藏0流量通道">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:Checkbox ID="chkFilterNoCount" Checked="true" runat="server">
                                        <Listeners>
                                            <Check Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:Checkbox>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarTextItem runat="server" Text="汇总统计">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSeparator>
                                    </ext:ToolbarSeparator>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
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
                                <ext:Column ColumnID="colClinetID" DataIndex="ChannelName" Header="通道" Width="65"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colClientGroupName" DataIndex="ClientGroupName" Width="55"
                                    Header="下家组" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colAssignedUser" DataIndex="AssignedUser" Width="50" Header="分配"
                                    Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ClientName" Header="下家" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelID" DataIndex="ChannelClientCode" Header="指令" Sortable="true"
                                    Width="120">
                                </ext:Column>
                                <ext:Column ColumnID="colUpSuccess" DataIndex="TotalCount" Header="点播数(条)" Sortable="true">
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
                                        <ext:ImageCommand Icon="TableEdit" CommandName="InterceptCountChange">
                                            <ToolTip Text="手动修改扣量" />
                                        </ext:ImageCommand>
                                        <ext:ImageCommand Icon="TableGo" CommandName="InterceptReset">
                                            <ToolTip Text="取消扣量并同步下家" />
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
                                        <ext:ImageCommand Icon="TableLightning" CommandName="ReSend">
                                            <ToolTip Text="重新发送所有数据" />
                                        </ext:ImageCommand>
                                        <ext:ImageCommand Icon="Table" CommandName="DownSycnCountDetail" Hidden="true">
                                            <ToolTip Text="显示所有明细数据" />
                                        </ext:ImageCommand>
                                    </Commands>
                                    <PrepareCommand Fn="prepareCellCommandTotalCount" Args="grid,command,record,row,col,value" />
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="InterceptRate" Header="实扣率" Width="50"
                                    Sortable="true">
                                    <Renderer Fn="decimalFormat" />
                                </ext:Column>
                                <ext:Column ColumnID="colInterceptRate" DataIndex="SetInterceptRate" Header="扣率"
                                    Sortable="true" Width="30">
                                    <Renderer Fn="showPerent" />
                                </ext:Column>
                                <ext:Column ColumnID="colPrice" DataIndex="Price" Header="价格" Sortable="true" Width="30">
                                    <Renderer Fn="decimalFormat1" />
                                </ext:Column>
                                <ext:Column ColumnID="colChannelClient" DataIndex="cmdEditChannelClient" Header="设置"
                                    Sortable="true" Width="30">
                                    <Commands>
                                        <ext:ImageCommand Icon="Cog" CommandName="cmdEditChannelClient">
                                            <ToolTip Text="设置" />
                                        </ext:ImageCommand>
                                    </Commands>
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
    <ext:Window ID="winReSendData" runat="server" Icon="TableGo" Title="重新发送数据" Frame="true"
        Width="640" ConstrainHeader="true" Height="220" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
    <ext:Window ID="winResetIntercept" runat="server" Icon="TableGo" Title="取消扣量同步下家"
        Frame="true" Width="640" ConstrainHeader="true" Height="320" Maximizable="true"
        Closable="true" Resizable="true" Modal="true" ShowOnLoad="false">
        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" TriggerEvent="show" ReloadOnEvent="true"
            ShowMask="true">
            <Params>
                <ext:Parameter Name="ClientChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
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
