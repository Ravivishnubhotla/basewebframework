

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdPackAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Clients.UCSPAdPackAdd" %>

<script type="text/javascript">
    function AllowChange() {
        return true;
    }


</script>
 
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
<ext:Window ID="winSPAdPackAdd" runat="server" Icon="ApplicationAdd" Title="����ָ��"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdPackAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
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
                               <ext:NumberField ID="numClientPrice" runat="server" FieldLabel="����۸�" AllowBlank="false" AllowDecimals="True" DecimalPrecision="2" AnchorHorizontal="95%" />

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdPack" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdPackAdd}.getForm().isValid() && AllowChange()) return false;" OnEvent="btnSaveSPAdPack_Click"
                    Success="Ext.MessageBox.alert('�����ɹ�', '��������ɹ�' ,callback);function callback(id) {#{formPanelSPAdPackAdd}.getForm().reset();#{storeSPAdPack}.reload(); };
" Failure="Ext.Msg.alert('����ʧ��', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdPack" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdPackAdd}.getForm().reset();#{winSPAdPackAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        
        <BeforeShow Handler=" #{storeAd}.reload();"></BeforeShow>
    </Listeners>
</ext:Window>
 

