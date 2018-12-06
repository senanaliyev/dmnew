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
    public class ContactTypeService
    {
        ContactTypeRepository conTyperep = new ContactTypeRepository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = conTyperep.GetList("sp_ContactType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> conTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                conTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return conTypeList;
        }
    }
}
