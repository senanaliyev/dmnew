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
    public class TemplateText_Service
    {
        TemplateText_Repository tempTextRpst = new TemplateText_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = tempTextRpst.GetList("sp_TemplateText_GetList", CommandType.StoredProcedure);
            List<CommonDTO> tempTextList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                tempTextList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return tempTextList;
        }
    }
}
