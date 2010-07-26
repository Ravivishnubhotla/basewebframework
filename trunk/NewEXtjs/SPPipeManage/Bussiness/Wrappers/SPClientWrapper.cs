
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
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


        public string UserLoginID
        {
            get
            {
                if (this.UserID != null && this.UserID>0)
                {
                    SystemUserWrapper user = SystemUserWrapper.FindById(this.UserID);

                    if (user != null)
                        return user.UserLoginID;
                }
                return "";
            }
        }



        //public bool SendMsg(string cpid, string mid, string mobile, string port, string ywid, string msg, string linkid, string dest, string price, Hashtable exparams)
        //{
        //    string requesturl = BulidUrl(cpid, mid, mobile, port, ywid, msg, linkid, dest, price, exparams);

        //    string errorMessage = string.Empty;

        //    bool sendOk = SendUrl(requesturl, out errorMessage);

        //    return sendOk;
        //}

        private static bool SendRequest(string requesturl, int timeOut, string okMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);
                    string responseText = sr.ReadToEnd();

                    return responseText.Trim().ToLower().Equals(okMessage);
                }

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }


        //private bool SendUrl(string requesturl, out string errorMessage)
        //{
        //    errorMessage = "";

        //    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);    
        //    webRequest.Timeout = 10000;
        //    HttpWebResponse webResponse = null;                                      
            
        //    try 
        //    { 
        //        if (webResponse.StatusCode == HttpStatusCode.OK)
        //        {
        //            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);
        //            string responseText = sr.ReadToEnd();

        //            return responseText.Trim().ToLower().Equals("ok");
        //        }
        //        else
        //        {
        //            errorMessage = "Error:" + webResponse.StatusCode;
        //            return false;
        //        }

        //    }

        //    catch 
        //    {
        //        errorMessage = "No Connection";
        //        return false; 
        //    }

        //}

        //private string BulidUrl(string cpid, string mid, string mobile, string port, string ywid, string msg, string linkid, string dest, string price, Hashtable exparams)
        //{
        //    NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

        //    //Hashtable values = new Hashtable();

        //    //values.Add("cpid", cpid);
        //    //values.Add("mid", mid);
        //    //values.Add("mobile", mobile);
        //    //values.Add("port", port);
        //    //values.Add("ywid", ywid);
        //    //values.Add("msg", msg);

        //    List<SPSendClientParamsWrapper> clientFieldMappings = this.GetFieldMappings();

        //    foreach (SPSendClientParamsWrapper clientFieldMapping in clientFieldMappings)
        //    {
        //        switch (clientFieldMapping.MappingParams)
        //        {
        //            case "mid":
        //                BulidParams(queryString, clientFieldMapping.Name, mid);
        //                break;
        //            case "mobile":
        //                BulidParams(queryString, clientFieldMapping.Name, mobile);
        //                break;
        //            case "port":
        //                BulidParams(queryString, clientFieldMapping.Name, port);
        //                break;
        //            case "ywid":
        //                BulidParams(queryString, clientFieldMapping.Name, ywid);
        //                break;
        //            case "msg":
        //                BulidParams(queryString, clientFieldMapping.Name, msg);
        //                break;
        //            case "cpid":
        //                BulidParams(queryString, clientFieldMapping.Name, cpid);
        //                break;
        //            case "linkid":
        //                BulidParams(queryString, clientFieldMapping.Name, linkid);
        //                break;
        //            case "dest":
        //                BulidParams(queryString, clientFieldMapping.Name, dest);
        //                break;
        //            case "price":
        //                BulidParams(queryString, clientFieldMapping.Name, price);
        //                break;
        //        }         
        //    }

        //    BulidParams(queryString, exparams);

        //    return string.Format("{0}?{1}", this.RecieveDataUrl, queryString.ToString());
        //}

        private List<SPSendClientParamsWrapper> GetFieldMappings()
        {
           return SPSendClientParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(this.entity));
        }




        //private void BulidParams(NameValueCollection queryString, Hashtable exparams)
        //{
        //    return;
        //}

	    private void BulidParams(NameValueCollection queryString, string key, string value)
	    {
            queryString.Add(key, HttpUtility.UrlEncode(value));
	    }

	    public static List<SPClientWrapper> FindByChannelID(int cid)
	    {
	        return ConvertToWrapperList(businessProxy.FindByChannelID(cid));
	    }

	    public static int GetClientIDByUserID(int userId)
	    {
	        SystemUserWrapper user = SystemUserWrapper.FindById(userId);

	        return ConvertEntityToWrapper(businessProxy.GetClientByUserID(userId)).Id;
	    }


        public void CloneChannelParams(int channelID)
        {
            businessProxy.CloneChannelParams(channelID, this.entity);
        }




	    public bool SendMsg(SPPaymentInfoWrapper spPaymentInfo)
	    {
            string requesturl = BulidUrl(spPaymentInfo);

            string errorMessage = string.Empty;

            bool sendOk = SendRequest(requesturl,10000,"ok", out errorMessage);

            return sendOk;   
	    }

	    private string BulidUrl(SPPaymentInfoWrapper spPaymentInfo)
	    {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            List<SPSendClientParamsWrapper> clientFieldMappings = this.GetFieldMappings();

            foreach (SPSendClientParamsWrapper clientFieldMapping in clientFieldMappings)
            {
                switch (clientFieldMapping.MappingParams)
                {
                    case "mid":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Mid);
                        break;
                    case "mobile":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.MobileNumber);
                        break;
                    case "port":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Port);
                        break;
                    case "ywid":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Ywid);
                        break;
                    case "msg":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Message);
                        break;
                    case "cpid":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Cpid);
                        break;
                    case "linkid":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Linkid);
                        break;
                    case "dest":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Dest);
                        break;
                    case "extendfield1":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField1);
                        break;
                    case "extendfield2":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField2);
                        break;
                    case "extendfield3":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField3);
                        break;
                    case "extendfield4":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField4);
                        break;
                    case "extendfield5":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField5);
                        break;
                    case "extendfield6":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField6);
                        break;
                    case "extendfield7":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField7);
                        break;
                    case "extendfield8":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField8);
                        break;
                    case "extendfield9":
                        BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField9);
                        break;
                }
            }

            return string.Format("{0}?{1}", this.RecieveDataUrl, queryString.ToString());
	    }

	    public bool SendMsgAndUpdate(SPPaymentInfoWrapper spPaymentInfoWrapper)
	    {
	        spPaymentInfoWrapper.SucesssToSend = SendMsg(spPaymentInfoWrapper);

            SPPaymentInfoWrapper.Update(spPaymentInfoWrapper);

            return spPaymentInfoWrapper.SucesssToSend.Value;
	    }
    }
}
