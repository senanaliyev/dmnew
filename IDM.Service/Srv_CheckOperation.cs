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
    public class Srv_CheckOperation
    {
        Rpst_CheckOperation oprRPST = new Rpst_CheckOperation();

        public List<DocumentOperationDTO> CheckOperation(long docID)
        {
            oprRPST.AddInputParameters("@docID", docID);
            DataTable dt = oprRPST.GetList("sp_CheckOperation", CommandType.StoredProcedure);
            List<DocumentOperationDTO> operationList = new List<DocumentOperationDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                operationList.Add(
                    new DocumentOperationDTO
                    {
                        doID = Convert.ToInt64(dr["doID"]),
                        opercode = dr["opercode"].ToString()
                    });
            }
            return operationList;
        }
    }
}
