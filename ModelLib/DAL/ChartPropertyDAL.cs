using System;
using System.Linq;
using System.Collections.Generic;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public class ChartPropertyDAL : DALBase, IChartPropertyDAL
    {
        public ChartProperty GetChartPropertyByCatalog(int chartId)
        {
            return _db.ChartProperties.SingleOrDefault(
                cp => cp.ChartId == chartId &&
                string.Compare(cp.CPName, "@Catalog") == 0);
        }

        public ChartProperty GetChartPropertyByData(int chartId)
        {
            return _db.ChartProperties.SingleOrDefault(
                cp => cp.ChartId == chartId &&
                string.Compare(cp.CPName, "@Data") == 0);
        }

        public List<ChartProperty> GetChartPropertyList(int chartId)
        {
            return _db.ChartProperties.
                Where(cp => cp.ChartId == chartId).ToList().
                Select(c => new ChartProperty { CPName = c.CPName, CPId = c.CPId }).ToList();
        }
        
    }
}
