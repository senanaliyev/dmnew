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
    public class OutDocToOrgan_Service
    {
        OutDocToOrgan_Repository ODORep = new OutDocToOrgan_Repository();
        public int Insert(OutDocToOrgan_DTO entity)
        {
            ODORep.AddInputParameters("@orgID", entity.orgID);
            ODORep.AddInputParameters("@docID", entity.docID);
            ODORep.AddInputParameters("@incharge", entity.incharge);
            ODORep.AddInputParameters("@guid", entity.guid);
            return ODORep.IUD("sp_OutDocToOrganization_Insert", CommandType.StoredProcedure);
        }

        public int UpdateDocID(long docID, string guid)
        {
            ODORep.AddInputParameters("@docID", docID);
            ODORep.AddInputParameters("@guid", guid);
            return ODORep.IUD("sp_OutDocToOrgan_UpdateByGUID", CommandType.StoredProcedure);
        }

        public List<OutDocToOrgan_DTO> GetList(string guid, long? docID)
        {
            ODORep.AddInputParameters("@guid", guid);
            ODORep.AddInputParameters("@docID", docID);
            DataTable dt = ODORep.GetList("sp_OutDocToOrgan_GetList", CommandType.StoredProcedure);
            List<OutDocToOrgan_DTO> organList = new List<OutDocToOrgan_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                organList.Add(
                    new OutDocToOrgan_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        orgTitle = dr["title"].ToString(),
                        inchargeTitle = (Convert.ToInt32(dr["incharge"]) != 0 ? "Nəzarətdədir" : "")
                    });
            }
            return organList;
        }

        //public List<Custom_DocumentFilesDTO> GetListByDocID(long id)
        //{
        //    docFiles.AddInputParameters("@id", id);
        //    DataTable dt = docFiles.GetList("sp_DocumentFiles_GetByDocID", CommandType.StoredProcedure);
        //    List<Custom_DocumentFilesDTO> docFilesList = new List<Custom_DocumentFilesDTO>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        docFilesList.Add(
        //            new Custom_DocumentFilesDTO
        //            {
        //                dfID = Convert.ToInt64(dr["dfID"]),
        //                attFileTypeTitle = dr["attFileTypeTitle"].ToString(),
        //                dfTitle = dr["dfTitle"].ToString(),
        //                dfName = dr["dfName"].ToString(),
        //                dfPageCount = dr["dfPageCount"].ToString(),
        //                dfGUID = dr["dfGUID"].ToString()
        //            });
        //    }
        //    return docFilesList;
        //}

        public int Delete(long id)
        {
            ODORep.AddInputParameters("@id", id);
            return ODORep.IUD("sp_OutDocToOrgan_DeleteByID", CommandType.StoredProcedure);
        }
    }
}
