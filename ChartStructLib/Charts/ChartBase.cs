using ChartStructLib.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace ChartStructLib.Charts
{
    public abstract class ChartBase
    {
        public string ChartJSONContent { get; set; }



        /// <summary>
        /// 產生JSON
        /// </summary>
        /// <returns></returns>
        public abstract string Generate(string[] cols , string catalog);
    }
}
