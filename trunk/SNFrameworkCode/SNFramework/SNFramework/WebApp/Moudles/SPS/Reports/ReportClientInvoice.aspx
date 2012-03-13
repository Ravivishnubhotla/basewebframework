<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportClientInvoice.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportClientInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true" OnRefreshData="storeSPClient_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="true" />
        </DirectEventConfig>
    </ext:Store>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="ReportPanel" runat="server" Title="通道指令流量变化趋势报表" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:DateField ID="dfStart" runat="server" FieldLabel="开始时间" LabelWidth="60" Width="150">
                            </ext:DateField>
                            <ext:DateField ID="dfEnd" runat="server" FieldLabel="结束时间" LabelWidth="60" Width="150">
                            </ext:DateField>
                            <ext:ComboBox ID="cmbClient" runat="server" FieldLabel="选择客户" LabelWidth="60" Width="180"
                                StoreID="storeSPClient" Editable="false" DisplayField="Name" ValueField="Id"
                                EmptyText="选择客户">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();#{cmbCode}.clearValue(); #{storeSPCode}.reload();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
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
                            <ext:Button ID='btnQuery' runat="server" Text="搜索" Icon="Find">
                                <DirectEvents>
                                    <Click OnEvent="btnQuery_Click" />
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <AutoLoad Url="Blank.htm" Mode="IFrame" NoCache="true" ShowMask="true" />
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
