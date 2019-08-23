using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLSqlSugar.Multiclass;
using MLSqlSugar.SqlSugar;
using SqlSugar;

namespace MLSqlSugar.Binary
{
   public class binaryDBApi
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public static List<BGoods> GetBinaryData()
        {
            List<BGoods> goods;
            SqlSugarClient db = DbConnect.Connect();

            goods = db.SqlQueryable
                    <dynamic>("select fname," +
                              "(case left(stype,1) when '1' then 1 " +
                              "else 0 end) as stype from tbSpXinXi ")
                .Select<BGoods>().OrderBy(" newid() ")
                .ToPageList(1,1300);

            return goods;
        }


        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public static List<BGoods> GetBinaryUnionData()
        {
            List<BGoods> goods;
            SqlSugarClient db = DbConnect.Connect();

            goods = db.UnionAll<dynamic>(db.SqlQueryable<dynamic>(
                            "select fname,1 as stype from tbSpXinXi")
                        .Where(" left(stype,1)='1'")
                        .Take(600),
                    db.SqlQueryable<dynamic>(
                            "select fname,0 as stype from tbSpXinXi")
                        .Where(" left(stype,1)<>'1'").Take(600))
                .Select<BGoods>().OrderBy(" newid()").ToList();

            return goods;
        }
    }
}
