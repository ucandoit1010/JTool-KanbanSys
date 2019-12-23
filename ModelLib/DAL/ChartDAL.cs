using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ModelLib.Models;
using ModelLib.Extend;

namespace ModelLib.DAL
{
    public enum RemoveResult
    {
        Exist = -2,
        Success = 1,
        Error = -1

    }

    public class ChartDAL : DALBase, IChartDAL, ICurrent
    {
        public Chart CurrentChart { get; set; }


        public Chart GetChartById(int id)
        {
            using (ConnContext db = new ConnContext())
            {
                return db.Charts.SingleOrDefault(c => c.ChartId == id);
            }
        }

        public List<Chart> GetChartList()
        {
            //using (ConnContext db = new ConnContext())
            //{
                return _db.Charts.ToList();
            //}
        }

        public DataTable GetChartTableById(int id)
        {
            DataTable result = null;
            Chart chartData = GetChartById(id);
            List<Chart> chartList = new List<Chart>() { chartData };

            result = chartList.ToDataTable();
            CurrentChart = chartData;

            return result;
        }

        public RemoveResult Remove(int id)
        {
            int result = 0;
            Chart chart;
            using (ConnContext db = new ConnContext())
            {
                chart = GetChartById(id);
                if (chart == null)
                {
                    result = -1;
                    return (RemoveResult)result;
                }

                if (db.KBProjects.SingleOrDefault(k => k.CId == id) != null)
                {
                    result = -2;
                    return (RemoveResult)result;
                }

                db.Charts.Remove(chart);
                result = db.SaveChanges();
            }

            return (RemoveResult)result;
        }

        public int Save(string chartType, string jsonVal)
        {
            //throw new NotImplementedException();
            Chart chart = null;

            //using (ConnContext db = new ConnContext())
            //{
            chart = new Chart();
            chart.ChartType = chartType;
            chart.ChartScript = jsonVal;

            _db.Charts.Add(chart);

            return _db.SaveChanges();
            //}
        }

        public Chart UpdateKBProjectById(Chart chart)
        {
            Chart chartData = null;

            //using (ConnContext db = new ConnContext())
            //{
            chartData = _db.Charts.SingleOrDefault(k => k.ChartId == chart.ChartId);
            chartData.ChartScript = chart.ChartScript;
            chartData.ChartType = chart.ChartType;
            try
            {
                _db.SaveChanges();
            }
            catch (Exception err)
            {
                throw err;
            }

            return chartData;
            //}
        }
    }
}
