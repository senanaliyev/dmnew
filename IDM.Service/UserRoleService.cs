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
    public class UserRoleService
    {
        RoleRepository role = new RoleRepository();
        public int Insert(RoleDTO entity)
        {
            role.AddInputParameters("@title", entity.title);
            return role.IUD("sp_Role_Insert", CommandType.StoredProcedure);
        }
        public int Update(RoleDTO entity)
        {
            role.AddInputParameters("@id", entity.id);
            role.AddInputParameters("@title", entity.title);
            return role.IUD("sp_Role_Update", CommandType.StoredProcedure);
        }

        public RoleDTO GetListByID(int id)
        {
            role.AddInputParameters("@id", id);
            DataTable dt = role.GetList("sp_Role_GetListByID", CommandType.StoredProcedure);
            RoleDTO singleRole = new RoleDTO();

            singleRole.id = Convert.ToInt32(dt.Rows[0]["id"]);
            singleRole.title = dt.Rows[0]["title"].ToString();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    singleRole.id = Convert.ToInt32(dr["id"]);
            //    singleRole.title = dr["title"].ToString();
            //}
            return singleRole;
        }
        public List<RoleDTO> GetList()
        {
            DataTable dt = role.GetList("sp_Role_GetList", CommandType.StoredProcedure);
            List<RoleDTO> roleList = new List<RoleDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                roleList.Add(new RoleDTO
                {
                    id = Convert.ToInt32(dr["id"]),
                    title = dr["title"].ToString()
                });
            }
            return roleList;
        }
    }
}
