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
        private IProjectMappingDAL iProjectMapping = null;
        private IChartPropertyDAL iChartProperty = null;

        public ShowController()
        {
            iProj = new KBProjectDAL();
            iProjectMapping = new ProjectMappingDAL();
            iChartProperty = new ChartPropertyDAL();
        }


        public ActionResult Display(string id)
        {
            string json = string.Empty;
            KBProject projData = iProj.GetProjectByURL(id);
            DataTable table = iProj.TestSQL(projData.ProjectSQL, projData.ProjectId);
            Lazy<C3JSLine> line = null;
            Lazy<C3JSBar> bar = null;
            
            switch (projData.Chart.ChartType)
            {
                case "Line":
                    ChartProperty chartPtyCatalog = 
                        iChartProperty.GetChartPropertyByCatalog(projData.ChartId);
                    ChartProperty chartPtyData =
                        iChartProperty.GetChartPropertyByData(projData.ChartId);
                    
                    //取得專案設定的Chart對應屬性
                    List<ProjectMapping> projMappingList =
                        iProjectMapping.GetProjectMappingsById(projData.ProjectId);

                    //取得project的catalog col name
                    ProjectMapping projMappingCatalog = 
                        projMappingList.SingleOrDefault(pm => pm.CPId == chartPtyCatalog.CPId);
                    
                    //取得project的data col name
                    ProjectMapping projMappingData =
                        projMappingList.SingleOrDefault(pm => pm.CPId == chartPtyData.CPId);

                    line = new Lazy<C3JSLine>(() => new C3JSLine(table, projData.Chart.ChartScript));
                    json = line.Value.Generate(
                        projMappingList.Where(pm => pm.CPId == projMappingData.CPId).Select(pmc => pmc.PropertyName).ToArray(),
                        projMappingCatalog.PropertyName);

                    break;
                case "Bar":

                    //bar = new Lazy<C3JSBar>(() => new C3JSBar(table, projData.Chart.ChartScript));
                    //bar.Value.Generate()

                    break;
                default:
                    break;
            }

            ViewData["Script"] = json;

            return View();
        }


    }
}