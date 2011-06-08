
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPSStatePaymentInfoWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPSStatePaymentInfoWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPSStatePaymentInfoWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPSStatePaymentInfoWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SPSStatePaymentInfoWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPSStatePaymentInfoWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPSStatePaymentInfoWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPSStatePaymentInfoWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPSStatePaymentInfoWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPSStatePaymentInfoEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPSStatePaymentInfoWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPSStatePaymentInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPSStatePaymentInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPSStatePaymentInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public bool InsertPayment(out PaymentInfoInsertErrorType errorType)
	    {
            errorType = PaymentInfoInsertErrorType.NoError;

            if (this.CheckHasLinkIDAndChannelID())
            {
                errorType = PaymentInfoInsertErrorType.RepeatLinkID;

                return false;
            }

            try
            {
                businessProxy.Save(this.entity);
                return true;
            }
            catch (Exception ex)
            {
                Exception innerEx = ex;

                while (innerEx.InnerException != null)
                {
                    innerEx = innerEx.InnerException;
                }

                if (innerEx is SqlException && ((SqlException)innerEx).Number == 2601)
                {
                    errorType = PaymentInfoInsertErrorType.RepeatLinkID;
                    return false;
                }

                throw ex;
            }


            //return businessProxy.InsertPayment(this.entity, uniqueKeyNames, out errorType);
	    }

	    public static SPSStatePaymentInfoWrapper FindByChannelIDAndLinkID(int channelID, string linkid)
	    {
            return ConvertEntityToWrapper(businessProxy.FindByChannelIDAndLinkID(channelID, linkid));
	    }

        public bool CheckHasLinkIDAndChannelID()
        {
            return businessProxy.CheckHasLinkIDAndChannelID(this.entity);
        }


    }
}
