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
    public class ConnectionController : ParentController
    {
        private IConnectionDAL iConn;

        public ConnectionController()
        {
            iConn = new ConnectionDAL();
        }

        public ActionResult Create()
        {
            ViewData["DBTypeList"] = GetDBTypeSelectList();

            return PartialView();
        }

        public ActionResult List()
        {
            return PartialView();
        }

        public ActionResult Remove(int id)
        {
            int rows = iConn.RemoveConnById(id);
            JSONResult result = new JSONResult();
            if (rows > 0)
            {
                result.Message = SuccessMessage;
                result.Code = "1";
            }
            else
            {
                if (rows == 0)
                {
                    result.Message = ErrorMessage;
                    result.Code = "0";
                }
                else
                {
                    result.Message = UsingMessage;
                    result.Code = "-1";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id)
        {
            Conn conn = iConn.GetConnById(id);

            return PartialView("ConnEdit", conn);
        }

        [HttpPost]
        public ActionResult SaveById(string AliasName, string ConnStr, string CId , string DBType)
        {
            Conn conn = new Conn();
            conn.AliasName = AliasName;
            conn.ConnStr = ConnStr;
            conn.CId = Convert.ToInt32(CId);
            conn.DBType = DBType;
            try
            {
                var connData = iConn.UpdateConnById(conn);
                var data = JsonConvert.SerializeObject(connData, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                return Json(new { flag = 1, rows = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { flag = 0, message = err.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Save(string AliasName, string ConnStr, string connType)
        {
            Conn conn = new Conn();
            conn.AliasName = AliasName;
            conn.ConnStr = ConnStr;
            conn.DBType = connType;
            conn.IsEnable = true;

            JSONResult result = new JSONResult();

            if (iConn.CreateConn(conn) > 0)
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

        //[HttpGet]
        //public ActionResult GetConnList()
        //{
        //    var list = iConn.GetConn();

        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetDBTypeList()
        {
            var list = GetDBTypeSelectList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        private List<SelectListItem> GetDBTypeSelectList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem()
            {
                Text = ConnDBType.Oracle.ToString(),
                Value = ((int)ConnDBType.Oracle).ToString()
            });
            selectList.Add(new SelectListItem()
            {
                Text = ConnDBType.SQLServer.ToString(),
                Value = ((int)ConnDBType.SQLServer).ToString()
            });

            return selectList;
        }

    }
}