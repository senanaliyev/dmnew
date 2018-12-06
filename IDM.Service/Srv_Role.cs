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
    public class Srv_Role
    {
        Rpst_Role roleRpst = new Rpst_Role();

        public int deleteRole(long id)
        {
            roleRpst.AddInputParameters("@id", id);
            return roleRpst.IUD("sp_Role_DeleteAssignedByID", CommandType.StoredProcedure);
        }
        public int AssignRole(int usrID, int roleID)
        {
            roleRpst.AddInputParameters("@usrID", usrID);
            roleRpst.AddInputParameters("@roleID", roleID);
            return roleRpst.IUD("sp_Role_AssignToUser", CommandType.StoredProcedure);
        }

        public List<CommonDTO> GetListByUserID(int usrID)
        {
            roleRpst.AddInputParameters("@usrID", usrID);
            DataTable dt = roleRpst.GetList("sp_Role_GetListByID", CommandType.StoredProcedure);
            if (dt != null)
            {
                List<CommonDTO> roleList = new List<CommonDTO>();
                foreach (DataRow dr in dt.Rows)
                {
                    roleList.Add(new CommonDTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = dr["title"].ToString()
                    });
                }
                return roleList;
            }
            else
            {
                return null;
            }
        }

        public List<CommonDTO> GetList()
        {
            DataTable dt = roleRpst.GetList("sp_Role_GetList", CommandType.StoredProcedure);
            if (dt != null)
            {
                List<CommonDTO> roleList = new List<CommonDTO>();
                foreach (DataRow dr in dt.Rows)
                {
                    roleList.Add(new CommonDTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = dr["title"].ToString()
                    });
                }
                return roleList;
            }
            else
            {
                return null;
            }
        }

    }
}
