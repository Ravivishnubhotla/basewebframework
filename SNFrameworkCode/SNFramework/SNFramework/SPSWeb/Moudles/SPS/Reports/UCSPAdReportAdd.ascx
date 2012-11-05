<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdReportAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Reports.UCSPAdReportAdd" %>
<ext:Store ID="storeAd" runat="server" AutoLoad="true"
    OnRefreshData="storeAd_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Store ID="storeClient" runat="server" AutoLoad="true"
    OnRefreshData="storeClient_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>


<ext:Store ID="storeAdPack" runat="server" AutoLoad="true"
    OnRefreshData="storeAdPack_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
                <ext:RecordField Name="AssignedClientName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Window ID="winSPAdReportAdd" runat="server" Icon="ApplicationAdd" Title="SPAdReport Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdReportAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>



                <ext:ComboBox ID="cmbAd" runat="server" FieldLabel="广告" StoreID="storeAd"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择广告"
                    AllowBlank="false">
                    <Listeners>
                        <Select Handler="#{cmbAdPack}.clearValue(); #{storeAdPack}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbAdPack" runat="server" FieldLabel="广告包" StoreID="storeAdPack" AnchorHorizontal="95%"
                    ItemSelector="div.list-item" TypeAhead="true" Editable="false" DisplayField="Name"
                    ValueField="Id" EmptyText="选择广告包" AllowBlank="false">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						<div class="list-item">
							 <h3>{Name}</h3>
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
                </ext:ComboBox>

                <ext:ComboBox ID="cmbClient" runat="server" FieldLabel="客户" StoreID="storeClient"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择客户"
                    AllowBlank="false">
                </ext:ComboBox>

                <ext:DateField ID="dateReportDate" runat="server" FieldLabel="报表日期" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdCount" runat="server" FieldLabel="上家订阅数" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numClientCount" runat="server" FieldLabel="下家订阅数" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdUseCount" runat="server" FieldLabel="上家打开数" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientUseCount" runat="server" FieldLabel="下家打开数" AllowBlank="false" AnchorHorizontal="95%" />


                <ext:NumberField ID="numAdDownCount" runat="server" FieldLabel="上家激活数" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientDownCount" runat="server" FieldLabel="下家激活数" AllowBlank="false" AnchorHorizontal="95%" />

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdReport" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdReportAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdReport_Click"
                    Success="Ext.MessageBox.alert('操作成功', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdReportAdd}.getForm().reset();#{storeSPAdReport}.reload(); };
"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdReport" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdReportAdd}.getForm().reset();#{winSPAdReportAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>

        <BeforeShow Handler="#{storeClient}.reload();#{storeAd}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>


