using System;
using System.Collections.Generic;
using ModelLib.Models;
using System.Data;

namespace ModelLib.DAL
{
    public interface IChartDAL
    {
        int Save(string chartType, string jsonVal);

        RemoveResult Remove(int id);

        List<Chart> GetChartList();

        Chart GetChartById(int id);

        DataTable GetChartTableById(int id);

        Chart UpdateKBProjectById(Chart chart);
    }
}
