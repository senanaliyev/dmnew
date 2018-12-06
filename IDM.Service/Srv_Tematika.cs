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
   public class Srv_Tematika
    {
       Rpst_Tematika tematikaRpst = new Rpst_Tematika();
        public List<CommonDTO> GetList()
        {
            DataTable dt = tematikaRpst.GetList("sp_Tematika_GetList", CommandType.StoredProcedure);
            List<CommonDTO> tematikaList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                tematikaList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return tematikaList;
        }
    }
}
