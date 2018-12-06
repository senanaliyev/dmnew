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
    public class LoginService
    {

        UserRepository userRep = new UserRepository();

        public Custom_UserDTO CheckUser(UserDTO entity)
        {
            userRep.AddInputParameters("@usrName", entity.usrName);
            userRep.AddInputParameters("@usrPassword", entity.usrPassword);
            DataTable dt = userRep.GetList("sp_User_Check", CommandType.StoredProcedure);
            Custom_UserDTO userInfo = new Custom_UserDTO();
            if (dt.Rows.Count > 0)
            {
                userInfo.usrID = Convert.ToInt32(dt.Rows[0]["usrID"]);
                userInfo.usrName = dt.Rows[0]["usrName"].ToString();
                userInfo.empName = dt.Rows[0]["empName"].ToString();
                userInfo.empSurname = dt.Rows[0]["empSurname"].ToString();
                return userInfo;
            }
            else
            {

                return null;
            }
        }
    }
}
