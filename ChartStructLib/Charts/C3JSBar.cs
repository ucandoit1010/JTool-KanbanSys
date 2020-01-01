using System;
using System.Collections.Generic;
using System.Data;
using ChartStructLib.Common;

namespace ChartStructLib.Charts
{
    public class C3JSBar : ChartBase
    {
        public DataTable Data { get; set; }
        public string ChartJson { get; set; }

        public C3JSBar(DataTable table, string chartJson)
        {
            Data = table;
            ChartJson = chartJson;
        }

        public override string Generate(string[] cols, string catalog)
        {
            throw new NotImplementedException();
        }

    }
}
