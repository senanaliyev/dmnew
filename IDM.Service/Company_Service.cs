using IDM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDM.Repository;
using System.Data;

namespace IDM.Service
{
    public class Company_Service
    {
        Company_Repository companyRep = new Company_Repository();

        public Company_DTO GetSingleRecord(int id)
        {
            companyRep.AddInputParameters("@id", id);
            DataTable dt = companyRep.GetList("sp_Company_GetByID", CommandType.StoredProcedure);
            Company_DTO singleRow = new Company_DTO();

            singleRow.id = Convert.ToInt32(dt.Rows[0]["id"]);
            singleRow.companyName = dt.Rows[0]["companyName"].ToString();
            singleRow.director = dt.Rows[0]["director"].ToString();
            singleRow.fulladdress = dt.Rows[0]["fulladdress"].ToString();
            return singleRow;
        }

        public int Insert(Company_DTO entity)
        {
            companyRep.AddInputParameters("@companyName", entity.companyName);
            companyRep.AddInputParameters("@director", entity.director);
            companyRep.AddInputParameters("@fulladdress", entity.fulladdress);
            return companyRep.IUD("sp_Company_Insert", CommandType.StoredProcedure);
        }

        public int Update(Company_DTO entity)
        {
            companyRep.AddInputParameters("@id", entity.id);
            companyRep.AddInputParameters("@companyName", entity.companyName);
            companyRep.AddInputParameters("@director", entity.director);
            companyRep.AddInputParameters("@fulladdress", entity.fulladdress);
            return companyRep.IUD("sp_Company_UpdateByID", CommandType.StoredProcedure);
        }
        public List<Company_DTO> GetRows()
        {
            DataTable dt = companyRep.GetList("sp_Company_GetList", CommandType.StoredProcedure);
            List<Company_DTO> companyRows = new List<Company_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                companyRows.Add(
                    new Company_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        companyName = dr["companyName"].ToString(),
                        director = dr["director"].ToString(),
                        fulladdress = dr["fulladdress"].ToString()
                    });
            }
            return companyRows;
        }

        public int Delete(Company_DTO entity)
        {
            companyRep.AddInputParameters("@id", entity.id);
            return companyRep.IUD("sp_Company_DeleteByID", CommandType.StoredProcedure);
        }
    }
}
