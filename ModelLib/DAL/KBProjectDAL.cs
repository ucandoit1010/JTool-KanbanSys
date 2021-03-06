﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity;
using ModelLib.Models;
using ModelLib.Helper;


namespace ModelLib.DAL
{
    public class KBProjectDAL : DALBase, IKBProject
    {
        public int CreateKBProject(KBProject proj)
        {
            if (proj == null)
            {
                throw new ArgumentNullException("KBProject Insert Model is Null");
            }

            int rows = 0;
            List<ChartProperty> chartPropertyList;

            try
            {
                _db.KBProjects.Add(proj);
                rows = _db.SaveChanges();

                chartPropertyList = _db.ChartProperties.Where(cp => cp.ChartId == proj.ChartId).ToList();
                foreach (var item in chartPropertyList)
                {
                    _db.ProjectMappings.Add(new ProjectMapping()
                    {
                        CPId = item.CPId,
                        ProjectId = proj.ProjectId
                    });
                }

                rows = _db.SaveChanges();
            }
            catch (Exception err)
            {
                throw err;
            }

            return rows;
        }

        public KBProject UpdateKBProjectById(KBProject proj)
        {
            KBProject projData = null;

            //using (ConnContext db = new ConnContext())
            //{
            projData = _db.KBProjects.SingleOrDefault(k => k.ProjectId == proj.ProjectId);
            projData.ProjectName = proj.ProjectName;
            projData.ProjectSQL = proj.ProjectSQL;
            projData.CId = proj.CId;
            projData.ChartId = proj.ChartId;

            _db.SaveChanges();

            return projData;
            //}
        }

        public int RemoveKBProjectById(int id)
        {
            KBProject proj = null;
            int rows = 0;

            //using (ConnContext db = new ConnContext())
            //{
                proj = _db.KBProjects.SingleOrDefault(c => c.ProjectId == id);
                proj.IsEnable = false;
                rows = _db.SaveChanges();
            //}

            return rows;
        }

        public KBProject GetKBProjectById(int id)
        {
            //using (ConnContext db = new ConnContext())
            //{
            //return _db.KBProjects.SingleOrDefault(c => c.CId == id);
            //}
            return _db.KBProjects.SingleOrDefault(c => c.ProjectId == id);
        }

        public List<KBProject> GetKBProjectList()
        {
            //List<KBProject> result = new List<KBProject>();
            //using (ConnContext db = new ConnContext())
            //{
            //    result = db.KBProjects.Include("Conn").Where(k => k.IsEnable == true).ToList();
            //}

            return _db.KBProjects.Where(k => k.IsEnable == true).ToList();
        }

        public DataTable TestSQL(string sql, int projId)
        {
            //string conn = DBConnHelper.GetSQLConn();
            ADONETReaderHelper readerHelper = new ADONETReaderHelper();

            KBProject project = _db.KBProjects.SingleOrDefault(pj => pj.ProjectId == projId);
            if (project == null)
            {
                return new DataTable();
            }

            Conn conn = project.Conn;

            if (conn == null)
            {
                return new DataTable();
            }

            switch (conn.DBType)
            {
                //SQL SERVER
                case "1":
                    return readerHelper.ExecuteSQL(sql, conn.ConnStr, DBConnType.SQLServer);

                //ORACLE
                default:
                    return readerHelper.ExecuteSQL(sql, conn.ConnStr, DBConnType.Oracle);
            }
        }

        public int UpdateUrlById(KBProject proj)
        {
            KBProject projData = null;
            int rows = 0;

            projData = _db.KBProjects.SingleOrDefault(k => k.ProjectId == proj.ProjectId);
            if (projData != null && string.IsNullOrEmpty(projData.Url))
            {
                projData.Url = proj.Url;
                rows = _db.SaveChanges();
            }
            
            return rows;
        }

        public string GetUrlById(KBProject proj)
        {
            KBProject projData = null;
            projData = _db.KBProjects.SingleOrDefault(k => k.ProjectId == proj.ProjectId);

            if (projData == null)
            {
                return string.Empty;
            }

            return projData.Url;
        }

        public KBProject GetProjectByURL(string url)
        {

            return _db.KBProjects.SingleOrDefault(k => k.Url == url);
        }

        public List<KBProject> GetKProjectPropertyList(int chartId)
        {
            var list = _db.KBProjects.Join(
                    _db.ChartProperties.Where(k => k.ChartId == chartId),
                    x => x.ChartId,
                    s => s.ChartId,
                    ((x, s) => x)).ToList();
            return list;
        }

    }
}
