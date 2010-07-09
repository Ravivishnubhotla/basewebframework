// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
	public interface ISPClientServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPClientEntity>
    {
	    List<SPSendClientParamsEntity> GetAllEnableParams(SPClientEntity entity);
	    List<SPClientEntity> FindByChannelID(int cid);
	    SPClientEntity GetClientByUserID(int userId);
    }

    internal partial class SPClientServiceProxy : ISPClientServiceProxy
    {
        public List<SPSendClientParamsEntity> GetAllEnableParams(SPClientEntity entity)
        {
            return this.DataObjectsContainerIocID.SPSendClientParamsDataObjectInstance.GetAllEnableParams(entity);
        }

        public List<SPClientEntity> FindByChannelID(int cid)
        {
            SPChannelEntity channelEntity = this.DataObjectsContainerIocID.SPChannelDataObjectInstance.Load(cid);

            List<SPClientChannelSettingEntity> settings = this.DataObjectsContainerIocID.SPClientChannelSettingDataObjectInstance.GetSettingByChannel(channelEntity);

            List<SPClientEntity> clientEntities = new List<SPClientEntity>();

            foreach (SPClientChannelSettingEntity spClientEntity in settings)
            {
                if(!clientEntities.Contains(spClientEntity.ClinetID))
                {
                    clientEntities.Add(spClientEntity.ClinetID);
                }
            }

            return clientEntities;
        }

        public SPClientEntity GetClientByUserID(int userId)
        {
            return this.SelfDataObj.GetClientByUserID(userId);
        }
    }
}