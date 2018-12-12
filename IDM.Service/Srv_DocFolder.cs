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
    public class Srv_DocFolder
    {

        CommonRepository folder = new CommonRepository();

        public List<Custom_DocGetList_DTO> FilterByFolderId(int id, int usrID)
        {
            folder.AddInputParameters("@usrID", usrID);
            folder.AddInputParameters("@folderid", id);
            DataTable dt = folder.GetList("sp_Document_FilterByFolderId", CommandType.StoredProcedure);
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
                    fromEmployee = dr["fromEmployee"].ToString(),
                    EditRead = (int.Parse(dr["EditRead"].ToString()) == 1 ? "Edit" : "Read")
                });
            }
            return docList;
        }

        public List<Custom_DocGetList_DTO> FilterByOperCode(string operationCode, int usrID)
        {
            folder.AddInputParameters("@usrID", usrID);
            folder.AddInputParameters("@operationCode", operationCode);
            DataTable dt = folder.GetList("sp_Document_FilterByOperCode", CommandType.StoredProcedure);
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
                    fromEmployee = dr["fromEmployee"].ToString(),
                    EditRead = (int.Parse(dr["EditRead"].ToString()) == 1 ? "Edit" : "Read")
                });
            }
            return docList;
        }

    }
}
