using System;
using System.Collections.Generic;
using System.Linq;
using ModelLib.Models;

namespace ModelLib.DAL
{
    public class ProjectMappingDAL : DALBase , IProjectMappingDAL
    {
        public List<ProjectMapping> GetProjectMappingsById(int projectId)
        {
            return _db.ProjectMappings.Where(pm => pm.ProjectId == projectId).ToList();
        }

        public ProjectMapping UpdateMappig(int projId, int cpId, string colName)
        {
            ProjectMapping mapping =
                _db.ProjectMappings.SingleOrDefault(pm => pm.ProjectId == projId && pm.CPId == cpId);

            try
            {
                if (mapping != null)
                {
                    mapping.CPId = cpId;
                    mapping.PropertyName = colName;
                    mapping.ProjectId = projId;
                }
                else
                {
                    mapping = new ProjectMapping();
                    mapping.ProjectId = projId;
                    mapping.CPId = cpId;
                    mapping.PropertyName = colName;
                    _db.ProjectMappings.Add(mapping);
                }

                _db.SaveChanges();

                return mapping;
            }
            catch (Exception err)
            {
                throw err; ;
            }
        }


    }
}
