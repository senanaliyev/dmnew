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
    public class PositionService
    {
        PositionRepository posRep = new PositionRepository();
        public List<StructureDTO> GetStructureListByParentID(int parid)
        {
            posRep.AddInputParameters("@parid", parid);
            DataTable dt = posRep.GetList("sp_Structure_GetListbyParentID", CommandType.StoredProcedure);
            List<StructureDTO> structureList = new List<StructureDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                structureList.Add(new StructureDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString(), parentid = Convert.ToInt32(dr["parentid"]) });
            }
            return structureList;
        }

        public List<PositionDTO> GetPositionListByStrID(int id)
        {
            posRep.AddInputParameters("@id", id);
            DataTable dt = posRep.GetList("sp_Position_GetListbyStrID", CommandType.StoredProcedure);
            List<PositionDTO> positionList = new List<PositionDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                positionList.Add(new PositionDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return positionList;
        }
    }
}
