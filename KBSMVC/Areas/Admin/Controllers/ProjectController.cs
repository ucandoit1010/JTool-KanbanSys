using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ModelLib.Models;
using ModelLib.DAL;
using Newtonsoft.Json;
using ModelLib.Helper;
using ModelLib.Models.ViewModel;


namespace KBSMVC.Areas.Admin.Controllers
{
    public class ProjectController : ParentController
    {
        private IKBProject iProj;
        private IChartPropertyDAL iProperty;
        private IProjectMappingDAL iProjectMapping;

        public ProjectController()
        {
            iProj = new KBProjectDAL();
            iProperty = new ChartPropertyDAL();
            iProjectMapping = new ProjectMappingDAL();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Save(string projName, string projSQL, string chartType, string connType)
        {
            KBProject project = new KBProject();
            project.CId = Convert.ToInt32(connType);
            project.ChartId = Convert.ToByte(chartType);
            project.ProjectName = projName;
            project.ProjectSQL = projSQL;
            project.IsEnable = true;

            JSONResult result = new JSONResult();

            if (iProj.CreateKBProject(project) > 0)
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

        public ActionResult List()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SaveById(int ProjectId, string ProjectName, string ProjectSQL, string CId , string ChartId)
        {
            KBProject proj;
            try
            {
                proj = iProj.UpdateKBProjectById(new KBProject()
                {
                    ProjectId = ProjectId,
                    ProjectName = ProjectName,
                    ProjectSQL = ProjectSQL,
                    CId = Convert.ToInt32(CId),
                    ChartId = byte.Parse(ChartId)
                });

                var data = JsonConvert.SerializeObject(proj, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                return Json(new { flag = 1, rows = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { flag = 0, message = err.Message }, JsonRequestBehavior.AllowGet);
            }

            //JSONResult result = new JSONResult();
            //if (rows > 0)
            //{
            //    result.Message = SuccessMessage;
            //    result.Code = "1";
            //}
            //else
            //{
            //    result.Message = ErrorMessage;
            //    result.Code = "0";
            //}

        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            KBProject proj = iProj.GetKBProjectById(id);
            
            return PartialView("ProjEdit", proj);

            //return Json(proj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            int rows = iProj.RemoveKBProjectById(id);
            JSONResult result = new JSONResult();
            if (rows > 0)
            {
                result.Message = SuccessMessage;
                result.Code = "1";
            }
            else
            {
                result.Message = ErrorMessage;
                result.Code = "0";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Test(string sql, string id)
        {
            DataTable table = iProj.TestSQL(sql, Convert.ToInt32(id));

            return PartialView(table);
        }
        

        [HttpGet]
        public ActionResult GetProjectList()
        {
            List<KBProject> dataList = dataList = iProj.GetKBProjectList();

            var data = JsonConvert.SerializeObject(dataList, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(new { total = dataList.Count , rows = data }, JsonRequestBehavior.AllowGet);

            //return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateURL(int id)
        {
            int rows = 0;
            RandomString randomStr = new RandomString();
            JSONResult result = new JSONResult();
            KBProject project = new KBProject();
            project.ProjectId = id;

            string val;
            string url = iProj.GetUrlById(project);
            if (string.IsNullOrEmpty(url))
            {
                val = randomStr.GetRandomString();
                project.Url = val;

                try
                {
                    rows = iProj.UpdateUrlById(project);
                    result.Code = "0";
                    result.Message = project.Url;
                }
                catch (Exception err)
                {
                    result.Code = "-1";
                    result.Message = err.Message;
                }
            }
            else
            {
                result.Code = "0";
                result.Message = url;
            }

            result.ResponseData = string.Format("http://{0}{1}{2}",
                Request.Url.Authority,
                System.Web.Configuration.WebConfigurationManager.AppSettings["URL"],
                url);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Mapping()
        {
            return PartialView("MappingView");
        }



        public ActionResult GetProjectChartPropertyList(int id)
        {
            KBProject project = iProj.GetKBProjectById(id);
            List<ProjectMapping> mappingList = iProjectMapping.GetProjectMappingsById(id);
            List<ChartProperty> chartPropertiesList = iProperty.GetChartPropertyList(id);
            List<ChartPropertyProjectViewModel> chartPropProjList = new List<ChartPropertyProjectViewModel>();
            ChartPropertyProjectViewModel chartProperty = null;
            ProjectMapping mapping = null;

            foreach (ChartProperty item in chartPropertiesList)
            {
                chartProperty = new ChartPropertyProjectViewModel();
                chartProperty.CPId = item.CPId;
                chartProperty.CPName = item.CPName;

                mapping = mappingList.SingleOrDefault(mp => mp.CPId == item.CPId);
                if (mapping != null)
                {
                    chartProperty.Column = mapping.PropertyName;
                }
                chartPropProjList.Add(chartProperty);
            }


            var data = JsonConvert.SerializeObject(chartPropProjList, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(new { total = chartPropProjList.Count, rows = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProjectChartProperty(int id)
        {
            KBProject project = iProj.GetKBProjectById(id);
            DataTable table = iProj.TestSQL(project.ProjectSQL, project.ProjectId);
            List<SelectListItem> selectList = new List<SelectListItem>();

            if (table != null && table.Rows.Count > 0)
            {
                selectList = ConvertDataColumnToSelectItemList(table.Columns);
            }

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UpdateMapping(int CPId, int ProjectId, string Column)
        {
            JSONResult result = new JSONResult();
            ProjectMapping mapping = null;
            ProjectMapping checkData;
            List<ProjectMapping> mappingList = 
                iProjectMapping.GetProjectMappingsById(ProjectId);

            if (mappingList.Count > 0)
            {
                checkData = mappingList.SingleOrDefault(cp => cp.CPId == CPId);
                if (checkData != null && string.Compare(checkData.PropertyName, Column) == 0)
                {
                    result.Code = "2";
                    return Json(result);
                }

            }

            try
            {
                mapping = iProjectMapping.UpdateMappig(ProjectId, CPId, Column);
                result.Code = "1";
                result.Message = SuccessMessage;
            }
            catch (Exception err)
            {
                result.Code = "0";
                result.Message = ErrorMessage;
            }

            return Json(result);
        }

        private List<SelectListItem> ConvertDataColumnToSelectItemList(DataColumnCollection colsList)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (DataColumn item in colsList)
            {
                selectList.Add(new SelectListItem()
                {
                    Text = item.ColumnName,
                    Value = item.ColumnName
                });
            }

            return selectList;
        }

    }
}