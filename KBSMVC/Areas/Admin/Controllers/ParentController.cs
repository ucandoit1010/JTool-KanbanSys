using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using ModelLib.DAL;
using ModelLib.Models;
using ModelLib.Helper;
using Newtonsoft.Json;

namespace KBSMVC.Areas.Admin.Controllers
{
    public class ParentController : Controller
    {
        protected string SuccessMessage = "操作成功";
        protected string ErrorMessage = "發生錯誤";
        protected string UsingMessage = "被使用中";

        private IKBProject iProj;
        protected IChartDAL iChart;
        protected IConnectionDAL iConn;


        public ParentController()
        {
            iChart = new ChartDAL();
            iConn = new ConnectionDAL();
            iProj = new KBProjectDAL();
        }

        [HttpGet]
        public ActionResult GetChartList()
        {
            List<SelectListItem> chartList = new List<SelectListItem>();
            var list = iChart.GetChartList();

            foreach (var item in list)
            {
                chartList.Add(new SelectListItem()
                {
                    Text = item.ChartType,
                    Value = item.ChartId.ToString()

                });
            }

            return Json(chartList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetConnTypeList()
        {
            List<SelectListItem> connList = new List<SelectListItem>();
            var list = iConn.GetConn();
            foreach (var item in list)
            {
                connList.Add(new SelectListItem()
                {
                    Text = item.AliasName,
                    Value = item.CId.ToString()

                });
            }

            return Json(connList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProjectSelectList()
        {
            List<SelectListItem> connList = new List<SelectListItem>();
            var list = iProj.GetKBProjectList();
            foreach (var item in list)
            {
                connList.Add(new SelectListItem()
                {
                    Text = item.ProjectName,
                    Value = item.ProjectId.ToString()
                });
            }

            return Json(connList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetConnList()
        {
            var list = iConn.GetConn();

            var data = JsonConvert.SerializeObject(list, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(new { total = list.Count, rows = data }, JsonRequestBehavior.AllowGet);
        }



    }
}