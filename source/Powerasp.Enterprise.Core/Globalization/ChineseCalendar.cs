using System;
using Powerasp.Enterprise.Core.ExtendBaseType;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class ChineseCalendar
    {
        public static readonly string[] AnimalsSymbol = new string[] { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        public static readonly string[] ChineseDay = new string[] { 
                                                                      "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", 
                                                                      "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十"
                                                                  };
        public static readonly string[] ChineseMonth = new string[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "寒", "腊" };
        internal static readonly string[] Era = new string[60];
        public static readonly string[] EtherealEra = new string[] { "甲", "乙", "丙", "丁", "戊", "已", "庚", "辛", "壬", "癸" };
        public static readonly string[] LunarHolDay = new string[] { 
                                                                       "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", 
                                                                       "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
                                                                   };
        private static readonly byte[] LunarHolDayArray = new byte[] { 
                                                                         150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                                                                         0x97, 0x87, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                                                                         0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 120, 0x87, 
                                                                         150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                                                                         0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                                                                         0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 
                                                                         150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 
                                                                         0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x87, 150, 0x87, 0x87, 0x79, 0x69, 
                                                                         0x69, 0x69, 120, 120, 0x86, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 
                                                                         0x95, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 120, 150, 0xa5, 0x97, 150, 0x97, 0x87, 0x79, 0x79, 
                                                                         0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                                                                         0x95, 180, 150, 0xa6, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa5, 0x97, 150, 0x97, 0x87, 0x79, 0x79, 
                                                                         0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 0x79, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                                                                         0x69, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x87, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 0x79, 0x69, 120, 0x77, 150, 0xa4, 150, 150, 0x97, 0x97, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 150, 0xa5, 0xa6, 150, 0x88, 120, 120, 120, 0x87, 0x87, 
                                                                         0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa6, 
                                                                         0x97, 0x97, 120, 0x79, 120, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 0x97, 0x97, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 0x79, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 120, 0x79, 120, 0x69, 120, 0x77, 150, 180, 150, 0xa6, 0x97, 0x97, 0x79, 0x79, 
                                                                         0x79, 0x69, 120, 120, 150, 0xa5, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 120, 0x79, 120, 0x68, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         0x79, 0x69, 120, 0x77, 150, 0xa5, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 150, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         0x79, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 0xb5, 150, 0xa5, 0xa6, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x69, 120, 0x87, 150, 180, 150, 0xa6, 0x97, 0x97, 120, 0x79, 
                                                                         120, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x89, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 150, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x79, 120, 0x87, 150, 180, 150, 0xa6, 150, 0x97, 120, 0x79, 
                                                                         120, 0x69, 120, 0x77, 150, 0xa4, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x77, 0x87, 0x95, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 120, 0x79, 
                                                                         120, 0x69, 120, 0x77, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 
                                                                         0xa5, 180, 0xa6, 0xa5, 0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         150, 0x97, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 0x79, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                                                                         0xa5, 180, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         150, 150, 0x88, 120, 120, 0x79, 0x77, 0x87, 0x95, 180, 150, 0xa5, 0x86, 0x97, 0x88, 120, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 0x76, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         150, 150, 0x88, 120, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xa5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                                                                         120, 0x69, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                                                                         120, 0x79, 120, 0x87, 150, 180, 0xa5, 0xb5, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                                                                         0xa5, 0xb3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 
                                                                         0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0x95, 180, 150, 0xa5, 150, 0x97, 0x88, 120, 
                                                                         120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 0xa6, 0xa5, 
                                                                         0xa6, 150, 0x88, 0x88, 120, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                                                                         120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 0x86, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 180, 0xa5, 0xa5, 
                                                                         0xa6, 150, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                                                                         120, 0x79, 0x77, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                                                                         0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                                                                         0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 150, 150, 0x88, 120, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                                                                         0xa6, 0xa6, 0x88, 120, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xa5, 
                                                                         0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 0xb5, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xb5, 
                                                                         0xa6, 0xa6, 0x88, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa6, 0x97, 0x87, 0x87, 0x88, 0x87, 150, 
                                                                         0xa5, 0xc3, 0xa5, 180, 0xa5, 0xa6, 0x87, 0x88, 0x87, 120, 0x87, 0x86, 0xa5, 0xb3, 0xa5, 0xb5, 
                                                                         0xa6, 0xa6, 0x87, 0x88, 0x88, 120, 0x87, 0x87, 0xa5, 180, 150, 0xa5, 0xa6, 150, 0x88, 0x88, 
                                                                         120, 120, 0x87, 0x87, 0x95, 180, 0xa5, 180, 0xa5, 0xa5, 0x97, 0x87, 0x87, 0x88, 0x86, 150, 
                                                                         0xa4, 0xc3, 0xa5, 0xa5, 0xa5, 0xa6, 0x97, 0x87, 0x87, 120, 0x87, 0x86, 0xa5, 0xc3, 0xa5, 0xb5, 
                                                                         0xa6, 0xa6, 0x87, 0x88, 120, 120, 0x87, 0x87
                                                                     };
        private static readonly byte[] LunarMonthArray = new byte[] { 
                                                                        0, 80, 4, 0, 0x20, 0x60, 5, 0, 0x20, 0x70, 5, 0, 0x40, 2, 6, 0, 
                                                                        80, 3, 7, 0, 0x60, 4, 0, 0x20, 0x70, 5, 0, 0x30, 0x80, 6, 0, 0x40, 
                                                                        3, 7, 0, 80, 4, 8, 0, 0x60, 4, 10, 0, 0x60, 5, 0, 0x30, 0x80, 
                                                                        5, 0, 0x40, 2, 7, 0, 80, 4, 9, 0, 0x60, 4, 0, 0x20, 0x60, 5, 
                                                                        0, 0x30, 0xb0, 6, 0, 80, 2, 7, 0, 80, 3
                                                                    };
        private static readonly int[] LunarMonthDayArray = new int[] { 
                                                                         0x4ae0, 0xa570, 0x5268, 0xd260, 0xd950, 0x6aa8, 0x56a0, 0x9ad0, 0x4ae8, 0x4ae0, 0xa4d8, 0xa4d0, 0xd250, 0xd548, 0xb550, 0x56a0, 
                                                                         0x96d0, 0x95b0, 0x49b8, 0x49b0, 0xa4b0, 0xb258, 0x6a50, 0x6d40, 0xada8, 0x2b60, 0x9570, 0x4978, 0x4970, 0x64b0, 0xd4a0, 0xea50, 
                                                                         0x6d48, 0x5ad0, 0x2b60, 0x9370, 0x92e0, 0xc968, 0xc950, 0xd4a0, 0xda50, 0xb550, 0x56a0, 0xaad8, 0x25d0, 0x92d0, 0xc958, 0xa950, 
                                                                         0xb4a8, 0x6ca0, 0xb550, 0x55a8, 0x4da0, 0xa5b0, 0x52b8, 0x52b0, 0xa950, 0xe950, 0x6aa0, 0xad50, 0xab50, 0x4b60, 0xa570, 0xa570, 
                                                                         0x5260, 0xe930, 0xd950, 0x5aa8, 0x56a0, 0x96d0, 0x4ae8, 0x4ad0, 0xa4d0, 0xd268, 0xd250, 0xd528, 0xb540, 0xb6a0, 0x96d0, 0x95b0, 
                                                                         0x49b0, 0xa4b8, 0xa4b0, 0xb258, 0x6a50, 0x6d40, 0xada0, 0xab60, 0x9370, 0x4978, 0x4970, 0x64b0, 0x6a50, 0xea50, 0x6b28, 0x5ac0, 
                                                                         0xab60, 0x9368, 0x92e0, 0xc960, 0xd4a8, 0xd4a0, 0xda50, 0x5aa8, 0x56a0, 0xaad8, 0x25d0, 0x92d0, 0xc958, 0xa950, 0xb4a0, 0xb550, 
                                                                         0xb550, 0x55a8, 0x4ba0, 0xa5b0, 0x52b8, 0x52b0, 0xa930, 0x74a8, 0x6aa0, 0xad50, 0x4da8, 0x4b60, 0x9570, 0xa4e0, 0xd260, 0xe930, 
                                                                         0xd530, 0x5aa0, 0x6b50, 0x96d0, 0x4ae8, 0x4ad0, 0xa4d0, 0xd258, 0xd250, 0xd520, 0xdaa0, 0xb5a0, 0x56d0, 0x4ad8, 0x49b0, 0xa4b8, 
                                                                         0xa4b0, 0xaa50, 0xb528, 0x6d20, 0xada0, 0x55b0
                                                                     };
        internal const int MaxYear = 0x802;
        internal const int MinYear = 0x76d;
        public static readonly string[] TelluricEra = new string[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        static ChineseCalendar()
        {
            for (int i = 0; i < 60; i++)
            {
                Era[i] = EtherealEra[i % 10] + TelluricEra[i % 12];
            }
        }

        public static ChineseDate CalcLunarDate()
        {
            return CalcLunarDate(DateTime.Today);
        }

        public static ChineseDate CalcLunarDate(DateTime date)
        {
            int lunarYearDays;
            int num4;
            int num5;
            int num6;
            bool flag = false;
            ChineseDate date2 = new ChineseDate(date);
            int spanDays = date2.SpanDays;
            if (spanDays < 0x31)
            {
                num4 = 0x76c;
                if (spanDays < 0x13)
                {
                    num5 = 11;
                    num6 = spanDays + 11;
                }
                else
                {
                    num5 = 12;
                    num6 = spanDays - 0x12;
                }
                goto Label_00A6;
            }
            num4 = 0x76d;
            num5 = 1;
            num6 = 1;
            spanDays -= 0x31;
            while (true)
            {
                lunarYearDays = GetLunarYearDays(num4);
                if (spanDays < lunarYearDays)
                {
                    break;
                }
                spanDays -= lunarYearDays;
                num4++;
            }
            Label_0065:
            lunarYearDays = GetLunarMonthDays(num4, num5);
            int num2 = (lunarYearDays << 0x10) >> 0x10;
            if (spanDays >= num2)
            {
                spanDays -= num2;
                if (num5 == GetLeapMonth(num4))
                {
                    flag = true;
                    lunarYearDays = lunarYearDays >> 0x10;
                    if (spanDays < lunarYearDays)
                    {
                        goto Label_00A1;
                    }
                    spanDays -= lunarYearDays;
                }
                num5++;
                goto Label_0065;
            }
            Label_00A1:
            num6 = spanDays + 1;
            Label_00A6:
            date2.ilunarDate = new DateTime(num4, num5, num6);
            date2.ileapMonth = flag;
            return date2;
        }

        internal static string GetAnimalsSymbolName(ChineseDate lunarDate)
        {
            return AnimalsSymbol[(lunarDate.ilunarDate.Year - 4) % 12];
        }

        private static int GetLeapMonth(int lunarYear)
        {
            if ((lunarYear < 0x76d) || (lunarYear > 0x802))
            {
                throw new ArgumentNullException("lunarYear");
            }
            int num = LunarMonthArray[(lunarYear - 0x76d) / 2];
            return ((((lunarYear - 0x76d) % 2) == 0) ? (num >> 4) : (num & 15));
        }

        internal static string GetLunarDay(ChineseDate lunarDate)
        {
            return ChineseDay[lunarDate.ilunarDate.Day - 1];
        }

        internal static string GetLunarHolDay(ChineseDate lunarDate)
        {
            int num;
            int index = (((lunarDate.idate.Year - 0x76d) * 12) + lunarDate.idate.Month) - 1;
            if ((index < 0) || (index >= LunarHolDayArray.Length))
            {
                throw new IndexOutOfRangeException("Invaild lunar day");
            }
            int num3 = LunarHolDayArray[index];
            index = -1;
            if (lunarDate.idate.Day < 15)
            {
                num = 15 - ((num3 >> 4) & 15);
            }
            else
            {
                num = (num3 & 15) + 15;
            }
            if (lunarDate.idate.Day == num)
            {
                index = ((lunarDate.idate.Month - 1) * 2) + ((lunarDate.idate.Day > 15) ? 1 : 0);
            }
            if (index == -1)
            {
                return string.Empty;
            }
            return LunarHolDay[index];
        }

        internal static string GetLunarMonth(ChineseDate lunarDate)
        {
            return ChineseMonth[lunarDate.ilunarDate.Month - 1];
        }

        private static int GetLunarMonthDays(int lunarYear, int lunarMonth)
        {
            if ((lunarYear < 0x76d) || (lunarYear > 0x802))
            {
                throw new ArgumentNullException("lunarYear");
            }
            if ((lunarMonth < 1) || (lunarMonth > 12))
            {
                throw new ArgumentNullException("lunarMonth");
            }
            int leapMonth = GetLeapMonth(lunarYear);
            int index = 0x10 - lunarMonth;
            if ((lunarMonth > leapMonth) && (leapMonth > 0))
            {
                index--;
            }
            BitArray array = new BitArray(LunarMonthDayArray[lunarYear - 0x76d]);
            int num3 = array.GetBit(index) ? 30 : 0x1d;
            if (lunarMonth == leapMonth)
            {
                return ((num3 + ((array.GetBit(index - 1) != null) ? 30 : 0x1d)) << 0x10);
            }
            return num3;
        }

        private static int GetLunarYearDays(int lunarYear)
        {
            if ((lunarYear < 0x76d) || (lunarYear > 0x802))
            {
                throw new ArgumentNullException("lunarYear");
            }
            int num2 = 0;
            for (int i = 1; i <= 12; i++)
            {
                int lunarMonthDays = GetLunarMonthDays(lunarYear, i);
                num2 += (lunarMonthDays >> 0x10) + ((lunarMonthDays << 0x10) >> 0x10);
            }
            return num2;
        }

        internal static string GetYearEraName(ChineseDate lunarDate)
        {
            return Era[(lunarDate.ilunarDate.Year - 4) % 60];
        }
    }
}