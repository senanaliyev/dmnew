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
    public class Assignment_Service
    {
        Assignment_Repository assignRep = new Assignment_Repository();

        public int InsertByTableName(string tablename, AssignmentDTO entity)
        {
            assignRep.AddInputParameters("@tablename", tablename);
            assignRep.AddInputParameters("@toid", entity.toid);
            assignRep.AddInputParameters("@fromid", entity.fromid);
            return assignRep.IUD("sp_Assignment_InsertByTableName", CommandType.StoredProcedure);
        }

        public int DeleteAssigned(int id, string tablename)
        {
            assignRep.AddInputParameters("@id", id);
            assignRep.AddInputParameters("@tablename", tablename);
            return assignRep.IUD("sp_Assignment_DeleteByID", CommandType.StoredProcedure);
        }

        public List<System_DTO> GetToTable(string tablename)
        {
            assignRep.AddInputParameters("@tablename", tablename);
            DataTable dt = assignRep.GetList("sp_Rows_GetByTableName", CommandType.StoredProcedure);
            List<System_DTO> tableRows = new List<System_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                tableRows.Add(
                    new System_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = dr["title"].ToString()
                    });
            }
            return tableRows;
        }

        public List<System_DTO> GetAssigned(int toid, string assignTable, string fromTable)
        {
            assignRep.AddInputParameters("@toid", toid);
            assignRep.AddInputParameters("@assignTable", assignTable);
            assignRep.AddInputParameters("@fromTable", fromTable);
            DataTable dt = assignRep.GetList("sp_Assignment_GetAssigned", CommandType.StoredProcedure);
            List<System_DTO> tableRows = new List<System_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                tableRows.Add(
                    new System_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = dr["title"].ToString()
                    });
            }
            return tableRows;
        }
    }
}
