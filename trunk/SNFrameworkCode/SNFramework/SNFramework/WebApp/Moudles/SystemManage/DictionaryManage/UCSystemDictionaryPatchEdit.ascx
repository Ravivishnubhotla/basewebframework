﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryPatchEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryPatchEdit" %>
<ext:Store ID="storeFilterSystemDictionary" runat="server" AutoLoad="true" OnRefreshData="storeFilterSystemDictionary_OnRefreshData">
    <Reader>
        <ext:JsonReader IDProperty="SystemDictionaryID">
            <Fields>
                <ext:RecordField Name="SystemDictionaryID" Type="int" />
                <ext:RecordField Name="SystemDictionaryCategoryID" />
                <ext:RecordField Name="SystemDictionaryKey" />
                <ext:RecordField Name="SystemDictionaryValue" />
                <ext:RecordField Name="SystemDictionaryDesciption" />
                <ext:RecordField Name="SystemDictionaryOrder" Type="int" />
                <ext:RecordField Name="SystemDictionaryIsEnable" Type="Boolean" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<script type="text/javascript">
    function getDirValues(grid) {
        var records = grid.store.modified, values = [];
        for (var i = 0; i < records.length; i++) {
            var dataR = grid.store.prepareRecord(records[i].data, records[i], {});
            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }
        return values;
    }

</script>
<ext:Window ID="winSystemDictionaryPatchEdit" runat="server" Icon="ApplicationAdd"
    Title="<%$ Resources:msgFormTitle %>" Width="800" Height="600" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true" Resizable="true"
    Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryPatchEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" Layout="Form">
            <TopBar>
                <ext:Toolbar ID="tbTop" runat="server">
                    <Items>
                        <ext:Button ID='btnSave' runat="server" Text="<%$ Resources : GlobalResource, msgSave  %>"
                            Icon="ApplicationEdit">
                            <DirectEvents>
                                <Click OnEvent="SubmitSelection" Failure="<%$ Resources : GlobalResource, msgShowError  %>" Success="#{storeFilterSystemDictionary}.commitChanges();#{storeFilterSystemDictionary}.reload();#{storeSystemDictionary}.reload();"> 
                                    <ExtraParams>
                                        <ext:Parameter Name="Values" Value="Ext.encode(getDirValues(#{gridPanelSystemDictionary}))"
                                            Mode="Raw" />
                                    </ExtraParams>
                                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:ComboBox ID="cmbGroup" runat="server" StoreID="storeGroup" Editable="true" TypeAhead="true"
                    FieldLabel="<%$ Resources:msgFiledCategory %>" Mode="Local" TriggerAction="All"
                    DisplayField="Name" ValueField="Name" AllowBlank="True" ForceSelection="false"
                    AnchorHorizontal="98%">
                    <Listeners>
                        <Select Handler="#{storeFilterSystemDictionary}.reload();"></Select>
                    </Listeners>
                </ext:ComboBox>
                <ext:GridPanel ID="gridPanelSystemDictionary" runat="server" StoreID="storeFilterSystemDictionary" 
                    Frame="true" AnchorVertical="93%" StripeRows="true" Title="<%$ Resources:msgGridTitle %>"
                    Icon="Table" AnchorHorizontal="98%">
                    <View>
                        <ext:GridView ForceFit="true" ID="GridView1">
                            <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                        </ext:GridView>
                    </View>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ColumnID="colSystemDictionaryKey" DataIndex="SystemDictionaryKey" Header="<%$ Resources:msgcolKey %>"
                                Sortable="true">
                                <Editor>
                                    <ext:TextField ID="txtSystemDictionaryKey" runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colSystemDictionaryValue" DataIndex="SystemDictionaryValue"
                                Header="<%$ Resources:msgcolValue %>" Sortable="true">
                                <Editor>
                                    <ext:TextField ID="txtSystemDictionaryValue" runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colSystemDictionaryDesciption" DataIndex="SystemDictionaryDesciption"
                                Header="<%$ Resources:msgcolDesciption %>" Sortable="true">
                                <Editor>
                                    <ext:TextArea ID="txtSystemDictionaryDesciption" runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colSystemDictionaryOrder" DataIndex="SystemDictionaryOrder"
                                Header="<%$ Resources:msgcolOrder %>" Sortable="true">
                                <Editor>
                                    <ext:NumberField ID="txtSystemDictionaryOrder" runat="server" AllowBlank="false" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colSystemDictionaryIsEnable" DataIndex="SystemDictionaryIsEnable"
                                Header="<%$ Resources:msgcolIsEnable %>" Sortable="true">
                                <Renderer Fn="FormatBool" />
                                <Editor>
                                    <ext:Checkbox ID="chkSystemDictionaryIsSystem" runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryPatchEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeGroup}.reload();#{storeFilterSystemDictionary}.reload();" />
    </Listeners>
</ext:Window>
