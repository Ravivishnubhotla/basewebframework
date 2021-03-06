// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using LD.SPPipeManage.Data.AdoNet;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
	public interface ISPClientGroupServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPClientGroupEntity>
    {
	    SPClientGroupEntity GetIDByUserID(int userId);
	    int QueryDataCount(DateTime startDate, DateTime endDate, int? channelClientId, bool afterIntercept, int clientGroupID,string province,string mo,string spcode,bool hassubcode);

	    int QueryPhoneCount(DateTime startDate, DateTime endDate, int? channelClientId, bool afterIntercept,
	                        int clientGroupID, string province, string mo, string spcode, bool hassubcode);
    }

    internal partial class SPClientGroupServiceProxy : ISPClientGroupServiceProxy
    {
        public SPClientGroupEntity GetIDByUserID(int userId)
        {
            return this.SelfDataObj.GetByUserID(userId);
        }

        public int QueryDataCount(DateTime startDate, DateTime endDate, int? channelClientId, bool afterIntercept, int clientGroupID,string province, string mo, string spcode, bool hassubcode)
        {
            if(afterIntercept)
            {
                return this.AdoNetDb.GetAllRecordCount(startDate, endDate, null, clientGroupID, channelClientId, mo, spcode, hassubcode,
                                                       province, AdoNetDataObject.DataType_Down);
            }
            else
            {
                return this.AdoNetDb.GetAllRecordCount(startDate, endDate, null, clientGroupID, channelClientId, mo, spcode, hassubcode,
                                                      province, AdoNetDataObject.DataType_All);               
            }
        }

        public int QueryPhoneCount(DateTime startDate, DateTime endDate, int? channelClientId, bool afterIntercept, int clientGroupID, string province, string mo, string spcode, bool hassubcode)
        {
            if (afterIntercept)
            {
                return this.AdoNetDb.GetPhoneCount(startDate, endDate, null, clientGroupID, channelClientId, mo, spcode, hassubcode,
                                                       province, AdoNetDataObject.DataType_Down);
            }
            else
            {
                return this.AdoNetDb.GetPhoneCount(startDate, endDate, null, clientGroupID, channelClientId, mo, spcode, hassubcode,
                                                      province, AdoNetDataObject.DataType_All);
            }
        }
    }
}
