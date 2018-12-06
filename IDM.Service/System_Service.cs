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
    public class System_Service
    {
        System_Repository sysRep = new System_Repository();

        public int InsertByTableName(string tablename, System_DTO entity)
        {
            sysRep.AddInputParameters("@tablename", tablename);
            sysRep.AddInputParameters("@code", entity.code);
            sysRep.AddInputParameters("@title", entity.title);
            if (tablename == "tbl_Position")
            {
                sysRep.AddInputParameters("@status", entity.status);
            }
            return sysRep.IUD("sp_Rows_InsertByTableName", CommandType.StoredProcedure);
        }

        public int UpdateByTableName(string tablename, System_DTO entity)
        {
            sysRep.AddInputParameters("@tablename", tablename);
            sysRep.AddInputParameters("@id", entity.id);
            sysRep.AddInputParameters("@title", entity.title);
            sysRep.AddInputParameters("@code", entity.code);
            if (tablename == "tbl_Position")
            {
                sysRep.AddInputParameters("@status", entity.status);
            }
            return sysRep.IUD("sp_Rows_UpdateByTableName", CommandType.StoredProcedure);
        }

        public System_DTO GetSingleRecord(string tablename, int id)
        {
            sysRep.AddInputParameters("@tablename", tablename);
            sysRep.AddInputParameters("@id", id);
            DataTable dt = sysRep.GetList("sp_SingleRow_GetByID", CommandType.StoredProcedure);
            System_DTO singleRow = new System_DTO();

            singleRow.id = Convert.ToInt32(dt.Rows[0]["id"]);
            singleRow.title = dt.Rows[0]["title"].ToString();
            singleRow.code = dt.Rows[0]["code"].ToString();
            singleRow.table = tablename;
            if (tablename=="tbl_Position")
            {
                singleRow.status =Convert.ToInt32(dt.Rows[0]["status"]);
            }
            return singleRow;
        }

        public List<System_DTO> GetRowsByTableName(string tablename)
        {
            sysRep.AddInputParameters("@tablename", tablename);
            DataTable dt = sysRep.GetList("sp_Rows_GetByTableName", CommandType.StoredProcedure);
            List<System_DTO> tableRows = new List<System_DTO>();

            if (tablename == "tbl_Position")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tableRows.Add(
                        new System_DTO
                        {
                            id = Convert.ToInt32(dr["id"]),
                            title = dr["title"].ToString(),
                            code = dr["code"].ToString(),
                            statusDesc = Convert.ToInt32(dr["status"]) == 0 ? "Qeyri-rəhbər işçi" : "Rəhbər işçi",
                        });
                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tableRows.Add(
                      new System_DTO
                      {
                          id = Convert.ToInt32(dr["id"]),
                          title = dr["title"].ToString(),
                          code = dr["code"].ToString(),
                      });
                }
            }
            return tableRows;
        }
    }
}
