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
    public class DocOperationService
    {
        DocOperationRepository docOperation = new DocOperationRepository();

        public int ChangeDocumentFinishDate(DocumentOperationDTO entity)
        {
            docOperation.AddInputParameters("@docID", entity.docID);
            docOperation.AddInputParameters("@docFinishDate", DateTime.ParseExact(entity.docFinishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            return docOperation.IUD("sp_DocUpdateFinishDateByDocID", CommandType.StoredProcedure);
        }

        public int ChangeDocumentFinishDate(long docID, int docDayCount, string docFinishDate)
        {
            docOperation.AddInputParameters("@docID", docID);
            docOperation.AddInputParameters("@docFinishDate", DateTime.ParseExact(docFinishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            return docOperation.IUD("sp_DocUpdateFinishDateByDocID", CommandType.StoredProcedure);
        }

        public DocumentOperationDTO GetOperationDelay(long doid)
        {
            docOperation.AddInputParameters("@doid", doid);
            DataTable dt = docOperation.GetList("sp_DocOperation_GetDelayByDoID", CommandType.StoredProcedure);
            DocumentOperationDTO operation = new DocumentOperationDTO();
            operation.docDayCount = Convert.ToInt32(dt.Rows[0]["docDayCount"]);
            operation.docFinishDate = Convert.ToDateTime(dt.Rows[0]["docFinishDate"]).ToString("dd/MM/yyyy");
            return operation;
        }

        public int CompleteOperation(long doid, string donote, string opercode)
        {
            docOperation.AddInputParameters("@doid", doid);
            docOperation.AddInputParameters("@donote", donote);
            docOperation.AddInputParameters("@opercode", opercode);
            return docOperation.IUD("sp_DocOperComplete_BydoID", CommandType.StoredProcedure);
        }

        public int ReturnOperation(long doid, string donote)
        {
            docOperation.AddInputParameters("@doid", doid);
            docOperation.AddInputParameters("@donote", donote);
            return docOperation.IUD("sp_DocOperReturn_BydoID", CommandType.StoredProcedure);
        }

        public long Insert(DocumentOperationDTO entity)
        {
            docOperation.AddInputParameters("@docID", entity.docID);
            docOperation.AddInputParameters("@fromDoID", entity.fromDoID);
            docOperation.AddInputParameters("@userID", entity.userID);
            docOperation.AddInputParameters("@fromUserID", entity.fromUserID);
            docOperation.AddInputParameters("@operationID", entity.operationID);
            docOperation.AddInputParameters("@operationPos", entity.operationPos);
            docOperation.AddInputParameters("@opercode", entity.opercode);
            docOperation.AddInputParameters("@doNote", entity.doNote);
            if (entity.docFinishDate != null)
            {
                docOperation.AddInputParameters("@docDayCount", entity.docDayCount);
                docOperation.AddInputParameters("@docFinishDate", DateTime.ParseExact(entity.docFinishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            }
            docOperation.AddInputParameters("@isActionConfirmed", entity.isActionConfirmed);
            docOperation.AddInputParameters("@isActionCompleted", entity.isActionCompleted);
            docOperation.AddInputParameters("@doDate", DateTime.ParseExact(entity.doDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            return docOperation.IUD("sp_DocumentOperation_Insert", CommandType.StoredProcedure);
        }

        public long Update(DocumentOperationDTO entity)
        {
            docOperation.AddInputParameters("@doID", entity.doID);
            docOperation.AddInputParameters("@docID", entity.docID);
            //docOperation.AddInputParameters("@doResponseID", entity.doResponseID);
            //docOperation.AddInputParameters("@doResponseNote", entity.doResponseNote);
            return docOperation.IUD("sp_DocumentOperation_Update", CommandType.StoredProcedure);
        }

        public List<OperationsHistory_DTO> GetOperationHistory(long docID)
        {
            docOperation.AddInputParameters("@docID", docID);
            DataTable dt = docOperation.GetList("sp_OperationsHistory", CommandType.StoredProcedure);
            List<OperationsHistory_DTO> docOpHistoryList = new List<OperationsHistory_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docOpHistoryList.Add(new OperationsHistory_DTO
                {
                    docRegNo = dr["docRegNo"].ToString(),
                    FromUser = dr["FromUser"].ToString(),
                    ToUser = dr["ToUser"].ToString(),
                    Operation= dr["Operation"].ToString(),
                    doDate = Convert.ToDateTime(dr["doDate"]).ToString("dd/MM/yyyy")
                });
            }
            return docOpHistoryList;
        }

        public List<Custom_DocOperationDTO> GetOperationList(long id, long doid)
        {
            docOperation.AddInputParameters("@id", id);
            docOperation.AddInputParameters("@doid", doid);
            DataTable dt = docOperation.GetList("sp_DocOperation_GetListByDocID", CommandType.StoredProcedure);
            List<Custom_DocOperationDTO> docOpList = new List<Custom_DocOperationDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docOpList.Add(new Custom_DocOperationDTO { doID = Convert.ToInt64(dr["doID"]), NameSurname = dr["NameSurname"].ToString(), conTypeTitle = dr["conTypeTitle"].ToString(), doNote = dr["doNote"].ToString() });
            }
            return docOpList;
        }

        public List<CommonDTO> OperationList()
        {
            DataTable dt = docOperation.GetList("sp_DocOperation_GetList", CommandType.StoredProcedure);
            List<CommonDTO> docOpList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docOpList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString(), });
            }
            return docOpList;
        }
        public int Delete(long id)
        {
            docOperation.AddInputParameters("@id", id);
            return docOperation.IUD("sp_DocOperation_DeleteByID", CommandType.StoredProcedure);
        }

    }
}
