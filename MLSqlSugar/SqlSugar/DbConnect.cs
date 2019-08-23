using System;
using System.Linq;
using SqlSugar;

namespace MLSqlSugar.SqlSugar
{
    /// <summary>
    /// 获取数据库连接字符串
    /// WebAPi项目中的TollStation.ini文件为数据库的连接参数
    /// </summary>
    public class DbConnect
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string _connstr = "";

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        private static string GetConnstr()
        {
            if (_connstr != "") return _connstr;

            //读取SQL的各个参数
            string server = ".";
            string database = "SMJXC_STD80_GS";
            string uid = "sa";
            string pwd = "sumsoft";

            _connstr = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database;

            return _connstr;
        }

        /// <summary>
        /// 分页查询每页显示数
        /// </summary>
        public static int PageSize = 50;

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connstr"></param>
        public static SqlSugarClient Connect()
        {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = GetConnstr(),
                    DbType = global::SqlSugar.DbType.SqlServer, //设置数据库类型
                    IsAutoCloseConnection = true, //自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute, //从实体特性中读取主键自增列信息
//                    InitKeyType = InitKeyType.SystemTable,
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        DataInfoCacheService = new HttpRuntimeCache() //RedisCache是继承ICacheService自已实现的一个类
                    }
                });

            //用来打印Sql方便你调式    
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);
                Console.WriteLine(db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };

            return db;
        }


    }
}
