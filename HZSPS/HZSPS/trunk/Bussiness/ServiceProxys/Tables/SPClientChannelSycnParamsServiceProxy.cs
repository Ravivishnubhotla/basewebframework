// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using Spring.Transaction.Interceptor;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
    public interface ISPClientChannelSycnParamsServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPClientChannelSycnParamsEntity>, ISPClientChannelSycnParamsServiceProxyDesigner
    {
        void PatchAdd(int channleClientId);
    }

    internal partial class SPClientChannelSycnParamsServiceProxy : ISPClientChannelSycnParamsServiceProxy
    {
        [Transaction(ReadOnly=false)]
        public void PatchAdd(int channleClientId)
        {
            SPClientChannelSettingEntity spClientChannelSettingEntity =
                this.DataObjectsContainerIocID.SPClientChannelSettingDataObjectInstance.Load(channleClientId);

            List<SPClientChannelSycnParamsEntity> paramsEntities =
                this.SelfDataObj.GetList_By_SPClientChannelSettingEntity(spClientChannelSettingEntity);


            foreach (SPClientChannelSycnParamsEntity paramsEntity in paramsEntities)
            {
                this.DataObjectsContainerIocID.SPClientChannelSycnParamsDataObjectInstance.Delete(paramsEntity);
            }

            SPClientChannelSycnParamsEntity moParamsEntity = new SPClientChannelSycnParamsEntity();

            moParamsEntity.ClientChannelSettingID = spClientChannelSettingEntity;
            moParamsEntity.Name = "mo";
            moParamsEntity.Title = "mo";
            moParamsEntity.Description = "上行内容";
            moParamsEntity.IsEnable = true;
            moParamsEntity.IsRequired = true;
            moParamsEntity.MappingParams = "ywid";
            
            this.DataObjectsContainerIocID.SPClientChannelSycnParamsDataObjectInstance.Save(moParamsEntity);
			
			SPClientChannelSycnParamsEntity linkidParamsEntity = new SPClientChannelSycnParamsEntity();

            linkidParamsEntity.ClientChannelSettingID = spClientChannelSettingEntity;
            linkidParamsEntity.Name = "linkid";
            linkidParamsEntity.Title = "linkid";
            linkidParamsEntity.Description = "唯一标识";
            linkidParamsEntity.IsEnable = true;
            linkidParamsEntity.IsRequired = true;
            linkidParamsEntity.MappingParams = "linkid";
            
            this.DataObjectsContainerIocID.SPClientChannelSycnParamsDataObjectInstance.Save(linkidParamsEntity);
			
			SPClientChannelSycnParamsEntity mobileParamsEntity = new SPClientChannelSycnParamsEntity();

            mobileParamsEntity.ClientChannelSettingID = spClientChannelSettingEntity;
            mobileParamsEntity.Name = "mobile";
            mobileParamsEntity.Title = "mobile";
            mobileParamsEntity.Description = "手机号码";
            mobileParamsEntity.IsEnable = true;
            mobileParamsEntity.IsRequired = true;
            mobileParamsEntity.MappingParams = "mobile";
            
            this.DataObjectsContainerIocID.SPClientChannelSycnParamsDataObjectInstance.Save(mobileParamsEntity);
			
			
			SPClientChannelSycnParamsEntity spCodeParamsEntity = new SPClientChannelSycnParamsEntity();

            spCodeParamsEntity.ClientChannelSettingID = spClientChannelSettingEntity;
            spCodeParamsEntity.Name = "spCode";
            spCodeParamsEntity.Title = "spCode";
            spCodeParamsEntity.Description = "通道号码";
            spCodeParamsEntity.IsEnable = true;
            spCodeParamsEntity.IsRequired = true;
            spCodeParamsEntity.MappingParams = "cpid";
            
            this.DataObjectsContainerIocID.SPClientChannelSycnParamsDataObjectInstance.Save(spCodeParamsEntity);


        }
    }
}
