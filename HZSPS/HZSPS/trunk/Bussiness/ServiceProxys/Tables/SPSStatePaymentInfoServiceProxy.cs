// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using Spring.Transaction.Interceptor;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
	public interface ISPSStatePaymentInfoServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPSStatePaymentInfoEntity> ,ISPSStatePaymentInfoServiceProxyDesigner
    {
	    bool InsertPayment(SPSStatePaymentInfoEntity entity, List<string> uniqueKeyNames, out PaymentInfoInsertErrorType errorType);
	    SPSStatePaymentInfoEntity FindByChannelIDAndLinkID(int channelId, string linkid);
        bool CheckHasLinkIDAndChannelID(SPSStatePaymentInfoEntity entity);
    }

    internal partial class SPSStatePaymentInfoServiceProxy : ISPSStatePaymentInfoServiceProxy
    {

        [Transaction(IsolationLevel.ReadUncommitted)]
        public bool CheckHasLinkIDAndChannelID(SPPaymentInfoEntity paymentInfo)
        {
            SPPaymentInfoEntity spPaymentInfoEntity = this.DataObjectsContainerIocID.SPPaymentInfoDataObjectInstance.CheckChannleLinkIDIsExist(paymentInfo.ChannelID, paymentInfo);

            return (spPaymentInfoEntity != null);
        }
   


        [Transaction(ReadOnly = false)]
        public bool InsertPayment(SPSStatePaymentInfoEntity statePaymentInfoEntity, List<string> uniqueKeyNames, out PaymentInfoInsertErrorType errorType)
        {
            errorType = PaymentInfoInsertErrorType.NoError;

            SPSStatePaymentInfoEntity spPaymentInfoEntity = this.DataObjectsContainerIocID.SPSStatePaymentInfoDataObjectInstance.CheckChannleLinkIDIsExist(statePaymentInfoEntity.ChannelID.Value, statePaymentInfoEntity, uniqueKeyNames);

            if (spPaymentInfoEntity != null)
            {
                errorType = PaymentInfoInsertErrorType.RepeatLinkID;

                return false;
            }

            this.DataObjectsContainerIocID.SPSStatePaymentInfoDataObjectInstance.Save(statePaymentInfoEntity);

            return true;
        }

        public SPSStatePaymentInfoEntity FindByChannelIDAndLinkID(int channelId, string linkid)
        {
            return this.DataObjectsContainerIocID.SPSStatePaymentInfoDataObjectInstance.FindByChannelIDAndLinkID(channelId, linkid);
        }

        [Transaction(IsolationLevel.ReadUncommitted)]
        public bool CheckHasLinkIDAndChannelID(SPSStatePaymentInfoEntity paymentInfo)
        {
            SPSStatePaymentInfoEntity spPaymentInfoEntity = this.DataObjectsContainerIocID.SPSStatePaymentInfoDataObjectInstance.FindByChannelIDAndLinkID(paymentInfo.ChannelID.Value, paymentInfo.Linkid);

            return (spPaymentInfoEntity != null);
        }
    }
}
