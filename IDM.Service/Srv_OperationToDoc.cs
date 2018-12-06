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
    public class Srv_OperationToDoc
    {
        Rpst_OperationToDoc oprToDoc = new Rpst_OperationToDoc();

        public OperationToDoc_DTO GetOperationToDocByPosID(int posid, int doctype)
        {
            oprToDoc.AddInputParameters("@posid", posid);
            oprToDoc.AddInputParameters("@doctype", doctype);
            DataTable dt = oprToDoc.GetList("sp_GetOperByPositionID", CommandType.StoredProcedure);
            OperationToDoc_DTO item = new OperationToDoc_DTO();
            item.id = Convert.ToInt32(dt.Rows[0]["id"]);
            item.toid = Convert.ToInt32(dt.Rows[0]["toid"]);
            item.fromid = Convert.ToInt32(dt.Rows[0]["fromid"]);
            item.positionid = Convert.ToInt32(dt.Rows[0]["positionid"]);
            item.opercode = dt.Rows[0]["opercode"].ToString();
            return item;
        }

        public OperationToDoc_DTO GetOperationToDocByOprID(int oprid, int doctype)
        {
            oprToDoc.AddInputParameters("@oprid", oprid);
            oprToDoc.AddInputParameters("@doctype", doctype);
            DataTable dt = oprToDoc.GetList("sp_GetOperByOprID", CommandType.StoredProcedure);
            OperationToDoc_DTO item = new OperationToDoc_DTO();
            item.id = Convert.ToInt32(dt.Rows[0]["id"]);
            item.toid = Convert.ToInt32(dt.Rows[0]["toid"]);
            item.fromid = Convert.ToInt32(dt.Rows[0]["fromid"]);
            item.positionid = Convert.ToInt32(dt.Rows[0]["positionid"]);
            item.opercode = dt.Rows[0]["opercode"].ToString();
            return item;
        }
    }
}
