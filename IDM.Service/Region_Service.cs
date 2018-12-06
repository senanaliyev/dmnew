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
    public class Region_Service
    {
        Region_Repository regionRep = new Region_Repository();
        public List<Region_DTO> GetList(long parentid)
        {
            regionRep.AddInputParameters("@parentid", parentid);
            DataTable dt = regionRep.GetList("sp_Region_GetListByParentID", CommandType.StoredProcedure);
            List<Region_DTO> regionList = new List<Region_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                regionList.Add(new Region_DTO { id = Convert.ToInt64(dr["id"]), title = dr["title"].ToString(), parentid = Convert.ToInt64(dr["parentid"]) });
            }
            return regionList;
        }
    }
}
