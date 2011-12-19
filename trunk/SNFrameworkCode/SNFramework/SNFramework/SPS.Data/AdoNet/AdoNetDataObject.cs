// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Spring.Data.Common;

namespace SPS.Data.AdoNet
{
 
    public partial class AdoNetDataObject
    {

        #region Common

        private T GetScalarFromDataSet<T>(DataTable dt, int columnIndex)
        {
            DataRow dr = GetFristDataRowFromDataTable(dt);

            if (dr != null && dr.Table.Columns.Count >= columnIndex + 1)
                return (T)dr[columnIndex];
            return default(T);
        }

        private T GetScalarFromDataSet<T>(DataSet ds, int columnIndex)
        {
            return GetScalarFromDataSet<T>(GetDataTableFromDataSet(ds), columnIndex);
        }

        private DataRow GetFristDataRowFromDataSet(DataSet ds)
        {
            return GetFristDataRowFromDataTable(GetDataTableFromDataSet(ds));
        }

        private DataRow GetFristDataRowFromDataTable(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        private DataTable GetDataTableFromDataSet(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #endregion



        public void UpdateUrlFailedSend(int recordId, string url,string errMessage)
        {
            if(errMessage.Length>3000)
            {
                errMessage = errMessage.Substring(0, 2999);
            }


            string sql = "update SPRecordExtendInfo set sSycnDataUrl=@sSycnDataUrl,sSycnDataFailedMessage=@Error where RecordID=@ID ;";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("sSycnDataUrl", url);

            dbParameters.AddWithValue("RecordID", recordId);

            dbParameters.AddWithValue("Error", errMessage);

            this.ExecuteNoQuery(sql, CommandType.Text, dbParameters);

        }


        public void UpdateUrlSuccessSend(int recordId, string url)
        {

            string sql = "update SPRecord set IsSycnSuccessed =1  where ID=@ID and IsIntercept=0 and IsSycnToClient=1 and IsStatOK=1;" +
                         "update SPRecordExtendInfo set  sSycnDataUrl=@sSycnDataUrl,sSycnDataFailedMessage='' where RecordID=@ID ;";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("sSycnDataUrl", url);

            dbParameters.AddWithValue("RecordID", recordId);

            this.ExecuteNoQuery(sql, CommandType.Text, dbParameters);
 
        }
    }
}