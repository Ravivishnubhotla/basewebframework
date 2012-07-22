using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public static class MongoDbData
    {
        //链接字符串
        private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["dbconnstring"];
        //数据库名
        private static string databaseName = System.Configuration.ConfigurationManager.AppSettings["databaseName"];
        //集合名
        private static string collectionName = System.Configuration.ConfigurationManager.AppSettings["collectionName"];


        public static PhoneAreaInfo GetPhoneAreaInfo(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            if (phoneNumber.Length < 7)
                return null;

            Document document = MongoHelper.FindOne(connectionString, databaseName, collectionName,
                                                    new Document
                                                        {
                                                            {"PhonePrefix", phoneNumber.Substring(0, 7)}
                                                        });

            if (document == null)
                return null;

            PhoneAreaInfo phoneAreaInfo = new PhoneAreaInfo();
            phoneAreaInfo.Province = document["Province"].ToString();
            phoneAreaInfo.City = document["City"].ToString();
            phoneAreaInfo.MobileOperators = document["OperatorType"].ToString();
            return phoneAreaInfo;

        }
    }
}
