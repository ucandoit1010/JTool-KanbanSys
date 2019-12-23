using System;
using System.Linq;
using System.Collections.Generic;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public class ConnectionDAL : DALBase, IConnectionDAL
    {
        public int CreateConn(Conn data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Conn Insert Model is Null");
            }

            int rows = 0;

            //using (ConnContext db = new ConnContext())
            //{
            _db.Conns.Add(data);
            rows = _db.SaveChanges();
            //}

            return rows;
        }

        public List<Conn> GetConn()
        {
            return _db.Conns.Where(c => c.IsEnable == true).ToList();
        }

        public Conn GetConnById(int id)
        {
            //using (ConnContext db = new ConnContext())
            //{
            return _db.Conns.SingleOrDefault(c => c.CId == id);
            //}
        }

        public int RemoveConnById(int id)
        {
            Conn proj = null;
            int rows = 0;

            //using (ConnContext db = new ConnContext())
            //{
            KBProject kbProj = _db.KBProjects.SingleOrDefault(k => k.CId == id && k.IsEnable == true);
            if (kbProj != null)
            {
                return -1;
            }

            proj = _db.Conns.SingleOrDefault(c => c.CId == id);
            proj.IsEnable = false;
            rows = _db.SaveChanges();
            //}

            return rows;
        }

        public Conn UpdateConnById(Conn conn)
        {
            Conn connData = null;

            connData = _db.Conns.SingleOrDefault(k => k.CId == conn.CId);
            connData.AliasName = conn.AliasName;
            connData.ConnStr = conn.ConnStr;
            connData.DBType = conn.DBType;

            _db.SaveChanges();

            return connData;

        }


    }
}
