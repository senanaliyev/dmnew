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
    public class OpResponseService
    {
        OpResponseRepository opResRep = new OpResponseRepository();

        public List<OpResponseDTO> GetListByID(int id)
        {
            opResRep.AddInputParameters("@id", id);
            DataTable dt = opResRep.GetList("sp_OpResponse_GetListByID", CommandType.StoredProcedure);
            List<OpResponseDTO> responseList = new List<OpResponseDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                responseList.Add(new OpResponseDTO
                {
                    id = Convert.ToInt32(dr["id"]),
                    title = dr["title"].ToString(),
                    action = dr["action"].ToString()
                });
            }
            return responseList;
        }

    }
}
