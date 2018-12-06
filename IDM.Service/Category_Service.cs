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
    public class Category_Service
    {
        Category_Repository categoryRep = new Category_Repository();
        public List<CommonDTO> GetList()
        {
            DataTable dt = categoryRep.GetList("sp_Category_GetList", CommandType.StoredProcedure);
            List<CommonDTO> categoryList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                categoryList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return categoryList;
        }
    }
}
