<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallWizard.aspx.cs"
    Inherits="Legendigital.Common.WebApp.Installs.InstallWizard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Center">
        <Items>
            <ext:Panel ID="Panel4" runat="server" Header="false" AutoScroll="true" Frame="true"
                Layout="Center">
                <CustomConfig>
                    <ext:ConfigItem Name="width" Value="75%" Mode="Value" />
                </CustomConfig>
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Header="false" Layout="fit" Frame="true">
                        <Items>
                            <ext:Panel ID="WizardPanel" runat="server" Title="Install Wizard" Height="300" Frame="true"
                                Layout="card" ActiveIndex="0">
                                <Items>
                                    <ext:Panel ID="Panel1" runat="server" Title="Step 1 of 3 : Set System Setting " Frame="true"
                                        Layout="Form" LabelWidth="180">
                                        <Items>
                                            <ext:TextField ID="txtName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
                                            <ext:TextField ID="txtDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
                                            <ext:TextField ID="txtVersion" runat="server" FieldLabel="Version" AnchorHorizontal="95%" />
                                            <ext:TextField ID="txtCopyRight" runat="server" FieldLabel="Copy Right" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="Panel2" runat="server" Title="Step 2 of 3 : Set System Administrator password"
                                        Frame="true" Layout="Form" LabelWidth="180">
                                        <Items>
                                            <ext:TextField ID="txtDevAdminPassword" runat="server" FieldLabel="Dev Admin Password"
                                                AllowBlank="false" AnchorHorizontal="95%" />
                                            <ext:TextField ID="txtSysAdminPassword" runat="server" FieldLabel="Sys Admin Password"
                                                AllowBlank="false" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="Panel3" runat="server" Layout="Form" Title="Step 3 of 3 : Finished Setting"
                                        Frame="true" LabelWidth="180">
                                        <Items>
                                            <ext:ComboBox ID="cmbMenuLan" runat="server" Editable="false" TypeAhead="true" Mode="Local"
                                                SelectedIndex="0" ForceSelection="true" TriggerAction="All" SelectOnFocus="true"
                                                FieldLabel="Select Menu Langerage" AnchorHorizontal="95%">
                                                <Items>
                                                    <ext:ListItem Text="简体中文" Value="zh-cn" />
                                                    <ext:ListItem Text="English" Value="us-en" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Items>
                                        <Buttons>
                                            <ext:Button ID="btnFinished" runat="server" Text="Install" Icon="DiskEdit">
                                                <DirectEvents>
                                                    <Click OnEvent="btnFinished_Click" Success="Ext.MessageBox.alert('Operation successful', 'System Install Successful');"
                                                        Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                                                        <EventMask ShowMask="true" Msg="Installing....." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Buttons>
                                    </ext:Panel>
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
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
