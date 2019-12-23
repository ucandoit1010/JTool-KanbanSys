using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ChartStructLib.Charts
{
    public class C3JSLine : ChartBase
    {
        public DataTable Data { get; set; }
        public string ChartJson { get; set; }

        public C3JSLine(DataTable table, string chartJson)
        {
            Data = table;
            ChartJson = chartJson;
        }

        public override string Generate(string axisColName , string valueColName)
        {
            string dataStr = string.Format("'{0}'", valueColName);
            string script = ChartJson;

            string catalogStr = ParseDataAxis(axisColName);

            if (Data != null || Data.Rows.Count > 0)
            {
                foreach (DataRow row in Data.Rows)
                {
                    dataStr += "," + row[valueColName].ToString();
                }
            }

            script = script.Replace(catelogTag, catalogStr);

            if (Data != null || Data.Rows.Count > 0)
            {
                script = script.Replace(dataTag, dataStr);
            }
            
            return script;
        }


        /// <summary>
        /// X軸
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        private string ParseDataAxis(string colName)
        {
            List<string> dataList = Data.AsEnumerable().Select(c => c.Field<string>(colName)).ToList();
            string catalogStr = string.Join(",", dataList.Select(c => string.Format("'{0}'", c.ToString())).ToArray());

            return catalogStr;
        }

    }
}
