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
    public class PositionToUserService
    {
        PositionToUserRepository posToUserRep = new PositionToUserRepository();
        public int Insert(PositionToUserDTO entity)
        {
            posToUserRep.AddInputParameters("@usrID", entity.usrID);
            posToUserRep.AddInputParameters("@strID", entity.strID);
            posToUserRep.AddInputParameters("@posID", entity.posID);
            return posToUserRep.IUD("sp_Position_Insert", CommandType.StoredProcedure);
        }
        public List<PositionToUserDTO> GetPositionsByUserID(int id)
        {
            posToUserRep.AddInputParameters("@usrID", id);
            DataTable dt = posToUserRep.GetList("sp_Positions_GetListByUserID", CommandType.StoredProcedure);
            List<PositionToUserDTO> positionList = new List<PositionToUserDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                positionList.Add(new PositionToUserDTO { ptuID = Convert.ToInt32(dr["ptuID"]), structureTitle = dr["structureTitle"].ToString(), positionTitle = dr["positionTitle"].ToString() });
            }
            return positionList;
        }
    }
}
