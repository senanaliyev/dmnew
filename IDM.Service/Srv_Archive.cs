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
    public class Srv_Archive
    {
        Rpst_Archive archiveRpst = new Rpst_Archive();

        public int Insert(Archive_DTO entity)
        {
            archiveRpst.AddInputParameters("@docID", entity.docID);
            archiveRpst.AddInputParameters("@zalNO", entity.zalNO);
            archiveRpst.AddInputParameters("@siraNO", entity.siraNO);
            archiveRpst.AddInputParameters("@shkafNO", entity.shkafNO);
            archiveRpst.AddInputParameters("@rafNO", entity.rafNO);
            archiveRpst.AddInputParameters("@erizeNO", entity.erizeNO);
            return archiveRpst.IUD("sp_Archive_Insert", CommandType.StoredProcedure);
        }

        public List<Custom_DocGetList_DTO> ArchiveFilter(Archive_DTO entity, int usrID)
        {
            archiveRpst.AddInputParameters("@usrID", usrID);
            archiveRpst.AddInputParameters("@zalNO", entity.zalNO);
            archiveRpst.AddInputParameters("@siraNO", entity.siraNO);
            archiveRpst.AddInputParameters("@shkafNO", entity.shkafNO);
            archiveRpst.AddInputParameters("@rafNO", entity.rafNO);
            archiveRpst.AddInputParameters("@erizeNO", entity.erizeNO);
            DataTable dt = archiveRpst.GetList("sp_Archive_Filter", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    DocFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    DocContentTypeTitle = dr["DocContentType"].ToString(),
                    DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    operationTitle = dr["operationTitle"].ToString(), //(Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    operationID = Convert.ToInt32(dr["operationID"]),
                    operationPos = Convert.ToInt32(dr["operationPos"]),
                    doID = Convert.ToInt64(dr["doID"]),
                    doNote = dr["doNote"].ToString(),
                    doDate = Convert.ToDateTime(dr["doDate"]).ToString("dd/MM/yyyy"),
                    fromUserID = Convert.ToInt32(dr["fromUserID"]),
                    fromEmployee = dr["fromEmployee"].ToString()
                });
                //docList.Add(new Archive_DTO
                //{
                //    docID = Convert.ToInt64(dr["docID"]),
                //    zalNO = dr["zalNO"].ToString(),
                //    siraNO = dr["siraNO"].ToString(),
                //    shkafNO = dr["shkafNO"].ToString(),
                //    rafNO = dr["rafNO"].ToString(),
                //    erizeNO = dr["erizeNO"].ToString(),
                //});
            }
            return docList;
        }


        public List<Custom_DocGetList_DTO> UnarchivedDocList(int usrID)
        {
            archiveRpst.AddInputParameters("@usrID", usrID);
            DataTable dt = archiveRpst.GetList("sp_Document_UnArchived", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    DocFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    DocContentTypeTitle = dr["DocContentType"].ToString(),
                    DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    operationTitle = dr["operationTitle"].ToString(), //(Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    operationID = Convert.ToInt32(dr["operationID"]),
                    operationPos = Convert.ToInt32(dr["operationPos"]),
                    doID = Convert.ToInt64(dr["doID"]),
                    doNote = dr["doNote"].ToString(),
                    doDate = Convert.ToDateTime(dr["doDate"]).ToString("dd/MM/yyyy"),
                    fromUserID = Convert.ToInt32(dr["fromUserID"]),
                    fromEmployee = dr["fromEmployee"].ToString()
                });
            }
            return docList;
        }

    }
}
