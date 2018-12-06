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
    public class SocialStatus_Service
    {
        SocialStatus_Repository socialStatusRep = new SocialStatus_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = socialStatusRep.GetList("sp_SocialStatus_GetList", CommandType.StoredProcedure);
            List<CommonDTO> socialStatusList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                socialStatusList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return socialStatusList;
        }
    }
}
