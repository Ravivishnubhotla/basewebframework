<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPhotoImport.ascx.cs"
    Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.UCPhotoImport" %>
<ext:Store ID="storeImportFile" runat="server" OnRefreshData="storeImportFile_Refresh"
    AutoLoad="true">
    <Reader>
        <ext:JsonReader ReaderID="Id">
            <Fields>
                <ext:RecordField Name="ID" Type="Int" />
                <ext:RecordField Name="PhotoID" Type="Int" />
                <ext:RecordField Name="FileName" Type="String" />
                <ext:RecordField Name="FileExt" Type="String" />
                <ext:RecordField Name="FilePath" Type="String" />
                <ext:RecordField Name="FileSize" Type="Int" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Hidden ID="hidPhotoID" runat="server">
</ext:Hidden>
<ext:Window ID="winPhotoImport" runat="server" Icon="PackageGo" Title="导入数据" Width="400"
    Height="320" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout3" runat="server">
            <ext:GridPanel Frame="true" ID="GridPanelImportFile" runat="server" StoreID="storeImportFile"
                AutoExpandColumn="FileName">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:ToolbarButton ID='tbtnImport' runat="server" Text="导入" Icon="DatabaseGo">
                                <AjaxEvents>
                                    <Click OnEvent="tbtnImport_Click" Success="Ext.MessageBox.alert('操作成功', '成功的导入了数据。',callback);function callback(id) { #{storeImportFile}.reload();#{storePhotos}.reload(); };">
                                        <EventMask ShowMask="true" Msg="图片导入中，请稍候....." />
                                        <ExtraParams>
                                            <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanelImportFile}.getRowsValues())"
                                                Mode="Raw" />
                                        </ExtraParams>
                                    </Click>
                                </AjaxEvents>
                            </ext:ToolbarButton>
                            <ext:ToolbarButton ID='ToolbarButton2' runat="server" Text="刷新" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeImportFile}.reload();" />
                                </Listeners>
                            </ext:ToolbarButton>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel2" runat="server">
                    <Columns>
                        <ext:Column DataIndex="FileName" Header="文件名">
                        </ext:Column>
                        <ext:Column DataIndex="FileExt" Header="扩展名" Width="60px">
                        </ext:Column>
                        <ext:Column DataIndex="FileSize" Header="文件大小">
                            <Renderer Format="FileSize" />
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <SelectionModel>
                    <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server">
                    </ext:CheckboxSelectionModel>
                </SelectionModel>
            </ext:GridPanel>
        </ext:FitLayout>
    </Body>
</ext:Window>
