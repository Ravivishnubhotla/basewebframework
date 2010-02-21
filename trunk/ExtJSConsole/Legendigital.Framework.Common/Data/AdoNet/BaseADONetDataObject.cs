using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Spring.Data.Common;
using Spring.Data.Generic;


namespace Legendigital.Framework.Common.Data.AdoNet
{
    public class BaseADONetDataObject : AdoDaoSupport
    {
        /// <summary>
        /// 创建IDbDataParameter参数
        /// </summary>
        /// <returns></returns>
        public System.Data.IDbDataParameter CreateNewDbParameter()
        {
            return this.DbProvider.CreateParameter();
        }
        /// <summary>
        /// 创建DbParameters参数
        /// </summary>
        /// <returns></returns>
        public DbParameters CreateNewDbParameters()
        {
            return new DbParameters(this.DbProvider);
        }
        /// <summary>
        /// 执行 SQL Command 返回DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            return ExecuteDataSet(commandText, commandType, CreateNewDbParameters());
        }
        /// <summary>
        /// 执行 SQL Command 返回DataSet(可输入参数)
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(string commandText, CommandType commandType, DbParameters parameters)
        {
            var ds = new DataSet();
            this.AdoTemplate.ClassicAdoTemplate.DataSetFillWithParameters(ds , commandType , commandText, parameters);
            return ds;
        }
        /// <summary>
        /// 执行 SQL Command 返回DataSet(可输入参数,并对结果集分页)
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(string commandText, CommandType commandType, DbParameters parameters, string tableName, int pageIndex, int pageSize)
        {
            return this.AdoTemplate.Execute<DataSet>(delegate(DbCommand cmd)
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                for (int i = 0; i < parameters.Count; i++)
                {
                    IDbDataParameter obj = this.CreateNewDbParameter();
                    obj.ParameterName = parameters[i].ParameterName;
                    obj.DbType = parameters[i].DbType;
                    obj.Direction = parameters[i].Direction;
                    obj.Value = parameters[i].Value;
                    cmd.Parameters.Add(obj);
                }
                var adapter = this.DbProvider.CreateDataAdapter() as DbDataAdapter;
                if (adapter==null)
                    throw new Exception(" Not support page query. ");
                adapter.SelectCommand = cmd;
                var ds = new DataSet();
                adapter.Fill(ds, (pageIndex - 1) * pageSize, pageSize, tableName);
                return ds;
            });
        }
        /// <summary>
        /// 执行 SQL Command 返回标量单值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual T ExecuteScalar<T>(string commandText, CommandType commandType, DbParameters parameters)
        {
            return (T) ExecuteScalar(commandText, commandType, parameters);
        }
        /// <summary>
        /// 执行 SQL Command 返回标量单值(可输入参数)
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(string commandText, CommandType commandType, DbParameters parameters)
        {
            return this.AdoTemplate.Execute(delegate(DbCommand cmd)
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                for (int i = 0; i < parameters.Count; i++)
                {
                    IDbDataParameter obj = this.CreateNewDbParameter();
                    obj.ParameterName = parameters[i].ParameterName;
                    obj.DbType = parameters[i].DbType;
                    obj.Direction = parameters[i].Direction;
                    obj.Value = parameters[i].Value;
                    cmd.Parameters.Add(obj);
                }
                return cmd.ExecuteScalar();
            });
        }
        /// <summary>
        /// 执行 SQL Command 返回标量单值(可输入参数) 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual IDataReader ExcuteDataReader(string commandText, CommandType commandType, DbParameters parameters)
        {
            IDbCommand cmd = GetCommandByCommandTextAndCommandTypeAndParameterList(commandText, commandType, parameters);
            return cmd.ExecuteReader();
        }

        public virtual IDataReader ExcuteDataReader(string commandText, CommandType commandType)
        {
            return ExcuteDataReader(commandText, commandType, CreateNewDbParameters());
        }

        protected void AddParameterToCmmand(IDbCommand cmd, IDataParameter parameter)
        {
            cmd.Parameters.Add(parameter);
        }

        protected IDbCommand GetCommandByCommandTextAndCommandTypeAndParameterList(string commandText, CommandType commandType, DbParameters parameters)
        {
            IDbCommand cmd = this.DbProvider.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            for (int i = 0; i < parameters.Count; i++)
            {
                AddParameterToCmmand(cmd, parameters[i]);              
            }
            return cmd;
        }

        protected IDbCommand GetCommandByCommandTextAndCommandTypeAndParameterList(string commandText, CommandType commandType)
        {
            return GetCommandByCommandTextAndCommandTypeAndParameterList(commandText, commandType,this.CreateNewDbParameters());
        }

        public DataTable GetSchema(string tableName)
        {
            string getSchemaSql = string.Format("select * from {0} where 1=0 ", tableName);
            using (IDbCommand cmd = GetCommandByCommandTextAndCommandTypeAndParameterList(tableName, CommandType.TableDirect))
            {
                using (IDbConnection conn = this.DbProvider.CreateConnection())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    DataTable dt = null;
                    using (IDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        dt = dr.GetSchemaTable();
                    }
                    conn.Close();
                    return dt;
                }

            }
        }
    }
}
