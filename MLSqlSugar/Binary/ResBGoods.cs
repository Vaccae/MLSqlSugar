using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MLSqlSugar.Binary
{
    public class ResBGoods:BGoods
    {
        [ColumnName("PredictedLabel")]
        public bool isyuce { get; set; }
        /// <summary>
        /// 概率
        /// </summary>
        [ColumnName("Probability")]
        public float Gailv { get; set; }
        /// <summary>
        /// 预测分数
        /// </summary>
        public float Score { get; set; }

    }
}
