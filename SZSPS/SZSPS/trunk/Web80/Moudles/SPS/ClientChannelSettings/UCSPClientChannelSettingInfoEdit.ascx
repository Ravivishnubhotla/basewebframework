<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingInfoEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingInfoEdit" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
<script type="text/javascript">
    function CheckDayMonthLimit(checkValue) {
        var txtDayLimit = <%= txtDayLimit.ClientID %>;
        var txtMonthLimit = <%= txtMonthLimit.ClientID %>;
        if (!checkValue) {
            txtDayLimit.hide();
            txtMonthLimit.hide();
        }
        else {
            txtDayLimit.show();
            txtMonthLimit.show();
        }
    }
    function CheckDayTotalLimit(checkValue) {
        var txtDayTotalLimit = <%= txtDayTotalLimit.ClientID %>;
        var chkDayTotalLimitInProvince = <%= chkDayTotalLimitInProvince.ClientID %>;
        if (!checkValue) {
            txtDayTotalLimit.hide();
            chkDayTotalLimitInProvince.hide();
        }
        else {
            txtDayTotalLimit.show();
            chkDayTotalLimitInProvince.show();
        }
    }
    

    function CheckDayTotalLimitInProvince(checkValue) {
        var grdAreaCountList = <%= grdAreaCountList.ClientID %>;
 
                if (!checkValue) {
                    grdAreaCountList.hide();
                }
                else {
                    grdAreaCountList.show();
                }
            }

            function setAreaCountList() {
                var grdAreaCountList = <%= grdAreaCountList.ClientID %>;
            
            var hidAreaCountList = <%= hidAreaCountList.ClientID %>;

            hidAreaCountList.setValue(Ext.encode(grdAreaCountList.getRowsValues(false)));
            
            //            alert(grdAreaCountList.getRowsValues(false));
            //            alert(Ext.encode(grdAreaCountList.getRowsValues(false)));
        }


        function addArea() {
            var storeResults = <%= storeAreaCountList.ClientID %>;
            var DirectionItem = Ext.data.Record.create(
                [
                    { name: "AreaName", type: "string" },
                    { name: "LimitCount", type: "int" }
                ]);
            var record = new DirectionItem(
                    {
                        AreaName: "",
                        LimitCount: 0
                    });
                
            storeResults.add(record); 
            storeResults.commitChanges(); 
    
        }
    
        function processcmd1(command, record) {
            //alert(command);
            if(command=="cmdDelete") {
                var storeResults = <%= storeAreaCountList.ClientID %>;
            storeResults.remove(record);
        }
    }
</script>

<ext:Store ID="storeAreaCountList" runat="server" AutoLoad="true" OnRefreshData="storeAreaCountList_Refresh">
    <Reader>
        <ext:JsonReader>
            <Fields>
                <ext:RecordField Name="AreaName" />
                <ext:RecordField Name="LimitCount" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>

<ext:Window ID="winSPClientChannelSettingInfoEdit" runat="server" Icon="ApplicationEdit"
    ConstrainHeader="true" Title="设置指令" Width="640" Height="399" AutoShow="false"
    Maximizable="true" Modal="true" ShowOnLoad="false" AutoScroll="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingAdd" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
                <Body>
                    <ext:FormLayout ID="FormLayout4" runat="server">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblName" runat="server" FieldLabel="名称" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelName" runat="server" FieldLabel="通道">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientName" runat="server" FieldLabel="下家">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblClientGroupName" runat="server" FieldLabel="下家组">
                                </ext:Label>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Label ID="lblChannelClientCode" runat="server" FieldLabel="指令" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkHasDayMonthLimit" runat="server" FieldLabel="日月号码限量">
                                    <Listeners>
                                        <Check Handler="CheckDayMonthLimit(#{chkHasDayMonthLimit}.getValue());"></Check>
                                    </Listeners>
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtDayLimit" MinValue="0" DecimalPrecision="0" runat="server"
                                    FieldLabel="日限制" Hidden="True" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtMonthLimit" MinValue="0" DecimalPrecision="0" runat="server"
                                    FieldLabel="月限制" Hidden="True" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkHasDayTotalLimit" runat="server" FieldLabel="日总限量">
                                    <Listeners>
                                        <Check Handler="CheckDayTotalLimit(#{chkHasDayTotalLimit}.getValue());"></Check>
                                    </Listeners>
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtDayTotalLimit" MinValue="0" DecimalPrecision="0" runat="server"
                                    FieldLabel="日总限量" Hidden="True" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkDayTotalLimitInProvince" runat="server" FieldLabel="是否分省" Hidden="True">
                                    <Listeners>
                                        <Check Handler="CheckDayTotalLimitInProvince(#{chkDayTotalLimitInProvince}.getValue());"></Check>
                                    </Listeners>
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidAreaCountList" runat="server" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:GridPanel FieldLabel="省份分布" ID="grdAreaCountList" runat="server" StoreID="storeAreaCountList"
                                    StripeRows="true" Header="False" Height="180" Frame="True">
                                    <TopBar>
                                        <ext:Toolbar ID="tbTop" runat="server">
                                            <Items>
                                                <ext:ToolbarButton ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                                    <Listeners>
                                                        <Click Handler="addArea();alert(#{grdAreaCountList}.getRowsValues());alert(#{grdAreaCountList}.getRowsValues({visibleOnly:true}));" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                                    <Listeners>
                                                        <Click Handler="#{storeAreaCountList}.reload();" />
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
                                            <ext:Column ColumnID="colAreaName" DataIndex="AreaName" Header="省份" Sortable="true">
                                                <Editor>
                                                    <ext:ComboBox ID="ComboBox1" runat="server" Editable="true" runat="server" FieldLabel="过滤省份"
                                                        AllowBlank="false" TriggerAction="All">
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
                                                            <ext:ListItem Value="其他" Text="其他"></ext:ListItem>
                                                            <ext:ListItem Value="" Text=""></ext:ListItem>
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
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column ColumnID="colLimitCount" DataIndex="LimitCount" Header="限量" Sortable="true">
                                                <Editor>
                                                    <ext:NumberField ID="NumberField1" runat="server">
                                                    </ext:NumberField>
                                                </Editor>
                                            </ext:Column>
                                            <ext:CommandColumn Header="管理" Width="160">
                                                <Commands>
                                                    <ext:GridCommand Icon="ApplicationDelete" CommandName="cmdDelete">
                                                        <ToolTip Text="删除" />
                                                    </ext:GridCommand>
                                                </Commands>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <LoadMask ShowMask="true" />
                                    <Listeners>
                                        <Command Handler="processcmd1( command, record);" />
                                    </Listeners>
                                </ext:GridPanel>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChannelSetting" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="setAreaCountList();if(!#{formPanelSPClientChannelSettingAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientChannelSetting_Click" Success="Ext.MessageBox.alert('操作成功', '成功的编辑了指令设置。',RefreshSPClientChannelSettingData);
"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChannelSetting" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingInfoEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
        <Listeners>
        <BeforeShow Handler="CheckDayTotalLimitInProvince(#{chkDayTotalLimitInProvince}.getValue());">
        </BeforeShow>
    </Listeners>
</ext:Window>
