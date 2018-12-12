using IDM.DTO;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
    public class DocumentService
    {
        DocumentRepository document = new DocumentRepository();

        public List<Custom_DocGetList_DTO> GetList(int usrID)
        {
            document.AddInputParameters("@usrID", usrID);
            DataTable dt = document.GetList("sp_Document_GetList", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    DocContentTypeTitle = dr["DocContentType"].ToString(),
                    DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
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

        //ilk varianti awagidakidir
        //public List<Custom_DocGetList_DTO> GetList(int usrID)
        //{
        //    document.AddInputParameters("@usrID", usrID);
        //    DataTable dt = document.GetList("sp_Document_GetList", CommandType.StoredProcedure);
        //    List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        docList.Add(new Custom_DocGetList_DTO
        //        {
        //            ID = Convert.ToInt64(dr["docID"]),
        //            doID = Convert.ToInt64(dr["doID"]),
        //            DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
        //            DocRegNo = dr["docRegNo"].ToString(),
        //            DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
        //            DocContentTypeTitle = dr["DocContentType"].ToString(),
        //            DocTypeTitle = dr["DocType"].ToString(),
        //            fromUser = dr["fromUser"].ToString(),
        //            operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
        //            operationID = (dr["operationID"] != null ? Convert.ToInt32(dr["operationID"]) : 0)
        //        });
        //    }
        //    return docList;
        //}


        public List<Custom_DocGetList_DTO> SearchByNameSurname(string name, string surname)
        {
            document.AddInputParameters("@name", name);
            document.AddInputParameters("@surname", surname);
            DataTable dt = document.GetList("sp_Document_SearchByNameSurname", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> resultList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                resultList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    //doID = Convert.ToInt64(dr["doID"]),
                    //DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    Name = dr["name"].ToString(),
                    Surname = dr["surname"].ToString(),
                    Middlename = dr["middlename"].ToString(),
                    Fullname = dr["surname"].ToString() + " " + dr["name"].ToString() + " " + dr["middlename"].ToString(),
                    //DocContentTypeTitle = dr["DocContentType"].ToString(),
                    //DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    //operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    //operationID = (dr["operationID"] != null ? Convert.ToInt32(dr["operationID"]) : 0)
                });
            }
            return resultList;
        }

        public List<Custom_DocGetList_DTO> SearchByDocNo(string docregno)
        {
            document.AddInputParameters("@docregno", docregno);
            DataTable dt = document.GetList("sp_Document_SearchByDocNo", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> resultList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                resultList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    //doID = Convert.ToInt64(dr["doID"]),
                    //DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    //DocContentTypeTitle = dr["DocContentType"].ToString(),
                    //DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    //operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    //operationID = (dr["operationID"] != null ? Convert.ToInt32(dr["operationID"]) : 0)
                });
            }
            return resultList;
        }
        public List<Custom_DocGetList_DTO> DocumentFirstLoad(ExtendedSearch_DTO entity, int usrID)
        {
            document.AddInputParameters("@usrID", usrID);
            document.AddInputParameters("@docRegNo", entity.docRegNo);
            document.AddInputParameters("@docContentType", entity.docContentType);
            document.AddInputParameters("@docType", entity.docType);
            document.AddInputParameters("@fromUserID", entity.fromUserID);
            DataTable dt = document.GetList("sp_Document_FirstLoad", CommandType.StoredProcedure);
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

        public List<Custom_DocGetList_DTO> FilterDocumentList(ExtendedSearch_DTO entity, int usrID)
        {
            document.AddInputParameters("@usrID", usrID);
            document.AddInputParameters("@docRegNo", entity.docRegNo);
            document.AddInputParameters("@docContentType", entity.docContentType);
            document.AddInputParameters("@docType", entity.docType);
            document.AddInputParameters("@fromUserID", entity.fromUserID);
            DataTable dt = document.GetList("sp_Document_FilteredList", CommandType.StoredProcedure);
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
        public List<Custom_DocGetList_DTO> GetListByTypeID(int id, int usrID)
        {
            document.AddInputParameters("@usrID", usrID);
            document.AddInputParameters("@id", id);
            DataTable dt = document.GetList("sp_Document_GetListByTypeID", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    DocContentTypeTitle = dr["DocContentType"].ToString(),
                    DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    operationID = Convert.ToInt32(dr["operationID"]),
                    operationPos = Convert.ToInt32(dr["operationPos"]),
                    doID = Convert.ToInt64(dr["doID"]),
                    doNote = dr["doNote"].ToString(),
                    doDate = Convert.ToDateTime(dr["doDate"]).ToString("dd/MM/yyyy"),
                    fromEmployee = dr["fromEmployee"].ToString()
                });
            }
            return docList;
        }

        public List<Custom_DocGetList_DTO> GetListByOperationID(int id, int usrID)
        {
            document.AddInputParameters("@usrID", usrID);
            document.AddInputParameters("@id", id);
            DataTable dt = document.GetList("sp_Document_GetListByOperationID", CommandType.StoredProcedure);
            List<Custom_DocGetList_DTO> docList = new List<Custom_DocGetList_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docList.Add(new Custom_DocGetList_DTO
                {
                    ID = Convert.ToInt64(dr["docID"]),
                    //doID = Convert.ToInt64(dr["doID"]),
                    DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    DocRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentType"].ToString(),
                    DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    operationID = (dr["operationID"] != null ? Convert.ToInt32(dr["operationID"]) : 0)
                });
            }
            return docList;
        }

        public long Insert(DocumentDTO entity)
        {
            document.AddOutputParameters("@id", entity.docID);
            document.AddInputParameters("@docContentType", entity.docContentType);
            document.AddInputParameters("@docRegNo", entity.docRegNo);

            if (entity.docRegDate == null) entity.docRegDate = DateTime.Now.ToString("dd/MM/yyyy");
            document.AddInputParameters("@docRegDate", DateTime.ParseExact(entity.docRegDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            document.AddInputParameters("@docDayCount", entity.docDayCount);

            if (entity.docFinishDate == null) entity.docFinishDate = DateTime.Now.ToString("dd/MM/yyyy");
            document.AddInputParameters("@docFinishDate", DateTime.ParseExact(entity.docFinishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            document.AddInputParameters("@docType", entity.docType);
            document.AddInputParameters("@docContent", entity.docContent);
            document.AddInputParameters("@docNote", entity.docNote);
            document.AddInputParameters("@docInCharge", entity.docInCharge);
            document.AddInputParameters("@belongToDoc", entity.belongToDoc);
            document.IUD("sp_Document_Insert", CommandType.StoredProcedure);
            return Convert.ToInt64(document.GetParamValue("@id"));
        }

        public int Update(DocumentDTO entity)
        {
            document.AddInputParameters("@id", entity.docID);
            document.AddInputParameters("@docContentType", entity.docContentType);
            document.AddInputParameters("@docRegNo", entity.docRegNo);
            if (entity.docRegDate == null) entity.docRegDate = DateTime.Now.ToString("dd/MM/yyyy");
            document.AddInputParameters("@docRegDate", DateTime.ParseExact(entity.docRegDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            document.AddInputParameters("@docDayCount", entity.docDayCount);
            if (entity.docFinishDate == null) entity.docFinishDate = DateTime.Now.ToString("dd/MM/yyyy");
            document.AddInputParameters("@docFinishDate", DateTime.ParseExact(entity.docFinishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            document.AddInputParameters("@docType", entity.docType);
            document.AddInputParameters("@docContent", entity.docContent);
            document.AddInputParameters("@docNote", entity.docNote);
            document.AddInputParameters("@docInCharge", entity.docInCharge);
            return document.IUD("sp_Document_Update", CommandType.StoredProcedure);
        }


        public int CompleteDocument(long docid)
        {
            document.AddInputParameters("@docid", docid);
            return document.IUD("sp_Document_CompleteByDocID", CommandType.StoredProcedure);
        }

        public int LockDocument(long docid)
        {
            document.AddInputParameters("@id", docid);
            return document.IUD("sp_Document_LockByID", CommandType.StoredProcedure);
        }


        public DocumentDTO GetDocumentByDocID(long docID)
        {
            document.AddInputParameters("@docID", docID);
            DataTable dt = document.GetList("[sp_Document_GetByDocID]", CommandType.StoredProcedure);
            DocumentDTO doc = new DocumentDTO();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd MMMM yyyy",new CultureInfo("az"));
            doc.docRegNo = dt.Rows[0]["docNumber"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.docContentType = Convert.ToInt32(dt.Rows[0]["docContentType"]);
            return doc;
        }
    }
}
