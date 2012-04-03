<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFlash1.aspx.cs" Inherits="Legendigital.Common.WebApp.TestPage.TestFlash1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <script type="text/javascript">
            var player = {
                play: function () {
                    Button1.disable();
                    Button2.enable();
                    Button3.enable();
                    //Window1.items.items[0].el.dom.api_play();

                    alert(VideoPlayer.el.dom);

                    VideoPlayer.el.dom.api_play();
                },

                pause: function () {
                    Button3.disable();
                    Button2.disable();
                    Slider1.disable();
                    Button1.enable();
                    //Window1.items.items[0].el.dom.api_pause();
                    VideoPlayer.el.dom.api_pause();
                },

                volume: function (el, level) {
                    //Window1.items.items[0].el.dom.api_setVolume(level)
                    VideoPlayer.el.dom.api_setVolume(level);
                }
            };
        </script>
        
        <ext:Window 
            ID="Window1"
            runat="server" 
            Title="Flash Movie" 
            Layout="fit" 
            Height="320" 
            Width="402"
            Maximizable="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button 
                            ID="Button1" 
                            runat="server" 
                            Text="Play" 
                            Icon="ControlPlayBlue" 
                            Handler="player.play" 
                            />
                        <ext:Button 
                            ID="Button2" 
                            runat="server" 
                            Text="Pause" 
                            Icon="ControlPauseBlue" 
                            Handler="player.pause" 
                            Disabled="true" 
                            />
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <ext:SplitButton ID="Button3" runat="server" Icon="Sound" Disabled="true">
                            <Menu>
                                <ext:Menu ID="Menu1" runat="server">
                                    <Items>
                                        <ext:Slider ID="Slider1" runat="server" Width="100" Number="100">
                                            <Plugins>
                                                <ext:SliderTip ID="SliderTip1" runat="server" />
                                            </Plugins>
                                            <Listeners>
                                                <Change Fn="player.volume" />
                                            </Listeners>
                                        </ext:Slider>            
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>
                    </Items>
                </ext:Toolbar>
            </TopBar>

        <Items>
            <ext:FlashComponent ID="VideoPlayer" runat="server" Url="http://you.video.sina.com.cn/api/sinawebApi/outplayrefer.php/vid=73551262_6_OkuwRis8DmTK+l1lHz2stqkM7KQNt6njnynt71+iJAlZVw6NYorfO4kK5yrTBc5A924/s.swf">
                <FlashParams>
                    <ext:Parameter Name="allowfullscreen" Value="true" Mode="Raw" />
                </FlashParams>
            </ext:FlashComponent>
        </Items>
    </ext:Window>
    </form>
</body>
</html>
