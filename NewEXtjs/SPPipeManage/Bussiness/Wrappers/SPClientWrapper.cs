
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPClientWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientWrapper obj)
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

        public static void Delete(SPClientWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPClientWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public bool SendMsg(string cpid, string mid, string mobile, string port, string ywid, string msg,Hashtable exparams)
	    {            
            string requesturl = BulidUrl(cpid, mid, mobile, port, ywid, msg, exparams);

	        string errorMessage = string.Empty;

            bool sendOk = SendUrl(requesturl, out errorMessage);

            return sendOk;
	    }

	    private bool SendUrl(string requesturl, out string errorMessage)
	    {
	        errorMessage = "";

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);    
            webRequest.Timeout = 60000;
	        HttpWebResponse webResponse = null;                                      
            
            try 
            { 
                webResponse = (HttpWebResponse)webRequest.GetResponse();


                //�ж�HTTP��Ӧ״̬ 
                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    errorMessage = "Error:" + webResponse.StatusCode;
                    return false;
                }


                string content = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return true;

            }

            catch 
            {
                errorMessage = "No Connection";
                return false; 
            }

	    }

	    private string BulidUrl(string cpid, string mid, string mobile, string port, string ywid, string msg, Hashtable exparams)
	    {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            BulidParams(queryString,"cpid", cpid);
            BulidParams(queryString, "mid", mid);
            BulidParams(queryString, "mobile", mobile);
            BulidParams(queryString, "port", port);
            BulidParams(queryString, "ywid", ywid);
            BulidParams(queryString, "msg", msg);

            BulidParams(queryString, exparams);

	        return string.Format("{0}?{1}", this.RecieveDataUrl, queryString.ToString());
	    }

	    private void BulidParams(NameValueCollection queryString, Hashtable exparams)
	    {
	        return;
	    }

	    private void BulidParams(NameValueCollection queryString, string key, string value)
	    {
            queryString.Add(key, HttpUtility.UrlEncode(value));
	    }
    }
}