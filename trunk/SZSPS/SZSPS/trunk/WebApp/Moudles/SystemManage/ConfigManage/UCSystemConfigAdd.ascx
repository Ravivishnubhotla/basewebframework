<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemConfigAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage.UCSystemConfigAdd" %>


<ext:Window ID="winSystemConfigAdd" runat="server" Icon="ApplicationAdd" Title="AddSystemConfig"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemConfigAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtConfigKey" runat="server" FieldLabel="ConfigKey" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtConfigValue" runat="server" FieldLabel="ConfigValue" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtConfigDescription" runat="server" FieldLabel="ConfigDescription" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSortIndex" runat="server" FieldLabel="SortIndex" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemConfig" runat="server" Text="Add" Icon="Add">

        </ext:Button>
        <ext:Button ID="btnCancelSystemConfig" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemConfigAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>