<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ExtJSConsole.Moudle.WebForm1" %>

<%@ Register Src="WebUserControl1.ascx" TagName="WebUserControl1" TagPrefix="uc1" %>
<%@ Register Src="WebUserControl2.ascx" TagName="WebUserControl2" TagPrefix="uc2" %>
<%@ Register src="WebUserControl3.ascx" tagname="WebUserControl3" tagprefix="uc3" %>
<%@ Register src="WebUserControl5.ascx" tagname="WebUserControl5" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
        .icon-exclamation {
            padding-left: 25px !important;
            background: url(/icons/exclamation-png/coolite.axd) no-repeat 3px 3px !important;
        }
        .icon-accept {
            padding-left: 25px !important;
            background: url(/icons/accept-png/coolite.axd) no-repeat 3px 3px !important;
        }
    </style>

</head>

<script type="text/javascript">
    //显示一个进度对话框
    function showProcessMsg() {
        Ext.MessageBox.show({
            msg: '正在保存数据, 请稍侯',
            progressText: '正在保存中',
            width: 300,
            wait: true,
            waitConfig: { interval: 200 },
            icon: 'ext-mb-save'
        });
    }
    function removeHandler() {
        //获取选中的行标识对象集合，和读取器中的id属性密切相关
        var selectedItems = GridPanel1.selModel.selections.keys;
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('提示', '请至少选择一条记录！');
        }
        else {
            Ext.MessageBox.confirm('提示', '确定要删除选中的记录么？', doRemove);
        }
    }

    //真正删除记录的处理函数，相当于C#中的委托实例
    function doRemove(dialogResult) {
        if (dialogResult == "yes") {
            Coolite.AjaxMethods.DeleteSelect();
        }
    } 
</script>

<body>
    <form id="form1" runat="server">
    <ext:ScriptManager ID="ScriptManager1" runat="server" />
    <uc4:WebUserControl5 ID="WebUserControl51" runat="server" />
    <uc3:WebUserControl3 ID="WebUserControl31" runat="server" />
    <uc2:WebUserControl2 ID="WebUserControl21" runat="server" />
    <uc1:WebUserControl1 ID="WebUserControl11" runat="server" />
    

    <ext:Store ID="Store1" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="Store1_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={3}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="xxx" Value="1">
            </ext:Parameter>
        </BaseParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="Store1" StripeRows="true"
        Title="系统应用列表" Icon="Table" AutoHeight="true" AutoExpandColumn="colSystemApplicationDescription">
        <TopBar>
            <ext:Toolbar ID="tbTop" runat="server">
                <Items>
                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="Add">
                        <Listeners>
                            <Click Handler="Coolite.AjaxMethods.NewRecord();" />
                        </Listeners>
                    </ext:ToolbarButton>
                    <ext:ToolbarButton ID='btnSearch' runat="server" Text="搜索" Icon="Find">
                        <Listeners>
                            <Click Handler="Coolite.AjaxMethods.ShowSearch();" />
                        </Listeners>
                    </ext:ToolbarButton>
                    <ext:ToolbarButton ID='btnDelete' runat="server" Text="删除" Icon="DatabaseDelete">
                        <Listeners>
                            <Click Handler="removeHandler();" />
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
                <ext:Column DataIndex="SystemApplicationID" Header="主键" Sortable="true">
                    <PrepareCommand Handler="" Args="grid,command,record,row,col,value" FormatHandler="False">
                    </PrepareCommand>
                </ext:Column>
                <ext:Column DataIndex="SystemApplicationName" Header="名称" Sortable="true">
                    <PrepareCommand Handler="" Args="grid,command,record,row,col,value" FormatHandler="False">
                    </PrepareCommand>
                </ext:Column>
                <ext:Column ColumnID="colSystemApplicationDescription" DataIndex="SystemApplicationDescription"
                    Header="描述">
                    <PrepareCommand Handler="" Args="grid,command,record,row,col,value" FormatHandler="False">
                    </PrepareCommand>
                </ext:Column>
                <ext:Column DataIndex="SystemApplicationUrl" Header="链接">
                    <PrepareCommand Handler="" Args="grid,command,record,row,col,value" FormatHandler="False">
                    </PrepareCommand>
                </ext:Column>
                <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="是否为系统应用" Sortable="true">
                    <PrepareCommand Handler="" Args="grid,command,record,row,col,value" FormatHandler="False">
                    </PrepareCommand>
                </ext:Column>
                <ext:CommandColumn Width="60">
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                            <ToolTip Text="Edit" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:CheckboxSelectionModel />
        </SelectionModel>
        <LoadMask ShowMask="true" />
        <BottomBar>
            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="12" StoreID="Store1"
                DisplayInfo="true" DisplayMsg="显示系统应用 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的系统应用" />
        </BottomBar>
        <Listeners>
            <Command Handler="Coolite.AjaxMethods.Processcmd(command, record.data.SystemApplicationID);" />
        </Listeners>
    </ext:GridPanel>
    </form>
</body>
</html>
