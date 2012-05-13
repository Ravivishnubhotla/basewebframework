using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SL.Drawing
{
    public class DrawingSetting
    {
        public string BgImageUrl { get; set; }

        public static string GetSettingValue(Dictionary<string, string> dir, string key)
        {
            if (dir != null && dir.ContainsKey(key) && !string.IsNullOrEmpty(dir[key]))
                return dir[key];

            return string.Empty;
        }
    }
}
