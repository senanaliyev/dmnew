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
    public class AppealTypeService
    {
        AppealTypeRepository appealTypeRep = new AppealTypeRepository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = appealTypeRep.GetList("sp_AppealType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> appealTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                appealTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return appealTypeList;
        }
    }
}
