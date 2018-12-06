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
    public class Office_Service
    {
        Office_Repository offRep = new Office_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = offRep.GetList("sp_OfficeGetList", CommandType.StoredProcedure);
            List<CommonDTO> officeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                officeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return officeList;
        }
    }
}
