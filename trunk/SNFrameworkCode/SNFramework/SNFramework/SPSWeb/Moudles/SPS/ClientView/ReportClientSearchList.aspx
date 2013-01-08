<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReportClientSearchList.aspx.cs" Inherits="SPSWeb.Moudles.SPS.ClientView.ReportClientSearchList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPCode}.reload(); "></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPCode" runat="server" AutoLoad="false" OnRefreshData="storeSPCode_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="MoCode" />
                    <ext:RecordField Name="AssignedClientName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="true" />
        </DirectEventConfig>
    </ext:Store>
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="false" RemoteSort="true" OnRefreshData="storeData_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="50" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="LinkID" />
                    <ext:RecordField Name="Mobile" />
                    <ext:RecordField Name="Mo" />
                    <ext:RecordField Name="SpNumber" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="City" />
                    <ext:RecordField Name="OperatorType" />
                    <ext:RecordField Name="IsSycnSuccessed" Type="Boolean" />
                    <ext:RecordField Name="SycnRetryTimes" Type="Int" />
                    <ext:RecordField Name="SycnDataUrl" />
                    <ext:RecordField Name="SycnReturnMessage" />
                    <ext:RecordField Name="Count" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="Count" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">


        var FormatBool = function (value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var FormatStat = function (value) {
            if (value)
                return '成功';
            else
                return '失败';
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Split="true" Collapsible="true">
                    <ext:Panel ID="SouthPanel" runat="server" Frame="True" Title="搜索条件" Height="130"
                        Layout="form">
                        <Items>
                            <ext:FormPanel ID="pnlsearch1" runat="server" Layout="HBoxLayout" AnchorHorizontal="95%">
                                <Defaults>
                                    <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                                </Defaults>
                                <LayoutConfig>
                                    <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Start" />
                                </LayoutConfig>
                                <Items>
                                    <ext:ComboBox ID="cmbCode" runat="server" FieldLabel="选择代码" LabelWidth="60" Width="260"
                                        StoreID="storeSPCode" AnchorHorizontal="95%" ItemSelector="div.list-item" TypeAhead="true"
                                        Editable="false" DisplayField="MoCode" ValueField="Id" EmptyText="选择代码">
                                        <Template ID="Template2" runat="server">
                                            <Html>
                                                <tpl for=".">
						<div class="list-item">
							 <h3>{MoCode}</h3>
 						<tpl if="AssignedClientName == ''">
							<font color="green">未分配</font>
						</tpl>
  						<tpl if="AssignedClientName != ''">
							 已分配 {AssignedClientName}
						</tpl>
 
						</div>
					</tpl>
                                            </Html>
                                        </Template>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbSycnStatus" Editable="false" runat="server" FieldLabel="同步"
                                        LabelWidth="40" Width="120" TriggerAction="All">
                                        <Items>
                                            <ext:ListItem Value="1" Text="成功"></ext:ListItem>
                                            <ext:ListItem Value="0" Text="失败"></ext:ListItem>
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
                                </Items>
                            </ext:FormPanel>
                            <ext:FormPanel ID="pnlsearch2" runat="server" Layout="HBoxLayout" AnchorHorizontal="95%">
                                <Defaults>
                                    <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                                </Defaults>
                                <LayoutConfig>
                                    <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Start" />
                                </LayoutConfig>
                                <Items>
                                    <ext:TextField ID="txtPhoneNumber" runat="server" FieldLabel="手机号" LabelWidth="60"
                                        Width="180" />
                                    <ext:TextField ID="txtSpNumber" runat="server" FieldLabel="端口号" LabelWidth="60" Width="180" />
                                    <ext:ComboBox ID="cmbProvince" Editable="false" runat="server" FieldLabel="省  份"
                                        LabelWidth="50" Width="130" TriggerAction="All">
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
                                </Items>
                            </ext:FormPanel>
                            <ext:FormPanel ID="pnlsearch3" runat="server" Layout="HBoxLayout" AnchorHorizontal="95%">
                                <Defaults>
                                    <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                                </Defaults>
                                <LayoutConfig>
                                    <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Start" />
                                </LayoutConfig>
                                <Items>
                                    <ext:TextField ID="txtMo" runat="server" FieldLabel="指令" LabelWidth="60" Width="180" />
                                    <ext:TextField ID="txtLinkID" runat="server" FieldLabel="LinkID" LabelWidth="60"
                                        Width="180" />
                                    <ext:ComboBox ID="cmbOperateType" Editable="false" runat="server" FieldLabel="运营商"
                                        LabelWidth="40" Width="120" TriggerAction="All">
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
                                    <ext:DateField ID="dfStart" runat="server" FieldLabel="开始时间" LabelWidth="60" Width="150">
                                    </ext:DateField>
                                    <ext:DateField ID="dfEnd" runat="server" FieldLabel="结束时间" LabelWidth="60" Width="150">
                                    </ext:DateField>
                                    <ext:Button ID='btnReset' runat="server" Text="重置" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{pnlsearch1}.reset();#{pnlsearch2}.reset();#{pnlsearch3}.reset();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID='btnFind' runat="server" Text="搜索" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeData}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:FormPanel>
                        </Items>
                    </ext:Panel>
                </North>
                <Center>
                    <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                        StoreID="storeData" AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeData}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{GridPanel1}.submitData(false);" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="接收时间" Sortable="true"
                                    Width="120">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y h:i:s')" />
                                </ext:Column>
                                <ext:Column ColumnID="colLinkID" DataIndex="LinkID" Header="唯一标识" Sortable="true"
                                    Width="130">
                                </ext:Column>
                                <ext:Column ColumnID="colMobile" DataIndex="Mobile" Header="手机号码" Sortable="true"
                                    Width="80">
                                </ext:Column>
                                <ext:Column ColumnID="colMo" DataIndex="Mo" Header="上行指令" Sortable="true" Width="90">
                                </ext:Column>
                                <ext:Column ColumnID="colSpNumber" DataIndex="SpNumber" Header="通道号码" Sortable="true"
                                    Width="95">
                                </ext:Column>
                                <ext:Column ColumnID="colProvince" DataIndex="Province" Header="省份" Sortable="true"
                                    Width="35">
                                </ext:Column>
                                <ext:Column ColumnID="colCity" DataIndex="City" Header="地市" Sortable="true" Width="35">
                                </ext:Column>
                                <ext:Column ColumnID="colOperatorType" DataIndex="OperatorType" Header="运营商" Sortable="true"
                                    Width="50">
                                </ext:Column>
                                <ext:Column ColumnID="colIsSycnSuccessed" DataIndex="IsSycnSuccessed" Header="同步状态"
                                    Sortable="true" Width="60">
                                    <Renderer Fn="FormatBool" />
                                </ext:Column>
                                <ext:Column ColumnID="colSycnRetryTimes" DataIndex="SycnRetryTimes" Header="重试" Sortable="true"
                                    Width="35">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <View>
                            <ext:GridView ID="GridView1" runat="server" />
                        </View>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                        </SelectionModel>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server">
                                <Template ID="Template1" runat="server">
                                    <Html>
                                        <p>
                                    <b>同步地址:</b> {SycnDataUrl}
                                <br/><b>失败消息:</b> {SycnReturnMessage}</p>
                                    </Html>
                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="50" DisplayInfo="true"
                                StoreID="storeData" DisplayMsg="显示记录 {0} - {1} 共: {2}" EmptyMsg="没有记录" />
                        </BottomBar>
                    </ext:GridPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
