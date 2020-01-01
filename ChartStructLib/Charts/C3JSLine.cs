using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;


namespace ChartStructLib.Charts
{
    public class C3JSLine : ChartBase
    {
        public DataTable Data { get; set; }
        public string ChartJson { get; set; }
        public ChartStruct chartStruct { get; set; }

        public C3JSLine(DataTable table, string chartJson)
        {
            Data = table;
            ChartJson = chartJson;
        }

        public override string Generate(string[] cols, string catalog)
        {
            if (Data == null || Data.Rows.Count == 0)
            {
                return string.Empty;
            }

            chartStruct = new ChartStruct();
            chartStruct.columns = new List<List<object>>();
            List<object> objList = null;
            chartStruct.axis = new Common.Axis();
            chartStruct.axis.x = new Common.X();
            chartStruct.axis.x.type = catalog;

            string[] cataAry = Data.AsEnumerable().Select(d => d.Field<string>(catalog)).ToArray();
            chartStruct.axis.x.categories = string.Join(",", cataAry);
            
            chartStruct.axis.y = new Common.Y();
            chartStruct.axis.y.label = string.Empty;

            foreach (string col in cols)
            {
                objList = new List<object>();
                objList.Insert(0, col);
                foreach (DataRow row in Data.Rows)
                {
                    objList.Add(row[col].ToString());
                }

                chartStruct.columns.Add(objList);
            }

            string json = JsonConvert.SerializeObject(new { data = chartStruct });

            return ChartJson.Replace("@Content", json);
        }

    }
}
