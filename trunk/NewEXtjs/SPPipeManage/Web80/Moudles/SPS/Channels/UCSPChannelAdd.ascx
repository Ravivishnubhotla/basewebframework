<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelAdd.ascx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.UCSPChannelAdd" %>
<ext:Window ID="winSPChannelAdd" runat="server" Icon="ApplicationAdd" Title="新建通道"
    Width="500" Height="418" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPChannelAdd" runat="server" Frame="true" Header="false" MonitorValid="true"
                BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPChannel" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True"   />
             </ext:Anchor> 
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"   />
                    </ext:Anchor>
					<ext:Anchor Horizontal="95%">
						<ext:TextArea ID="txtArea" runat="server" FieldLabel="支持省份" AllowBlank="True"   />
                    </ext:Anchor>

			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtChannelCode" runat="server" FieldLabel="通道编码" AllowBlank="True"   />
             </ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtFuzzyCommand" runat="server" FieldLabel="提交别名" AllowBlank="True"   />
             </ext:Anchor> 

				 <ext:Anchor Horizontal="95%"> 
						<ext:NumberField ID="txtPort" runat="server" FieldLabel="端口"  AllowBlank="True"  />
                 	</ext:Anchor> 
			 <ext:Anchor Horizontal="95%">
						<ext:TextField ID="txtChannelType" runat="server" FieldLabel="通道类型" AllowBlank="True"   />
             </ext:Anchor> 
				 <ext:Anchor Horizontal="95%"> 
						<ext:NumberField ID="txtPrice" runat="server" FieldLabel="单价"  AllowBlank="True"  />
                 	</ext:Anchor> 
				 <ext:Anchor Horizontal="95%"> 
						<ext:NumberField ID="txtRate" runat="server" FieldLabel="分成比例"  AllowBlank="True"  />
                 	</ext:Anchor> 

                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPChannelAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannel_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了通道。',callback);function callback(id) {#{formPanelSPChannelAdd}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPChannelAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
