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
    public class AttachDoc
    {
        Rpst_AttachDoc attachDocRpst = new Rpst_AttachDoc();
        public List<CommonDTO> GetList()
        {
            DataTable dt = attachDocRpst.GetList("sp_AttachDoc_GetList", CommandType.StoredProcedure);
            List<CommonDTO> attachDocList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                attachDocList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return attachDocList;
        }
    }
}
