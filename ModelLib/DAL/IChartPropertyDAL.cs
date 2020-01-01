using System;
using System.Collections.Generic;
using System.Linq;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public interface IChartPropertyDAL
    {
        ChartProperty GetChartPropertyByCatalog(int chartId);

        ChartProperty GetChartPropertyByData(int chartId);

        List<ChartProperty> GetChartPropertyList(int chartId);

    }
}
