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
    public class InternalDocService
    {
        InternalDocRepository interDoc = new InternalDocRepository();
        public int Insert(InternalDocDTO entity)
        {
            interDoc.AddInputParameters("@docID", entity.docID);
            interDoc.AddInputParameters("@actionTypeID", entity.actionTypeID);
            interDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            interDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            interDoc.AddInputParameters("@conTypeID", entity.conTypeID);
            interDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            return interDoc.IUD("sp_InternalDocument_Insert", CommandType.StoredProcedure);
        }

        public int Update(InternalDocDTO entity)
        {
            interDoc.AddInputParameters("@docID", entity.docID);
            interDoc.AddInputParameters("@actionTypeID", entity.actionTypeID);
            interDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            interDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            interDoc.AddInputParameters("@conTypeID", entity.conTypeID);
            interDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            return interDoc.IUD("sp_InternalDocument_Update", CommandType.StoredProcedure);
        }

        public Custom_DocInternalDTO GetDocumentByID(long id)
        {
            interDoc.AddInputParameters("@id", id);
            DataTable dt = interDoc.GetList("sp_DocInternal_GetById", CommandType.StoredProcedure);
            Custom_DocInternalDTO doc = new Custom_DocInternalDTO();
            foreach (DataRow dr in dt.Rows)
            {
                doc.docID = Convert.ToInt64(dr["docID"]);
                doc.docRegNo = dr["docRegNo"].ToString();
                doc.docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy");
                doc.docDayCount = Convert.ToInt32(dr["docDayCount"]);
                doc.docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy");
                doc.docType = Convert.ToInt32(dr["docType"]);
                doc.docNote = dr["docNote"].ToString();
                doc.docContent = dr["docContent"].ToString();
                doc.actionTypeID = (dr["actionTypeID"] != DBNull.Value ? Convert.ToInt32(dr["actionTypeID"]) : 0);
                doc.relatedDocNo = dr["relatedDocNo"].ToString();
                doc.relatedDocRegDate = dr["relatedDocRegDate"].ToString();
                doc.conTypeID = (dr["conTypeID"] != DBNull.Value ? Convert.ToInt32(dr["conTypeID"]) : 0);
                doc.tematikaID = Convert.ToInt32(dr["tematikaID"]);
            }
            return doc;
        }

        public InternalRegFileDoc GetRegDocumentByDocID(long docID)
        {
            interDoc.AddInputParameters("@docID", docID);
            DataTable dt = interDoc.GetList("[sp_InternalRegFileDocument]", CommandType.StoredProcedure);
            InternalRegFileDoc doc = new InternalRegFileDoc();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.tematika = dt.Rows[0]["tematika"].ToString();
            doc.docType = dt.Rows[0]["documentType"].ToString();
            doc.actionTitle = dt.Rows[0]["actionTitle"].ToString();
            doc.contentTitle = dt.Rows[0]["contentTitle"].ToString();
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            return doc;
        }
    }
}
