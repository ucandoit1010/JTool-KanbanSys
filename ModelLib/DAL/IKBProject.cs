using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public interface IKBProject
    {
        int CreateKBProject(KBProject proj);

        List<KBProject> GetKBProjectList();

        KBProject GetKBProjectById(int id);

        KBProject UpdateKBProjectById(KBProject proj);

        int RemoveKBProjectById(int id);

        DataTable TestSQL(string sql);

        int UpdateUrlById(KBProject proj);

        string GetUrlById(KBProject proj);

        KBProject GetProjectByURL(string url);

    }
}
