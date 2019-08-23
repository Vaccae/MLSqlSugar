using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLSqlSugar.SqlSugar;
using SqlSugar;

namespace MLSqlSugar.Multiclass
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public class MultiDbApi
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Goods> GetMultiData()
        {
            IEnumerable<Goods> goods;
            SqlSugarClient db = DbConnect.Connect();

            goods = db.SqlQueryable<dynamic>("select incode,fname," +
                                             "left(stype,3) as stype " +
                                             "from tbSpXinXi ")
                .Select<Goods>().OrderBy(" newid() ").ToPageList(1, 1000);

            return goods;
        }

        public static string GetStypeName(string code)
        {
            SqlSugarClient db = DbConnect.Connect();
            var res = db.Ado.GetString($"select sdesc from tbSpPlXinXi where stype='{code}' ");

            return (string) res;
        }
    }
}
