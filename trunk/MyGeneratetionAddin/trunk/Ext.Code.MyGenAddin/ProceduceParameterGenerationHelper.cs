using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dnp.Utils;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public static class ProceduceParameterGenerationHelper
    {
        private static Utils utils = new Utils();


 

        #region const

        private const string defaultFilterString = "_ -";

        private const StringCase defaultStringCase = StringCase.CamelCase;

        private const string defaultFormat = "{0}";

        private static readonly string[] notNullableTypes = new string[] { "string", "byte[]", "object" };

        #endregion


        #region GenerateNameByParameter

        public static string GenerateNameByParameter(IParameter parameter, string format, StringCase stringCase,
                                                       string filterString)
        {
            string generateName = parameter.Name;
            switch (stringCase)
            {
                case StringCase.CamelCase:
                    generateName = utils.SetCamelCase(generateName);
                    break;
                case StringCase.PascalCase:
                    generateName = utils.SetPascalCase(generateName);
                    break;
            }
            char[] filterChar = filterString.ToCharArray();
            foreach (char c in filterChar)
            {
                generateName = generateName.Replace(c.ToString(), "");
            }
            return string.Format(format, generateName);
        }

        public static string GenerateNameByParameter(IParameter parameter, string format, StringCase stringCase)
        {
            return GenerateNameByParameter(parameter, format, stringCase, defaultFilterString);
        }

        public static string GenerateNameByParameter(IParameter parameter, string format)
        {
            return GenerateNameByParameter(parameter, format, defaultStringCase, defaultFilterString);
        }

        public static string GenerateNameByParameter(IParameter parameter)
        {
            return GenerateNameByParameter(parameter, defaultFormat, defaultStringCase, defaultFilterString);
        }

        #endregion


        public static int GenerateParameterSize(IParameter parameter)
        {
            if (!(parameter.LanguageType.ToLower() == "string"))
                return 0;
            if (parameter.CharacterMaxLength > 8000)
                return 0;
            return parameter.CharacterMaxLength;
        }

        public static string GenerateParameterDbType(IParameter parameter)
        {
            return parameter.DbTargetType;
        }

        public static string GenerateParameterLangageType(IParameter parameter,bool isAllowNullable)
        {
            foreach (string notNullableType in notNullableTypes)
            {
                if (parameter.LanguageType.ToLower() == notNullableType)
                {
                    return notNullableType;
                }
            }

            if (parameter.IsNullable)
            {
                if (isAllowNullable)
                {
                    return parameter.LanguageType +"?";
                }
            }
            return parameter.LanguageType;
        }

        public static string GenerateParameterDirection(IParameter parameter)
        {
            switch (parameter.Direction)
            {
                case ParamDirection.Input:
                    return "ParameterDirection.Input";
                    break;
                case ParamDirection.Output:
                    return "ParameterDirection.Output";
                    break;
                case ParamDirection.InputOutput:
                    return "ParameterDirection.InputOutput";
                    break;
                case ParamDirection.ReturnValue:
                    return "ParameterDirection.ReturnValue";
                    break;
            }
            return "";
        }

        public static string GenerateMethodParameterName(IParameter parameter)
        {
            return GenerateNameByParameter(parameter, "{0}", StringCase.PascalCase).Replace("@", "");
        }

        public static string GenerateMethodByParameter(IParameter parameter,bool isAllowNullable)
        {
            return string.Format("{2} {0} {1}", GenerateParameterLangageType(parameter, isAllowNullable), GenerateMethodParameterName(parameter), GenerateMethodParameterTypeByParameter(parameter));
        }


        public static string GenerateMethodParameterTypeByParameter(IParameter parameter)
        {
            switch (parameter.Direction)
            {
                case ParamDirection.Input:
                    return "";
                    break;
                case ParamDirection.Output:
                    return "out";
                    break;
                case ParamDirection.InputOutput:
                    return "ref";
                    break;
                case ParamDirection.ReturnValue:
                    return "out";
                    break;
            }
            return "";
        }
    }
}
