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
    public class Srv_Permission
    {
        Rpst_Permission permissionRpst = new Rpst_Permission();
        public List<Permission_DTO> GetList(int usrID)
        {
            permissionRpst.AddInputParameters("@usrID", usrID);
            DataTable dt = permissionRpst.GetList("sp_Permission_GetByUserID", CommandType.StoredProcedure);
            List<Permission_DTO> componentList = new List<Permission_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                componentList.Add(new Permission_DTO { usrID = Convert.ToInt32(dr["usrID"]), componentid = dr["componentid"].ToString() });
            }
            return componentList;
        }
    }
}
