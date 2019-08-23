using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using SqlSugar;

namespace MLSqlSugar.Binary
{
    public class BGoods
    {
        public string fname { get; set; }
        [ColumnName("Label"),SugarColumn(ColumnName = "stype")]
        public bool isshengxian { get; set; }
    }
}
