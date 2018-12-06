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
    public class DocumentFilesService
    {
        DocumentFilesRepository docFiles = new DocumentFilesRepository();
        public int Insert(DocumentFilesDTO entity)
        {
            docFiles.AddInputParameters("@dfTitle", entity.dfTitle);
            docFiles.AddInputParameters("@dfGUID", entity.dfGUID);
            docFiles.AddInputParameters("@attFileTypeID", entity.attFileTypeID);
            docFiles.AddInputParameters("@dfPageCount", entity.dfPageCount);
            docFiles.AddInputParameters("@dfContent", entity.dfContent);
            docFiles.AddInputParameters("@dfName", entity.dfName);
            return docFiles.IUD("sp_DocumentFiles_Insert", CommandType.StoredProcedure);
        }

        public int InsertByID(DocumentFilesDTO entity)
        {
            docFiles.AddInputParameters("@docID", entity.docID);
            docFiles.AddInputParameters("@dfTitle", entity.dfTitle);
            docFiles.AddInputParameters("@attFileTypeID", entity.attFileTypeID);
            docFiles.AddInputParameters("@dfPageCount", entity.dfPageCount);
            docFiles.AddInputParameters("@dfContent", entity.dfContent);
            docFiles.AddInputParameters("@dfName", entity.dfName);
            return docFiles.IUD("sp_DocumentFiles_InsertByID", CommandType.StoredProcedure);
        }

        public List<Custom_DocumentFilesDTO> GetListByGuid(string guid)
        {
            docFiles.AddInputParameters("@guid", guid);
            DataTable dt = docFiles.GetList("sp_DocumentFiles_GetByGuid", CommandType.StoredProcedure);
            List<Custom_DocumentFilesDTO> docFilesList = new List<Custom_DocumentFilesDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docFilesList.Add(
                    new Custom_DocumentFilesDTO
                    {
                        dfID = Convert.ToInt64(dr["dfID"]),
                        attFileTypeTitle = dr["attFileTypeTitle"].ToString(),
                        dfTitle = Convert.ToInt32(dr["dfTitle"]),
                        dfTitleDesc = dr["dfTitleDesc"].ToString(),
                        dfName = dr["dfName"].ToString(),
                        dfPageCount = dr["dfPageCount"].ToString(),
                        dfGUID = dr["dfGUID"].ToString()
                    });
            }
            return docFilesList;
        }

        public List<Custom_DocumentFilesDTO> GetListByDocID(long id)
        {
            docFiles.AddInputParameters("@id", id);
            DataTable dt = docFiles.GetList("sp_DocumentFiles_GetByDocID", CommandType.StoredProcedure);
            List<Custom_DocumentFilesDTO> docFilesList = new List<Custom_DocumentFilesDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docFilesList.Add(
                    new Custom_DocumentFilesDTO
                    {
                        dfID = Convert.ToInt64(dr["dfID"]),
                        attFileTypeTitle = dr["attFileTypeTitle"].ToString(),
                        dfTitle = Convert.ToInt32(dr["dfTitle"]),
                        dfTitleDesc= dr["dfTitleDesc"].ToString(),
                        dfName = dr["dfName"].ToString(),
                        dfPageCount = dr["dfPageCount"].ToString(),
                        dfGUID = dr["dfGUID"].ToString()
                    });
            }
            return docFilesList;
        }

        public int Delete(long id)
        {
            docFiles.AddInputParameters("@id", id);
            return docFiles.IUD("sp_DocumentFiles_DeleteByID", CommandType.StoredProcedure);
        }
    }
}
