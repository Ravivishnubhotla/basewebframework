<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDataOperator.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportDataOperator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <%--            <DocumentReady Handler="#{storeSPChannel}.reload();" />--%>
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <%--            <Load Handler="if(#{storeSPChannel}.data.items.length>0) {#{cmbChannelID}.setValue(#{storeSPChannel}.data.items[0].data.Id); #{cmbChannelID}.fireEvent('select'); 
            };" />--%>
        </Listeners>
        <AjaxEventConfig Timeout="120000">
            <EventMask ShowMask="true"></EventMask>
        </AjaxEventConfig>
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
        <Listeners>
            <Load Handler="if(#{storeSPChannelClientSetting}.data.items.length>0) {#{cmbCode}.setValue(#{cmbCode}.store.getAt(0).get('Id'));}" />
        </Listeners>
        <AjaxEventConfig Timeout="120000">
            <EventMask ShowMask="true"></EventMask>
        </AjaxEventConfig>
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
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:Panel ID="ReportPanel" runat="server" Title="通道指令省份分布报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text=" ">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfReportEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="运营商:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbOperator" Width="70" Editable="true" runat="server" AllowBlank="True" TriggerAction="All">
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
                                    <ext:ToolbarTextItem Text="省份:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbProvince"  Width="80" Editable="true" runat="server" AllowBlank="True" TriggerAction="All">
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
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbChannelID"  Width="80" runat="server" AllowBlank="true" StoreID="storeSPChannel"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" Editable="false" DisplayField="Name"
                                        ValueField="Id">
                                        <Listeners>
                                            <Select Handler="#{cmbCode}.clearValue();#{storeSPChannelClientSetting}.reload();this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{cmbCode}.clearValue(); #{cmbCode}.triggers[0].hide(); }" />
                                        </Listeners>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="指令:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbCode"  Width="110" runat="server" AllowBlank="true" StoreID="storeSPChannelClientSetting"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" Editable="false" DisplayField="Name"
                                        ValueField="Id" ItemSelector="div.list-item">
                                        <Template ID="Template1" runat="server">
                <Html>
					<tpl for=".">
						<div class="list-item">
							 <h3>{ClientName}</h3>
							 {ChannelClientCode}
						</div>
					</tpl>
				</Html>
                                        </Template>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                    </ext:ComboBox>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <AjaxEvents>
                                            <Click OnEvent="btnRefresh_Click" />
                                        </AjaxEvents>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" ShowMask="true" />
                    </ext:Panel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
