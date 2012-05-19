using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dnp.Utils;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public static class ProceduceGenerationHelper
    {
        private static Utils utils = new Utils();

        #region const

        private const string defaultFilterString = "_ -";

        private const StringCase defaultStringCase = StringCase.CamelCase;

        private const string defaultFormat = "{0}";

        private static readonly string[] notNullableTypes = new string[] { "string", "byte[]", "object" };

        #endregion

        #region GenerateNameByProceduce

        public static string GenerateNameByProceduce(IProcedure procedure, string format, StringCase stringCase, string filterString)
        {
            string generateName = procedure.Name;
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

        public static string GenerateNameByProceduce(IProcedure procedure, string format, StringCase stringCase)
        {
            return GenerateNameByProceduce(procedure, format, stringCase, defaultFilterString);
        }

        public static string GenerateNameByProceduce(IProcedure procedure, string format)
        {
            return GenerateNameByProceduce(procedure, format, defaultStringCase, defaultFilterString);
        }

        public static string GenerateNameByProceduce(IProcedure procedure)
        {
            return GenerateNameByProceduce(procedure, defaultFormat, defaultStringCase, defaultFilterString);
        }

        #endregion

        public static IColumn GenerateColumnByProcedure(IParameter parameter, ITable table)
        {
            foreach (IColumn column in table.Columns)
            {
                if (column.Name.ToLower().Trim().Equals(parameter.Name.Replace("@", "").ToLower().Trim()))
                {
                    return column;
                }
            }
            return null;
        }

        public static string GenerateProceduceParametersMethodListForTable(IProcedure procedure, ITable table, bool isAllowNullable)
        {
            StringBuilder sbMethodList = new StringBuilder();

            int count = 0;

            foreach (IParameter parameter in procedure.Parameters)
            {
                IColumn column = GenerateColumnByProcedure(parameter, table);

                if (column==null)
                    continue;

                switch (parameter.Direction)
                {
                    case ParamDirection.ReturnValue:
                        break;
                    case ParamDirection.Output:
                    case ParamDirection.InputOutput:
                    case ParamDirection.Input:
                        count++;
                        if (count > 1)
                        {
                            sbMethodList.Append(",");
                        }
                        sbMethodList.Append(ProceduceParameterGenerationHelper.GenerateMethodByParameter(parameter, column.IsNullable));
                        //sbMethodList.Append(parameter.Direction.ToString() + "----" + column.Name + column.IsNullable.ToString());
                        break;
                    case ParamDirection.Unknown:
                        break;
                }


            }

            return sbMethodList.ToString();
        }

        public static string GenerateProceduceParametersMethodList(IProcedure procedure, bool isAllowNullable)
         {
             StringBuilder sbMethodList = new StringBuilder();

             int count = 0;

             foreach (IParameter parameter in procedure.Parameters)
             {
                 switch (parameter.Direction)
                 {
                     case ParamDirection.ReturnValue:
                         break;
                     case ParamDirection.Output:
                         count++;
                         if(count>1)
                         {
                             sbMethodList.Append(",");
                         }
                         sbMethodList.Append(ProceduceParameterGenerationHelper.GenerateMethodByParameter(parameter, isAllowNullable));
                         sbMethodList.Append(parameter.Direction.ToString() + parameter.IsNullable.ToString());
                         break;
                     case ParamDirection.InputOutput:
                         count++;
                         if(count>1)
                         {
                             sbMethodList.Append(",");
                         }
                         sbMethodList.Append(ProceduceParameterGenerationHelper.GenerateMethodByParameter(parameter, isAllowNullable));
                         sbMethodList.Append(parameter.Direction.ToString() + parameter.IsNullable.ToString());
                         break;
                     case ParamDirection.Input:
                         count++;
                         if(count>1)
                         {
                             sbMethodList.Append(",");
                         }
                         sbMethodList.Append(ProceduceParameterGenerationHelper.GenerateMethodByParameter(parameter, isAllowNullable));
                         sbMethodList.Append(parameter.Direction.ToString() + parameter.IsNullable.ToString());
                         break;
                     case ParamDirection.Unknown:
                         break;
                 }

 
             }

             return sbMethodList.ToString();
         }

 

    }
}
