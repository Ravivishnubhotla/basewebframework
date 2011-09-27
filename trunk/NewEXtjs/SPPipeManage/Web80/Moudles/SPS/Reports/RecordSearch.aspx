<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="RecordSearch.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.RecordSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannel}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="store1" runat="server" AutoLoad="false" RemoteSort="true" OnRefreshData="store1_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelName" />
                    <ext:RecordField Name="MobileNumber" />
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
        <BaseParams>
            <ext:Parameter Name="ChannelID" Value="#{cmbChannelID}.getValue()" Mode="Raw" />
            <ext:Parameter Name="ChannelClientID" Value="#{cmbCode}.getValue()" Mode="Raw" />
            <ext:Parameter Name="txtPhone" Value="#{txtPhone}.getValue()" Mode="Raw" />
        </BaseParams>
        <AjaxEventConfig Timeout="120000">
        </AjaxEventConfig>
    </ext:Store>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="storeSPChannelClientSetting" runat="server" AutoLoad="false" OnRefreshData="storeSPChannelClientSetting_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="ClientName" />
                    <ext:RecordField Name="ChannelClientCode" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="ChannelID" Value="#{cmbChannelID}.getValue()" Mode="Raw" />
        </BaseParams>
    </ext:Store>
    <style type="text/css">
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        
        .list-item h3
        {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:BorderLayout runat="server">
                <North CollapseMode="Default" Collapsible="true" Split="true">
                    <ext:FormPanel ID="pnlSeach" runat="server" Title="检索条件" AutoScroll="true" Height="300"
                        Frame="true">
                        <Body>
                            <ext:FormLayout ID="frmSearch" runat="server" LabelSeparator=":" LabelWidth="100">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbProvince" Editable="true" runat="server" AllowBlank="True" FieldLabel="省份"
                                            TriggerAction="All" Hidden="true">
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
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="true" StoreID="storeSPChannel"
                                            FieldLabel="通道" TypeAhead="true" Mode="Local" Editable="false" DisplayField="Name"
                                            ValueField="Id" TriggerAction="All">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();#{cmbCode}.clearValue();#{storeSPChannelClientSetting}.reload();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbCode" runat="server" AllowBlank="true" StoreID="storeSPChannelClientSetting"
                                            FieldLabel="指令" TypeAhead="true" Mode="Local" Editable="false" DisplayField="Name"
                                            ValueField="Id" ItemSelector="div.list-item" TriggerAction="All">
                                            <Template ID="Template2" runat="server">
                <Html>
					<tpl for=".">
						<div class="list-item">
							 <h3>{ClientName}</h3>
							 {ChannelClientCode}
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
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:TextArea ID="txtPhone" runat="server" FieldLabel="手机号码" Height="170">
                                        </ext:TextArea>
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnSearch" runat="server" Text="搜索" Icon="Find">
                                <Listeners>
                                    <Click Handler="#{store1}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnReset" runat="server" Text="重置" Icon="Cancel">
                                <Listeners>
                                    <Click Handler="#{pnlSeach}.getForm().reset();#{store1}.removeAll()" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button1" runat="server" Text="导出查询结果" Icon="PageExcel" AutoPostBack="true"
                                OnClick="ToExcel">
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </North>
                <Center>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="检索结果" Icon="Table" AutoExpandColumn="colRequestContent"
                        AutoScroll="true" AutoWidth="true">
                        <View>
                            <ext:GridView ID="GridView1">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colReportDate" DataIndex="MobileNumber" Header="手机号" Sortable="true">
                                </ext:Column>
                                <ext:Column ColumnID="colChannelName" DataIndex="ChannelName" Header="通道名" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colCode" DataIndex="Code" Header="指令" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colClientName" DataIndex="ClientName" Header="下家名" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Linkid" Header="LinkID" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Province" Header="省份" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colYwid" DataIndex="Ywid" Header="上行内容" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colCpid" DataIndex="Cpid" Header="长号码" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="日期" Sortable="true">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="30" StoreID="store1"
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
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
