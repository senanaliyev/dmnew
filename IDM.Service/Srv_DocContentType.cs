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
    public class Srv_DocContentType
    {
        Rpst_DocContentType docContentTypeRPST = new Rpst_DocContentType();

        public List<CommonDTO> GetList()
        {
            DataTable dt = docContentTypeRPST.GetList("sp_DocContentType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> docContentTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docContentTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return docContentTypeList;
        }
    }
}
