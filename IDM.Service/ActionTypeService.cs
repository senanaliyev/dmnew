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
    public class ActionTypeService
    {
        ActionTypeRepository actTyperep = new ActionTypeRepository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = actTyperep.GetList("sp_ActionType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> actTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                actTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return actTypeList;
        }
    }
}
