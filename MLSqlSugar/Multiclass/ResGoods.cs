using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MLSqlSugar.Multiclass
{
    public class ResGoods
    {
        [ColumnName("PredictedLabel")]
        public string stype { get; set; }
        [ColumnName("Probability")]
        public float Percent { get; set; }

        public float[] Score { get; set; }
    }
}
