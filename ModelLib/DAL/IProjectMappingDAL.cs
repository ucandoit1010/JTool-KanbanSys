using System;
using System.Collections.Generic;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public interface IProjectMappingDAL
    {
        List<ProjectMapping> GetProjectMappingsById(int projectId);

        ProjectMapping UpdateMappig(int projId, int cpId, string colName);


    }
}
