<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPChannelCodeTreeListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.SPChannelCodeTreeListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Items>
                    <ext:Panel ID="Panel1" Region="North" runat="server" Padding="15" Title="复杂表格操作演示"
                        Html="包含数据行复制，删除，编辑，选择。" />
                    <ext:TreeGrid ID="TreeGrid1" runat="server" Title="Core Team Projects" Width="500"
                        Height="300" NoLeafIcon="true" EnableDD="true">
                        <Columns>
                            <ext:TreeGridColumn Header="task" Width="230" DataIndex="task" />
                            <ext:TreeGridColumn Header="duration" Width="100" DataIndex="duration" Align="Center"
                                SortType="AsFloat">
                            </ext:TreeGridColumn>
                            <ext:TreeGridColumn Header="Assigned To" Width="150" DataIndex="user" />
                        </Columns>
                        <Root>
                            <ext:TreeNode Text="Tasks">
                                <Nodes>
                                    <ext:TreeNode Icon="Folder" Expanded="true">
                                        <CustomAttributes>
                                            <ext:ConfigItem Name="task" Value="Project: Shopping" Mode="Value" />
                                            <ext:ConfigItem Name="duration" Value="13.25" />
                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                        </CustomAttributes>
                                        <Nodes>
                                            <ext:TreeNode Icon="Folder">
                                                <CustomAttributes>
                                                    <ext:ConfigItem Name="task" Value="Housewares" Mode="Value" />
                                                    <ext:ConfigItem Name="duration" Value="1.25" />
                                                    <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                </CustomAttributes>
                                                <Nodes>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Kitchen supplies" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Groceries" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.4" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Cleaning supplies" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.4" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Office supplies" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.2" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Icon="Folder" Expanded="true">
                                                <CustomAttributes>
                                                    <ext:ConfigItem Name="task" Value="Remodeling" Mode="Value" />
                                                    <ext:ConfigItem Name="duration" Value="12" />
                                                    <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                </CustomAttributes>
                                                <Nodes>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Retile kitchen" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="6.5" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Icon="Folder">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Paint bedroom" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="2.75" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                        <Nodes>
                                                            <ext:TreeNode Leaf="true">
                                                                <CustomAttributes>
                                                                    <ext:ConfigItem Name="task" Value="Ceiling" Mode="Value" />
                                                                    <ext:ConfigItem Name="duration" Value="1.25" />
                                                                    <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                                </CustomAttributes>
                                                            </ext:TreeNode>
                                                            <ext:TreeNode Leaf="true">
                                                                <CustomAttributes>
                                                                    <ext:ConfigItem Name="task" Value="Walls" Mode="Value" />
                                                                    <ext:ConfigItem Name="duration" Value="1.5" />
                                                                    <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                                </CustomAttributes>
                                                            </ext:TreeNode>
                                                        </Nodes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Decorate living room" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="2.75" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Fix lights" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.75" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Reattach screen door" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="2" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                </Nodes>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Icon="Folder">
                                        <CustomAttributes>
                                            <ext:ConfigItem Name="task" Value="Project: Testing" Mode="Value" />
                                            <ext:ConfigItem Name="duration" Value="2" />
                                            <ext:ConfigItem Name="user" Value="Core Team" Mode="Value" />
                                        </CustomAttributes>
                                        <Nodes>
                                            <ext:TreeNode Icon="Folder">
                                                <CustomAttributes>
                                                    <ext:ConfigItem Name="task" Value="Mac OSX" Mode="Value" />
                                                    <ext:ConfigItem Name="duration" Value="0.75" />
                                                    <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                </CustomAttributes>
                                                <Nodes>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Safari" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Icon="Folder">
                                                <CustomAttributes>
                                                    <ext:ConfigItem Name="task" Value="Windows" Mode="Value" />
                                                    <ext:ConfigItem Name="duration" Value="3.75" />
                                                    <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                                </CustomAttributes>
                                                <Nodes>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Safari" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Internet Explorer" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="3" />
                                                            <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                </Nodes>
                                            </ext:TreeNode>
                                            <ext:TreeNode Icon="Folder">
                                                <CustomAttributes>
                                                    <ext:ConfigItem Name="task" Value="Linux" Mode="Value" />
                                                    <ext:ConfigItem Name="duration" Value="0.5" />
                                                    <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                                </CustomAttributes>
                                                <Nodes>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Leaf="true">
                                                        <CustomAttributes>
                                                            <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                            <ext:ConfigItem Name="duration" Value="0.25" />
                                                            <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                                        </CustomAttributes>
                                                    </ext:TreeNode>
                                                </Nodes>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                        </Root>
                    </ext:TreeGrid>
                </Items>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
