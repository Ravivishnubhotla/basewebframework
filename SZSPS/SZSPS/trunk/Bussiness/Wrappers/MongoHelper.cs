using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public static class MongoHelper
    {
        public static Document FindOne(string mongoConnsring, string mongoDbName, string mongoCollectionName, object spec)
        {
            using (Mongo mongo = new Mongo(mongoConnsring))
            {
                //获取databaseName对应的数据库，不存在则自动创建
                MongoDatabase mongoDatabase = mongo.GetDatabase(mongoDbName) as MongoDatabase;

                //获取collectionName对应的集合，不存在则自动创建
                MongoCollection<Document> mongoCollection = mongoDatabase.GetCollection<Document>(mongoCollectionName) as MongoCollection<Document>;

                //链接数据库
                mongo.Connect();

                ////在集合中查找键值对为ID=1的文档对象
                Document docFind = mongoCollection.FindOne(spec);

                mongo.Disconnect();
 
                return docFind;
            }
        }

    }
}
