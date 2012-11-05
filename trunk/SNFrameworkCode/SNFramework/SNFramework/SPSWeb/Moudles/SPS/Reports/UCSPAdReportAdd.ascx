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



                <ext:ComboBox ID="cmbAd" runat="server" FieldLabel="���" StoreID="storeAd"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="ѡ����"
                    AllowBlank="false">
                    <Listeners>
                        <Select Handler="#{cmbAdPack}.clearValue(); #{storeAdPack}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbAdPack" runat="server" FieldLabel="����" StoreID="storeAdPack" AnchorHorizontal="95%"
                    ItemSelector="div.list-item" TypeAhead="true" Editable="false" DisplayField="Name"
                    ValueField="Id" EmptyText="ѡ�����" AllowBlank="false">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						<div class="list-item">
							 <h3>{Name}</h3>
 						<tpl if="AssignedClientName == ''">
							<font color="green">δ����</font>
						</tpl>
  						<tpl if="AssignedClientName != ''">
							 �ѷ��� {AssignedClientName}
						</tpl>
 
						</div>
					</tpl>
                        </Html>
                    </Template>
                </ext:ComboBox>

                <ext:ComboBox ID="cmbClient" runat="server" FieldLabel="�ͻ�" StoreID="storeClient"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="ѡ��ͻ�"
                    AllowBlank="false">
                </ext:ComboBox>

                <ext:DateField ID="dateReportDate" runat="server" FieldLabel="��������" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdCount" runat="server" FieldLabel="�ϼҶ�����" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numClientCount" runat="server" FieldLabel="�¼Ҷ�����" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdUseCount" runat="server" FieldLabel="�ϼҴ���" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientUseCount" runat="server" FieldLabel="�¼Ҵ���" AllowBlank="false" AnchorHorizontal="95%" />


                <ext:NumberField ID="numAdDownCount" runat="server" FieldLabel="�ϼҼ�����" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientDownCount" runat="server" FieldLabel="�¼Ҽ�����" AllowBlank="false" AnchorHorizontal="95%" />

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdReport" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdReportAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdReport_Click"
                    Success="Ext.MessageBox.alert('�����ɹ�', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdReportAdd}.getForm().reset();#{storeSPAdReport}.reload(); };
"
                    Failure="Ext.Msg.alert('����ʧ��', result.errorMessage);">
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


