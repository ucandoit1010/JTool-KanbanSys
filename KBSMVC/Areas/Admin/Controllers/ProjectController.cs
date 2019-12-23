﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ModelLib.Models;
using ModelLib.DAL;
using Newtonsoft.Json;
using ModelLib.Helper;

namespace KBSMVC.Areas.Admin.Controllers
{
    public class ProjectController : ParentController
    {
        private IKBProject iProj;

        public ProjectController()
        {
            iProj = new KBProjectDAL();

        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Save(string projName, string projSQL, string chartType)
        {
            KBProject project = new KBProject();
            project.CId = Convert.ToInt32(chartType);
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
        public ActionResult Test(string sql)
        {
            DataTable table = iProj.TestSQL(sql);
            
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

    }
}