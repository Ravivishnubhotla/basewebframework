<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataImportPage.aspx.cs" Inherits="SNFramework.BSF.Moudles.DataImports.DataImportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showPanel(panType) {
            var frmExcel = <%= frmExcel.ClientID %>;
            var frmAccess = <%= frmAccess.ClientID %>;
            var frmFlatFile = <%= frmFlatFile.ClientID %>;

            if (panType == "1") {
                frmExcel.show();
                frmAccess.hide();
                frmFlatFile.hide();
            }
            else if(panType == "2") {
                frmExcel.hide();
                frmAccess.show();
                frmFlatFile.hide();
            }
            else if(panType == "3") {
                frmExcel.hide();
                frmAccess.hide();
                frmFlatFile.show();
            }
        }   

 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="WizardPanel" runat="server" Title="数据导入向导" Frame="True" Layout="card"
                ActiveIndex="0">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Border="false" Header="True">
                        <Items>
                            <ext:BorderLayout ID="BorderLayout1" runat="server">
                                <North>
                                    <ext:Panel ID="Panel4" runat="server" Html="<h1>&nbsp;选择数据源</h1><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;选择需要从中复制数据的源</p><P>&nbsp;</p>"
                                        Frame="True" Header="False" />
                                </North>
                                <Center>
                                    <ext:FormPanel ID="Tab1" LabelWidth="55" runat="server" Frame="True" Header="False"
                                        Layout="form">
                                        <Items>
                                            <ext:ComboBox ID="cmbDataSourceTye" FieldLabel="数据源" Editable="False" runat="server"
                                                AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:ListItem Text="Microsoft Excel" Value="1" />
                                                    <ext:ListItem Text="平面文件源" Value="3" />
                                                    <ext:ListItem Text="Microsoft Access" Value="2" />
                                                </Items>
                                                <Listeners>
                                                    <Select Handler="showPanel(#{cmbDataSourceTye}.getValue());"></Select>
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:FormPanel ID="frmExcel" runat="server" HideLabel="True" Frame="True" Header="False"
                                                Hidden="True" Layout="form" AnchorHorizontal="100%" AnchorVertical="-53">
                                                <Items>
                                                    <ext:FieldSet ID="FieldSet1"  LabelAlign="Top" runat="server" CheckboxToggle="false" Title="Excel 连接设置"
                                                        Collapsed="false" Layout="Form">
                                                        <Items>
                                                            <ext:FileUploadField ID="BasicField" FieldLabel="Excel 文件路径" runat="server"
                                                                ButtonText="浏览" Icon="Attach" AnchorHorizontal="98%" />
                                                            <ext:ComboBox ID="ComboBox1" FieldLabel="Excel 文件版本" Editable="False" runat="server"
                                                                AnchorHorizontal="100%">
                                                                <Items>
                                                                    <ext:ListItem Text="Excel 97-2003" Value="1" />
                                                                    <ext:ListItem Text="Excel 2007" Value="3" />
                                                                </Items>
                                                            </ext:ComboBox>
                                                            <ext:Checkbox ID="Checkbox4" HideLabel="True" BoxLabel="首行包含列名" runat="server" />
                                                        </Items>
                                                    </ext:FieldSet>
                                                </Items>
                                            </ext:FormPanel>
                                            <ext:FormPanel ID="frmAccess" runat="server" HideLabel="True" Frame="True" Header="False"
                                                Layout="form" AnchorHorizontal="100%" Hidden="True" AnchorVertical="-53">
                                                <Items>
                                                    <ext:Label ID="Label2" runat="server" Text="Microsoft Access" AnchorHorizontal="98%" />
                                                </Items>
                                            </ext:FormPanel>
                                            <ext:FormPanel ID="frmFlatFile" runat="server" HideLabel="True" Frame="True" Header="False"
                                                Layout="form" AnchorHorizontal="100%" Hidden="True" AnchorVertical="-53">
                                                <Items>
                                                    <ext:Label ID="Label3" runat="server" Text="平面文件源" AnchorHorizontal="98%" />
                                                </Items>
                                            </ext:FormPanel>
                                        </Items>
                                    </ext:FormPanel>
                                </Center>
                            </ext:BorderLayout>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" Html="<h1>Card 2</h1><p>Step 2 of 3</p>" Border="false"
                        Header="false" />
                    <ext:Panel ID="Panel3" runat="server" Html="<h1>Congratulations!</h1><p>Step 3 of 3 - Complete</p>"
                        Border="false" Header="false" />
                </Items>
                <Buttons>
                    <ext:Button ID="btnPrev" runat="server" Text="Prev" Disabled="true" Icon="PreviousGreen">
                        <DirectEvents>
                            <Click OnEvent="Prev_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)"
                                        Mode="Raw" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnNext" runat="server" Text="Next" Icon="NextGreen">
                        <DirectEvents>
                            <Click OnEvent="Next_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)"
                                        Mode="Raw" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
