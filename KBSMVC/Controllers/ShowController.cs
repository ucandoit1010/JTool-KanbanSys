using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLib.Models;
using ModelLib.DAL;
using ChartStructLib.Charts;
using System.Data;

namespace KBSMVC.Controllers
{
    public class ShowController : Controller
    {
        private IKBProject iProj = null;


        public ShowController()
        {
            iProj = new KBProjectDAL();

        }


        public ActionResult Display(string id)
        {
            string json = string.Empty;
            KBProject projData = iProj.GetProjectByURL(id);
            DataTable table = iProj.TestSQL(projData.ProjectSQL);
            C3JSLine line = new C3JSLine(table, projData.Chart.ChartScript);

            switch (projData.Chart.ChartType)
            {
                case "Line":
                    json = line.Generate("CurrencyType", "Currency");

                    break;
                case "Bar":

                    break;
                default:
                    break;
            }

            ViewData["Script"] = json;

            return View();
        }


    }
}