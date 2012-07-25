<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemSettingEditor.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.SettingManage.SystemSettingEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="SetFieldTriggerShow(#{txtSystemName}, #{txtSystemName}.getValue());SetFieldTriggerShow(#{txtSystemDescription}, #{txtSystemDescription}.getValue());SetFieldTriggerShow(#{txtSystemLisence}, #{txtSystemLisence}.getValue());">
            </DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

            function ShowTextEdit(triggerField, index) {
            if(index==0) {
 

                var winEditor = <%= winSystemTerminologyEditor.ClientID %> ;
                
 
              winEditor.autoLoad.params.TerminologyCode = triggerField.getValue();
              winEditor.setTitle(String.format('<%= GetGlobalResourceObject("GlobalResource","msgTitleEditLangItem").ToString() %>',triggerField.getValue()));
              winEditor.show();   
            }
        }

        function SetFieldTriggerShow(triggerField, triggerText) {
            var tText = Ext.util.Format.lowercase(triggerText);

            tText = Ext.util.Format.trim(tText);

            if(tText!='')
                tText = Ext.util.Format.substr(tText, 0, 3);

            if (tText == "[l]") {
                triggerField.triggers[0].show();
            }
            else {
                triggerField.triggers[0].hide();
            }

        }
    </script>
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Icon="ServerWrench" Title="<%$ Resources:Panel1Title %>"
                Frame="true" Layout="Center">
                <Items>
                    <ext:Panel ID="Panel2" runat="server" Icon="ServerWrench" Title="<%$ Resources:Panel2Title %>"
                        Width="500" Frame="true" AutoHeight="true">
                        <Content>
                            <ext:FormPanel ID="formPanelSystemSettingEdit" runat="server" Frame="true" Header="false"
                                MonitorValid="true" Layout="form" LabelSeparator=":" LabelWidth="100">
                                <Items>
                                    <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                                    </ext:Hidden>
                                    <ext:TriggerField ID="txtSystemName" runat="server" FieldLabel="<%$ Resources:txtSystemNameFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="SimpleEdit" />
                                        </Triggers>
                                        <Listeners>
                                            <Change Handler="SetFieldTriggerShow(this,newValue);"></Change>
                                            <TriggerClick Handler="ShowTextEdit(this,index);"></TriggerClick>
                                        </Listeners>
                                    </ext:TriggerField>
                                    <ext:TriggerField ID="txtSystemDescription" runat="server" FieldLabel="<%$ Resources:txtSystemDescriptionFieldLabel %>"
                                        AllowBlank="True" AnchorHorizontal="95%">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="SimpleEdit" />
                                        </Triggers>
                                        <Listeners>
                                            <Change Handler="SetFieldTriggerShow(this,newValue);"></Change>
                                            <TriggerClick Handler="ShowTextEdit(this,index);"></TriggerClick>
                                        </Listeners>
                                    </ext:TriggerField>
                                    <ext:TextField ID="txtSystemUrl" runat="server" FieldLabel="<%$ Resources:txtSystemUrlFieldLabel %>"
                                        AllowBlank="True" AnchorHorizontal="95%" />
                                    <ext:TextField ID="txtSystemVersion" runat="server" FieldLabel="<%$ Resources:txtSystemVersionFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%" />
                                    <ext:TriggerField ID="txtSystemLisence" runat="server" FieldLabel="<%$ Resources:txtSystemLisenceFieldLabel %>"
                                        AllowBlank="False" AnchorHorizontal="95%">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="SimpleEdit" />
                                        </Triggers>
                                        <Listeners>
                                            <Change Handler="SetFieldTriggerShow(this,newValue);"></Change>
                                            <TriggerClick Handler="ShowTextEdit(this,index);"></TriggerClick>
                                        </Listeners>
                                    </ext:TriggerField>
                                </Items>
                            </ext:FormPanel>
                        </Content>
                        <Buttons>
                            <ext:Button ID="btnSaveSystemSetting" runat="server" Text="<%$ Resources:btnSaveSystemSettingText %>"
                                Icon="ApplicationEdit">
                                <DirectEvents>
                                    <Click Before="if(!#{formPanelSystemSettingEdit}.getForm().isValid()) return false;"
                                        OnEvent="btnSaveSystemSetting_Click" Success="<%$ Resources:SaveOkScript %>"
                                        Failure="<%$ Resources:SaveFailedScript %>">
                                        <EventMask ShowMask="true" Msg="<%$ Resources:btnSaveSystemSettingEventMaskMsg %>" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winSystemTerminologyEditor" runat="server" Title="Window" Frame="true"
        Width="700" ConstrainHeader="true" Height="500" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="../TerminologyManage/SystemTerminologyListPage.aspx" Mode="IFrame"
            NoCache="true" TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="TerminologyCode" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
