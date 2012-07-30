<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemApplicationAdd" %>
<ext:Window ID="winSystemApplicationAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtSystemApplicationName" runat="server" DataIndex="SystemApplicationName" FieldLabel="<%$ Resources:msgFieldName %>" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationCode" runat="server"  DataIndex="SystemApplicationCode" FieldLabel="<%$ Resources:msgFieldCode %>" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription"  DataIndex="SystemApplicationDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" runat="server"  DataIndex="SystemApplicationUrl" FieldLabel="<%$ Resources:msgFieldUrl %>" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication"  DataIndex="SystemApplicationIsSystemApplication" runat="server" Checked="true"
                    FieldLabel="<%$ Resources:msgFieldIsSystem %>" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="<%$ Resources:msgAddScript %>" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                    <ExtraParams>
                        <ext:Parameter Name="frmValues" Value="Ext.encode(#{formPanelSystemApplicationAdd}.getForm().getFieldValues(false, 'dataIndex'))"
                            Mode="Raw">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
