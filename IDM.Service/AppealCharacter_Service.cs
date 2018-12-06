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
    public class AppealCharacter_Service
    {
        AppealCharacter_Repository appealCharacRep = new AppealCharacter_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = appealCharacRep.GetList("sp_AppealCharac_GetList", CommandType.StoredProcedure);
            List<CommonDTO> appealCharacList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                appealCharacList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return appealCharacList;
        }
    }
}
