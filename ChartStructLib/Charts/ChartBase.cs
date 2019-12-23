using System;


namespace ChartStructLib.Charts
{
    public abstract class ChartBase
    {
        public const string dataTag = "@Data";
        public const string catelogTag = "@Catelog";


        public abstract string Generate(string axisColName, string valueColName);

    }
}
