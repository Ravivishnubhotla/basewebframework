<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportDataChange.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.ReportDataChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannel}.reload();" />
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
            <Load Handler="if(#{storeSPChannel}.data.items.length>0) {#{cmbChannelID}.setValue(#{storeSPChannel}.data.items[0].data.Id); #{cmbChannelID}.fireEvent('select'); 
            };" />
        </Listeners>
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
                    <ext:Panel ID="ReportPanel" runat="server" Title="通道指令流量变化趋势报表" Icon="Table">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="通道:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="false" StoreID="storeSPChannel"
                                        TypeAhead="true" Mode="Local" Editable="false" DisplayField="Name" ValueField="Id">
                                        <Listeners>
                                            <Select Handler="#{cmbCode}.clearValue();#{storeSPChannelClientSetting}.reload();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="指令:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbCode" runat="server" AllowBlank="false" StoreID="storeSPChannelClientSetting"
                                        TypeAhead="true" Mode="Local" Editable="false" DisplayField="Name" ValueField="Id"
                                        ItemSelector="div.list-item">
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
