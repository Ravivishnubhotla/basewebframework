using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Text;

namespace Powerasp.Enterprise.Core.Utility
{
    public class StringUtil
    {
        public const string AngleBracketsEnd = ">";
        public const string AngleBracketsStart = "<";
        public const string Colon = ":";
        public const string Comma = ",";
        public const string Cr = "\r";
        public const string CrLf = "\r\n";
        public const string DoubleQuotationMark = "\"";
        public const string ExcalmatoryMark = "!";
        public const string Interrogation = "?";
        public const string Lf = "\n";
        public const string OpenBracketsEnd = "}";
        public const string OpenBracketsStart = "{";
        public const string ParenthesesEnd = ")";
        public const string ParenthesesStart = "(";
        public const string Period = ".";
        public const string Quotes = "\"";
        public const string Semicolon = ";";
        public const string SingleQuotationMark = "'";
        public const string Space = " ";
        public const string SquareBracketsEnd = "]";
        public const string SquareBracketsStart = "[";
        public const string Tab = "\t";

        public static string[] ArrayToString(ICollection collection)
        {
            int num = 0;
            string[] strArray = new string[collection.Count];
            foreach (object obj2 in collection)
            {
                strArray[num++] = obj2.ToString();
            }
            return strArray;
        }

        public static string[] ArrayToString(IList ary)
        {
            if (ary == null)
            {
                throw new ArgumentNullException("ary");
            }
            return ArrayToString(ary, 0, ary.Count);
        }

        public static string[] ArrayToString(IList ary, int index, int count)
        {
            if (ary == null)
            {
                throw new ArgumentNullException("ary");
            }
            if ((index < 0) || (index > ary.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((count < 0) || ((index + count) > ary.Count))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            string[] strArray = new string[count];
            for (int i = 0; i < count; i++)
            {
                strArray[i] = ary[index + 1].ToString();
            }
            return strArray;
        }

        public static StringDictionary BuildDictionary(string s, char[] itemSplit, char[] keySplit)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            StringDictionary dictionary = new StringDictionary();
            string[] strArray = s.Split(itemSplit);
            if (strArray.Length > 0)
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str = strArray[i];
                    if (str.Trim() != string.Empty)
                    {
                        int index = str.IndexOf(new string(keySplit));
                        string key = (index > 0) ? str.Substring(0, index) : str.Trim();
                        string str3 = (index >= 0) ? str.Substring(index + 1).Trim() : string.Empty;
                        if (dictionary.ContainsKey(key))
                        {
                            dictionary[key] = str3;
                        }
                        else
                        {
                            dictionary.Add(key, str3);
                        }
                    }
                }
            }
            return dictionary;
        }

        public static string BytesToHex(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            StringBuilder builder = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));
            }
            return builder.ToString();
        }

        public static string ByteToHex(byte value)
        {
            return string.Format("{0:x}", value);
        }

        public static string FormatNumber(long number, string[] format)
        {
            return FormatNumber(number, format, true);
        }

        public static string FormatNumber(long number, string[] format, bool binary)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            double x = binary ? 1024.0 : 1000.0;
            int index = format.Length - 1;
            for (int i = 0; i < format.Length; i++)
            {
                if (Math.Pow(x, (double) (i + 1)) > number)
                {
                    index = i;
                    break;
                }
            }
            return string.Format("{0:f3}{1}", ((double) number) / Math.Pow(x, (double) index), format[index]);
        }

        public static byte[] HexToBytes(string hexNumber)
        {
            if (hexNumber == null)
            {
                throw new ArgumentNullException("hexNumber");
            }
            if (hexNumber.Length == 0)
            {
                return new byte[0];
            }
            StringBuilder builder = new StringBuilder(hexNumber.ToUpper(CultureInfo.CurrentCulture));
            char ch = builder[0];
            if (ch.Equals('0'))
            {
                ch = builder[1];
                if (ch.Equals('X'))
                {
                    builder.Remove(0, 2);
                }
            }
            if ((builder.Length % 2) != 0)
            {
                throw new ArgumentException("String must represent a valid hexadecimal (e.g. : 0F99DD)");
            }
            byte[] buffer = new byte[builder.Length / 2];
            try
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    int startIndex = i * 2;
                    buffer[i] = byte.Parse(builder.ToString(startIndex, 2), NumberStyles.AllowHexSpecifier);
                }
            }
            catch (FormatException exception)
            {
                throw new ArgumentException("error", exception);
            }
            return buffer;
        }

        public static string Int16ToHex(short value)
        {
            return string.Format("{0:x}", value);
        }

        public static string Int32ToHex(int value)
        {
            return string.Format("{0:x}", value);
        }

        public static string Int64ToHex(long value)
        {
            return string.Format("{0:x}", value);
        }

        public static bool IsNumber(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (s == string.Empty)
            {
                return false;
            }
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsNumber(s[i]))
                {
                    if ((s[i] == '.') && !flag)
                    {
                        flag = true;
                    }
                    else if ((s[i] != '-') || (i != 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string MakeCapitalize(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            string[] strArray = s.Split(new char[] { ' ' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length != 0)
                {
                    s = strArray[i];
                    char ch = s[0];
                    strArray[i] = string.Format("{0}{1}", ch.ToString().ToUpper(), s.Substring(1, s.Length - 1));
                }
            }
            return string.Join(" ", strArray);
        }

        public static string MoveOpenBrackets(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            return MoveSymbol(s, "{"[0], "}"[0]);
        }

        public static string MoveParentheses(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            return MoveSymbol(s, "("[0], ")"[0]);
        }

        public static string MoveQuotes(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            return MoveSymbol(s, "\""[0]);
        }

        public static string MoveSingleQuotationMarks(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            return MoveSymbol(s, "'"[0]);
        }

        public static string MoveSymbol(string s, char symbol)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            return MoveSymbol(s, symbol, symbol);
        }

        public static string MoveSymbol(string s, char symbolStart, char symbolEnd)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            char[] chArray = s.ToCharArray();
            if (chArray.Length < 2)
            {
                return s;
            }
            int index = 0;
            int length = chArray.Length;
            if ((chArray[index] == symbolStart) && (chArray[length - 1] == symbolEnd))
            {
                index++;
                length--;
            }
            return new string(chArray, index, length - index);
        }

        public static string Prefix(string name, string prefix)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (prefix == null)
            {
                return name;
            }
            return (prefix + name);
        }

        public static string[] Prefix(string[] names, string prefix)
        {
            if (names == null)
            {
                throw new ArgumentNullException("names");
            }
            if (prefix == null)
            {
                return names;
            }
            string[] strArray = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                strArray[i] = Prefix(names[i], prefix);
            }
            return strArray;
        }

        public static string Subsection(string original, int length)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }
            if (original.Length < length)
            {
                return original;
            }
            StringReader reader = null;
            StringBuilder builder = null;
            try
            {
                builder = new StringBuilder();
                reader = new StringReader(original);
                char[] buffer = new char[length];
                while (true)
                {
                    int num = reader.ReadBlock(buffer, 0, buffer.Length);
                    if (num == 0)
                    {
                        goto Label_0070;
                    }
                    builder.Append(new string(buffer, 0, num));
                    builder.Append("\r\n");
                }
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {
                    }
                    reader = null;
                }
            }
            Label_0070:
            return builder.ToString();
        }

        public static string[] Suffix(string[] names, string suffix)
        {
            if (names == null)
            {
                throw new ArgumentNullException("names");
            }
            if (suffix == null)
            {
                return names;
            }
            string[] strArray = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                strArray[i] = Suffix(names[i], suffix);
            }
            return strArray;
        }

        public static string Suffix(string name, string suffix)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (suffix == null)
            {
                return name;
            }
            return (name + suffix);
        }
    }
}