<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigGroupAdd.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.ConfigManage.UCSystemConfigGroupAdd" %>
<ext:Window ID="winSystemConfigGroupAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigGroupAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="<%$ Resources:msgFiledName %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="<%$ Resources:msgFiledCode %>" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="<%$ Resources:msgFiledDescription %>" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="<%$ Resources:msgFiledIsEnable %>" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsSystem" runat="server" FieldLabel="<%$ Resources:msgFiledIsSystem %>" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemConfigGroup" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemConfigGroupAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemConfigGroup_Click" Success="<%$ Resources:msgAddScript %>"
                     Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemConfigGroup" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemConfigGroupAdd}.getForm().reset();#{winSystemConfigGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
