using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.ADOFrameworks
{
    [Serializable]
    public class AdoBaseProcedureConfig
    {
        public string _proceduceMethodNameFormat;
        [Category("[存储过程代码设置]"), ReadOnly(false), Description("存储过程方法名称格式"), Browsable(true)]
        public string ProceduceMethodNameFormat
        {
            get { return _proceduceMethodNameFormat; }
            set { _proceduceMethodNameFormat = value; }
        }
 

        #region 存储过程代码生成

        public string GenerateProceduceCodeMethodName(IProcedure procedure)
        {
            return ProceduceGenerationHelper.GenerateNameByProceduce(procedure, this.ProceduceMethodNameFormat,
                                                                     StringCase.PascalCase,
                                                                     "");
        }

        public string GenerateProceduceParamterName(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateNameByParameter(parameter, "{0}", StringCase.PascalCase);
        }

        public string GenerateParameterDirection(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateParameterDirection(parameter);
        }

        public int GenerateParameterSize(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateParameterSize(parameter);
        }

        public string GenerateParameterDbType(IParameter parameter)
        {
            return parameter.DbTargetType;
        }

        #endregion
    }
}
