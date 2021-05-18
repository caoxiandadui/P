using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OMEN.Core.Common
{
    public class DapperHelper
    {
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static object Scalar(string sql)
        {
            using (IDbConnection conn=new SqlConnection(ConfigurationManager.conn))
            {
                object result = conn.ExecuteScalar(sql);
                return result;
            }
        }
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.conn))
            {
                var result = conn.Query<T>(sql).ToList();
                return result;
            }
        }
        /// <summary>
        /// 添加、删除、修改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Execute(string sql)
        {
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.conn))
            {
                var result = conn.Execute(sql);
                return result;
            }
        }
        public int Delete(string sql)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(sql);
                return result;
            }
        }

        //添加
        public int Add(string sql)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(sql);
                return result;
            }
        }
        public int Upt(string sql)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(sql);
                return result;
            }
        }
    }
}
