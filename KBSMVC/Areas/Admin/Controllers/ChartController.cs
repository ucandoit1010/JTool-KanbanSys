using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLib.Models;
using ModelLib.DAL;
using Newtonsoft.Json;

namespace KBSMVC.Areas.Admin.Controllers
{
    public class ChartController : ParentController
    {


        public ChartController()
        {


        }


        [HttpGet]
        public ActionResult GetChart()
        {
            var list = iChart.GetChartList();

            var data = JsonConvert.SerializeObject(list, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(new { total = list.Count, rows = data }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return PartialView();
        }

        public ActionResult List()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            Chart chart = iChart.GetChartById(id);

            return PartialView("ChartEdit", chart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string chartType, string jsonVal)
        {
            JSONResult result = new JSONResult();

            if (iChart.Save(chartType, jsonVal) > 0)
            {
                result.Code = "1";
                result.Message = SuccessMessage;
            }
            else
            {
                result.Code = "0";
                result.Message = ErrorMessage;
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult SaveById(string ChartType, string ChartScript , string ChartId)
        {
            Chart chart = new Chart();
            chart.ChartScript = ChartScript;
            chart.ChartType = ChartType;
            chart.ChartId = byte.Parse(ChartId);

            try
            {
                var chartData = iChart.UpdateKBProjectById(chart);
                return Json(new { flag = 1, rows = chartData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { flag = 0, message = err.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Remove()
        {
            return View();
        }

    }
}