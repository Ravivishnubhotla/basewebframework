// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using Spring.Transaction.Interceptor;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
    public interface ISPClientServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPClientEntity>, ISPClientServiceProxyDesigner
    {
	    List<SPSendClientParamsEntity> GetAllEnableParams(SPClientEntity entity);
	    List<SPClientEntity> FindByChannelID(int cid);
	    SPClientEntity GetClientByUserID(int userId);
        void CloneChannelParams(int channelId, SPClientEntity entity);
 
        List<SPClientEntity> GetAllDefaultClient();
        List<SPClientEntity> FindAllNotInClientGroup(int clientGroupId);
        void QuickAdd(string loginId, string code, SPChannelEntity channelEntity, int mainloginuserId, List<CodeUserID> codeUserIds, string channelCode, int orderIndex, bool hasSubCode, string codeType, string allowAndDisableArea, string getway, string dayLimit, string monthLimit, string sendText, decimal defaultprice);
 
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

        [Transaction(ReadOnly = false)]
        public void CloneChannelParams(int channelId, SPClientEntity entity)
        {
            SPChannelEntity channelEntity = this.DataObjectsContainerIocID.SPChannelDataObjectInstance.Load(channelId);

            List<SPChannelParamsEntity> channelParamsEntities =
                this.DataObjectsContainerIocID.SPChannelParamsDataObjectInstance.GetAllEnableParams(channelEntity);


            List<SPSendClientParamsEntity> sendClientParamsEntities =
                this.DataObjectsContainerIocID.SPSendClientParamsDataObjectInstance.GetAllEnableParams(entity);

            foreach (SPSendClientParamsEntity spSendClientParamsEntity in sendClientParamsEntities)
            {
                this.DataObjectsContainerIocID.SPSendClientParamsDataObjectInstance.Delete(spSendClientParamsEntity);
            }

            foreach (SPChannelParamsEntity channelParamsEntity in channelParamsEntities)
            {
                SPSendClientParamsEntity spSendClientParamsEntity = new SPSendClientParamsEntity();
                spSendClientParamsEntity.ClientID = entity;
                spSendClientParamsEntity.Name = channelParamsEntity.Name;
                spSendClientParamsEntity.Title = channelParamsEntity.Title;
                spSendClientParamsEntity.Description = channelParamsEntity.Description;
                spSendClientParamsEntity.IsEnable = channelParamsEntity.IsEnable;
                spSendClientParamsEntity.IsRequired = channelParamsEntity.IsRequired;
                spSendClientParamsEntity.MappingParams = channelParamsEntity.ParamsMappingName;
                this.DataObjectsContainerIocID.SPSendClientParamsDataObjectInstance.Save(spSendClientParamsEntity);
            }
        }

        private void SetClientPrice(int clientid, decimal price)
        {
            SPClientPriceEntity spClientPrice = new SPClientPriceEntity();
            spClientPrice.SPClientID = clientid;
            spClientPrice.Price = price;
            spClientPrice.SPClientGroupID = 0;
            this.DataObjectsContainerIocID.SPClientPriceDataObjectInstance.Save(spClientPrice);
        }



 

        public List<SPClientEntity> GetAllDefaultClient()
        {
            return this.SelfDataObj.GetAllDefaultClient();
        }

        public List<SPClientEntity> FindAllNotInClientGroup(int clientGroupId)
        {
            return this.SelfDataObj.FindAllNotInClientGroup(this.DataObjectsContainerIocID.SPClientGroupDataObjectInstance.Load(clientGroupId));
        }

 

        public void QuickAdd(string loginId, string code, SPChannelEntity channelEntity, int mainloginuserId, List<CodeUserID> codeUserIds, string channelCode, int orderIndex, bool hasSubCode, string codeType, string allowAndDisableArea, string getway, string dayLimit, string monthLimit, string sendText, decimal defaultprice)
        {
            SPClientEntity mainclientEntity = new SPClientEntity();
            mainclientEntity.Name = channelEntity.Name + loginId;
            mainclientEntity.Description = channelEntity.Name + loginId;
            mainclientEntity.UserID = mainloginuserId;
            mainclientEntity.IsDefaultClient = false;
            mainclientEntity.Alias = "";

            this.DataObjectsContainerIocID.SPClientDataObjectInstance.Save(mainclientEntity);

            SetClientPrice(mainclientEntity.Id,defaultprice);

            SPClientChannelSettingEntity mainChannelClient = new SPClientChannelSettingEntity();

            mainChannelClient.Name = channelEntity.Name + loginId;
            mainChannelClient.Description = channelEntity.Name + loginId;
            mainChannelClient.ChannelID = channelEntity;
            mainChannelClient.ClinetID = mainclientEntity;
            mainChannelClient.InterceptRate = 0;
            mainChannelClient.OrderIndex = orderIndex;
            mainChannelClient.UpRate = 0;
            mainChannelClient.DownRate = 0;
            mainChannelClient.CommandColumn = "ywid";
            mainChannelClient.DefaultPrice = defaultprice;
            if (codeType == "1")
            {
                mainChannelClient.CommandType = "1";
            }
            else if (codeType == "2")
            {
                mainChannelClient.CommandType = "3";
            }
            else
            {
                mainChannelClient.CommandType = "3";
            }
            mainChannelClient.CommandCode = code;
            mainChannelClient.SyncData = false;
            mainChannelClient.ChannelCode = channelCode;
            mainChannelClient.Disable = false;
            mainChannelClient.AllowAndDisableArea = allowAndDisableArea;
            mainChannelClient.Getway = getway;
            mainChannelClient.DayLimit = dayLimit;
            mainChannelClient.MonthLimit = monthLimit;
            mainChannelClient.SendText = sendText;
           



            this.DataObjectsContainerIocID.SPClientChannelSettingDataObjectInstance.Save(mainChannelClient);

            foreach (CodeUserID codeUserId in codeUserIds)
            {
                SPClientEntity subClientEntity = new SPClientEntity();
                subClientEntity.Name = channelEntity.Name + loginId + codeUserId.Code;
                subClientEntity.Description = channelEntity.Name + loginId + codeUserId.Code;
                subClientEntity.UserID = codeUserId.UserID;
                subClientEntity.IsDefaultClient = false;
                subClientEntity.Alias = "";



                this.DataObjectsContainerIocID.SPClientDataObjectInstance.Save(subClientEntity);

                SetClientPrice(subClientEntity.Id, defaultprice);


                SPClientChannelSettingEntity subChannelClient = new SPClientChannelSettingEntity();

                subChannelClient.Name = channelEntity.Name + loginId + codeUserId.Code;
                subChannelClient.Description = channelEntity.Name + loginId + codeUserId.Code;
                subChannelClient.ChannelID = channelEntity;
                subChannelClient.ClinetID = subClientEntity;
                subChannelClient.InterceptRate = 0;
                subChannelClient.OrderIndex = orderIndex + 1;
                subChannelClient.UpRate = 0;
                subChannelClient.DownRate = 0;
                subChannelClient.CommandColumn = "ywid";
                subChannelClient.CommandType = "3";
                subChannelClient.CommandCode = code + codeUserId.Code;
                subChannelClient.SyncData = false;
                subChannelClient.ChannelCode = channelCode;
                subChannelClient.Disable = false;
                subChannelClient.AllowAndDisableArea = allowAndDisableArea;
                subChannelClient.Getway = getway;
                subChannelClient.DayLimit = dayLimit;
                subChannelClient.MonthLimit = monthLimit;
                subChannelClient.SendText = sendText;
                subChannelClient.DefaultPrice = defaultprice;
                this.DataObjectsContainerIocID.SPClientChannelSettingDataObjectInstance.Save(subChannelClient);
            }
        }

        public SPClientEntity GetClientByUserID(int userId)
        {
            return this.SelfDataObj.GetClientByUserID(userId);
        }
    }
}
