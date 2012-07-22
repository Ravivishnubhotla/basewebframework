<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientGroupQuery.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientGroups.UCSPClientGroupQuery" %>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
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
    <AjaxEventConfig Timeout="120000">
        <EventMask ShowMask="true"></EventMask>
    </AjaxEventConfig>
</ext:Store>
<ext:Window ID="winSPClientGroupQuery" runat="server" Icon="ApplicationEdit" ConstrainHeader="true"
    Title="下家用户数查询" Width="640" Height="399" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false" AutoScroll="true">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelQuery" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
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
                                <ext:DateField FieldLabel="开始时间" ID="dfStart" runat="server" AllowBlank="False">
                                </ext:DateField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:DateField FieldLabel="结束时间" ID="dfEnd" runat="server" AllowBlank="False">
                                </ext:DateField>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbCode" runat="server" AllowBlank="true" StoreID="storeSPChannelClientSetting" Hidden="True"
                                    FieldLabel="选择指令" TypeAhead="true" Mode="Local" TriggerAction="All" Editable="false"
                                    DisplayField="Name" ValueField="Id" ItemSelector="div.list-item">
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
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMo" runat="server" FieldLabel="指令" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkIncludeSubCode" runat="server" FieldLabel="包含子指令">
                                </ext:Checkbox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtSpcode" runat="server" FieldLabel="通道号码" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbProvince" Editable="true" runat="server" FieldLabel="省份" BlankText="所有"
                                    AllowBlank="True" TriggerAction="All">
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
                                <ext:Label ID="lblResult" runat="server" FieldLabel="查询结果" AllowBlank="False" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSPClientGroupQuery" runat="server" Text="查询" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelQuery}.getForm().isValid()) return false;"
                    OnEvent="btnSPClientGroupQuery_Click" Failure="Ext.Msg.alert('查询失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据查询中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelwinSPClientChannelQuery" runat="server" Text="关闭" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelQuery}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeSPChannelClientSetting}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>
