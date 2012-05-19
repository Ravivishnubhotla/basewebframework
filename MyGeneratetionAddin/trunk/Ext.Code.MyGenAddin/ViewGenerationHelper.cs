using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dnp.Utils;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public static class ViewGenerationHelper
    {
        private static Utils utils = new Utils();

        #region const

        private const string defaultFilterString = "_ -";

        private const StringCase defaultStringCase = StringCase.CamelCase;

        private const string defaultFormat = "{0}";

        private static readonly string[] notNullableTypes = new string[] { "string", "byte[]", "object" };

        #endregion

        #region GenerateNameByViewColumn

        public static string GenerateNameByView(IView table, string format, StringCase stringCase, string filterString)
        {
            string generateName = table.Name;
            if (!string.IsNullOrEmpty(filterString))
            {
                string[] filterStrings = filterString.Split((",").ToCharArray());
                foreach (string s in filterStrings)
                {
                    if (generateName.ToUpper().StartsWith(s.ToUpper()))
                    {
                        generateName = generateName.Substring(s.Length, generateName.Length - s.Length);
                    }
                }
            }
            switch (stringCase)
            {
                case StringCase.CamelCase:
                    generateName = utils.SetCamelCase(generateName);
                    break;
                case StringCase.PascalCase:
                    generateName = utils.SetPascalCase(generateName);
                    break;
            }
            return string.Format(format, generateName);
        }

        public static string GenerateNameByView(IView view, string format, StringCase stringCase)
        {
            return GenerateNameByView(view, format, stringCase, defaultFilterString);
        }

        public static string GenerateNameByView(IView view, string format)
        {
            return GenerateNameByView(view, format, defaultStringCase, defaultFilterString);
        }

        public static string GenerateNameByView(IView view)
        {
            return GenerateNameByView(view, defaultFormat, defaultStringCase, defaultFilterString);
        }

        #endregion


    }
}
