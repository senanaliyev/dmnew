using IDM.DTO;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
    public class Organization_Service
    {
        Organization_Repository organization = new Organization_Repository();
        public List<Organization_DTO> GetList(int id)
        {
            organization.AddInputParameters("@id", id);
            DataTable dt = organization.GetList("sp_Organization_ListById", CommandType.StoredProcedure);
            List<Organization_DTO> organizationsList = new List<Organization_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                organizationsList.Add(new Organization_DTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return organizationsList;
        }
    }
}
