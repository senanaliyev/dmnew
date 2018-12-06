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
    public class Gender_Service
    {
        Gender_Repository genderRep = new Gender_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = genderRep.GetList("sp_Gender_GetList", CommandType.StoredProcedure);
            List<CommonDTO> genderList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                genderList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return genderList;
        }
    }
}
