// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Data.Tables;
using SPS.Entity.Tables;


namespace SPS.Bussiness.ServiceProxys.Tables
{
	public interface ISPCodeServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPCodeEntity> ,ISPCodeServiceProxyDesigner
    {


    }

    internal partial class SPCodeServiceProxy : ISPCodeServiceProxy
    {

        public static SPCodeEntity NewDefaultCode(SPChannelEntity channelEntity)
        {
            SPCodeEntity code = new SPCodeEntity();

            code.Name = channelEntity.Name + "Ĭ�ϱ���";
            code.Description = channelEntity.Name + "Ĭ�ϱ���";
            code.ChannelID = channelEntity;
            code.OrderIndex = 0;
            code.Mo  = "";
            code.MOType = "7";
            code.HasFilters = false;
            code.IsDiable = false;

            return code;
        }
    }
}
