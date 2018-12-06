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
    public class UserService
    {
        UserRepository user = new UserRepository();
        public int Insert(UserDTO entity)
        {
            user.AddOutputParameters("@id", entity.usrID);
            user.AddInputParameters("@usrName", entity.usrName);
            user.AddInputParameters("@usrPassword", entity.usrPassword);
            user.IUD("sp_User_Insert", CommandType.StoredProcedure);
            return Convert.ToInt32(user.GetParamValue("@id"));
        }

        public List<UserDTO> GetList()
        {
            DataTable dt = user.GetList("sp_User_GetList", CommandType.StoredProcedure);
            List<UserDTO> userList = new List<UserDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                userList.Add(new UserDTO { usrID = Convert.ToInt32(dr["usrID"]), usrName = dr["usrName"].ToString() });
            }
            return userList;
        }
    }
}
